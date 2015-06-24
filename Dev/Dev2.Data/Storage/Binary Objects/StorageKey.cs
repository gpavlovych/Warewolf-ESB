
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

namespace Dev2.Data.Storage.Binary_Objects
{
    /// <summary>
    /// Used as the internal storage key ;)
    /// </summary>
    public class StorageKey
    {

        public Guid UID;

        public String UniqueKey;

        public int FragmentID;

        public StorageKey(Guid uid, String key)
        {
            UID = uid;

            UniqueKey = key;

            FragmentID = key.GetHashCode();

        }
    }
}
