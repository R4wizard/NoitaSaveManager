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

        public static void Launch(string installPath, string savePath, int seed = 0)
        {
            Process noita = new Process();
            noita.StartInfo.FileName = Path.Combine(installPath, "noita.exe");
            noita.StartInfo.WorkingDirectory = installPath;
            noita.StartInfo.Arguments = "-no_logo_splashes";

            if(seed != 0)
            {
                File.WriteAllText(Path.Combine(savePath, "nsm_seed"), seed.ToString());
                File.WriteAllText(Path.Combine(installPath, "magic.txt"), "<MagicNumbers WORLD_SEED=\"" + seed + "\" />");
                noita.StartInfo.Arguments += " -magic_numbers magic.txt";
            } else
            {
                File.Delete(Path.Combine(savePath, "nsm_seed"));
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

            if (File.Exists(Path.Combine(path, "magic_numbers.salakieli")))
                File.Delete(Path.Combine(path, "magic_numbers.salakieli"));

            if (File.Exists(Path.Combine(path, "player.salakieli")))
                File.Delete(Path.Combine(path, "player.salakieli"));

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

            if (hash == "3bbb44abfe5f4e08dcff1aba3160cd512f7e756c")
                return "update #3";

            if (hash == "ba848c498a12afa987ce08383acec71722980c56")
                return "update #2";

            hash = hash.Substring(0, 6);
            return "update #" + hash;
        }
    }
}
