using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using BrightIdeasSoftware;
using NoitaSaveManager.Noita;
using NoitaSaveManager.Utils;

namespace NoitaSaveManager
{
    public partial class MainForm : Form
    {
        private delegate void SafeCallDelegate();

        private string installPath;
        private string noitaSavePath;
        private string localSavePath;
        private string gameVersionHash;

        private Dictionary<string, GameSave> gameSaves;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameSaves = new Dictionary<string, GameSave>();

            installPath = GetInstallPath();

            noitaSavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "..", "LocalLow", "Nolla_Games_Noita", "save00");
            localSavePath = Path.Combine(Environment.CurrentDirectory, "NoitaSaves");

            gameVersionHash = "unknown";
            if (File.Exists(Path.Combine(installPath, "_version_hash.txt")))
                gameVersionHash = File.ReadAllText(Path.Combine(installPath, "_version_hash.txt"));

            if (!Directory.Exists(noitaSavePath))
            {
                MessageBox.Show("Could not detect Noita save game location, ensure you have booted the game atleast once.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            if (!Directory.Exists(localSavePath))
                Directory.CreateDirectory(localSavePath);

            AutoUpdater.UpdateFormSize = new System.Drawing.Size(500, 500);
            AutoUpdater.RunUpdateAsAdmin = true;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Start("https://noita.r4wizard.co.uk/AutoUpdater.xml");
            Analytics.TrackPage("Main Form", "/main-form");

            GameHandler.GameFinished += GameHandler_GameFinished;

            label1.Text = "NSM by R4wizard\nv" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

            gameSaves.Add("--default", new GameSave
            {
                ID = "--default",
                Name = "Play Noita",
                Group = "New Game",
                Subtitle = "Launch Noita without any changes.",
                BuiltIn = true
            });
            gameSaves.Add("--custom", new GameSave
            {
                ID = "--custom",
                Name = "Play Noita with Custom Options",
                Group = "New Game",
                Subtitle = "Launch Noita with your own custom options.",
                BuiltIn = true
            });

            foreach (var nextSave in Directory.GetDirectories(localSavePath))
            {
                GameSave save = GameSave.Load(nextSave);
                gameSaves.Add(save.ID, save);
            }


            olvGSColumnName.Renderer = CreateDescribedRowRenderer();
            olvGSColumnName.GroupKeyGetter = delegate (object row)
            {
                GameSave save = (GameSave)row;
                return save.Group;
            };

            olvGSColumnName.GroupFormatter = (BrightIdeasSoftware.OLVGroup group, BrightIdeasSoftware.GroupingParameters parms) =>
            {
                group.Id = 2;

                if ((string)group.Key == "New Game")
                    group.Id = 1;

                if ((string)group.Key == "Auto Saves")
                {
                    group.Id = 3;
                    group.Collapsed = true;
                    group.Task = "delete all";
                }

                parms.GroupComparer = Comparer<BrightIdeasSoftware.OLVGroup>.Create((x, y) => (x.GroupId.CompareTo(y.GroupId)));
            };


            lstGameSaves.BeforeCreatingGroups += LstGameSaves_BeforeCreatingGroups;
            lstGameSaves.GroupTaskClicked += LstGameSaves_GroupTaskClicked;
            lstGameSaves.ContextMenuStrip = ctxMenuSavesList;
            lstGameSaves.Sort(new OLVColumn("hidden", "LastModified"));
            lstGameSaves.CellPadding = new Rectangle(10, 3, 10, 3);
            lstGameSaves.RowHeight = 39;
            lstGameSaves.AlwaysGroupByColumn = olvGSColumnName;
            lstGameSaves.SetObjects(gameSaves.Values);
        }

        private void LstGameSaves_GroupTaskClicked(object sender, GroupTaskClickedEventArgs e)
        {
            if(e.Group.Key.ToString() == "Auto Saves")
            {
                DialogResult res = MessageBox.Show("Clear all existing auto saves?", "Clear Auto Saves", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    List<GameSave> toRemove = new List<GameSave>();
                    foreach (var save in gameSaves.Values)
                    {
                        if (save.Group == "Auto Saves")
                            toRemove.Add(save);
                    }
                    foreach(var save in toRemove) {
                        save.Delete();
                        gameSaves.Remove(save.ID);
                    }
                    lstGameSaves.BuildList(true);
                }
            }
        }

        private void LstGameSaves_BeforeCreatingGroups(object sender, CreateGroupsEventArgs e)
        {
            e.Parameters.ItemComparer = Comparer<BrightIdeasSoftware.OLVListItem>.Create((x, y) => {
                GameSave gsX = (GameSave)x.RowObject;
                GameSave gsY = (GameSave)y.RowObject;
                return gsY.LastModified.CompareTo(gsX.LastModified);
            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GameSave selectedSave = GetSelectedSave(false);

            if (selectedSave != null)
            {
                DialogResult res = MessageBox.Show("Overwrite existing save '" + selectedSave.Name + "'?", "Overwrite Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                    selectedSave = null;
            }

            CreateGameSave(selectedSave);
        }

        private void deleteSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameSave selectedSave = GetSelectedSave(false);
            if (selectedSave == null)
                return;

            DialogResult res = MessageBox.Show("Remove save '" + selectedSave.Name + "'?", "Remove Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                selectedSave.Delete();
                gameSaves.Remove(selectedSave.ID);
            }
            Analytics.TrackEvent("SaveList", "DeleteSave", selectedSave.Name);
            lstGameSaves.BuildList(true);
        }

        private void viewLCAPRecipesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameSave selectedSave = GetSelectedSave(false);
            if (selectedSave == null)
                return;

            LCAPForm lcap = new LCAPForm(uint.Parse(selectedSave.Seed));
            lcap.ShowDialog();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            GameSave selectedSave = GetSelectedSave();

            if (selectedSave == null)
                selectedSave = gameSaves["--default"];

            if (selectedSave.ID == "--default")
            {
                GameHandler.Launch(installPath, noitaSavePath);
                Analytics.TrackEvent("SaveList", "PlaySave", "Built-in: Default");
                return;
            }

            if (selectedSave.ID == "--custom")
            {
                CustomPlayOptionsForm cpo = new CustomPlayOptionsForm();
                cpo.ShowDialog();

                GameHandler.ClearSave(noitaSavePath);
                GameHandler.Launch(installPath, noitaSavePath, cpo.Seed, cpo.BiomeMap);
                Analytics.TrackEvent("SaveList", "PlaySave", "Built-in: Custom");
                return;
            }

            selectedSave.RestoreFromStore(noitaSavePath);
            GameHandler.Launch(installPath, noitaSavePath);
            Analytics.TrackEvent("SaveList", "PlaySave", selectedSave.Name);
        }

        private void GameHandler_GameFinished()
        {
            if(File.Exists(Path.Combine(noitaSavePath, "player.xml")) || File.Exists(Path.Combine(noitaSavePath, "player.salakieli")))
                CreateGameSave(null, true);
        }

        private void CreateGameSave(GameSave selectedSave, bool autosave = false)
        {
            bool creatingNewSave = false;
            string name = "Unknown";
            string group = "Game Saves";
            if (autosave == true)
            {
                name = "Autosave";
                group = "Auto Saves";
                creatingNewSave = true;
            } else if (selectedSave == null)
            {
                name = Prompt.ShowDialog("Enter new save name");
                if (name.Trim() == "")
                    name = "Unnamed Save";
                creatingNewSave = true;
            }

            string id;
            if (creatingNewSave)
            {
                id = GetUnusedId(name);
                selectedSave = new GameSave
                {
                    ID = id,
                    Name = name,
                    GameVersion = gameVersionHash,
                    Location = Path.Combine(localSavePath, id),
                    LastModified = DateTime.Now,
                    Group = group
                };
                gameSaves.Add(id, selectedSave);
            } else
            {
                id = selectedSave.ID;
            }

            selectedSave.CopyToStore(noitaSavePath);
            selectedSave.LastModified = DateTime.Now;
            selectedSave.LoadSeed();
            selectedSave.LoadEncryptedData();
            selectedSave.UpdateSubtitle();
            Analytics.TrackEvent("SaveList", "CreateSave", selectedSave.Name);
            RebuildSavesList();
        }

        private void RebuildSavesList()
        {
            if (lstGameSaves.InvokeRequired)
            {
                var d = new SafeCallDelegate(RebuildSavesList);
                lstGameSaves.Invoke(d);
            }
            else
            {
                lstGameSaves.BuildList(true);
            }
        }

        private string GetInstallPath()
        {
            if (File.Exists("install_path.txt"))
            {
                string path = File.ReadAllText("install_path.txt").Trim();
                if (Directory.Exists(path))
                    return path;
            }

            string defaultPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Noita";
            if (File.Exists(Path.Combine(defaultPath, "noita.exe")))
                return defaultPath; // Hey, most people live here so let's skip the search if so.

            try
            {
                return Steam.FindCommonSteamappFolder("Noita");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to auto-discover Notia install location.\r\n\r\n   - " + ex.Message.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                string path = Prompt.ShowDialog("Enter Noita install location");
                File.WriteAllText("install_path.txt", path);
                if (!File.Exists(Path.Combine(path, "noita.exe")))
                {
                    MessageBox.Show("Invalid path entered, couldn't find '" + Path.Combine(path, "noita.exe") + "'.");
                    Application.Exit();
                    return "";
                }
                return path;
            }
        }

        private DescribedTaskRenderer CreateDescribedRowRenderer()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "Subtitle";
            renderer.TitleFont = new Font(Font.FontFamily, 9);
            renderer.DescriptionFont = new Font(Font.FontFamily, 8);
            renderer.DescriptionColor = Color.Gray;
            renderer.ImageTextSpace = 0;
            renderer.TitleDescriptionSpace = 1;
            renderer.UseGdiTextRendering = true;
            return renderer;
        }

        private string GetUnusedId(string name, int index = 0)
        {
            string id = name.ToAlphaNumericOnly("-") + "-" + index;
            string path = Path.Combine(localSavePath, id);
            if (!Directory.Exists(path))
                return id;
            return GetUnusedId(name, index + 1);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog();
        }

        private void openFolderInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameSave selectedSave = GetSelectedSave();
            if (selectedSave == null)
                return;

            string path = selectedSave.Location;
            if (selectedSave.BuiltIn)
                path = noitaSavePath;

            Process.Start(path);
        }

