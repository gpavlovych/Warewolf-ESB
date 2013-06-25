﻿
using System;
using System.Linq;
using System.Windows;
using Dev2.Studio.Core;
using Dev2.Studio.Core.AppResources.Enums;
using Dev2.Studio.Core.Interfaces;
using Dev2.Studio.Utils.ActivityDesignerUtils;
using Dev2.Studio.ViewModels.Workflow;

namespace Dev2.Studio.Views.Workflow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WorkflowDesignerView
    {
        public WorkflowDesignerView()
        {
            InitializeComponent();
            this.PreviewDrop += DropPointOnDragEnter;
            this.PreviewDragOver += DropPointOnDragEnter;
        }

        void DropPointOnDragEnter(object sender, DragEventArgs e)
        {
            var dropEnabled = true;
            var formats = e.Data.GetFormats();
            if (!formats.Any()) return;
            var modelItemString = formats.FirstOrDefault(s => s.IndexOf("ResourceTreeViewModel") >= 0);
            if (String.IsNullOrEmpty(modelItemString))
            {
                modelItemString = formats.FirstOrDefault(s => s.IndexOf("WorkflowItemTypeNameFormat") >= 0);
                if (String.IsNullOrEmpty(modelItemString)) return;
            }
            var objectData = e.Data.GetData(modelItemString);
            IContextualResourceModel contextualResourceModel = ResourceHelper.GetContextualResourceModel(objectData);
            if(contextualResourceModel==null) return;
            //if (contextualResourceModel.Environment.IsLocalHost()) return;
            WorkflowDesignerViewModel currentViewModel = (WorkflowDesignerViewModel)this.DataContext;
            if(currentViewModel==null) return;
            if(contextualResourceModel.ResourceType == ResourceType.WorkflowService || contextualResourceModel.ServerResourceType==ResourceType.WorkflowService.ToString() || currentViewModel.EnvironmentModel.ID==contextualResourceModel.Environment.ID)
            {
                return;
            }
            e.Effects = DragDropEffects.None;
            e.Handled = true;
        }
    }
}
