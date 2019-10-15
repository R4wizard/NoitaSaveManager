namespace NoitaSaveManager
{
    partial class EditSaveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSaveForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSeed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPosX = new System.Windows.Forms.TextBox();
            this.txtPosY = new System.Windows.Forms.TextBox();
            this.txtMaxHP = new System.Windows.Forms.TextBox();
            this.txtHP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkDamageLog = new System.Windows.Forms.CheckBox();
            this.txtGameVersion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(144, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(253, 22);
            this.txtName.TabIndex = 3;
            // 
            // txtSeed
            // 
            this.txtSeed.Location = new System.Drawing.Point(144, 39);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(253, 22);
            this.txtSeed.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seed";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(144, 67);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(253, 22);
            this.txtLocation.TabIndex = 7;
            this.txtLocation.DoubleClick += new System.EventHandler(this.txtLocation_DoubleClick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Location";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Position";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPosX
            // 
            this.txtPosX.Location = new System.Drawing.Point(144, 123);
            this.txtPosX.Name = "txtPosX";
            this.txtPosX.Size = new System.Drawing.Size(124, 22);
            this.txtPosX.TabIndex = 10;
            // 
            // txtPosY
            // 
            this.txtPosY.Location = new System.Drawing.Point(273, 123);
            this.txtPosY.Name = "txtPosY";
            this.txtPosY.Size = new System.Drawing.Size(124, 22);
            this.txtPosY.TabIndex = 11;
            // 
            // txtMaxHP
            // 
            this.txtMaxHP.Location = new System.Drawing.Point(273, 151);
            this.txtMaxHP.Name = "txtMaxHP";
            this.txtMaxHP.Size = new System.Drawing.Size(124, 22);
            this.txtMaxHP.TabIndex = 14;
            // 
            // txtHP
            // 
            this.txtHP.Location = new System.Drawing.Point(144, 151);
            this.txtHP.Name = "txtHP";
            this.txtHP.Size = new System.Drawing.Size(124, 22);
            this.txtHP.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "Health";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(144, 179);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(253, 22);
            this.txtMoney.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "Money";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkDamageLog
            // 
            this.chkDamageLog.AutoSize = true;
            this.chkDamageLog.Location = new System.Drawing.Point(144, 211);
            this.chkDamageLog.Name = "chkDamageLog";
            this.chkDamageLog.Size = new System.Drawing.Size(125, 17);
            this.chkDamageLog.TabIndex = 19;
            this.chkDamageLog.Text = "Enable damage log";
            this.chkDamageLog.UseVisualStyleBackColor = true;
            // 
            // txtGameVersion
            // 
            this.txtGameVersion.Location = new System.Drawing.Point(144, 95);
            this.txtGameVersion.Name = "txtGameVersion";
            this.txtGameVersion.ReadOnly = true;
            this.txtGameVersion.Size = new System.Drawing.Size(253, 22);
            this.txtGameVersion.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 22);
            this.label7.TabIndex = 20;
            this.label7.Text = "Game Version";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditSaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(409, 281);
            this.Controls.Add(this.txtGameVersion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkDamageLog);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMaxHP);
            this.Controls.Add(this.txtHP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPosY);
            this.Controls.Add(this.txtPosX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSaveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NoitaSaveManager :: Edit Save";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPosX;
        private System.Windows.Forms.TextBox txtPosY;
        private System.Windows.Forms.TextBox txtMaxHP;
        private System.Windows.Forms.TextBox txtHP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkDamageLog;
        private System.Windows.Forms.TextBox txtGameVersion;
        private System.Windows.Forms.Label label7;
    }
}