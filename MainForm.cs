
//Multiple face detection and recognition in real time
//Using EmguCV cross platform .Net wrapper to the Intel OpenCV image processing library for C#.Net
//Writed by Sergio Andrés Guitérrez Rojas
//"Serg3ant" for the delveloper comunity
// Sergiogut1805@hotmail.com
//Regards from Bucaramanga-Colombia ;)

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.Linq;
using libProChic;

namespace MultiFaceRec
{
    public partial class FrmPrincipal : Form
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face, eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null, gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<Profile> labels= new List<Profile>();
        List<string> NamePersons = new List<string>();
        int IMGSIZE = 75, fillerHeight = 15;//ContTrain, NumLabels, t;
        string name, folderRoot=Environment.ExpandEnvironmentVariables("%appdata%")+ @"\LeMS\Imagenation\";
        ConfigHelper config,existImg = new ConfigHelper();
        Bitmap faceFrame;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.elvThumb.FileOpened += elvThumb_Open;
            this.grpResults.ControlAdded += FaceControlChange;
            this.grpResults.ControlRemoved += FaceControlChange;
            //PicasaDBConverter.CheckForPicasaDB();
            labels.Add(new Profile());
            trainingImages.Add(new Image<Gray, byte>(IMGSIZE,IMGSIZE));
            propertyGrid1.SelectedObject =imageBoxFrameGrabber;
            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                if (!Directory.Exists(folderRoot + "DB\\FaceDB")){
                    Directory.CreateDirectory(folderRoot + @"DB\FaceDB");
                    Directory.CreateDirectory(folderRoot + @"DB\ImageDB");
                }
                    foreach (String prof in Directory.GetDirectories(folderRoot + @"DB\FaceDB"))
                {
                    labels.Add(new Profile(prof));
                    trainingImages.Add(new Image<Gray, byte>(prof+"\\pro.jpg").Resize(IMGSIZE,IMGSIZE,INTER.CV_INTER_CUBIC));
                }
                labels = labels.OrderBy(f => f.LastFirstName()).ToList();
            }
            catch
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            GetKeys();
            config = new ConfigHelper(folderRoot + "prop.ini");
            prepareETV();
        }
        private void prepareETV() {
            etvDirStruct.Clear();
            foreach (Config c in config.GetConfigGroup("Dir",true).ToArray())
            {
                etvDirStruct.AddNode(c.Setting);
            }
        }
        private Image<Gray,byte> ResizeImage(Image<Gray,byte> input, int maxHeight, int maxWidth)
        {
            int ogWidth = input.Width, ogHeight = input.Height;
            float ratioX = maxWidth / ogWidth, ratioY = maxHeight / ogHeight, ratio = Math.Min(ratioX, ratioY), sourceRatio = ogWidth / ogHeight;
            int w = (int)(ogWidth * ratio), h = (int)(ogHeight * ratio);
            return input.Resize(w, h,INTER.CV_INTER_CUBIC);
        }
        private void btnDetect_Click(object sender, EventArgs e)
        {
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            //System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(this.FrameGrabber));
            //t.Start();
            //Application.Idle += new EventHandler(FrameGrabber);
            //btnDetect.Enabled = false;
        }
       /* private void btnAddFace_Click(object sender, System.EventArgs e)
        {
            try
            {
                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                //labels.Add(txtName.Text);

                //Show face added in gray scale
                imgTrain.Image = TrainedFace;

                //Write the number of triained faces in a file text for further load
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Bitmap.Save(Application.StartupPath + "/TrainedFaces/face" + i + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }

                MessageBox.Show(txtName.Text + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }*/
        private void elvThumb_Open(String filePath)
        {
            Debug.WriteLine("Opening " + filePath);
            FrameGrabber(filePath);
            Debug.WriteLine("Opened " + filePath);
        }


        private void profileManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileManager pMan = new ProfileManager();
            if (pMan.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void etvDirStruct_AfterSelect(object sender, TreeViewEventArgs e)
        {
            elvThumb.Directory = e.Node.Tag.ToString();
            lblDirectory.Text = "Directory: " + elvThumb.Directory.TrimEnd('\\') + ": " + elvThumb.Items.Count + " Images";
    }
        private void directoryManagerToolStripMenuItem_Click(object sender, EventArgs e){
            DirectoryManager dMan = new DirectoryManager(config);
            dMan.ShowDialog();
            if (dMan.DirChange){prepareETV();}                
        }
        void pre(Rectangle rect,String fileName)
        {            
            String loopIndex = "0";

            //draw the face detected in the 0th (gray) channel with blue color
            System.Drawing.Image facePreview = faceFrame.Clone(new Rectangle(rect.X, rect.Y, rect.Width, rect.Height), System.Drawing.Imaging.PixelFormat.DontCare);
            currentFrame.Draw(rect, new Bgr(Color.Red), 2);
            if (!NameIndex.ContainsKey(fileName) || trainingImages.ToArray().Length != 0)
            {
                //TermCriteria for face recognition with numbers of trained images like maxIteration
                MCvTermCriteria termCrit = new MCvTermCriteria(labels.Count + 1, 0.001);

                result = currentFrame.Copy(rect).Convert<Gray, byte>().Resize(IMGSIZE, IMGSIZE, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //Eigen face recognizer
                NewEigenObjectRecognizer recognizer = new NewEigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 850, termCrit);

                name = recognizer.Recognize(result);
            }
            else name = existImg.GetConfig(loopIndex, "n").Setting;
            //Draw the label for each face detected and recognized
            currentFrame.Draw(name, ref font, new Point(rect.X - 2, rect.Y - 2), new Bgr(Color.LightGreen));
            FaceFiller fil = new FaceFiller(facePreview, name, labels,loopIndex, AddKey(fileName, CreateKey(loopIndex, rect.X, rect.Y, rect.Width, rect.Height, name, fileName)));
            fil.DetailUpdate += Fil_DetailUpdate;
            fil.Location = new Point(fil.Location.X, fillerHeight);
            fillerHeight += fil.Height + 5;
            grpResults.Controls.Add(fil);
            loopIndex = (int.Parse(loopIndex) + 1) + "";
        }
        void FrameGrabber(String fileName)
        {
                //foreach (String fileName in System.IO.Directory.GetFiles(@"E:\Public\Pictures\YearBook\2019", "*.jpg")) {
                Console.WriteLine("Inside");
            fillerHeight = 15;
            //lblNumber.Text = "0";
            //label4.Text = "";
            //NamePersons.Add("");
            //Get the current frame form capture device
            MCvAvgComp[][] facesDetected =null;
            currentFrame = new Image<Bgr, byte>(fileName);//grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);//new Image<Bgr, byte>(fileName);//
            faceFrame = new Bitmap(currentFrame.Bitmap);
            if (!NameIndex.ContainsKey(fileName))
            {

                //Convert it to Grayscale
                gray = currentFrame.Convert<Gray, Byte>();
                //Face Detector
                facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(30, 30));
            }
                //Action for each element detected
                grpResults.Controls.Clear();
            if (NameIndex.ContainsKey(fileName))
            {
                existImg = new ConfigHelper(folderRoot + @"DB\ImageDB\" + NameIndex[fileName].ToString("0000000000"), false);
                foreach (ConfigGroup c in existImg.GetAllConfigsGroup()) pre(new Rectangle(c.Item("x").Int, c.Item("y").Int, c.Item("w").Int, c.Item("h").Int),fileName);
            }
            else
            {
                foreach (MCvAvgComp f in facesDetected[0])  pre(f.rect,fileName);
               //NamePersons[t - 1] = name;
                //NamePersons.Add("");


                //Set the number of faces detected on the scene
                //lblNumber.Text = facesDetected[0].Length.ToString();

                /*
                //Set the region of interest on the faces

                gray.ROI = f.rect;
                MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                   eye,
                   1.1,
                   10,
                   Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                   new Size(20, 20));
                gray.ROI = Rectangle.Empty;

                foreach (MCvAvgComp ey in eyesDetected[0])
                {
                    Rectangle eyeRect = ey.rect;
                    eyeRect.Offset(f.rect.X, f.rect.Y);
                    currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                }

*/

                //Bitmap b = (new Bitmap(fileName));
                //foreach (var p in b.PropertyItems) Debug.WriteLine(ReadFunctions.getString(p.Value)+ b.PropertyIdList);
            }
            //Show the faces procesed and recognized
            lblDirectory.Text = ("Directory: " + elvThumb.Directory.TrimEnd('\\') + ": " + elvThumb.Items.Count + " Images").PadRight(130)+ "File: " + Path.GetFileName(fileName);
                    imageBoxFrameGrabber.Image = currentFrame.Bitmap;
                imageBoxFrameGrabber.Invalidate();
            imageBoxFrameGrabber.Focus();
                    //lblNobody.Text = names;
                    //Clear the list(vector) of names
            NamePersons.Clear();
            }

        private void Fil_DetailUpdate(object sender, EventArgs e)
        {
            labels.Add(new Profile( sender.ToString()));
            trainingImages.Add(new Image<Gray, byte>(  sender.ToString() + "\\pro.jpg").Resize(IMGSIZE,IMGSIZE,INTER.CV_INTER_CUBIC));
        }
        private void FaceControlChange(Object sender, EventArgs e)
        {
            lblFaces.Text = "Faces: " + grpResults.Controls.Count + " Found";
        }
        private Dictionary<String, Int64> NameIndex { get; set; } = new Dictionary<string, long>();
        private void GetKeys()
        {
            if (!Directory.Exists(folderRoot + @"DB\ImageDB")) Directory.CreateDirectory(folderRoot + @"DB\ImageDB\");
            if (!File.Exists(folderRoot + @"DB\ImageDB\keys")) File.WriteAllText(folderRoot + @"DB\ImageDB\keys", "");
            String[] map = File.ReadAllLines(folderRoot + @"DB\ImageDB\keys");
            Dictionary<String, Int64> result = new Dictionary<string, long>();
            foreach (String m in map)
            {
                String[] split = m.Split('=');
                NameIndex.Add(split[0], long.Parse(split[1]));
            }
        }
        private Int64 AddKey(String imgPath, Int64 key)
        {
            if (!NameIndex.ContainsKey(imgPath)){
                String build = "";
                NameIndex.Add(imgPath, key);
                String[] paths = NameIndex.Keys.ToArray();
                Int64[] keys = NameIndex.Values.ToArray();
                for (int index = 0; index < keys.Length; index++) {
                    build += paths[index] + '=' + keys[index].ToString("0000000000")+Environment.NewLine;
                }
                File.WriteAllText(folderRoot + @"DB\ImageDB\keys", build);
            }
            return key;
        }
        private Int64 CreateKey(String index,int x,int y,int w,int h,String name,String filename)
        {
            Int64 key = NameIndex.Count + 1;
            if (NameIndex.ContainsKey(filename)) key = NameIndex[filename];
            ConfigHelper keyCreate;
            keyCreate = new ConfigHelper(folderRoot + @"DB\ImageDB\" + key.ToString("0000000000"), false);
            keyCreate.SetConfig(index, "x", x.ToString(), true);
            keyCreate.SetConfig(index, "y", y.ToString(), true);
            keyCreate.SetConfig(index, "w", w.ToString(), true);
            keyCreate.SetConfig(index, "h", h.ToString(), true);
            keyCreate.SetConfig(index, "n", name, true);
            keyCreate.Save();
            return key;
        }
    }
}