namespace MultiFaceRec
{
    partial class ProfileManager
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
            this.btnLoadProfile = new System.Windows.Forms.Button();
            this.lbxProfiles = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadProfile
            // 
            this.btnLoadProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadProfile.Enabled = false;
            this.btnLoadProfile.Location = new System.Drawing.Point(12, 227);
            this.btnLoadProfile.Name = "btnLoadProfile";
            this.btnLoadProfile.Size = new System.Drawing.Size(123, 23);
            this.btnLoadProfile.TabIndex = 0;
            this.btnLoadProfile.Text = "&Load";
            this.btnLoadProfile.UseVisualStyleBackColor = true;
            this.btnLoadProfile.Click += new System.EventHandler(this.btnLoadProfile_Click);
            // 
            // lbxProfiles
            // 
            this.lbxProfiles.FormattingEnabled = true;
            this.lbxProfiles.Location = new System.Drawing.Point(13, 13);
            this.lbxProfiles.Name = "lbxProfiles";
            this.lbxProfiles.Size = new System.Drawing.Size(259, 199);
            this.lbxProfiles.TabIndex = 1;
            this.lbxProfiles.SelectedIndexChanged += new System.EventHandler(this.lbxProfiles_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(141, 227);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(131, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ProfileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lbxProfiles);
            this.Controls.Add(this.btnLoadProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProfileManager";
            this.Text = "ProfileManager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadProfile;
        private System.Windows.Forms.ListBox lbxProfiles;
        private System.Windows.Forms.Button btnDelete;
    }
}