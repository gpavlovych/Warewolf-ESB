﻿
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2016 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common.Interfaces;

namespace Dev2.Activities.Designers2.Decision
{
    public partial class DecisionDesigner : ICheckControlEnabledView
    {
        public DecisionDesigner()
        {
            InitializeComponent();
        }

        public bool GetControlEnabled(string controlName)
        {
            var largeView = DataContext as Large;

            return largeView != null && largeView.LargeDataGrid.IsEnabled;
        }

        public void DoneAction()
        {
            var largeView = DataContext as Large;
            if(largeView != null)
            {
                largeView.DoneButton.Command.Execute(null);
            }
        }


    }
}
