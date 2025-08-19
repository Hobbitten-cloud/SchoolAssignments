namespace TotallySafeLib
{
    public class TotallySafe
    {
        public static double Divider(int number)
        {
            return 7 / number;
        }

        public static int StringToInt(string stringToConvert)
        {
            return int.Parse(stringToConvert);
        }

        public static int GetValueAtPosition(int positionInArray)
        {
            int[] intArray = { 1, 2, 3, 4, 5 };

            if (positionInArray < 0)
            {
                throw new NegativeIndexOutOfRangeException("Der kan ikke være negative tal i indexet"); // Vi kaster vores egen exception
            }
            else if (positionInArray > intArray.Length)
            {
                throw new NegativeIndexOutOfRangeException("Der kan ikke være nogle index tal som er større end vores array"); // Vi kaster vores egen exception
            }

            return intArray[positionInArray];
        }
    }
}
