using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFaceRec
{
    class FaceFiller:Panel
    {
        PictureBox picPreview = new PictureBox();
        Label txtName = new Label();
        Button btnSave = new Button();
        public FaceFiller(System.Drawing.Image preview, String name)
        {
            this.Bounds = new System.Drawing.Rectangle(5,10,115, 150);
            picPreview.Bounds = new System.Drawing.Rectangle(3, 3,110,80);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            //Clipboard.SetText(name);
            if (name == null) name = "<Unknown Person>";
            txtName.Text = name;
            txtName.Bounds = new System.Drawing.Rectangle(3, 90, 110, 25);
            txtName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btnSave.Bounds = new System.Drawing.Rectangle(3, 115, 110, 30);
            btnSave.Text = "Enter Details";
            btnSave.Click += btnDetails;
            picPreview.Image = preview;
            Debug.WriteLine("'" + name + "'");
            this.Controls.Add(txtName);
            this.Controls.Add(btnSave);
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
        public event EventHandler DetailUpdate = new EventHandler((e, a) => { });
    }
}