        private void decryptSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameSave selectedSave = GetSelectedSave(false);
            if (selectedSave == null)
                return;

            selectedSave.Decrypt();
            MessageBox.Show("Save file has successfully been decrypted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void encryptSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameSave selectedSave = GetSelectedSave(false);
            if (selectedSave == null)
                return;

            selectedSave.Encrypt();
            MessageBox.Show("Save file has successfully been encrypted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private GameSave GetSelectedSave(bool allowBuiltIn = true)
        {
            GameSave selectedSave = null;
            if (lstGameSaves.SelectedItems.Count >= 1)
                selectedSave = (GameSave)lstGameSaves.SelectedItem.RowObject;

            if (allowBuiltIn == false && selectedSave != null && selectedSave.BuiltIn == true)
                return null;

            return selectedSave;
        }

        private void lstGameSaves_DoubleClick(object sender, EventArgs e)
        {
            btnPlay_Click(sender, e);
        }

        private void editSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameSave selectedSave = GetSelectedSave(false);
            if (selectedSave == null)
                return;

            EditSaveForm cpo = new EditSaveForm(selectedSave);
            cpo.ShowDialog();
            selectedSave.LoadEncryptedData();
            selectedSave.LoadSeed();
            selectedSave.UpdateSubtitle();
            RebuildSavesList();
        }
    }
}