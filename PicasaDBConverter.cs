using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MultiFaceRec
{
    class PicasaDBConverter
    { 
        /*Converted from https://github.com/skisoo/PicasaDBReader, which was under the MIT License and requires the following:
        Copyright (c) 2013 skisoo http://skisoo.com

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
*/
public static void CheckForPicasaDB()
        {
            String folder = Environment.ExpandEnvironmentVariables("%LOCALAPPDATA%") + @"/Google/Picasa2/db3/";
            if (Directory.Exists((folder)))
            {
                System.Windows.Forms.MessageBox.Show("Exists");
                PicasaFaces faces = new PicasaFaces(folder);
                faces.populate();
                faces.populatePersons();
                faces.gatherImages();
                faces.processImages();
            }
        }
    }
  public  class Face
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public Image img { get; set; }
        public String name { get; set; }
        public Face(int x, int y, int w, int h, String name, Image i)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.name = name;
            this.img = i;
        }

        public new String ToString()
        {
            String s = name + "\nx:" + x + ", y:" + y + ", w:" + w + ", h:" + h;
            //s+= "\nFrom bottom left corner:\nx:"+(x-w/2)+", y:"+(y-h/2)+", w:"+w+", h:"+h;
            return s;
        }
    }
   public class Image
    {
        public String path { get; set; }
        public Boolean hasFaceData { get; set; } = false;
        public Boolean hasChild { get; set; } = false;
        public long index { get; set; }
        public int h { get; set; }
        public int w { get; set; }
        public List<Face> faces { get; set; }
        public Image(String path, long index, int w, int h)
        {
            this.path = path;
            this.index = index;
            this.h = h;
            this.w = w;
            faces = new List<Face>();
        }
        public Face AddFace(String facerect, String person)
        {
            int fx1 = (int)(w * (str4HextoDec(facerect.Substring(0, 4)) / 65535.0F));
            int fy1 = (int)(h * (str4HextoDec(facerect.Substring(4, 4)) / 65535.0F));
            int fx2 = (int)(w * (str4HextoDec(facerect.Substring(8, 4)) / 65535.0F));
            int fy2 = (int)(h * (str4HextoDec(facerect.Substring(12, 4)) / 65535.0F));
            Face f = new Face(fx1, fy1, fx2 - fx1, fy2 - fy1, person, this);
            faces.Add(f);
            return f;
        }
        public long str4HextoDec(String str)
        {
            long ret = long.Parse(str);
            return ret;
        }
        public new String ToString(){
            String s = "\n" + path + "\nw:" + w + ", h:" + h;
            if (faces.Count != 0)
            {
                s += "\nFaces:";
                foreach (Face f in faces)
                {
                    s += "\n" + f.ToString();
                }
            }
            return s;
        }
    }
    public class Indexes
    {
        private const String PARAM_OUTPUT_FOLDER = "outAdd";

        private const String PARAM_PICASA_DB_FOLDER = "folder";

        //will store the name of the folders or the name of the image file (the index in the list will be the correct index of the image file)
        public List<String> names { get; set; } = new List<String>();

        //will store 0xFFFFFFFF for folder, the index of the folder for image files
        public List<long> indexes { get; set; }= new List<long>();
        public List<long> originalIndexes { get; set; }= new List<long>();
        String folder;
        public long folderIndex { get; set; } = (4294967295L);
        public long entries { get; set; }

        public Indexes(String folder)
        {
            this.folder = folder;
        }

        public void Populate() {
            BinaryReader din = new BinaryReader(new FileStream(folder + "thumbindex.db",FileMode.Open));
            long magic = ReadFunctions.readUnsignedInt(din); //file start with a magic sequence
            entries = ReadFunctions.readUnsignedInt(din); // then number of entries

            String path;
            long index;
            long folderIndex = (4294967295L); //0xFFFFFFFF

            for (int i = 0; i < entries; i++)
            {

                path = ReadFunctions.getString(din);  // null terminated string
                ReadFunctions.read26(din);            // followed by 26 garbaged bytes
                index = ReadFunctions.readUnsignedInt(din); // followed by the index (0xFFFFFFFF for folder)


                names.Add(path);
                indexes.Add((long)i);
                originalIndexes.Add(index);
                if (path == (""))
                {   //empty file name (deleted), change index to 0xFFFFFFFF
                    indexes[i] = folderIndex;
                }
            }
            din.Close();
        }
        
}
   public class ReadFunctions
    {
        public  static String dumpStringField(BinaryReader din)
        {
	            return getString(din);
        }

        public  static String dumpByteField(BinaryReader din)
        {
            Int32 i = (din.ReadByte());
	            return i.ToString();
	    }

    public  static String dump2byteField(BinaryReader din)
    {
        Int32 i = (readUnsignedShort(din));
	            return i.ToString();
	    }

public  static String dump4byteField(BinaryReader din)
{
    long i = (readUnsignedInt(din));
	            return i.ToString();
	    }
	 
	    public  static String dump8byteField(BinaryReader din)
{
    String s = "";
int[] bytes = new int[8];
	            for (int i = 0; i<8; i++) {
	                bytes[i] = din.ReadByte();
	            }
	            for (int i = 7; i>=0; i--) {
	                String x = bytes[i].ToString();
	                if (x.Length == 1) {
	                    s+=("0");
	                }
	                s+=(x);
	            }
	        return s;
	    }

        public static String dumpDateField(BinaryReader din) {
            String s = "Date";
        int[] bytes = new int[8];
        long ld = 0;
	            for (int i = 0; i<8; i++) {
	                bytes[i] = din.ReadByte();
	                long tmp = bytes[i];
        tmp <<= (8*i);
	                ld += tmp;
	            }
          //  s += new DateTime((ld - 25569L));// * 86400L * 1000L);

            return s;
	    }

	    public  static String getString(BinaryReader din)
{
    String sb = "";
int c;
	        while((c = din.ReadByte()) != 0) {
	            sb+=((char)c);
	        }
	        return sb;
	    }

	    public  static int readUnsignedShort(BinaryReader din)
{
	        int ch1 = din.ReadByte();
	        int ch2 = din.ReadByte();
	        if ((ch1 | ch2) < 0)
	            throw new Exception();
	        return ((ch2<<8) + ch1<<0);
	    }

	    public  static long readUnsignedInt(BinaryReader din)
{
	        int ch1 = din.ReadByte();
	        int ch2 = din.ReadByte();
	        int ch3 = din.ReadByte();
	        int ch4 = din.ReadByte();
	        if ((ch1 | ch2 | ch3 | ch4) < 0)
	            throw new Exception();

long ret =
    (((long)ch4) << 24) +
    (((long)ch3) << 16) +
    (((long)ch2) << 8) +
    (((long)ch1) << 0);
	        return ret;
	    }
	    
	    public  static void read26(BinaryReader din)
{
            for(int i=0; i<26; i++)
            din.ReadByte();
}
}
    public class PicasaFaces
    {
        PMPDB db;
        Dictionary<String, String> personsId;
        Dictionary<String, List<Face>> personFaces;
        Dictionary<long, Image> images;

        public PicasaFaces(String folder)
        {
            db = new PMPDB(folder);
            personsId = new Dictionary<String, String>();
            personFaces = new Dictionary<String, List<Face>>();
            images = new Dictionary<long, Image>();
        }

        public void populate() {
            db.populate();
        }

        public void populatePersons()
        {
            List<String> tokens = db.albumdata["token"];
            List<String> name = db.albumdata["name"];
            int nb = tokens.Count;
            personsId.Add("0", "nobody");

            for (int i = 0; i < nb; i++)
            {
                String t = tokens[i];
                if (t.StartsWith("]facealbum:"))
                {
                    personsId.Add(t.Split(':')[1], name[i]);
                }
            }
        }
        public void gatherImages()
        {
            long nb = db.indexes.entries;


            for (int i = 0; i < nb; i++)
            {

                if (db.indexes.indexes[i] != (db.indexes.folderIndex))
                { // not a folder
                    String path = db.indexes.names[(int)(db.indexes.indexes[i])]+ db.indexes.names[i];
                    int w = int.Parse(db.imagedata["width"][i]);
                    int h = int.Parse(db.imagedata["height"][i]);
                    Image img = new Image(path, i, w, h);
                    String personName = personsId[db.imagedata["personalbumid"][i]];
                    if (db.imagedata["facerect"][i] != ("0000000000000001"))
                    {
                        img.hasFaceData = true;

                        Face f = img.AddFace(db.imagedata["facerect"][i], personName);
                        if (db.imagedata["personalbumid"][i] != ("0"))
                        {
                            if (!personFaces.ContainsKey(personName))
                            {
                                personFaces.Add(personName, new List<Face>());
                            }

                            personFaces[personName].Add(f);
                        }
                    }
                    images.Add((long)i, img);
                }
                else
                { // folder
                    if (db.indexes.names[i] == ("") && db.indexes.originalIndexes[i] != (db.indexes.folderIndex))
                    { // reference
                        if (i >= db.imagedata["personalbumid"].Count)
                        {
                            break;
                        }
                        String personName = personsId[db.imagedata["personalbumid"][i]];
                        long originalIndex = db.indexes.originalIndexes[i];
                        if (db.imagedata["facerect"][i] != ("0000000000000001"))
                        {
                            images[originalIndex].hasChild = true;
                            Face f = images[originalIndex].AddFace(db.imagedata["facerect"][i], personName);
                            if (db.imagedata["personalbumid"][i] != ("0"))
                            {
                                if (!personFaces.ContainsKey(personName))
                                {
                                    personFaces.Add(personName, new List<Face>());
                                }

                                personFaces[personName].Add(f);
                            }
                        }
                    }// else folder
                }
    }
}

public void processImages(){
            String csv = ("person, file path,image width,image height,face x,face y,face width,face height\n");
		foreach(String person in personFaces.Keys){
			foreach(Face f in personFaces[person]){
				csv+=(person);
				csv+=(",");
				csv+=(f.img.path);
				csv+=(",");
				csv+=(f.img.w);
				csv+=(",");
				csv+=(f.img.h);
				csv+=(",");
				csv+=(f.x);
				csv+=(",");
				csv+=(f.y);
				csv+=(",");
				csv+=(f.w);
				csv+=(",");
				csv+=(f.h);
				csv+=("\n");
			}
		}
    File.WriteAllText("faces.csv", csv);
	}
}
   public class PMPDB{   
    public Dictionary<String, List<String>> catdata  {get;set;}
public   Dictionary<String, List<String>> albumdata{get;set;}
public   Dictionary<String, List<String>> imagedata{get;set;}
    String folder;
    public MultiFaceRec.Indexes indexes { get; set; }

    public PMPDB(String folder)
    {
        this.folder = folder;
        indexes = new MultiFaceRec.Indexes(folder);
    }

    public void populate(){
        indexes.Populate();
        catdata = getTable("catdata");
        albumdata = getTable("albumdata");
        imagedata = getTable("imagedata");
        List<String> img = new List<String>();
		foreach(long l in indexes.indexes){
			img.Add(l.ToString());
		}
List<String> ois = new List<String>();
		foreach(long l in indexes.originalIndexes){
			ois.Add(l.ToString());
		}
		imagedata.Add("index",img);
		imagedata.Add("original index", ois);
		imagedata.Add("name", indexes.names);
		
	}


        private Dictionary<String, List<String>> getTable(String table) {    
    String[] files = Directory.GetFiles(folder, "*.pmp");
            Dictionary<String, List<String>> data = new Dictionary<string, List<string>>();
        
        for(int i = 0; i<files.Length; i++){
                String filename = files[i];
    String fieldname = (new FileInfo(filename).Name).Replace(table + "_", "").Replace(".pmp", "");

    //System.out.print(fieldname+" ");
    data.Add(fieldname, readColumn(filename)); //saving column fieldname
        }
        return data;
    }
	
	private static List<String> readColumn(String file){
    List<String> l = new List<String>();
            BinaryReader din = new BinaryReader(new FileStream(file,FileMode.OpenOrCreate));
long magic = ReadFunctions.readUnsignedInt(din); //file start with a magic sequence
int type = ReadFunctions.readUnsignedShort(din); // then the entries type
         if ((magic=ReadFunctions.readUnsignedShort(din)) != 0x1332) {  //first constant
            throw new Exception("Failed magic2 "+ magic.ToString());
        }
        if ((magic=ReadFunctions.readUnsignedInt(din)) != 0x2) {  //second constant
            throw new Exception("Failed magic3 "+ magic.ToString());
        }
        if ((magic=ReadFunctions.readUnsignedShort(din)) != type) { // type again
            throw new Exception("Failed repeat type "+
                                   magic.ToString());
        }
        if ((magic=ReadFunctions.readUnsignedShort(din)) != 0x1332) {  //third constant
            throw new Exception("Failed magic4 "+ magic.ToString());
        }
        long v = ReadFunctions.readUnsignedInt(din); //number of entries
        
        
        // records.
        for(int i = 0; i<v; i++){
            if (type == 0) {
                l.Add(ReadFunctions.dumpStringField(din));
            }
            else if (type == 0x1) {
                l.Add(ReadFunctions.dump4byteField(din));
            }
            else if (type == 0x2) {
                l.Add(ReadFunctions.dumpDateField(din));
            }
            else if (type == 0x3) {
                l.Add(ReadFunctions.dumpByteField(din));
            }
            else if (type == 0x4) {
                l.Add(ReadFunctions.dump8byteField(din));
            }
            else if (type == 0x5) {
                l.Add(ReadFunctions.dump2byteField(din));
            }
            else if (type == 0x6) {
                l.Add(ReadFunctions.dumpStringField(din));
            }
            else if (type == 0x7) {
                l.Add(ReadFunctions.dump4byteField(din));
            }
            else {
                throw new Exception("Unknown type: "+type.ToString());
            }
        }
        din.Close();
        return l;
    }
	
	public void writeCSVs(String outAdd){
    writeCSV("catdata", catdata, outAdd);
    writeCSV("imagedata", imagedata, outAdd);
    writeCSV("albumdata", albumdata, outAdd);
}

public static void writeCSV(String table, Dictionary<String, List<String>> data, String outAdd){
    	// not all files have the same number of elements, get the maximum size for a table
        int max = 0;
        foreach (String key in data.Keys){
        int size = data[key].Count;
        //Console.WriteLine(key+":"+size);
        if (size > max)
            max = size;
    }

    String s = "";
        
        // column names
        foreach (String key in data.Keys){
                s+=(key);
                s+=(";");
            }
        s+=("\n");
        for(int i = 0; i<max ; i++){
            foreach (String key in data.Keys){
                
                // for column that have less elements that the max, fill the end with %empty%
                if(data[key].Count>i){
                    s+=(data[key][i]);
                }else{
                    s+=("%empty%");
                }
                s+=(";");
            }
            s+=("\n");
        }
    File.WriteAllText(outAdd + table + ".csv", s);
    }
 
}
 
}
