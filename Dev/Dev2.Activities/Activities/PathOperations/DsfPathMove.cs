
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2016 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Activities.PathOperations;
using Dev2.Common.Interfaces.Toolbox;
using Dev2.Data.PathOperations.Interfaces;
using Dev2.PathOperations;
using Warewolf.Core;

// ReSharper disable CheckNamespace
namespace Unlimited.Applications.BusinessDesignStudio.Activities
// ReSharper restore CheckNamespace
{
    [ToolDescriptorInfo("FileFolder-Move", "Move", ToolType.Native, "8999E59A-38A3-43BB-A98F-6090C5C9EA1E", "Dev2.Acitivities", "1.0.0.0", "Legacy", "File & Folder", "/Warewolf.Studio.Themes.Luna;component/Images.xaml")]
    public class DsfPathMove : DsfAbstractMultipleFilesActivity, IPathInput, IPathOutput, IPathOverwrite,
                               IDestinationUsernamePassword
    {
        public DsfPathMove()
            : base("Move")
        {
        }

        protected override string ExecuteBroker(IActivityOperationsBroker broker, IActivityIOOperationsEndPoint scrEndPoint, IActivityIOOperationsEndPoint dstEndPoint)
        {
            Dev2CRUDOperationTO opTo = new Dev2CRUDOperationTO(Overwrite);
            return broker.Move(scrEndPoint, dstEndPoint, opTo);
        }

        protected override void MoveRemainingIterators()
        {
        }
    }
}
