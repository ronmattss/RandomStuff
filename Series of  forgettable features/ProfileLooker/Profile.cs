using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileLooker
{
    //this class is for handling basic information
   public class Profile
    {
        public string name;
        public int age;
        public int yearOfBirth;

        public Profile(string Name,int Age,int BirthYear )
        {
            name = Name;
            age = Age;
            yearOfBirth = BirthYear;         

        }
        public Profile()
        {

        }
    }
}
