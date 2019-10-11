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
    public partial class LCAPForm : Form
    {
        private uint Seed;

        public LCAPForm(uint seed)
        {
            InitializeComponent();
            Seed = seed;
        }

        private void LCAPForm_Load(object sender, EventArgs e)
        {
            Analytics.TrackPage("LCAP Form", "/lcap-form");
            SeedRecipeData data = SeedRecipe.GetRecipesForSeed(Seed);
            label1.Text = Seed.ToString();

            lblAPMaterial1.Text = SeedRecipe.MaterialToString(data.AlchemicalPrecursor.Material1);
            lblAPMaterial3.Text = SeedRecipe.MaterialToString(data.AlchemicalPrecursor.Material2);
            lblAPMaterial2.Text = SeedRecipe.MaterialToString(data.AlchemicalPrecursor.Material3);

            lblLCMaterial1.Text = SeedRecipe.MaterialToString(data.LivelyConcoction.Material1);
            lblLCMaterial3.Text = SeedRecipe.MaterialToString(data.LivelyConcoction.Material2);
            lblLCMaterial2.Text = SeedRecipe.MaterialToString(data.LivelyConcoction.Material3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Hide();
            Analytics.TrackEvent("LCAPViewer", "ViewRecipes", "Clicked");
        }
    }
}
