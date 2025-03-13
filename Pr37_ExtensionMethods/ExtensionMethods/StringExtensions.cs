using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        //public static string Shift(this string st, int shift)
        //{

        //    if (shift > 0)
        //    {
        //        st = st.Substring(1, st.Length + 1) + st.Substring(0, 1);
        //    }
        //    else if (shift < 0)
        //    {
        //        st = st.Substring(1, st.Length - 1) + st.Substring(0, 1);
        //    }
        //    else
        //    {
        //        st = "";
        //    }

        //    return st;
        //}

        //public static string Shift(this string st, int shift)
        //{
        //    // Checks if the string is null and if it is it just returns the an empty text string
        //    if (st == null)
        //    {
        //        return "";
        //    }

        //    // the int length gets string length but as a value
        //    int length = st.Length;

        //    //
        //    int absShift = (shift > 0 ? shift : shift * -1) % length;

        //    if (shift < 0)
        //    {
        //        st = st.Substring(absShift, length - absShift) + st.Substring(0, absShift);
        //    }
        //    else
        //    {
        //        st = st.Substring(length - absShift, absShift) + st.Substring(0, length - absShift);
        //    }

        //    return st;
        //}

        public static string Shift(this string st, int shift)
        {
            // Checks if the string is null and if it is it just returns the an empty text string
            if (st == null)
            {
                return "";
            }

            int length = st.Length;

            int absShift = shift;

            if (absShift < 0)
            {
                // If absShift is -4 for example, change it to 4
                absShift = absShift * -1;
            }

            // absShift - pre: absShift: 16, length: 15
            absShift = absShift % length; // læser op på remaineder operatoren
            // absShift - post: absShift: 1

            if (shift < 0)
            {
                string firstPart = st.Substring(absShift, length - absShift);
                string secondPart = st.Substring(0, absShift);

                // Hello,  1 --> oHell
                st = firstPart + secondPart; // This is my life: e, This is my lif: eThis is my Lif
            }
            else
            {
                // Hello, -1 --> elloH
               
                st = st.Substring(length - absShift, absShift) + st.Substring(0, length - absShift);
            }

            return st;
        }
    }
}
