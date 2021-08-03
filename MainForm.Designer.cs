namespace MultiFaceRec
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.grpResults = new System.Windows.Forms.Panel();
            this.lblFaces = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.lblDirectory = new libProChic.Label();
            this.imageBoxFrameGrabber = new libProChic.PictureBox();
            this.etvDirStruct = new libProChic.ExplorerTreeView();
            this.elvThumb = new libProChic.ExplorerListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpResults
            // 
            this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResults.AutoScroll = true;
            this.grpResults.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpResults.Location = new System.Drawing.Point(1645, 43);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(150, 582);
            this.grpResults.TabIndex = 11;
            // 
            // lblFaces
            // 
            this.lblFaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFaces.AutoSize = true;
            this.lblFaces.Location = new System.Drawing.Point(1642, 27);
            this.lblFaces.Name = "lblFaces";
            this.lblFaces.Size = new System.Drawing.Size(81, 13);
            this.lblFaces.TabIndex = 12;
            this.lblFaces.Text = "Faces: 0 Found";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1807, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.directoryManagerToolStripMenuItem,
            this.profileManagerToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // directoryManagerToolStripMenuItem
            // 
            this.directoryManagerToolStripMenuItem.Name = "directoryManagerToolStripMenuItem";
            this.directoryManagerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.directoryManagerToolStripMenuItem.Text = "&Directory Manager";
            this.directoryManagerToolStripMenuItem.Click += new System.EventHandler(this.directoryManagerToolStripMenuItem_Click);
            // 
            // profileManagerToolStripMenuItem
            // 
            this.profileManagerToolStripMenuItem.Name = "profileManagerToolStripMenuItem";
            this.profileManagerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.profileManagerToolStripMenuItem.Text = "&Profile Manager";
            this.profileManagerToolStripMenuItem.Click += new System.EventHandler(this.profileManagerToolStripMenuItem_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(1388, 27);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(251, 488);
            this.propertyGrid1.TabIndex = 14;
            // 
            // lblDirectory
            // 
            this.lblDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.DropShadow = false;
            this.lblDirectory.Location = new System.Drawing.Point(262, 501);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(169, 13);
            this.lblDirectory.TabIndex = 19;
            this.lblDirectory.Text = "No Directory Seletected: 0 Images";
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBoxFrameGrabber.AutoScroll = true;
            this.imageBoxFrameGrabber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Image = null;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(261, 27);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(1121, 463);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.imageBoxFrameGrabber.TabIndex = 18;
            this.imageBoxFrameGrabber.ZoomBeyoundFit = true;
            // 
            // etvDirStruct
            // 
            this.etvDirStruct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.etvDirStruct.DirectoryRoot = "";
            this.etvDirStruct.ImageIndex = 0;
            this.etvDirStruct.Location = new System.Drawing.Point(13, 27);
            this.etvDirStruct.Name = "etvDirStruct";
            this.etvDirStruct.SelectedImageIndex = 0;
            this.etvDirStruct.Size = new System.Drawing.Size(242, 598);
            this.etvDirStruct.TabIndex = 16;
            this.etvDirStruct.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.etvDirStruct_AfterSelect);
            // 
            // elvThumb
            // 
            this.elvThumb.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.elvThumb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elvThumb.AutoRefreshFolder = true;
            this.elvThumb.CacheThumbnails = true;
            this.elvThumb.Directory = "";
            this.elvThumb.DisplayMode = libProChic.ExplorerListView.DisplayType.Files;
            this.elvThumb.FileSizeType = libProChic.ExplorerListView.SizeType.Bytes;
            this.elvThumb.Filter = "*.jpg";
            this.elvThumb.FollowPallet = false;
            this.elvThumb.GridLines = true;
            this.elvThumb.LargeImageListSize = new System.Drawing.Size(48, 48);
            this.elvThumb.Location = new System.Drawing.Point(261, 521);
            this.elvThumb.Name = "elvThumb";
            this.elvThumb.OnErrorGoToParentDirectory = false;
            this.elvThumb.OSIconLocationPath = "";
            this.elvThumb.Pattern = ((System.Drawing.Bitmap)(resources.GetObject("elvThumb.Pattern")));
            this.elvThumb.Root = "C:\\";
            this.elvThumb.SelectedColor = System.Drawing.Color.Empty;
            this.elvThumb.SelectedTextColor = System.Drawing.Color.Empty;
            this.elvThumb.Size = new System.Drawing.Size(1378, 104);
            this.elvThumb.TabIndex = 15;
            this.elvThumb.UpdateDesktop = false;
            this.elvThumb.UseCompatibleStateImageBehavior = false;
            this.elvThumb.ViewType = libProChic.ExplorerListView.ExplorerType.General;
            this.elvThumb.Wallpaper = ((System.Drawing.Bitmap)(resources.GetObject("elvThumb.Wallpaper")));
            this.elvThumb.WallpaperLayout = System.Windows.Forms.ImageLayout.None;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1807, 637);
            this.Controls.Add(this.lblDirectory);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.Controls.Add(this.etvDirStruct);
            this.Controls.Add(this.elvThumb);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.lblFaces);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "LeMS IMAGE-nation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel grpResults;
        private System.Windows.Forms.Label lblFaces;
        private libProChic.ExplorerListView elvThumb;
        private libProChic.ExplorerTreeView etvDirStruct;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoryManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileManagerToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private libProChic.PictureBox imageBoxFrameGrabber;
        private libProChic.Label lblDirectory;
    }
}

