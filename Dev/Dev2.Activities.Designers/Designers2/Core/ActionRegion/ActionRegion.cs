﻿using System;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Dev2.Common.Interfaces.DB;
using Dev2.Common.Interfaces.ServerProxyLayer;
using Dev2.Common.Interfaces.ToolBase;
using Dev2.Studio.Core.Activities.Utils;
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ExplicitCallerInfoArgument
// ReSharper disable UnusedMember.Global

namespace Dev2.Activities.Designers2.Core.ActionRegion
{
    public class ActionRegion : IActionToolRegion<IDbAction>
    {
        private readonly ModelItem _modelItem;
        private readonly ISourceToolRegion<IDbSource> _source;
        private double _minHeight;
        private double _currentHeight;
        private double _maxHeight;
        private bool _isVisible;
        private const double BaseHeight = 25;

        readonly Dictionary<int, IList<IToolRegion>> _previousRegions = new Dictionary<int, IList<IToolRegion>>();
        private Action _sourceChangedAction;
        private IDbAction _selectedAction;
        private IDbServiceModel _model;
        private ICollection<IDbAction> _actions;
        private bool _isActionEnabled;
        private bool _isRefreshing;
        private int _actionId;

        public ActionRegion()
        {
            ToolRegionName = "ActionRegion";
            SetInitialValues();
        }

        public ActionRegion(IDbServiceModel model, ModelItem modelItem, ISourceToolRegion<IDbSource> source)
        {
            ToolRegionName = "ActionRegion";
            _modelItem = modelItem;
            _model = model;
            _source = source;
            _source.SomethingChanged += SourceOnSomethingChanged;
            SetInitialValues();
            Dependants = new List<IToolRegion>();
            IsRefreshing = false;
            if (_source.SelectedSource != null)
            {
                Actions = model.GetActions(_source.SelectedSource);
            }
            ActionId = modelItem.GetProperty<int>("ActionId");
            if (ActionId != 0)
            {
                SelectedAction = Actions.FirstOrDefault(action => source.GetHashCode() == ActionId);
            }

            RefreshActionsCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(() =>
            {
                IsRefreshing = true;
                if(_source.SelectedSource != null)
                {
                    Actions = model.GetActions(_source.SelectedSource);
                }
                IsRefreshing = false;
            }, CanRefresh);

            IsVisible = true;
            _modelItem = modelItem;
        }

        private void SourceOnSomethingChanged(object sender, IToolRegion args)
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            if (_source != null && _source.SelectedSource != null)
            {
                Actions = _model.GetActions(_source.SelectedSource);
                SelectedAction = null;
                IsActionEnabled = true;
                IsVisible = true;
            }
            // ReSharper disable once ExplicitCallerInfoArgument
            OnPropertyChanged(@"IsVisible");
            OnHeightChanged(this);
        }

        private void SetInitialValues()
        {
            MinHeight = BaseHeight;
            MaxHeight = BaseHeight;
            CurrentHeight = BaseHeight;
            IsVisible = true;
        }

        public bool CanRefresh()
        {
            return SelectedAction != null;
        }

