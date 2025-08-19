using System;
using System.Collections.Generic;
using System.Text;

namespace WPFAndMVVM2.Models
{
    public class Person
    {
        // idCount maintains a counter assigned as Id to each new Person-object and 
        // then incremented so that each Person-object has a unique Id number
        private static int idCount = 0;

        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public Person()
        {

            Id = idCount++;
        }

        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName}: {Age} years; T: {Phone}";
        }
    }
}
