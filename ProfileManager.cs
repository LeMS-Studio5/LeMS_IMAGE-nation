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
    public partial class ProfileManager : Form
    {
        private String dbLoc = Environment.ExpandEnvironmentVariables("%appdata%") + @"\LeMS\Imagenation\DB\FaceDB";
        private Dictionary<int, int> indexReflect = new Dictionary<int, int>(); //lbx index, db index
        public ProfileManager()
        {
            InitializeComponent();
            foreach (String pro in Directory.GetDirectories(dbLoc))
            {
                lbxProfiles.Items.Add(new Profile(pro).FirstLastName());
                indexReflect.Add(lbxProfiles.Items.Count - 1, int.Parse(new DirectoryInfo(pro).Name));
            }
        }
        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
            PersonDetails per = new PersonDetails(indexReflect[lbxProfiles.SelectedIndex]);
            if (per.ShowDialog() == DialogResult.OK)
            {
                lbxProfiles.SelectedItem = per.Profile.FirstLastName();
            }
        }

        private void lbxProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = btnLoadProfile.Enabled = (lbxProfiles.SelectedIndex>-1);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Directory.Delete(dbLoc + indexReflect[lbxProfiles.SelectedIndex].ToString("000000"),true);
            indexReflect.Remove(lbxProfiles.SelectedIndex);
            lbxProfiles.Items.RemoveAt(lbxProfiles.SelectedIndex);
        }
    }
}
