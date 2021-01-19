using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ClassLibrary
{

    

    public static class LibraryReader
    {

        

        public static Library.library ReadLibrary(string path= @"../../../../Library.xml")
        {

            FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer xmlser = new XmlSerializer(typeof(Library.library));
            Library.library loadedlib = (Library.library)xmlser.Deserialize(fs);
            fs.Close();

            return loadedlib;
        }

        public static void Main()
        {
         
        }
    }
}
