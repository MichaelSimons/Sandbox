using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace ConsoleApplication
{
    public class Program
    {
        private static Platform platform;

        public static void Main(string[] args)
        {
            platform = Program.DetermineOSPlatform();
            Stopwatch s = Stopwatch.StartNew();
            bool result = GetIsDockerContainer();
            s.Stop();
            Console.WriteLine("Running in Container:  " + result.ToString() + " " + s.ElapsedTicks);
        }

        // TODO:  Windows logic is only able of detecting Containers which may be Docker related.
        // Do we want Docker specific logic or is Containers sufficient?  
        public static bool GetIsDockerContainer()
        {
            // TODO:  What should be done if you don't have access to registry or file?  Should this be
            // reported as unkown or is 'false' adequate assuming this is an edge case?
            switch (platform)
            {
                case Platform.Windows:
                    // Only use this registry setting for telemetry purposes – do not change product behavior inside containers based on this key. 
                    return Registry.GetValue("HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Control", "ContainerType", null) != null;
                case Platform.Linux:
                    return File.Exists("/.dockerenv");
                case Platform.Darwin:
                default:
                    return false;
            }
        }

        private static Platform DetermineOSPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Platform.Windows;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Platform.Linux;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return Platform.Darwin;
            }
            return Platform.Unknown;
        }
    }

    public enum Platform
    {
        Unknown = 0,
        Windows = 1,
        Linux = 2,
        Darwin = 3
    }
}
