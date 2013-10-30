﻿using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace Dev2.Studio.AppResources.Behaviors
{
    public class ThumbResizeBehavior : Behavior<Thumb>
    {
        const int ChangeThreshold = 1;

        public double MinWidthOffset { get; set; }

        public double MinHeightOffset { get; set; }

        #region Override Methods

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Unloaded += AssociatedObjectOnUnloaded;
            AssociatedObject.DragDelta += AssociatedObjectOnDragDelta;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.Unloaded += AssociatedObjectOnUnloaded;
            AssociatedObject.DragDelta -= AssociatedObjectOnDragDelta;
        }

        #endregion Override Methods

        #region Properties

        public FrameworkElement TargetElement { get { return (FrameworkElement)GetValue(TargetElementProperty); } set { SetValue(TargetElementProperty, value); } }

        // Using a DependencyProperty as the backing store for TargetElement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetElementProperty =
            DependencyProperty.Register("TargetElement", typeof(FrameworkElement), typeof(ThumbResizeBehavior), new PropertyMetadata(null));

        public FrameworkElement ContentElement { get { return (FrameworkElement)GetValue(ContentElementProperty); } set { SetValue(ContentElementProperty, value); } }

        // Using a DependencyProperty as the backing store for ContentElement.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentElementProperty =
            DependencyProperty.Register("ContentElement", typeof(FrameworkElement), typeof(ThumbResizeBehavior), new PropertyMetadata(null));

        #endregion

        #region Event Handlers

        void AssociatedObjectOnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            AssociatedObject.Unloaded -= AssociatedObjectOnUnloaded;
            AssociatedObject.DragDelta -= AssociatedObjectOnDragDelta;
            routedEventArgs.Handled = true;
        }

        void AssociatedObjectOnDragDelta(object sender, DragDeltaEventArgs e)
        {
            if(TargetElement == null)
            {
                return;
            }

            //
            // If the height or with is not a number get the actual value.
            //
            if(double.IsNaN(TargetElement.Height))
            {
                TargetElement.Height = TargetElement.ActualHeight;
            }

            if(double.IsNaN(TargetElement.Width))
            {
                TargetElement.Width = TargetElement.ActualWidth;
            }

            // Check for legacy usage - adorner framework MUST always use ContentElement - DO NOT REMOVE!!!
            var minWidth = ContentElement == null ? TargetElement.MinWidth : ContentElement.MinWidth;
            var maxWidth = ContentElement == null ? TargetElement.MaxWidth : ContentElement.MaxWidth;
            var minHeight = ContentElement == null ? TargetElement.MinHeight : ContentElement.MinHeight;
            var maxHeight = ContentElement == null ? TargetElement.MaxHeight : ContentElement.MaxHeight;

            if(TargetElement.Height + e.VerticalChange > 0)
            {
                if(Math.Abs(e.VerticalChange) > ChangeThreshold)
                {
                    var newHeight = TargetElement.Height + e.VerticalChange;

                    if((minHeight.Equals(0D) || newHeight > minHeight + MinHeightOffset) &&
                       (maxHeight.Equals(double.PositiveInfinity) || newHeight < maxHeight))
                    {
                        TargetElement.Height += e.VerticalChange;
                    }
                }
            }

            if(TargetElement.Width + e.HorizontalChange > 0)
            {
                if(Math.Abs(e.HorizontalChange) > ChangeThreshold)
                {
                    var newWidth = TargetElement.Width + e.HorizontalChange;
                    if((minWidth.Equals(0D) || newWidth > minWidth + MinWidthOffset) &&
                       (maxWidth.Equals(double.PositiveInfinity) || newWidth < maxWidth))
                    {
                        TargetElement.Width += e.HorizontalChange;
                    }
                }
            }
        }

        #endregion Event Handlers
    }
}
