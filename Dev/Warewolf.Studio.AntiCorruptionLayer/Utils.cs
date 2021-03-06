﻿using System.Diagnostics;
using System.Reflection;
using Vestris.ResourceLib;

namespace Warewolf.Studio.AntiCorruptionLayer
{
    public class Utils
    {
        public static string FetchVersionInfo()
        {
            var versionResource = GetFileVersionInfo();
            return versionResource.FileVersion;
        }

        public static string FetchInformationalVersionInfo()
        {
            var versionResource = GetFileVersionInfo();
            return versionResource.ProductVersion;
        }

        private static FileVersionInfo GetFileVersionInfo()
        {
            var asm = Assembly.GetExecutingAssembly();
            var fileName = asm.Location;
            var versionResource = FileVersionInfo.GetVersionInfo(fileName);
            return versionResource;
        }
    }
}
