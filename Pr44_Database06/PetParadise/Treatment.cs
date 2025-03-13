using System;
using System.Collections.Generic;
using System.Text;

namespace PetParadise
{
    public class Treatment
    {
        public int TreatmentId { get; set; }
        public string Service { get; set; }
        public DateOnly? Date { get; set; }
        public double Charge { get; set; }

        public Treatment(int treatmentId)
        {
            TreatmentId = treatmentId;
        }

        public override string ToString()
        {
            return $"{TreatmentId}: {Service} on {Date?.ToString("dd-MM-yyyy")} 00:00:00 costs {Charge}";
        }

    }
}
