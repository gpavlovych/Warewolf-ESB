using System;
using System.Windows;
using Caliburn.Micro;
using Dev2.Activities.Designers2.Core.Help;
using Dev2.Common.Interfaces.Data;
using Dev2.Common.Interfaces.Studio.Controller;
using Dev2.Interfaces;
using Dev2.Studio.ViewModels.WorkSurface;
using Microsoft.Practices.Prism.Mvvm;
using Warewolf.Studio.ViewModels;

// ReSharper disable MemberCanBePrivate.Global

namespace Dev2.ViewModels
{
    public class SourceViewModel<T> : BaseWorkSurfaceViewModel, IHelpSource, IStudioTab
        where T : IEquatable<T>
    {
        readonly IPopupController _popupController;

        public SourceViewModel(IEventAggregator eventPublisher, SourceBaseImpl<T> vm, IPopupController popupController,IView view)
            : base(eventPublisher)
        {
            ViewModel = vm;
            View = view;
            _popupController = popupController;
            ViewModel.PropertyChanged += (sender, args) =>
            {
                if(args.PropertyName == "Header")
                {
                    OnPropertyChanged("DisplayName");
                }
                var mainViewModel = CustomContainer.Get<IMainViewModel>();
                if (mainViewModel != null)
                {
                    ViewModelUtils.RaiseCanExecuteChanged(mainViewModel.SaveCommand);
                }
            };
        }

        protected override void OnDispose()
        {
            _eventPublisher.Unsubscribe(this);
            base.OnDispose();
            if (ViewModel != null) ViewModel.Dispose();
        }

        public override object GetView(object context = null)
        {
            return View;
        }

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, ViewModel);
        }

        public override string DisplayName
        {
            get
            {
                return ViewModel.Header;
            }            
        }

        protected override void OnViewLoaded(object view)
        {
            var loadedView = view as IView;
            if (loadedView != null)
            {
                loadedView.DataContext = ViewModel;
                base.OnViewLoaded(loadedView);
            }
        }



// ReSharper disable once UnusedMember.Global
        public ResourceType ResourceType
        {
            get
            {
                if (ViewModel != null)
                {
                    if(ViewModel.Image != null)
                    {
                        return ViewModel.Image.Value;
                    }
                }
                return ResourceType.Unknown;
            }
        }


        #region Implementation of IHelpSource

        public string HelpText { get; set; }
        public SourceBaseImpl<T> ViewModel { get; set; }
        public IView View { get; set; }

        #endregion

        #region Implementation of IStudioTab

        public bool IsDirty
        {
            get
            {
                return ViewModel.HasChanged && ViewModel.CanSave();
            }
        }

        public bool DoDeactivate(bool showMessage)
        {
            if (showMessage)
            {
                ViewModel.UpdateHelpDescriptor(string.Empty);
                if (ViewModel.HasChanged)
                {
                    var result = _popupController.Show(string.Format(StringResources.ItemSource_NotSaved),
                                          string.Format("Save {0}?", ViewModel.Header.Replace("*", "")),
                                          MessageBoxButton.YesNoCancel,
                                          MessageBoxImage.Information, "", false, false, true, false);

                    switch (result)
                    {
                        case MessageBoxResult.Cancel:
                        case MessageBoxResult.None:
                            return false;
                        case MessageBoxResult.No:
                            return true;
                        case MessageBoxResult.Yes:
                            if (ViewModel.CanSave())
                            {
                                ViewModel.Save();
                            }
                            break;
                    }
                }
            }
            else
            {
                ViewModel.UpdateHelpDescriptor(String.Empty);
                if (ViewModel.CanSave())
                {
                    ViewModel.Save();
                }
            }
            return true;
        }

        #endregion
    }
}