        public IDbAction SelectedAction
        {
            get
            {
                return _selectedAction;
            }
            set
            {
                if (!Equals(value, _selectedAction) && _selectedAction != null)
                {
                    if (!String.IsNullOrEmpty(_selectedAction.Name))
                    StorePreviousValues(_selectedAction.Name.GetHashCode());
                }

                if (IsAPreviousValue(value) && _selectedAction != null)
                {
                    RestorePreviousValues(value);
                    SetSelectedAction(value);
                }
                else
                {
                    SetSelectedAction(value);
                    SourceChangedAction();
                    OnSomethingChanged(this);
                }
                var delegateCommand = RefreshActionsCommand as Microsoft.Practices.Prism.Commands.DelegateCommand;
                if (delegateCommand != null)
                {
                    delegateCommand.RaiseCanExecuteChanged();
                }

                _selectedAction = value;
                OnPropertyChanged();
            }
        }
        public ICollection<IDbAction> Actions
        {
            get
            {
                return _actions;
            }
            set
            {
                _actions = value;
                OnPropertyChanged();
            }
        }
        public ICommand RefreshActionsCommand { get; set; }
        public bool IsActionEnabled
        {
            get
            {
                return _isActionEnabled;
            }
            set
            {
                _isActionEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public Action SourceChangedAction
        {
            get
            {
                return _sourceChangedAction ?? (() => { });
            }
            set
            {
                _sourceChangedAction = value;
            }
        }
        public event SomethingChanged SomethingChanged;

        #region Implementation of IToolRegion

        public string ToolRegionName { get; set; }
        public double MinHeight
        {
            get
            {
                return _minHeight;
            }
            set
            {
                _minHeight = value;
                OnPropertyChanged();
            }
        }
        public double CurrentHeight
        {
            get
            {
                return _currentHeight;
            }
            set
            {
                _currentHeight = value;
                OnPropertyChanged();
            }
        }
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }
        public double MaxHeight
        {
            get
            {
                return _maxHeight;
            }
            set
            {
                _maxHeight = value;
                OnPropertyChanged();
            }
        }
        public event HeightChanged HeightChanged;
        public IList<IToolRegion> Dependants { get; set; }

        public IToolRegion CloneRegion()
        {
            return new ActionRegion
            {
                MaxHeight = MaxHeight,
                MinHeight = MinHeight,
                IsVisible = IsVisible,
                SelectedAction = SelectedAction,
                CurrentHeight = CurrentHeight
            };
        }

        public void RestoreRegion(IToolRegion toRestore)
        {
            var region = toRestore as ActionRegion;
            if (region != null)
            {
                MaxHeight = region.MaxHeight;
                SelectedAction = region.SelectedAction;
                MinHeight = region.MinHeight;
                CurrentHeight = region.CurrentHeight;
                IsVisible = region.IsVisible;
            }
        }

        public int GetId()
        {
            return SelectedAction.Name.GetHashCode();
        }

        #endregion

        #region Implementation of IActionToolRegion<IDbAction>

        private void SetSelectedAction(IDbAction value)
        {
            if (value != null)
            {
                _selectedAction = value;
                SavedAction = value;
                ActionId = value.GetHashCode();
            }

            OnHeightChanged(this);
            OnPropertyChanged("SelectedAction");
        }

        int ActionId
        {
            get
            {
                return _actionId;
            }
            set
            {
                _actionId = value;
                if (_modelItem != null)
                {
                    _modelItem.SetProperty("ActionId", value);
                }
            }
        }

        private void StorePreviousValues(int id)
        {
            _previousRegions.Remove(id);
            _previousRegions[id] = new List<IToolRegion>(Dependants.Select(a => a.CloneRegion()));
        }

        private void RestorePreviousValues(IDbAction value)
        {
            var toRestore = _previousRegions[value.Name.GetHashCode()];
            foreach (var toolRegion in Dependants.Zip(toRestore, (a, b) => new Tuple<IToolRegion, IToolRegion>(a, b)))
            {
                toolRegion.Item1.RestoreRegion(toolRegion.Item2);
            }
        }

        private bool IsAPreviousValue(IDbAction value)
        {
            return _previousRegions.Keys.Any(a => a == value.Name.GetHashCode());
        }

        public IList<string> Errors
        {
            get
            {
                return SelectedAction == null ? new List<string> { "Invalid Action Selected" } : new List<string>();
            }
        }

        public IDbAction SavedAction
        {
            get
            {
                return _modelItem.GetProperty<IDbAction>("SavedAction");
            }
            set
            {
                _modelItem.SetProperty("SavedAction", value);
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void OnHeightChanged(IToolRegion args)
        {
            var handler = HeightChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        protected virtual void OnSomethingChanged(IToolRegion args)
        {
            var handler = SomethingChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
