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
            libProChic.ImageList imageList5 = new libProChic.ImageList();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            libProChic.ImageList imageList6 = new libProChic.ImageList();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.grpResults = new System.Windows.Forms.Panel();
            this.lblFaces = new System.Windows.Forms.Label();
            this.elvThumb = new libProChic.ExplorerListView();
            this.explorerTreeView1 = new libProChic.ExplorerTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.PanAndZoom;
            this.imageBoxFrameGrabber.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(261, 12);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(1378, 546);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBoxFrameGrabber.TabIndex = 4;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // grpResults
            // 
            this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResults.AutoScroll = true;
            this.grpResults.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpResults.Location = new System.Drawing.Point(1645, 30);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(150, 595);
            this.grpResults.TabIndex = 11;
            // 
            // lblFaces
            // 
            this.lblFaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFaces.AutoSize = true;
            this.lblFaces.Location = new System.Drawing.Point(1645, 11);
            this.lblFaces.Name = "lblFaces";
            this.lblFaces.Size = new System.Drawing.Size(36, 13);
            this.lblFaces.TabIndex = 12;
            this.lblFaces.Text = "Faces";
            // 
            // elvThumb
            // 
            this.elvThumb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elvThumb.AutoRefreshFolder = true;
            this.elvThumb.Directory = "E:\\Public\\Pictures\\Yearbook\\2019\\";
            this.elvThumb.DisplayMode = libProChic.ExplorerListView.DisplayType.DirectoriesAndFiles;
            this.elvThumb.FileSizeType = libProChic.ExplorerListView.SizeType.Bytes;
            this.elvThumb.Filter = "*.jpg";
            this.elvThumb.FollowPallet = false;
            this.elvThumb.GridLines = true;
            this.elvThumb.ImageSize = new System.Drawing.Size(32, 32);
            this.elvThumb.LargeImageList = imageList5;
            this.elvThumb.Location = new System.Drawing.Point(261, 564);
            this.elvThumb.Name = "elvThumb";
            this.elvThumb.OnErrorGoToParentDirectory = false;
            this.elvThumb.OSIconLocationPath = "";
            this.elvThumb.Pattern = ((System.Drawing.Bitmap)(resources.GetObject("elvThumb.Pattern")));
            this.elvThumb.Root = "C:\\";
            this.elvThumb.SelectedColor = System.Drawing.Color.Empty;
            this.elvThumb.SelectedTextColor = System.Drawing.Color.Empty;
            this.elvThumb.Size = new System.Drawing.Size(1378, 61);
            this.elvThumb.SmallImageList = imageList6;
            this.elvThumb.TabIndex = 10;
            this.elvThumb.UpdateDesktop = false;
            this.elvThumb.UseCompatibleStateImageBehavior = false;
            this.elvThumb.ViewType = libProChic.ExplorerListView.ExplorerType.General;
            this.elvThumb.Wallpaper = ((System.Drawing.Bitmap)(resources.GetObject("elvThumb.Wallpaper")));
            this.elvThumb.WallpaperLayout = System.Windows.Forms.ImageLayout.None;
            // 
            // explorerTreeView1
            // 
            this.explorerTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.explorerTreeView1.DirectoryRoot = "E:\\Public\\Pictures\\OurPix\\2021";
            this.explorerTreeView1.Location = new System.Drawing.Point(13, 13);
            this.explorerTreeView1.Name = "explorerTreeView1";
            this.explorerTreeView1.Size = new System.Drawing.Size(242, 612);
            this.explorerTreeView1.TabIndex = 13;
            this.explorerTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.explorerTreeView1_AfterSelect);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1807, 637);
            this.Controls.Add(this.explorerTreeView1);
            this.Controls.Add(this.lblFaces);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.elvThumb);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.Name = "FrmPrincipal";
            this.Text = "LeMS IMAGE-nation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private libProChic.ExplorerListView elvThumb;
        private System.Windows.Forms.Panel grpResults;
        private System.Windows.Forms.Label lblFaces;
        private libProChic.ExplorerTreeView explorerTreeView1;
    }
}

