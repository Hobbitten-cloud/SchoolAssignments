using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPersistence.Models
{
    public class Schedule
    {
        public int? Id { get; set; }
        public DateOnly? Date {  get; set; }
        public Avaliability? Avaliability { get; set; }

        // Constructor with no paramenters
        public Schedule()
        {

        }

        // Constructor with with paramenters
        public Schedule(DateOnly date, Avaliability avaliability)
        {
            Date = date;
            Avaliability = avaliability;
        }
    }
}
