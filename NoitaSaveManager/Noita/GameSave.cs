using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
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

        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float HP { get; set; }
        public float MaxHP { get; set; }
        public uint Money { get; set; }
        public bool ReportDamage { get; set; }

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
            save.LoadEncryptedData();
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

        public void SaveSeed()
        {
            string streamFile = Path.Combine(Location, "world", ".stream_info");
            if (!File.Exists(streamFile))
                return;
            
            byte[] worldStream = File.ReadAllBytes(streamFile);
            byte[] intBytes = BitConverter.GetBytes(uint.Parse(Seed)).Reverse().ToArray();
            worldStream[0xD + 0x0] = intBytes[0];
            worldStream[0xD + 0x1] = intBytes[1];
            worldStream[0xD + 0x2] = intBytes[2];
            worldStream[0xD + 0x3] = intBytes[3];
            File.WriteAllBytes(streamFile, worldStream);
        }

        public void LoadEncryptedData()
        {
            string playerFile = Path.Combine(Location, "player.salakieli");
            if (File.Exists(playerFile))
            {
                string contents = GameSaveCrypto.Decrypt(playerFile);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(contents);

                XmlNode transformNode = xmlDoc.SelectSingleNode("//Entity/_Transform");
                PositionX = float.Parse(transformNode.Attributes["position.x"].Value);
                PositionY = float.Parse(transformNode.Attributes["position.y"].Value);

                XmlNode damageNode = xmlDoc.SelectSingleNode("//Entity/DamageModelComponent");
                HP = float.Parse(damageNode.Attributes["hp"].Value) * 25;
                MaxHP = float.Parse(damageNode.Attributes["max_hp"].Value) * 25;

                XmlNode walletNode = xmlDoc.SelectSingleNode("//Entity/WalletComponent");
                Money = uint.Parse(walletNode.Attributes["money"].Value);

                XmlNode gameLogNode = xmlDoc.SelectSingleNode("//Entity/GameLogComponent");
                ReportDamage = gameLogNode.Attributes["report_damage"].Value == "1";
            }
        }
        
        public void SaveEncryptedData()
        {
            string playerFile = Path.Combine(Location, "player.salakieli");
            if (File.Exists(playerFile))
            {
                string contents = GameSaveCrypto.Decrypt(playerFile);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(contents);

                XmlNode transformNode = xmlDoc.SelectSingleNode("//Entity/_Transform");
                transformNode.Attributes["position.x"].Value = PositionX.ToString();
                transformNode.Attributes["position.y"].Value = PositionY.ToString();

                XmlNode damageNode = xmlDoc.SelectSingleNode("//Entity/DamageModelComponent");
                damageNode.Attributes["hp"].Value = (HP / 25f).ToString();
                damageNode.Attributes["max_hp"].Value = (MaxHP / 25f).ToString();

                XmlNode walletNode = xmlDoc.SelectSingleNode("//Entity/WalletComponent");
                walletNode.Attributes["money"].Value = Money.ToString();

                XmlNode gameLogNode = xmlDoc.SelectSingleNode("//Entity/GameLogComponent");
                gameLogNode.Attributes["report_damage"].Value = ReportDamage ? "1" : "0";

                using (var stringWriter = new StringWriter())
                using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                {
                    xmlDoc.WriteTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    GameSaveCrypto.Encrypt(playerFile, stringWriter.GetStringBuilder().ToString());
                }
            }
        }

        public void UpdateSubtitle()
        {
            if (BuiltIn)
                return;

            Subtitle = LastModified.ToString();
            Subtitle += " - HP:  " + HP + "/" + MaxHP;
            Subtitle += " - Money:  " + Money;
            Subtitle += " - Seed:  " + Seed;
        }

        public void WriteSaveInfo()
        {
            File.WriteAllText(Path.Combine(Location, "nsm_name"), Name);
            File.WriteAllText(Path.Combine(Location, "nsm_group"), Group);
            File.WriteAllText(Path.Combine(Location, "nsm_game_version"), GameVersion);
            File.WriteAllText(Path.Combine(Location, "nsm_last_modified"), LastModified.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public void CopyToStore(string noitaPath)
        {
            if (!Directory.Exists(Location))
                Directory.CreateDirectory(Location);

            WriteSaveInfo();

            GameHandler.ClearSave(Location);

            if(Directory.Exists(Path.Combine(noitaPath, "world")))
                CopyDirectory.Copy(Path.Combine(noitaPath, "world"), Path.Combine(Location, "world"));

            if(File.Exists(Path.Combine(noitaPath, "player.salakieli")))
                File.Copy(Path.Combine(noitaPath, "player.salakieli"), Path.Combine(Location, "player.salakieli"));

            if (File.Exists(Path.Combine(noitaPath, "player.xml")))
                File.Copy(Path.Combine(noitaPath, "player.xml"), Path.Combine(Location, "player.xml"));

            if (File.Exists(Path.Combine(noitaPath, "world_state.salakieli")))
                File.Copy(Path.Combine(noitaPath, "world_state.salakieli"), Path.Combine(Location, "world_state.salakieli"));

            if (File.Exists(Path.Combine(noitaPath, "world_state.xml")))
                File.Copy(Path.Combine(noitaPath, "world_state.xml"), Path.Combine(Location, "world_state.xml"));

        }

        public void RestoreFromStore(string noitaPath)
        {
            GameHandler.ClearSave(noitaPath);

            if(Directory.Exists(Path.Combine(Location, "world")))
                CopyDirectory.Copy(Path.Combine(Location, "world"), Path.Combine(noitaPath, "world"));

            if (File.Exists(Path.Combine(Location, "player.salakieli")))
                File.Copy(Path.Combine(Location, "player.salakieli"), Path.Combine(noitaPath, "player.salakieli"));

            if (File.Exists(Path.Combine(Location, "player.xml")))
                File.Copy(Path.Combine(Location, "player.xml"), Path.Combine(noitaPath, "player.xml"));

            if (File.Exists(Path.Combine(Location, "world_state.salakieli")))
                File.Copy(Path.Combine(Location, "world_state.salakieli"), Path.Combine(noitaPath, "world_state.salakieli"));

            if (File.Exists(Path.Combine(Location, "world_state.xml")))
                File.Copy(Path.Combine(Location, "world_state.xml"), Path.Combine(noitaPath, "world_state.xml"));
        }

        public void Delete()
        {
            Directory.Delete(Location, true);
        }

        public void Encrypt()
        {
            string playerFile = Path.Combine(Location, "player.salakieli");
            if (File.Exists(playerFile + ".xml"))
            {
                string contents = File.ReadAllText(playerFile + ".xml");
                GameSaveCrypto.Encrypt(playerFile, contents);
            }

            string worldStateFile = Path.Combine(Location, "world_state.salakieli");
            if (File.Exists(worldStateFile + ".xml"))
            {
                string contents = File.ReadAllText(worldStateFile + ".xml");
                GameSaveCrypto.Encrypt(worldStateFile, contents);
            }

            string magicNumbersFile = Path.Combine(Location, "magic_numbers.salakieli");
            if (File.Exists(magicNumbersFile + ".xml"))
            {
                string contents = File.ReadAllText(magicNumbersFile + ".xml");
                GameSaveCrypto.Encrypt(magicNumbersFile, contents);
            }
        }

        public void Decrypt()
        {
            string playerFile = Path.Combine(Location, "player.salakieli");
            if (File.Exists(playerFile))
            {
                string contents = GameSaveCrypto.Decrypt(playerFile);
                File.WriteAllText(playerFile + ".xml", contents);
            }

            string worldStateFile = Path.Combine(Location, "world_state.salakieli");
            if (File.Exists(worldStateFile))
            {
                string contents = GameSaveCrypto.Decrypt(worldStateFile);
                File.WriteAllText(worldStateFile + ".xml", contents);
            }

            string magicNumbersFile = Path.Combine(Location, "magic_numbers.salakieli");
            if (File.Exists(magicNumbersFile))
            {
                string contents = GameSaveCrypto.Decrypt(magicNumbersFile);
                File.WriteAllText(magicNumbersFile + ".xml", contents);
            }
        }
    }
}

