using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class PersonDetails : Form
    {
        int profileIndex=0;
        String dbLoc = Environment.ExpandEnvironmentVariables("%appdata%") + @"\LeMS\Imagenation\DB\";
        public PersonDetails(System.Drawing.Image profile)
        {
            InitializeComponent();
            picProfile.Image = profile;
        }
        public PersonDetails(int index)
        {
            profileIndex = index;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Required(txtFirst))
            {
                while (profileIndex == 0 || Directory.Exists(dbLoc + profileIndex.ToString("000000"))) profileIndex++;
                Directory.CreateDirectory(dbLoc+ profileIndex.ToString("000000"));
                libProChic.ConfigHelper profile = new libProChic.ConfigHelper(dbLoc + profileIndex.ToString("000000") + @"\details.pro",false);
                if (!File.Exists(dbLoc + profileIndex.ToString("000000") + @"\pro.jpg")) picProfile.Image.Save(dbLoc + profileIndex.ToString("000000") + @"\pro.jpg", System.Drawing.Imaging.ImageFormat.Bmp);
                profile.SetConfig("Hidden", "Ver", Application.ProductVersion,true);
                profile.SetConfig("Main", "FN", txtFirst.Text,true);
                profile.SetConfig("Main", "MN", txtMiddle.Text,true);
                profile.SetConfig("Main", "LN", txtLast.Text,true);
                profile.Save();
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private Boolean Required(TextBox txt)
        {
            if (txt.Text == "")
            {
                MessageBox.Show("Please fill out the required field " + txt.Tag.ToString());
                txt.Focus();
                return false;
            }
            return true;
        }
        public String ProfileName()
        {
            return (txtFirst.Text + " " + txtLast.Text).Trim();
        }
        public String profileLocation()
        {
            return dbLoc + profileIndex.ToString("000000");
        }
    }
}
