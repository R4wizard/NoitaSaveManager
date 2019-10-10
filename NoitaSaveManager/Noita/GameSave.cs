using System;
using System.IO;
using System.Windows.Forms;
using NoitaSaveManager.Utils;

namespace NoitaSaveManager.Noita
{
    public class GameSave
    {
        public string ID;
        public string Name;
        public string SubName;
        public string Location;
        public string GameVersion;
        public DateTime LastModified;

        public bool BuiltIn;
        public ListViewItem ListViewItem;

        public static GameSave Load(string path)
        {
            GameSave save = new GameSave
            {
                ID = Path.GetFileName(path),
                Name = "Unknown",
                GameVersion = "",
                LastModified = DateTime.Now,
                Location = path
            };

            if (File.Exists(Path.Combine(path, "nsm_name")))
                save.Name = File.ReadAllText(Path.Combine(path, "nsm_name"));

            if (File.Exists(Path.Combine(path, "nsm_game_version")))
                save.GameVersion = File.ReadAllText(Path.Combine(path, "nsm_game_version"));

            if (File.Exists(Path.Combine(path, "nsm_last_modified")))
                save.LastModified = DateTime.Parse(File.ReadAllText(Path.Combine(path, "nsm_last_modified")));

            return save;
        }

        public void CopyToStore(string noitaPath)
        {
            if (!Directory.Exists(Location))
                Directory.CreateDirectory(Location);

            File.WriteAllText(Path.Combine(Location, "nsm_name"), Name);
            File.WriteAllText(Path.Combine(Location, "nsm_game_version"), GameVersion);
            File.WriteAllText(Path.Combine(Location, "nsm_last_modified"), LastModified.ToString("yyyy-MM-dd HH:mm:ss"));

            GameHandler.ClearSave(Location);
            CopyDirectory.Copy(Path.Combine(noitaPath, "world"), Path.Combine(Location, "world"));
            File.Copy(Path.Combine(noitaPath, "player.salakieli"), Path.Combine(Location, "player.salakieli"));
            File.Copy(Path.Combine(noitaPath, "world_state.salakieli"), Path.Combine(Location, "world_state.salakieli"));
        }

        public void RestoreFromStore(string noitaPath)
        {
            GameHandler.ClearSave(noitaPath);
            CopyDirectory.Copy(Path.Combine(Location, "world"), Path.Combine(noitaPath, "world"));
            File.Copy(Path.Combine(Location, "player.salakieli"), Path.Combine(noitaPath, "player.salakieli"));
            File.Copy(Path.Combine(Location, "world_state.salakieli"), Path.Combine(noitaPath, "world_state.salakieli"));
        }
    }
}
