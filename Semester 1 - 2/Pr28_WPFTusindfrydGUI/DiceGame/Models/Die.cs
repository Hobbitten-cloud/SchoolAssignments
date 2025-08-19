using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Models
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
        public int FaceValue { get; set; }

        public int Id { get; set; }

        public Die(int Id, int faceValue)
        {
            this.Id = Id;
            Status = DiceStatus.NotRolled;
            FaceValue = faceValue;
        }

    }
}
