using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ProfileLooker
{
    class Program
    {
        static void Main(string[] args)
        {
        // Create a profile
        // load a profile
        // search a profile
        // save to database?
        // CONVERT TO FORMS!!!
        START:
            Console.WriteLine("Press the corresponding numbers to select \n1. Create a profile \n2. Load a profile\n3. Find the profile you want to load");
            Profile displayProfile;
            switch(Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    displayProfile = XMLFileHandling.CreateProfile();
                    XMLFileHandling.SaveToXML(displayProfile);
                    XMLFileHandling.ShowInfo(displayProfile);        
                    break;

                case ConsoleKey.D2:
                    Console.WriteLine("Type the profile name: ");
                    string Name = Console.ReadLine();
                    XMLFileHandling.ShowInfo(XMLFileHandling.LoadXMLProfile(Name));                                    
                    break;

                case ConsoleKey.D3:
                    Console.WriteLine("Find the profile you want to load: ");
                    string[] profHolder = XMLFileHandling.SearchXMLProfile();                    
                    foreach(string profile in profHolder)
                    {
                        Console.WriteLine(profile);
                    }
                    break;

                default:
                    Console.WriteLine("Wrong Key");
                    Console.Clear();
                    goto START;
            }

            


            Console.ReadKey();            
        }


      


       
    }
}
