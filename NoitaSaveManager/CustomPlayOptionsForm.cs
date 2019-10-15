using NoitaSaveManager.Noita;
using NoitaSaveManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoitaSaveManager
{
    public partial class CustomPlayOptionsForm : Form
    {
        public uint Seed = 0;
        public string BiomeMap = "";

        public CustomPlayOptionsForm()
        {
            InitializeComponent();
        }

        private void CustomPlayOptionsForm_Load(object sender, EventArgs e)
        {
            Analytics.TrackPage("Custom Play Options Form", "/custom-play-options-form");
            RandomSeed();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Height == 140)
            {
                Height = 252;
                linkLabel1.Text = "hide LCAP";
            }
            else
            {
                Height = 140;
                linkLabel1.Text = "show LCAP";
            }
        }

        private void RandomSeed()
        {
            txtSeed.Text = Math.Floor((new Random()).NextDouble() * (uint.MaxValue - 1)).ToString();
            UpdateLCAP();
        }

        private void UpdateLCAP()
        {
            SeedRecipeData data = SeedRecipe.GetRecipesForSeed(Seed);

            lblAPMaterial1.Text = SeedRecipe.MaterialToString(data.AlchemicalPrecursor.Material1);
            lblAPMaterial3.Text = SeedRecipe.MaterialToString(data.AlchemicalPrecursor.Material2);
            lblAPMaterial2.Text = SeedRecipe.MaterialToString(data.AlchemicalPrecursor.Material3);

            lblLCMaterial1.Text = SeedRecipe.MaterialToString(data.LivelyConcoction.Material1);
            lblLCMaterial3.Text = SeedRecipe.MaterialToString(data.LivelyConcoction.Material2);
            lblLCMaterial2.Text = SeedRecipe.MaterialToString(data.LivelyConcoction.Material3);
        }

        private void txtSeed_TextChanged(object sender, EventArgs e)
        {
            Seed = uint.Parse(txtSeed.Text);
            UpdateLCAP();
        }

        private void txtSeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            Seed = uint.Parse(txtSeed.Text);
            UpdateLCAP();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RandomSeed();
            UpdateLCAP();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = comboBox1.Text;
            switch (val)
            {
                case "Default":
                    BiomeMap = "";
                    break;
                case "The End":
                    BiomeMap = "data/biome_impl/biome_map_the_end.png";
                    break;
                case "Trailer":
                    BiomeMap = "data/biome_impl/biome_map_trailer.png";
                    break;
                default:
                    BiomeMap = val;
                    break;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Hide();
        }
    }
}
