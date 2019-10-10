using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

            if (File.Exists(Path.Combine(path, "nsm_game_version")))
                save.GameVersion = File.ReadAllText(Path.Combine(path, "nsm_game_version"));

            if (File.Exists(Path.Combine(path, "nsm_last_modified")))
                save.LastModified = DateTime.Parse(File.ReadAllText(Path.Combine(path, "nsm_last_modified")));

            save.LoadSeed();
            save.UpdateSubtitle();

            return save;
        }

        public void LoadSeed()
        {
            string streamFile = Path.Combine(Location, "world", ".stream_info");
            if (!File.Exists(streamFile))
                return;

            byte[] worldStream = File.ReadAllBytes(streamFile);
            byte[] intBytes = worldStream.Skip(0xD).Take(4).Reverse().ToArray();
            Seed = BitConverter.ToUInt32(intBytes, 0).ToString();
        }

        public void UpdateSubtitle()
        {
            if (Subtitle == "")
            {
                Subtitle = LastModified.ToString();

                string update = GameHandler.GameVersionHashToUpdate(GameVersion);
                if (update != "")
                    Subtitle += " - " + update;
            }
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
        }

        public string DecryptFile(string filename)
        {
            return ""; // see NoitaSaveManager.UnreleasedCrypto.SaveFileDecrypter
        }
    }
}

