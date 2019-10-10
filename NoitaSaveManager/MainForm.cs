using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using NoitaSaveManager.Noita;
using NoitaSaveManager.Utils;

namespace NoitaSaveManager
{
    public partial class MainForm : Form
    {
        private string installPath;
        private string noitaSavePath;
        private string localSavePath;
        private string gameVersionHash;

        private Dictionary<string, GameSave> gameSaves;

        public MainForm()
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

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdater.UpdateFormSize = new System.Drawing.Size(500, 500);
            AutoUpdater.RunUpdateAsAdmin = true;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Start("https://noita.r4wizard.co.uk/AutoUpdater.xml");
            Analytics.TrackPage("Main Form", "/main-form");

            label1.Text = "NSM by R4wizard\nv" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

            gameSaves.Add("--default", new GameSave
            {
                ID = "--default",
                Name = "Play Noita",
                SubName = "Launch Noita without any changes.",
                BuiltIn = true
            });
            gameSaves.Add("--custom", new GameSave
            {
                ID = "--custom",
                Name = "Play Noita with Custom Seed",
                SubName = "Launch Noita with your own custom seed.",
                BuiltIn = true
            });

            foreach (var nextSave in Directory.GetDirectories(localSavePath))
            {
                GameSave save = GameSave.Load(nextSave);
                gameSaves.Add(save.ID, save);
            }

            UpdateSavesList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GameSave selectedSave = null;
            if (lstSaves.SelectedItems.Count >= 1)
                selectedSave = (GameSave)lstSaves.SelectedItems[0].Tag;

            if (selectedSave == null || selectedSave.BuiltIn)
                selectedSave = null;

            if (selectedSave != null)
            {
                DialogResult res = MessageBox.Show("Overwrite existing save '" + selectedSave.Name + "'?", "Overwrite Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                    selectedSave = null;
            }

            if (selectedSave == null)
            {
                string name = Prompt.ShowDialog("Enter new save name");
                string id = GetUnusedId(name);

                if (name.Trim() == "")
                    name = "Unnamed Save";

                selectedSave = new GameSave
                {
                    ID = id,
                    Name = name,
                    GameVersion = gameVersionHash,
                    Location = Path.Combine(localSavePath, id),
                    LastModified = DateTime.Now
                };
                gameSaves.Add(id, selectedSave);
            }

            UpdateSavesList();

            selectedSave.LastModified = DateTime.Now;
            selectedSave.CopyToStore(noitaSavePath);
            Analytics.TrackEvent("SaveList", "CreateSave", selectedSave.Name);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            GameSave selectedSave = null;
            if (lstSaves.SelectedItems.Count >= 1)
                selectedSave = (GameSave)lstSaves.SelectedItems[0].Tag;

            if (selectedSave == null || selectedSave.BuiltIn)
                selectedSave = null;

            if (selectedSave != null)
            {
                DialogResult res = MessageBox.Show("Remove save '" + selectedSave.Name + "'?", "Remove Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    Directory.Delete(selectedSave.Location, true);
                    lstSaves.Items.Remove(selectedSave.ListViewItem);
                    gameSaves.Remove(selectedSave.ID);
                    UpdateSavesList();
                }
                Analytics.TrackEvent("SaveList", "DeleteSave", selectedSave.Name);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            GameSave selectedSave = null;
            if (lstSaves.SelectedItems.Count >= 1)
                selectedSave = (GameSave)lstSaves.SelectedItems[0].Tag;

            if (selectedSave == null)
                selectedSave = gameSaves["--default"];

            if (selectedSave.ID == "--default")
            {
                GameHandler.Launch(installPath);
                return;
            }

            if (selectedSave.ID == "--custom")
            {
                string input = Prompt.ShowDialog("Enter your custom seed");
                if (input.Trim() == "")
                    return;

                int seed = 0;
                int.TryParse(input, out seed);

                GameHandler.ClearSave(noitaSavePath);
                GameHandler.Launch(installPath, seed);
                return;
            }

            selectedSave.RestoreFromStore(noitaSavePath);
            GameHandler.Launch(installPath);
            Analytics.TrackEvent("SaveList", "PlaySave", selectedSave.Name);
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

        private ListViewItem CreateListViewItem(GameSave save)
        {
            ListViewItem lvi = new ListViewItem("");
            lvi.Tag = save;
            lvi.SubItems.Add("");
            lstSaves.Items.Add(lvi);
            return lvi;
        }

        private void UpdateSavesList()
        {
            foreach (var save in gameSaves.Values)
            {
                if (save.ListViewItem == null)
                    save.ListViewItem = CreateListViewItem(save);

                save.ListViewItem.Text = save.Name;
                if (save.SubName != null)
                {
                    save.ListViewItem.SubItems[1].Text = save.SubName;
                }
                else
                {
                    string update = GameHandler.GameVersionHashToUpdate(save.GameVersion);
                    save.ListViewItem.SubItems[1].Text = save.LastModified.ToString("yyyy-MM-dd HH:mm:ss") + (update != "" ? " - " + update : "");
                }
            }

            SortSavesList();
        }

        public void SortSavesList()
        {
            ListView list = lstSaves;
            int total = list.Items.Count;
            list.BeginUpdate();
            ListViewItem[] items = new ListViewItem[total];
            for (int i = 0; i < total; i++)
            {
                int count = list.Items.Count;
                int minIdx = 0;
                for (int j = 1; j < count; j++)
                {
                    string a = list.Items[j].SubItems[1].Text;
                    string b = list.Items[minIdx].SubItems[1].Text;
                    if (a.CompareTo(b) > 0)
                        minIdx = j;
                }
                items[i] = list.Items[minIdx];
                list.Items.RemoveAt(minIdx);
            }
            list.Items.AddRange(items);
            list.EndUpdate();
        }

        private string GetUnusedId(string name, int index = 0)
        {
            string id = name.ToAlphaNumericOnly("-") + "-" + index;
            string path = Path.Combine(localSavePath, id);
            if (!Directory.Exists(path))
                return id;
            return GetUnusedId(name, index + 1);
        }
    }
}