using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistens
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public bool IsMarried { get; set; }
        public int NoOfChildren { get; set; }

        public Person(string name, DateTime birthDate, double height, bool isMarried, int noOfChildren)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.Height = height;
            this.IsMarried = isMarried;
            this.NoOfChildren = noOfChildren;
        }
        public string MakeTitle()
        {
            return Name + ";" + BirthDate + ";" + Height + ";" + IsMarried + ";" + NoOfChildren;
        }
    }
}
