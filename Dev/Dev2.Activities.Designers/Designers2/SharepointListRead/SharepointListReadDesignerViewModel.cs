
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2015 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using Dev2.Activities.Designers2.Core;
using Dev2.Activities.Designers2.FindRecordsMultipleCriteria;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Common.Interfaces.Infrastructure.Providers.Errors;
using Dev2.Common.Interfaces.Infrastructure.Providers.Validation;
using Dev2.Common.Interfaces.Infrastructure.SharedModels;
using Dev2.Data.ServiceModel;
using Dev2.Providers.Validation.Rules;
using Dev2.Runtime.Configuration.ViewModels.Base;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Services.Events;
using Dev2.Studio.Core;
using Dev2.Studio.Core.Activities.Utils;
using Dev2.Studio.Core.Interfaces;
using Dev2.Studio.Core.Messages;
using Dev2.Threading;
using Dev2.TO;
using Dev2.Validation;
using Unlimited.Applications.BusinessDesignStudio.Activities;

namespace Dev2.Activities.Designers2.SharepointListRead
{
    public class SharepointListReadDesignerViewModel : ActivityCollectionDesignerViewModel<SharepointSearchTo>
    {
        public Func<string> GetDatalistString = () => DataListSingleton.ActiveDataList.Resource.DataList;
        readonly IList<string> _requiresSearchCriteria = new List<string> { "Doesn't Contain", "Contains", "=", "<> (Not Equal)", "Ends With", "Doesn't Start With", "Doesn't End With", "Starts With", "Is Regex", "Not Regex", ">", "<", "<=", ">=" };
        readonly IEventAggregator _eventPublisher;
        static readonly SharepointSource NewSharepointSource = new SharepointSource
        {
            ResourceID = Guid.NewGuid(),
            ResourceName = "New Sharepoint Server Source..."
        };
        static readonly SharepointSource SelectSharepointSource = new SharepointSource
        {
            ResourceID = Guid.NewGuid(),
            ResourceName = "Select a Sharepoint Server Source..."
        };
        static readonly SharepointListTo SelectSharepointList = new SharepointListTo
        {
            FullName = "Select a List..."
        };
        public SharepointListReadDesignerViewModel(ModelItem modelItem)
            : this(modelItem, new AsyncWorker(), EnvironmentRepository.Instance.ActiveEnvironment, EventPublishers.Aggregator)
        {
           // Modelitem = modelItem;
        }
        public SharepointListReadDesignerViewModel(ModelItem modelItem, IAsyncWorker asyncWorker, IEnvironmentModel environmentModel, IEventAggregator eventPublisher)
            : base(modelItem)
        {
            AddTitleBarLargeToggle();
            AddTitleBarHelpToggle();
            VerifyArgument.IsNotNull("asyncWorker", asyncWorker);
            _asyncWorker = asyncWorker;
            VerifyArgument.IsNotNull("environmentModel", environmentModel);
            _environmentModel = environmentModel;
            VerifyArgument.IsNotNull("eventPublisher", eventPublisher);
            _eventPublisher = eventPublisher;

            WhereOptions = new ObservableCollection<string>(SharepointSearchOptions.SearchOptions());
            SearchTypeUpdatedCommand = new DelegateCommand(OnSearchTypeChanged);

            SharepointServers = new ObservableCollection<SharepointSource>();
            Lists = new ObservableCollection<SharepointListTo>();

            EditSharepointServerCommand = new RelayCommand(o => EditSharepointSource(), o => IsSharepointServerSelected);
            RefreshListsCommand = new RelayCommand(o => RefreshLists(), o => IsListSelected);
            
            RefreshSharepointSources(true);
            dynamic mi = ModelItem;
            InitializeItems(mi.FilterCriteria);
        }


        void RefreshSharepointSources(bool isInitializing = false)
        {
            IsRefreshing = true;
            if (isInitializing)
            {
                _isInitializing = true;
            }

            LoadSharepointServerSources(() =>
            {
                SetSelectedSharepointServer(SelectedSharepointServer);
                LoadLists(() =>
                {
                    SetSelectedList(SharepointList);
                    LoadListFields(() =>
                    {
                        IsRefreshing = false;
                        if (isInitializing)
                        {
                            _isInitializing = false;
                        }
                    });
                });
            });
        }

