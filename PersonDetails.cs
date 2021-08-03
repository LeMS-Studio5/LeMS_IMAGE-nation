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
        String dbLoc = Environment.ExpandEnvironmentVariables("%appdata%") + @"\LeMS\Imagenation\DB\FaceDB\";
        public PersonDetails(System.Drawing.Image ProfileImage)
        {
            InitializeComponent();
            picProfile.Image = ProfileImage;
            if (Directory.GetDirectories(dbLoc).Length>0) profileIndex = int.Parse(new DirectoryInfo(Directory.GetDirectories(dbLoc).Last()).Name)+1;
            Profile = new Profile(dbLoc + profileIndex.ToString("000000"));
        }
        public PersonDetails(int index)
        {
            InitializeComponent();
            profileIndex = index;
            Profile = new Profile(dbLoc + profileIndex.ToString("000000"));
            txtFirst.Text = Profile.FirstName;
            txtMiddle.Text = Profile.MiddleName;
            txtLast.Text = Profile.LastName;
            picProfile.Image = Profile.ProfilePicture;
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
                if (! Directory.Exists(dbLoc + profileIndex.ToString("000000")))Directory.CreateDirectory(dbLoc+ profileIndex.ToString("000000"));
                if (!File.Exists(dbLoc + profileIndex.ToString("000000") + @"\pro.jpg")) picProfile.Image.Save(dbLoc + profileIndex.ToString("000000") + @"\pro.jpg");
                Profile.Version = Application.ProductVersion;
                Profile.FirstName= txtFirst.Text;
                Profile.MiddleName = txtMiddle.Text;
                Profile.LastName = txtLast.Text;
                Profile.Save();
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
        public Profile Profile { get; set; }
        public String profileLocation()
        {
            return dbLoc + profileIndex.ToString("000000");
        }
    }
}
