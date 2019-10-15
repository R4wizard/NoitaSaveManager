using NoitaSaveManager.Noita;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoitaSaveManager
{
    public partial class EditSaveForm : Form
    {
        public GameSave Save;

        public EditSaveForm(GameSave save)
        {
            InitializeComponent();
            Save = save;

            txtName.Text = save.Name;
            txtSeed.Text = save.Seed.ToString();
            txtLocation.Text = save.Location;
            txtGameVersion.Text = GameHandler.GameVersionHashToUpdate(save.GameVersion);

            txtPosX.Text = save.PositionX.ToString();
            txtPosY.Text = save.PositionY.ToString();
            txtHP.Text = save.HP.ToString();
            txtMaxHP.Text = save.MaxHP.ToString();
            txtMoney.Text = save.Money.ToString();
            chkDamageLog.Checked = save.ReportDamage;
        }

        private void txtLocation_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(Save.Location);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save.Seed = txtSeed.Text;
            Save.Name = txtName.Text;
            Save.PositionX = float.Parse(txtPosX.Text);
            Save.PositionY = float.Parse(txtPosY.Text);
            Save.HP = float.Parse(txtHP.Text);
            Save.MaxHP = float.Parse(txtMaxHP.Text);
            Save.Money = uint.Parse(txtMoney.Text);
            Save.ReportDamage = chkDamageLog.Checked;
            Save.WriteSaveInfo();
            Save.SaveEncryptedData();
            Save.SaveSeed();
            Close();
        }
    }
}
