using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public class FaceFiller:Panel
    {
        private static string folderRoot = Environment.ExpandEnvironmentVariables("%appdata%") + @"\LeMS\Imagenation\DB\", imageIndex;
        private Int64 lngKey;
        PictureBox picPreview = new PictureBox();
        ComboBox txtName = new ComboBox();
        Button btnSave = new Button();
        Button btnDelete = new Button();
        public FaceFiller(System.Drawing.Image preview, String name,List<Profile> db,String imgIndex, Int64 key)
        {
            imageIndex = imgIndex;
            lngKey = key;
            this.Bounds = new System.Drawing.Rectangle(5,10,120, 150);
            picPreview.Bounds = new System.Drawing.Rectangle(3, 3,110,80);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            Name = name;
            //Clipboard.SetText(name);
            if (name == null ) name = "";
            txtName.Bounds = new System.Drawing.Rectangle(3, 90, 115, 25);
            txtName.DataSource = db;
            txtName.DropDownStyle = ComboBoxStyle.DropDownList;
            txtName.SelectedText = name;
            btnSave.Bounds = new System.Drawing.Rectangle(3, 115, 55, 30);
            btnSave.Text = "Details";
            btnSave.Click += btnDetails;
            btnDelete.Bounds = new System.Drawing.Rectangle(3+btnSave.Width+5, 115, 55, 30);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDel;
            picPreview.Image = preview;
            Debug.WriteLine("'" + name + "'");
            this.Controls.Add(txtName);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnDelete);
            this.Controls.Add(picPreview);
        }
        private void btnDetails(Object sender, EventArgs e)
        {
            PersonDetails details = new PersonDetails(picPreview.Image);
            if (details.ShowDialog() == DialogResult.OK)
            {
                txtName.Text = details.Profile.FirstLastName();
                DetailUpdate?.Invoke(details.profileLocation(), e);
            }
        }
        private void btnDel(Object sender, EventArgs e) {
            libProChic.ConfigHelper con = new libProChic.ConfigHelper(folderRoot + @"ImageDB\" + lngKey.ToString("0000000000"));
            con.RemoveGroup(imageIndex);
            con.Save();
            this.Dispose();
        }
        public new String Name { get; set; } = "";
        public event EventHandler DetailUpdate = new EventHandler((e, a) => { });
    }
}
