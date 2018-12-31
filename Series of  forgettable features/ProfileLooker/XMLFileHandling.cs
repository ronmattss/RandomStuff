using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ProfileLooker
{
     public class XMLFileHandling
    {
        // Static class to handle XML I/O inside a console
        public static Profile CreateProfile()
        {
            string name;
            int age;
            int year;
            Console.WriteLine("Enter name");
            name = Console.ReadLine();
            Console.WriteLine("Enter age");
            age = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter Birth Year");
            year = Convert.ToInt16(Console.ReadLine());
            Profile basicProfile = new Profile(name, age, year);

            return basicProfile;
        }
        public static void ShowInfo(Profile information)
        {
            // Clear the screen then Show these information
            Console.Clear();
            Console.WriteLine("Your Basic Information:");
            Console.WriteLine("Name: {0} ", information.name);
            Console.WriteLine("Age: {0} ", information.age);
            Console.WriteLine("Birth Year: {0}", information.yearOfBirth);
        }
        public static void SaveToXML(Profile profile)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Profile));
            var path = @"C:\Users\Shade\Tutorial\" + profile.name + ".xml";
            FileStream file = File.Create(path);
            writer.Serialize(file, profile);
            file.Close();
        }
        public static Profile LoadXMLProfile(string profileName)
        {
            Profile loadedProfile;
            XmlSerializer reader = new XmlSerializer(typeof(Profile));
            string path;
            StreamReader file;
            string Name = profileName;
        TRYAGAIN:
            try
            {
                path = @"C:\Users\Shade\Tutorial\" + Name + ".xml";
                file = new StreamReader(path);
            }
            catch (FileNotFoundException e)
            {

                Console.WriteLine("Could not find the file {0}!", Name + ".xml");
                Console.WriteLine("Type the profile name again: ");
                Name = Console.ReadLine();
                goto TRYAGAIN;


            }
            finally
            {


            }
            //file = new StreamReader(path);
            loadedProfile = (Profile)reader.Deserialize(file);
            file.Close();
            return loadedProfile;


        }

        public static string[] SearchXMLProfile()
        {
            string[] files =Directory.GetFiles( @"C:\Users\Shade\Tutorial\");
            for(int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileNameWithoutExtension(files[i]); 
            }

            return files;

        }
        public static string[] SearchXMLProfile(string path)
        {
            string[] files = Directory.GetFiles(@path);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileNameWithoutExtension(files[i]);
            }

            return files;

        }
    }
}
