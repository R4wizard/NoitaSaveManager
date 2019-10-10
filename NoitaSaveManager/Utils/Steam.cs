using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace NoitaSaveManager.Utils
{
    public class Steam
    {
        public static string GetPath()
        {
            try
            {
                return (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", null);
            } catch (Exception ex)
            {
                throw new SteamHelperException("error locating steam installation folder", ex);
            }
        }

        public static string ReadConfigVDF()
        {
            try
            {
                return File.ReadAllText(Path.Combine(GetPath(), "config/config.vdf"));
            }
            catch (Exception ex)
            {
                throw new SteamHelperException("error reading steam configuration file", ex);
            }
        }

        public static string[] GetBaseInstallFolders()
        {
            try
            {
                Regex folders = new Regex("BaseInstallFolder_[0-9]+\"[^\"]+\"([^\"]+)");
                List<string> paths = new List<string>();
                foreach (Match match in folders.Matches(ReadConfigVDF()))
                    paths.Add(match.Groups[1].Value);

                paths.Add(GetPath());
                return paths.ToArray();
            }
            catch (Exception ex)
            {
                throw new SteamHelperException("error parsing steam library locations", ex);
            }
        }

        public static string FindCommonSteamappFolder(string folder)
        {
            foreach(string baseInstallFolder in GetBaseInstallFolders())
            {
                string testFolder = Path.Combine(baseInstallFolder, "steamapps/common", folder);
                testFolder = Path.GetFullPath(testFolder);
                if (Directory.Exists(testFolder))
                    return testFolder;
            }

            throw new SteamHelperException("unable to find steamapp for " + folder + "");
        }
    }

    public class SteamHelperException : Exception
    {
        public SteamHelperException() { }
        public SteamHelperException(string message) : base(message) { }
        public SteamHelperException(string message, Exception inner) : base(message, inner) { }
    }
}
