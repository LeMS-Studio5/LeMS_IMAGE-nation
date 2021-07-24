using libProChic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiFaceRec
{
    public class Profile
    {
        private String profileDir="";
        private ConfigHelper prof;
        public Profile()
        {

        }

        public Profile(String profileFolder)
        {
            if (!profileFolder.EndsWith("\\")) profileFolder += "\\";
            prof = new ConfigHelper(profileFolder+ "details.pro",false);
            profileDir = profileFolder;
        }

        public string FirstName { get { return prof.GetConfig("Main", "FN").Setting; } set { prof.SetConfig("Main", "FN", value, true); } }
        public string MiddleName { get { return prof.GetConfig("Main", "MN").Setting; } set { prof.SetConfig("Main", "MN", value, true); } }
        public string LastName { get { return prof.GetConfig("Main", "LN").Setting; } set { prof.SetConfig("Main", "LN", value, true); } }
        public Bitmap ProfilePicture { get { return prepareImage(profileDir + "pro.jpg"); } }
        public string Version { get { return prof.GetConfig("Hidden", "Ver").Setting; } set { prof.SetConfig("Hidden", "Ver", value, true); } }
        public void Save()
        {
            prof.Save();
        }
        public String FirstLastName()
        {
            return prof.GetConfig("Main", "FN").Setting + " " + prof.GetConfig("Main", "LN").Setting;
        }
        public Bitmap prepareImage(string imageLocation)
        {
            if (!File.Exists(imageLocation))
                throw new Exception(imageLocation + " could not be found");
            FileStream fs = new System.IO.FileStream(imageLocation, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            BinaryReader Reader = new BinaryReader(fs);
            Bitmap bmpStream = new Bitmap(new MemoryStream(Reader.ReadBytes(System.Convert.ToInt32(fs.Length))));//System.Drawing.Image.FromStream(ImageStream));
            Bitmap bmp = bmpStream.Clone(new Rectangle(0, 0, bmpStream.Width, bmpStream.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb); // , col As Color, intBiPerPixel As Integer = 16 'FROM https://stackoverflow.com/questions/29585959/how-to-release-picture-from-picturebox-so-picture-file-may-be-deleted-in-vb-net and https://www.translatetheweb.com/?ref=TVert&from=&to=en&a=https://dotnet.currifex.org/dotnet/code/graphics/#ImageNoLock                                                                                                                                                     // Dim myEncoderParameters As EncoderParameters = New EncoderParameters(1), memoryStream = New MemoryStream()
            Reader.Close();
            return (bmp); // Image.FromStream(memoryStream)
        }
    }
}
