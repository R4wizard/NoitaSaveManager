using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoitaSaveManager.Noita
{
    public delegate void GameFinishedHandler();

    public class GameHandler
    {
        public static event GameFinishedHandler GameFinished;

        public static bool IsRunning { get; private set; }

        public static void Launch(string installPath, string savePath, uint seed = 0, string biomeMap = "")
        {
            LaunchNonSteam(installPath, savePath, seed, biomeMap);
        }

        public static void LaunchNonSteam(string installPath, string savePath, uint seed = 0, string biomeMap = "")
        {
            Process noita = new Process();
            noita.StartInfo.FileName = Path.Combine(installPath, "noita.exe");
            noita.StartInfo.WorkingDirectory = installPath;
            noita.StartInfo.Arguments = "-no_logo_splashes";

            if (seed != 0)
            {
                File.WriteAllText(Path.Combine(installPath, "magic.txt"), "<MagicNumbers WORLD_SEED=\"" + seed + "\" />");
                noita.StartInfo.Arguments += " -magic_numbers magic.txt";
            }

            if (biomeMap != "")
            {
                noita.StartInfo.Arguments += " -biome-map " + biomeMap;
            }

            IsRunning = true;

            noita.EnableRaisingEvents = true;
            noita.Exited += Noita_Exited;

            noita.Start();
        }

        public static void LaunchSteam(string installPath, string savePath, uint seed = 0, string biomeMap = "")
        {
            // THIS CODE CURRENTLY BREAKS THE AUTOSAVING CODE
            // WE CAN'T USE THIS UNTIL THAT IS FIXED
            
            Process noita = new Process();
            noita.StartInfo.FileName = "steam://run/881100//-no_logo_splashes";
            noita.StartInfo.WorkingDirectory = installPath;

            if (seed != 0)
            {
                File.WriteAllText(Path.Combine(installPath, "magic.txt"), "<MagicNumbers WORLD_SEED=\"" + seed + "\" />");
                noita.StartInfo.FileName += " -magic_numbers magic.txt";
            }

            if (biomeMap != "")
            {
                noita.StartInfo.FileName += " -biome-map " + biomeMap;
            }

            IsRunning = true;

            noita.EnableRaisingEvents = true;
            noita.Exited += Noita_Exited;

            noita.Start();
        }

        private static void Noita_Exited(object sender, EventArgs e)
        {
            IsRunning = false;
            GameFinished?.Invoke();
        }

        public static void ClearSave(string path)
        {
            if (Directory.Exists(Path.Combine(path, "world")))
                Directory.Delete(Path.Combine(path, "world"), true);

            if (File.Exists(Path.Combine(path, "magic_numbers.xml")))
                File.Delete(Path.Combine(path, "magic_numbers.xml"));

            if (File.Exists(Path.Combine(path, "magic_numbers.salakieli")))
                File.Delete(Path.Combine(path, "magic_numbers.salakieli"));

            if (File.Exists(Path.Combine(path, "player.xml")))
                File.Delete(Path.Combine(path, "player.xml"));

            if (File.Exists(Path.Combine(path, "player.salakieli")))
                File.Delete(Path.Combine(path, "player.salakieli"));

            if (File.Exists(Path.Combine(path, "world_state.xml")))
                File.Delete(Path.Combine(path, "world_state.xml"));

            if (File.Exists(Path.Combine(path, "world_state.salakieli")))
                File.Delete(Path.Combine(path, "world_state.salakieli"));

            if (File.Exists(Path.Combine(path, "nsm_seed")))
                File.Delete(Path.Combine(path, "nsm_seed"));
        }

        public static string GameVersionHashToUpdate(string hash)
        {
            hash = hash.Trim();

            if (hash == "")
                return "";

            if (hash == "c0ba23bc0c325a0dc06604f114ee8217112a23af")
                return "update #4";

            if (hash == "3bbb44abfe5f4e08dcff1aba3160cd512f7e756c")
                return "update #3";

            if (hash == "ba848c498a12afa987ce08383acec71722980c56")
                return "update #2";

            hash = hash.Substring(0, 6);
            return "update #" + hash;
        }
    }
}
