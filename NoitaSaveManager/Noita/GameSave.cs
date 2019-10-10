using System;
using System.IO;
using NoitaSaveManager.Utils;

namespace NoitaSaveManager.Noita
{
    public class GameSave
    {
        public string ID;
        public string Group { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Seed { get; set; }
        public string GameVersion { get; set; }
        public string Subtitle { get; set; }
        public DateTime LastModified { get; set; }


        public bool BuiltIn;

        public static GameSave Load(string path)
        {
            GameSave save = new GameSave
            {
                ID = Path.GetFileName(path),
                Name = "Unknown",
                GameVersion = "",
                Group = "Game Saves",
                Seed = "",
                LastModified = DateTime.Now,
                Subtitle = "",
                Location = path
            };

            if (File.Exists(Path.Combine(path, "nsm_name")))
                save.Name = File.ReadAllText(Path.Combine(path, "nsm_name"));

            if (File.Exists(Path.Combine(path, "nsm_group")))
                save.Group = File.ReadAllText(Path.Combine(path, "nsm_group"));

            if (File.Exists(Path.Combine(path, "nsm_seed")))
                save.Seed = File.ReadAllText(Path.Combine(path, "nsm_seed"));

            if (File.Exists(Path.Combine(path, "nsm_game_version")))
                save.GameVersion = File.ReadAllText(Path.Combine(path, "nsm_game_version"));

            if (File.Exists(Path.Combine(path, "nsm_last_modified")))
                save.LastModified = DateTime.Parse(File.ReadAllText(Path.Combine(path, "nsm_last_modified")));

            if (save.Subtitle == "")
                save.Subtitle = save.LastModified.ToString();

            return save;
        }

        public void CopyToStore(string noitaPath)
        {
            if (!Directory.Exists(Location))
                Directory.CreateDirectory(Location);

            File.WriteAllText(Path.Combine(Location, "nsm_name"), Name);
            File.WriteAllText(Path.Combine(Location, "nsm_group"), Group);
            File.WriteAllText(Path.Combine(Location, "nsm_game_version"), GameVersion);
            File.WriteAllText(Path.Combine(Location, "nsm_last_modified"), LastModified.ToString("yyyy-MM-dd HH:mm:ss"));

            GameHandler.ClearSave(Location);

            if(Directory.Exists(Path.Combine(noitaPath, "world")))
                CopyDirectory.Copy(Path.Combine(noitaPath, "world"), Path.Combine(Location, "world"));

            if(File.Exists(Path.Combine(noitaPath, "player.salakieli")))
                File.Copy(Path.Combine(noitaPath, "player.salakieli"), Path.Combine(Location, "player.salakieli"));

            if (File.Exists(Path.Combine(noitaPath, "world_state.salakieli")))
                File.Copy(Path.Combine(noitaPath, "world_state.salakieli"), Path.Combine(Location, "world_state.salakieli"));

            string seedPath = Path.Combine(noitaPath, "nsm_seed");
            if (File.Exists(seedPath))
                File.Copy(seedPath, Path.Combine(Location, "nsm_seed"));
        }

        public void RestoreFromStore(string noitaPath)
        {
            GameHandler.ClearSave(noitaPath);

            if(Directory.Exists(Path.Combine(Location, "world")))
                CopyDirectory.Copy(Path.Combine(Location, "world"), Path.Combine(noitaPath, "world"));

            if (File.Exists(Path.Combine(Location, "player.salakieli")))
                File.Copy(Path.Combine(Location, "player.salakieli"), Path.Combine(noitaPath, "player.salakieli"));

            if (File.Exists(Path.Combine(Location, "world_state.salakieli")))
                File.Copy(Path.Combine(Location, "world_state.salakieli"), Path.Combine(noitaPath, "world_state.salakieli"));

            string seedPath = Path.Combine(Location, "nsm_seed");
            if (File.Exists(seedPath))
                File.Copy(seedPath, Path.Combine(noitaPath, "nsm_seed"));
        }
    }
}
