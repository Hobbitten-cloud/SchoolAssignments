using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPersistence.Models
{
    public class Subject
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Level { get; set; }

        // Constructor with no paramenters
        public Subject()
        {

        }

        //Constructor with with paramenters
        public Subject(string name, int level)
        {
            Name = name;
            Level = level;
        }
    }
}
