using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hjemmeprojekt_Terninger.Model
{
    public enum DiceStatus
    {
        NotRolled,
        Rolled,
        Selected,
        Used
    }
    public class Die
    {
        public DiceStatus Status { get; set; }
        public int Id { get; set; }
        public int FaceValue { get; set; }
        public Die(int Id, int faceValue)
        {
            this.Id = Id;
            Status = DiceStatus.NotRolled;
            FaceValue = faceValue;
        }

       
        // faceValue (1, 2, 3, 4, 5, 6)
        // id (DiceId1, DiceId2, DiceId3, DiceId4, DiceId5, DiceId6)

    }
}