        void SetSelectedList(string listName)
        {
            var selectedTable = Lists.FirstOrDefault(t => t.FullName == listName);
            if (selectedTable == null)
            {
                if (Lists.FirstOrDefault(t => t.Equals(SelectSharepointList)) == null)
                {
                    Lists.Insert(0, SelectSharepointList);
                }
                selectedTable = SelectSharepointList;
            }
            SelectedList = selectedTable;
        }

        List<SharepointListTo> GetSharepointLists(SharepointSource dbSource)
        {
            var tables = _environmentModel.ResourceRepository.GetSharepointLists(dbSource);
            return tables ?? new List<SharepointListTo>();
        }

        void LoadLists(System.Action continueWith = null)
        {
            Lists.Clear();

            if (!IsSharepointServerSelected)
            {
                if (continueWith != null)
                {
                    continueWith();
                }
                return;
            }

            // Get Selected values on UI thread BEFORE starting asyncWorker
            var selectedDatabase = SelectedSharepointServer;
            _asyncWorker.Start(() => GetSharepointLists(selectedDatabase), tableList =>
            {
               foreach (var listTo in tableList.OrderBy(t => t.FullName))
                {
                    Lists.Add(listTo);
                }
                if (continueWith != null)
                {
                    continueWith();
                }
            });
        }

        void SetSelectedSharepointServer(SharepointSource sharepointServerSource)
        {
            var selectSharepointSource = sharepointServerSource == null ? null : SharepointServers.FirstOrDefault(d => d.ResourceID == sharepointServerSource.ResourceID);
            if (selectSharepointSource == null)
            {
                if (SharepointServers.FirstOrDefault(d => d.Equals(SelectSharepointSource)) == null)
                {
                    SharepointServers.Insert(0, SelectSharepointSource);
                }
                selectSharepointSource = SelectSharepointSource;
            }
            SelectedSharepointServer = selectSharepointSource;
        }
        IEnumerable<SharepointSource> GetSharepointServers()
        {
            return _environmentModel.ResourceRepository.FindSourcesByType<SharepointSource>(_environmentModel, enSourceType.SharepointServerSource);
        }
        void LoadSharepointServerSources(System.Action continueWith = null)
        {
            SharepointServers.Clear();
            SharepointServers.Add(NewSharepointSource);

            _asyncWorker.Start(() => GetSharepointServers().OrderBy(r => r.ResourceName), sharepointSources =>
            {
                foreach (var sharepointSource in sharepointSources)
                {
                    SharepointServers.Add(sharepointSource);
                }
                if (continueWith != null)
                {
                    continueWith();
                }
            });
        }
        public bool IsSelectedSharepointServerFocused { get { return (bool)GetValue(IsSelectedSharepointServerFocusedProperty); } set { SetValue(IsSelectedSharepointServerFocusedProperty, value); } }

        public static readonly DependencyProperty IsSelectedSharepointServerFocusedProperty =
            DependencyProperty.Register("IsSelectedSharepointServerFocused", typeof(bool), typeof(SharepointListReadDesignerViewModel), new PropertyMetadata(false));

        public bool IsSelectedListFocused { get { return (bool)GetValue(IsSelectedListFocusedProperty); } set { SetValue(IsSelectedListFocusedProperty, value); } }

        public static readonly DependencyProperty IsSelectedListFocusedProperty =
            DependencyProperty.Register("IsSelectedListFocused", typeof(bool), typeof(SharepointListReadDesignerViewModel), new PropertyMetadata(false));

       
        public SharepointSource SelectedSharepointServer
        {
            get
            {
                return (SharepointSource)GetValue(SelectedSharepointServerProperty);
            }
            set
            {
                SetValue(SelectedSharepointServerProperty, value);

                EditSharepointServerCommand.RaiseCanExecuteChanged();
            }
        }

        public static readonly DependencyProperty SelectedSharepointServerProperty =
            DependencyProperty.Register("SelectedSharepointServer", typeof(SharepointSource), typeof(SharepointListReadDesignerViewModel), new PropertyMetadata(null, OnSelectedSharepointServerChanged));

        static void OnSelectedSharepointServerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = (SharepointListReadDesignerViewModel)d;
            if (viewModel.IsRefreshing)
            {
                return;
            }
            viewModel.OnSharepointServerChanged();
            viewModel.EditSharepointServerCommand.RaiseCanExecuteChanged();
        }

        public bool IsRefreshing { get { return (bool)GetValue(IsRefreshingProperty); } set { SetValue(IsRefreshingProperty, value); } }

