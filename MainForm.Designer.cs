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
            libProChic.ImageList imageList1 = new libProChic.ImageList();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            libProChic.ImageList imageList2 = new libProChic.ImageList();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grpTraining = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.imgTrain = new Emgu.CV.UI.ImageBox();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.lblPersonPresent = new System.Windows.Forms.Label();
            this.lblNobody = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblNumberDetected = new System.Windows.Forms.Label();
            this.btnDetect = new System.Windows.Forms.Button();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.elvThumb = new libProChic.ExplorerListView();
            this.grpTraining.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrain)).BeginInit();
            this.grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(87, 201);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 31);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "2. Add face";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAddFace_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(67, 170);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(107, 20);
            this.txtName.TabIndex = 7;
            this.txtName.Text = "Sergio";
            // 
            // grpTraining
            // 
            this.grpTraining.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTraining.Controls.Add(this.lblName);
            this.grpTraining.Controls.Add(this.txtName);
            this.grpTraining.Controls.Add(this.imgTrain);
            this.grpTraining.Controls.Add(this.btnAdd);
            this.grpTraining.Location = new System.Drawing.Point(1395, 12);
            this.grpTraining.Name = "grpTraining";
            this.grpTraining.Size = new System.Drawing.Size(184, 248);
            this.grpTraining.TabIndex = 8;
            this.grpTraining.TabStop = false;
            this.grpTraining.Text = "Training: ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(11, 173);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Name: ";
            // 
            // imgTrain
            // 
            this.imgTrain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgTrain.Location = new System.Drawing.Point(11, 18);
            this.imgTrain.Name = "imgTrain";
            this.imgTrain.Size = new System.Drawing.Size(163, 134);
            this.imgTrain.TabIndex = 5;
            this.imgTrain.TabStop = false;
            // 
            // grpResults
            // 
            this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResults.Controls.Add(this.lblPersonPresent);
            this.grpResults.Controls.Add(this.lblNobody);
            this.grpResults.Controls.Add(this.lblNumber);
            this.grpResults.Controls.Add(this.lblNumberDetected);
            this.grpResults.Controls.Add(this.btnDetect);
            this.grpResults.Location = new System.Drawing.Point(1585, 12);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(209, 248);
            this.grpResults.TabIndex = 9;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results: ";
            // 
            // lblPersonPresent
            // 
            this.lblPersonPresent.AutoSize = true;
            this.lblPersonPresent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonPresent.ForeColor = System.Drawing.Color.Black;
            this.lblPersonPresent.Location = new System.Drawing.Point(9, 23);
            this.lblPersonPresent.Name = "lblPersonPresent";
            this.lblPersonPresent.Size = new System.Drawing.Size(197, 15);
            this.lblPersonPresent.TabIndex = 17;
            this.lblPersonPresent.Text = "Persons present in the scene:";
            // 
            // lblNobody
            // 
            this.lblNobody.AutoSize = true;
            this.lblNobody.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNobody.ForeColor = System.Drawing.Color.Blue;
            this.lblNobody.Location = new System.Drawing.Point(9, 53);
            this.lblNobody.Name = "lblNobody";
            this.lblNobody.Size = new System.Drawing.Size(61, 19);
            this.lblNobody.TabIndex = 16;
            this.lblNobody.Text = "Nobody";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.ForeColor = System.Drawing.Color.Red;
            this.lblNumber.Location = new System.Drawing.Point(163, 124);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(16, 16);
            this.lblNumber.TabIndex = 15;
            this.lblNumber.Text = "0";
            // 
            // lblNumberDetected
            // 
            this.lblNumberDetected.AutoSize = true;
            this.lblNumberDetected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberDetected.Location = new System.Drawing.Point(10, 92);
            this.lblNumberDetected.Name = "lblNumberDetected";
            this.lblNumberDetected.Size = new System.Drawing.Size(179, 15);
            this.lblNumberDetected.TabIndex = 14;
            this.lblNumberDetected.Text = "Number of faces detected: ";
            // 
            // btnDetect
            // 
            this.btnDetect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetect.Location = new System.Drawing.Point(84, 179);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(110, 53);
            this.btnDetect.TabIndex = 2;
            this.btnDetect.Text = "1. Detect and recognize";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(12, 12);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(1377, 538);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBoxFrameGrabber.TabIndex = 4;
            this.imageBoxFrameGrabber.TabStop = false;
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
            this.elvThumb.LargeImageList = imageList1;
            this.elvThumb.Location = new System.Drawing.Point(12, 556);
            this.elvThumb.Name = "elvThumb";
            this.elvThumb.OnErrorGoToParentDirectory = false;
            this.elvThumb.OSIconLocationPath = "";
            this.elvThumb.Pattern = ((System.Drawing.Bitmap)(resources.GetObject("elvThumb.Pattern")));
            this.elvThumb.Root = "C:\\";
            this.elvThumb.SelectedColor = System.Drawing.Color.Empty;
            this.elvThumb.SelectedTextColor = System.Drawing.Color.Empty;
            this.elvThumb.Size = new System.Drawing.Size(1377, 61);
            this.elvThumb.SmallImageList = imageList2;
            this.elvThumb.TabIndex = 10;
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
            this.ClientSize = new System.Drawing.Size(1806, 629);
            this.Controls.Add(this.elvThumb);
            this.Controls.Add(this.grpResults);
            this.Controls.Add(this.grpTraining);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.Name = "FrmPrincipal";
            this.Text = "Serg3ant\'s face detector and recgonizer :D";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.grpTraining.ResumeLayout(false);
            this.grpTraining.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrain)).EndInit();
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private Emgu.CV.UI.ImageBox imgTrain;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox grpTraining;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.Label lblPersonPresent;
        private System.Windows.Forms.Label lblNobody;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblNumberDetected;
        private System.Windows.Forms.Button btnDetect;
        private libProChic.ExplorerListView elvThumb;
    }
}

