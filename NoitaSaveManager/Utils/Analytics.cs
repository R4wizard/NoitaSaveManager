using GoogleAnalyticsTracker.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoitaSaveManager.Utils
{
    public class Analytics
    {
        private static SimpleTracker Tracker;

        public static SimpleTracker Get()
        {
            if (Tracker == null)
            {
                OperatingSystem os = System.Environment.OSVersion;
                SimpleTrackerEnvironment environment = new SimpleTrackerEnvironment(os.Platform.ToString(), os.Version.ToString(), os.VersionString);
                Tracker = new SimpleTracker("UA-104211362-5", environment);
            }

            return Tracker;
        }

        public static Task TrackPage(string name, string path)
        {
            SimpleTracker tracker = Get();
            return tracker.TrackPageViewAsync(name, path, new Dictionary<int, string>());
        }

        public static Task TrackEvent(string category, string action, string label)
        {
            SimpleTracker tracker = Get();
            return tracker.TrackEventAsync(category, action, label, new Dictionary<int, string>());
        }

    }
}
