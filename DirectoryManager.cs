using libProChic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class DirectoryManager : Form
    {
        public Boolean DirChange { get; internal set; } = false;
        ConfigHelper con;
        public DirectoryManager(ConfigHelper config)
        {
            InitializeComponent();
            con = config;
            foreach( Config c in con.GetConfigGroup("Dir").ToArray())
            {
                lbxDirs.Items.Add(c.Setting);
            }
        }

        private void lbxDirs_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDel.Enabled = (lbxDirs.SelectedIndex > -1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (fbdDirMan.ShowDialog() == DialogResult.OK)
            {
                lbxDirs.Items.Add(fbdDirMan.SelectedPath);
                con.SetConfig("Dir", con.GetConfigGroup("Dir").ToArray().Length+"", fbdDirMan.SelectedPath,true);
                con.Save();
                DirChange = true;
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            con.GetConfigGroup("Dir").RemoveAt(lbxDirs.SelectedIndex);
            lbxDirs.Items.RemoveAt(lbxDirs.SelectedIndex);
            con.Save();
            DirChange = true;
        }
    }
}