        public static readonly DependencyProperty IsRefreshingProperty =
            DependencyProperty.Register("IsRefreshing", typeof(bool), typeof(SharepointListReadDesignerViewModel), new PropertyMetadata(false));

        void CreateSharepointServerSource()
        {
            _eventPublisher.Publish(new ShowNewResourceWizard("SharepointServerSource"));
            RefreshSharepointSources();
        }

        static string GetListName(SharepointListTo table)
        {
            return table == null ? null : table.FullName;
        }

        protected virtual void OnSharepointServerChanged()
        {
            if (SelectedSharepointServer == NewSharepointSource)
            {
                CreateSharepointServerSource();
                return;
            }

            IsRefreshing = true;
            // Save selection
            var listName = GetListName(SelectedList);

            SharepointServers.Remove(SelectSharepointSource);
            SharepointServerResourceId = SelectedSharepointServer.ResourceID;

            Lists.Clear();
            LoadLists(() =>
            {
                // Restore Selection
                SetSelectedList(listName);
                LoadListFields(() => { IsRefreshing = false; });
            });
        }

        public Guid SharepointServerResourceId
        {
            get
            {
                return GetProperty<Guid>();  
            }
            set
            {
                if (!_isInitializing)
                {
                    SetProperty(value);

                } 
            }
        }

        public SharepointListTo SelectedList
        {
            get
            {
                return (SharepointListTo)GetValue(SelectedListProperty);
            }
            set
            {
                SetValue(SelectedListProperty, value);
                RefreshListsCommand.RaiseCanExecuteChanged();
            }
        }

        public static readonly DependencyProperty SelectedListProperty =
            DependencyProperty.Register("SelectedList", typeof(SharepointListTo), typeof(SharepointListReadDesignerViewModel), new PropertyMetadata(null, OnSelectedListChanged));

