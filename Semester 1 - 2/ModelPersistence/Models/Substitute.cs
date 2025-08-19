using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPersistence.Models
{
    public class Substitute
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Region { get; set; }
        public string? Phone { get; set; }
        public string? PersonNumber { get; set; }
        public bool? Verified { get; set; }

        // Constructor with no paramenters
        public Substitute()
        {

        }

        // Constructor with with paramenters
        public Substitute(string name, string email, string region, string phone, string personNumber, bool verified)
        {
            Name = name;
            Email = email;
            Region = region;
            Phone = phone;
            PersonNumber = personNumber;
            Verified = verified;
        }
    }
}
