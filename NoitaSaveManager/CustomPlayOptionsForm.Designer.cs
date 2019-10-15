namespace NoitaSaveManager
{
    partial class CustomPlayOptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomPlayOptionsForm));
            this.txtSeed = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblLCMaterial3 = new System.Windows.Forms.Label();
            this.lblLCMaterial2 = new System.Windows.Forms.Label();
            this.lblLCMaterial1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAPMaterial3 = new System.Windows.Forms.Label();
            this.lblAPMaterial2 = new System.Windows.Forms.Label();
            this.lblAPMaterial1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSeed
            // 
            this.txtSeed.Location = new System.Drawing.Point(91, 12);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(283, 22);
            this.txtSeed.TabIndex = 0;
            this.txtSeed.TextChanged += new System.EventHandler(this.txtSeed_TextChanged);
            this.txtSeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeed_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Default",
            "The End",
            "Trailer"});
            this.comboBox1.Location = new System.Drawing.Point(91, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(349, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Default";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seed";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Biome Map";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(349, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(380, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 21);
            this.button2.TabIndex = 6;
            this.button2.Text = "random";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(17, 67);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(68, 23);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "show LCAP";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblLCMaterial3);
            this.groupBox3.Controls.Add(this.lblLCMaterial2);
            this.groupBox3.Controls.Add(this.lblLCMaterial1);
            this.groupBox3.Location = new System.Drawing.Point(229, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(211, 100);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lively Concoction";
            // 
            // lblLCMaterial3
            // 
            this.lblLCMaterial3.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLCMaterial3.Location = new System.Drawing.Point(6, 68);
            this.lblLCMaterial3.Name = "lblLCMaterial3";
            this.lblLCMaterial3.Size = new System.Drawing.Size(199, 25);
            this.lblLCMaterial3.TabIndex = 5;
            this.lblLCMaterial3.Text = "Material 3";
            this.lblLCMaterial3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLCMaterial2
            // 
            this.lblLCMaterial2.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLCMaterial2.Location = new System.Drawing.Point(6, 43);
            this.lblLCMaterial2.Name = "lblLCMaterial2";
            this.lblLCMaterial2.Size = new System.Drawing.Size(199, 25);
            this.lblLCMaterial2.TabIndex = 4;
            this.lblLCMaterial2.Text = "Material 2";
            this.lblLCMaterial2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLCMaterial1
            // 
            this.lblLCMaterial1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLCMaterial1.Location = new System.Drawing.Point(6, 18);
            this.lblLCMaterial1.Name = "lblLCMaterial1";
            this.lblLCMaterial1.Size = new System.Drawing.Size(199, 25);
            this.lblLCMaterial1.TabIndex = 3;
            this.lblLCMaterial1.Text = "Material 1";
            this.lblLCMaterial1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAPMaterial3);
            this.groupBox1.Controls.Add(this.lblAPMaterial2);
            this.groupBox1.Controls.Add(this.lblAPMaterial1);
            this.groupBox1.Location = new System.Drawing.Point(12, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alchemical Precursor";
            // 
            // lblAPMaterial3
            // 
            this.lblAPMaterial3.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPMaterial3.Location = new System.Drawing.Point(6, 68);
            this.lblAPMaterial3.Name = "lblAPMaterial3";
            this.lblAPMaterial3.Size = new System.Drawing.Size(199, 25);
            this.lblAPMaterial3.TabIndex = 5;
            this.lblAPMaterial3.Text = "Material 3";
            this.lblAPMaterial3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAPMaterial2
            // 
            this.lblAPMaterial2.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPMaterial2.Location = new System.Drawing.Point(6, 43);
            this.lblAPMaterial2.Name = "lblAPMaterial2";
            this.lblAPMaterial2.Size = new System.Drawing.Size(199, 25);
            this.lblAPMaterial2.TabIndex = 4;
            this.lblAPMaterial2.Text = "Material 2";
            this.lblAPMaterial2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAPMaterial1
            // 
            this.lblAPMaterial1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPMaterial1.Location = new System.Drawing.Point(6, 18);
            this.lblAPMaterial1.Name = "lblAPMaterial1";
            this.lblAPMaterial1.Size = new System.Drawing.Size(199, 25);
            this.lblAPMaterial1.TabIndex = 3;
            this.lblAPMaterial1.Text = "Material 1";
            this.lblAPMaterial1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 101);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(30);
            this.label2.Size = new System.Drawing.Size(428, 100);
            this.label2.TabIndex = 10;
            this.label2.Text = "WARNING: Knowing these recipes may affect your gameplay and can be considered spo" +
    "ilers. Click here to view the recipes or click close to retreat quitely backward" +
    "s.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // CustomPlayOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(452, 101);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtSeed);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomPlayOptionsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NoitaSaveManager :: Custom Options";
            this.Load += new System.EventHandler(this.CustomPlayOptionsForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSeed;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblLCMaterial3;
        private System.Windows.Forms.Label lblLCMaterial2;
        private System.Windows.Forms.Label lblLCMaterial1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAPMaterial3;
        private System.Windows.Forms.Label lblAPMaterial2;
        private System.Windows.Forms.Label lblAPMaterial1;
        private System.Windows.Forms.Label label2;
    }
}