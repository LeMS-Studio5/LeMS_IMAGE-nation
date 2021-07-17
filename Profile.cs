using libProChic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiFaceRec
{
    public class Profile
    {
        private ConfigHelper prof;
        public Profile()
        {

        }

        public Profile(String fileName)
        {
            prof = new ConfigHelper(fileName);
        }
        public String FirstLastName()
        {
            return prof.GetConfig("Main", "FN").Setting + " " + prof.GetConfig("Main", "LN").Setting;
        }
    }
}
