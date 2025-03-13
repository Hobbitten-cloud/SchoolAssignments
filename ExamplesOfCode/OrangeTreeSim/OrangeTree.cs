using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OrangeTreeSim
{
    public class OrangeTree
    {
        private int age;
        private int height;
        private bool treeAlive;
        private int numOranges;
        private int orangesEaten;

        public int Age
        {
            set
            {
                if (value >= 0)
                {
                    this.age = value;
                }
            }
            get
            {
                return age;
            }
        }
        public int Height
        {
            set
            {
                this.height = value;
            }
            get
            {
                return height;
            }
        }
        public bool TreeAlive
        {
            set
            {
                this.treeAlive = value;
            }
            get
            {
                return treeAlive;
            }
        }
        public int NumOranges
        {
            get
            {
                return numOranges;
            }
        }
        public int OrangesEaten
        {
            get
            {
                return orangesEaten;
            }
        }
        public void OneYearPasses()
        {
            Console.WriteLine("Hej");
            age++;

            if (age < 80)
            {
                height = height + 2; //height += 2; (en hurtigere måde at definere udtrykket på)
                treeAlive = true;

                if (age <= 1) //producerer ikke appelsiner
                {
                    numOranges = 0;
                }
                else //producerer appelsiner
                {
                    numOranges = (age - 1) * 5; //minus det 1. år, gange 5 grundet det stiger med 5 i produktion af appelsiner for hvert år det ældes
                    //numOranges += 5; - Det vi havde skrevet. Det foroven er det som Anne fik skrevet
                }
            }
            else
            {
                height = height + 0; //height += 0 (en hurtigere måde at definere udtrykket på)
                treeAlive = false;
                numOranges = 0;
            }
            orangesEaten = 0; //nulstiller spist appelsiner hvert år
        }
        public void EatOrange(int count)
        {
            if (count <= numOranges)
            {
                orangesEaten += count; //øger antallet af allerede spiste appelsiner med dem vi spiser nu. Kan ikke huske hvorfor jeg gjorde det

                numOranges -= count; //reducerer antallet af appelsiner med dem der bliver spist
            }
        }
    }
}


