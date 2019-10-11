namespace NoitaSaveManager
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstGameSaves = new BrightIdeasSoftware.ObjectListView();
            this.olvGSColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvGSColumnSeed = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ctxMenuSavesList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLCAPRecipesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstGameSaves)).BeginInit();
            this.ctxMenuSavesList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NoitaSaveManager.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(424, 224);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 518);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "save game";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(359, 518);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(77, 29);
            this.btnPlay.TabIndex = 10;
            this.btnPlay.Text = "play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(95, 518);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "NSM by R4wizard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 219;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 118;
            // 
            // lstGameSaves
            // 
            this.lstGameSaves.AllColumns.Add(this.olvGSColumnName);
            this.lstGameSaves.AllColumns.Add(this.olvGSColumnSeed);
            this.lstGameSaves.CellEditUseWholeCell = false;
            this.lstGameSaves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvGSColumnName,
            this.olvGSColumnSeed});
            this.lstGameSaves.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstGameSaves.FullRowSelect = true;
            this.lstGameSaves.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstGameSaves.Location = new System.Drawing.Point(12, 242);
            this.lstGameSaves.MultiSelect = false;
            this.lstGameSaves.Name = "lstGameSaves";
            this.lstGameSaves.Size = new System.Drawing.Size(424, 270);
            this.lstGameSaves.SpaceBetweenGroups = 3;
            this.lstGameSaves.TabIndex = 13;
            this.lstGameSaves.UseCompatibleStateImageBehavior = false;
            this.lstGameSaves.View = System.Windows.Forms.View.Details;
            // 
            // olvGSColumnName
            // 
            this.olvGSColumnName.AspectName = "Name";
            this.olvGSColumnName.FillsFreeSpace = true;
            this.olvGSColumnName.Text = "Name";
            this.olvGSColumnName.Width = 188;
            // 
            // olvGSColumnSeed
            // 
            this.olvGSColumnSeed.AspectName = "Seed";
            this.olvGSColumnSeed.Text = "Seed";
            this.olvGSColumnSeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.olvGSColumnSeed.Width = 142;
            // 
            // ctxMenuSavesList
            // 
            this.ctxMenuSavesList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteSaveToolStripMenuItem,
            this.toolStripSeparator1,
            this.viewLCAPRecipesToolStripMenuItem});
            this.ctxMenuSavesList.Name = "ctxMenuSavesList";
            this.ctxMenuSavesList.Size = new System.Drawing.Size(181, 76);
            // 
            // deleteSaveToolStripMenuItem
            // 
            this.deleteSaveToolStripMenuItem.Name = "deleteSaveToolStripMenuItem";
            this.deleteSaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteSaveToolStripMenuItem.Text = "Delete Save";
            this.deleteSaveToolStripMenuItem.Click += new System.EventHandler(this.deleteSaveToolStripMenuItem_Click);
            // 
            // viewLCAPRecipesToolStripMenuItem
            // 
            this.viewLCAPRecipesToolStripMenuItem.Name = "viewLCAPRecipesToolStripMenuItem";
            this.viewLCAPRecipesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewLCAPRecipesToolStripMenuItem.Text = "View LCAP Recipes";
            this.viewLCAPRecipesToolStripMenuItem.Click += new System.EventHandler(this.viewLCAPRecipesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(448, 559);
            this.Controls.Add(this.lstGameSaves);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Noita Save Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstGameSaves)).EndInit();
            this.ctxMenuSavesList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private BrightIdeasSoftware.ObjectListView lstGameSaves;
        private BrightIdeasSoftware.OLVColumn olvGSColumnName;
        private BrightIdeasSoftware.OLVColumn olvGSColumnSeed;
        private System.Windows.Forms.ContextMenuStrip ctxMenuSavesList;
        private System.Windows.Forms.ToolStripMenuItem deleteSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem viewLCAPRecipesToolStripMenuItem;
    }
}

