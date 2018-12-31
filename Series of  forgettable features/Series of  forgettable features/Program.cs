using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seriesofforgettablefeatures
{
   public class XMMLWriteTutorial
    {
        static void Main(string[] args)
        {
            WriteXML();
            ReadXML();
            Console.ReadKey();
        }

        public class Book
        {
            public String title;
            public String author;
        }

        public static void WriteXML()
        {
            Book overview = new Book();


            overview.title = "Serialize Tutorial";
            overview.author = "Shade";
            System.Xml.Serialization.XmlSerializer writer = 
        new System.Xml.Serialization.XmlSerializer(typeof(Book));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "Serialiation Wriritng to XML File.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, overview);
            file.Close();
        }

        public static void ReadXML()
        {
            //instantiate xmlSerializzer
            System.Xml.Serialization.XmlSerializer reader =   
        new System.Xml.Serialization.XmlSerializer(typeof(Book));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "Serialiation Wriritng to XML File.xml";
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            Book overview = (Book)reader.Deserialize(file);
            file.Close();

            Console.WriteLine("Book title: " + overview.title + " Book Author: "+ overview.author);
        }
    }
}