        static void OnSelectedListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = (SharepointListReadDesignerViewModel)d;
            if (viewModel.IsRefreshing)
            {
                return;
            }
            viewModel.OnSelectedListChanged();
            viewModel.RefreshListsCommand.RaiseCanExecuteChanged();
        }
        bool _isInitializing;
        readonly IEnvironmentModel _environmentModel;
        readonly IAsyncWorker _asyncWorker;
        protected virtual void OnSelectedListChanged()
        {
            if (SelectedList != null)
            {
                IsRefreshing = true;
                Lists.Remove(SelectedList);
                SharepointList = SelectedList.FullName;
                LoadListFields(() => { IsRefreshing = false; });
            }
        }

        void LoadListFields(System.Action continueWith=null)
        {
            if (!IsListSelected || _isInitializing)
            {
                if (!_isInitializing)
                {
                    ModelItemCollection.Clear();
                }
                if (continueWith != null)
                {
                    continueWith();
                }
                return;
            }

            ModelItemCollection.Clear();
            var selectedSharepointServer = SelectedSharepointServer;
            var selectedList = SelectedList;
            // ReSharper disable ImplicitlyCapturedClosure
            _asyncWorker.Start(() => GetListFields(selectedSharepointServer, selectedList), columnList =>
            // ReSharper restore ImplicitlyCapturedClosure
            {
                var fieldMappings = columnList.Select(mapping => new SharepointReadListTo("", mapping.Name)).Cast<ISharepointReadListTo>().ToList();
                ReadListItems = fieldMappings;
                if (continueWith != null)
                {
                    continueWith();
                }
            });
        }

        public List<ISharepointReadListTo> ReadListItems
        {
            get
            {
                return GetProperty<List<ISharepointReadListTo>>();
            }
            set
            {
                if (!_isInitializing)
                {
                    SetProperty(value);
                }
            }
        }

        List<ISharepointFieldTo> GetListFields(ISharepointSource source, SharepointListTo list)
        {
            var columns = _environmentModel.ResourceRepository.GetSharepointListFields(source, list);
            return columns ?? new List<ISharepointFieldTo>();
        }
        string SharepointList
        {
            get { return GetProperty<string>(); }
            set
            {
                if (!_isInitializing)
                {
                    SetProperty(value);
                }
            }
        }
        public bool IsListSelected { get; set; }

        void RefreshLists()
        {
        }

        public RelayCommand RefreshListsCommand { get; set; }

        public bool IsSharepointServerSelected { get; set; }

        void EditSharepointSource()
        {
        }

        public RelayCommand EditSharepointServerCommand { get; set; }

        public ObservableCollection<SharepointListTo> Lists { get; set; }

        public ObservableCollection<SharepointSource> SharepointServers { get; set; }

        public override string CollectionName { get { return "FilterCriteria"; } }

        public ICommand SearchTypeUpdatedCommand { get; private set; }

        public ObservableCollection<string> WhereOptions { get; private set; }

        string FieldsToSearch { get { return GetProperty<string>(); } }

        public bool IsFieldsToSearchFocused { get { return (bool)GetValue(IsFieldsToSearchFocusedProperty); } set { SetValue(IsFieldsToSearchFocusedProperty, value); } }
        public static readonly DependencyProperty IsFieldsToSearchFocusedProperty = DependencyProperty.Register("IsFieldsToSearchFocused", typeof(bool), typeof(FindRecordsMultipleCriteriaDesignerViewModel), new PropertyMetadata(default(bool)));

        string Result { get { return GetProperty<string>(); } }

        public bool IsResultFocused { get { return (bool)GetValue(IsResultFocusedProperty); } set { SetValue(IsResultFocusedProperty, value); } }
        public static readonly DependencyProperty IsResultFocusedProperty = DependencyProperty.Register("IsResultFocused", typeof(bool), typeof(FindRecordsMultipleCriteriaDesignerViewModel), new PropertyMetadata(default(bool)));

        void OnSearchTypeChanged(object indexObj)
        {
            var index = (int)indexObj;

            if(index == -1)
            {
                index = 0;
            }

            if(index < 0 || index >= ItemCount)
            {
                return;
            }

            var mi = ModelItemCollection[index];

            var searchType = mi.GetProperty("SearchType") as string;

            if(searchType == "Is Between" || searchType == "Not Between")
            {
                mi.SetProperty("IsSearchCriteriaVisible", false);
            }
            else
            {
                mi.SetProperty("IsSearchCriteriaVisible", true);
            }

            var requiresCriteria = _requiresSearchCriteria.Contains(searchType);
            mi.SetProperty("IsSearchCriteriaEnabled", requiresCriteria);
            if(!requiresCriteria)
            {
                mi.SetProperty("SearchCriteria", string.Empty);
            }
        }

        protected override IEnumerable<IActionableErrorInfo> ValidateThis()
        {
            // ReSharper disable LoopCanBeConvertedToQuery
            foreach(var error in GetRuleSet("FieldsToSearch").ValidateRules("'In Field(s)'", () => IsFieldsToSearchFocused = true))
            // ReSharper restore LoopCanBeConvertedToQuery
            {
                yield return error;
            }
            // ReSharper disable LoopCanBeConvertedToQuery
            foreach(var error in GetRuleSet("Result").ValidateRules("'Result'", () => IsResultFocused = true))
            // ReSharper restore LoopCanBeConvertedToQuery
            {
                yield return error;
            }
        }

        protected override IEnumerable<IActionableErrorInfo> ValidateCollectionItem(ModelItem mi)
        {
            var dto = mi.GetCurrentValue() as FindRecordsTO;
            if(dto == null)
            {
                yield break;
            }

            foreach (var error in dto.GetRuleSet("SearchCriteria", GetDatalistString()).ValidateRules("'Match'", () => mi.SetProperty("IsSearchCriteriaFocused", true)))
            {
                yield return error;
            }

            foreach(var error in dto.GetRuleSet("From", GetDatalistString()).ValidateRules("'From'", () => mi.SetProperty("IsFromFocused", true)))
            {
                yield return error;
            }

            foreach(var error in dto.GetRuleSet("To", GetDatalistString()).ValidateRules("'To'", () => mi.SetProperty("IsToFocused", true)))
            {
                yield return error;
            }
        }

        public IRuleSet GetRuleSet(string propertyName)
        {
            var ruleSet = new RuleSet();

            switch(propertyName)
            {
                case "FieldsToSearch":
                    ruleSet.Add(new IsStringEmptyOrWhiteSpaceRule(() => FieldsToSearch));
                    ruleSet.Add(new IsValidExpressionRule(() => FieldsToSearch, GetDatalistString(), "1"));
                    ruleSet.Add(new HasNoDuplicateEntriesRule(() => FieldsToSearch));
                    ruleSet.Add(new HasNoIndexsInRecordsetsRule(() => FieldsToSearch));
                    break;

                case "Result":
                    ruleSet.Add(new IsStringEmptyOrWhiteSpaceRule(() => Result));
                    ruleSet.Add(new IsValidExpressionRule(() => Result, GetDatalistString(),"1"));
                    break;
            }
            return ruleSet;
        }
    }
}
