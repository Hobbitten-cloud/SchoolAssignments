namespace Statements_for_choices_loop
{
    internal class Statements_for_choices_loop
    {
        static void Main(string[] args)
        {
            // Declaring variables
            string message;
            bool exit = false;

            // Makes the giveaway choices to be a loop. So if the user mess up with the choices given it will rerun the loop
            while (exit == false)   
            {
                // Sets up the base questions in the giveaway
                Console.WriteLine("Bobs Giveaway");
                Console.WriteLine("Choose a door number 1, 2 or 3: ");
                Console.Write("Insert text here: ");

                // Creates a new variable to handle what if it chooses. Because of "scope"
                // If none of the values are detected the code reruns it iself because of the exit being false. When it returns true it ends the loop.
                string userValue = Console.ReadLine();
                if (userValue == "1")
                {
                    message = "You just won a nice trip to America";
                    exit = true;
                }
                else if (userValue == "2")
                {
                    message = "You just won a car in the giveaway";
                    exit = true;
                }
                else if (userValue == "3")
                {
                    message = "You just won a new boat for you to use";
                    exit = true;
                }
                else
                {
                    message = ("You did not enter any of the given numbers. Please retry");
                }
                // Handles the else message incase someone does mess up in the choices they were given
                Console.WriteLine(message);
            }

            // Makes a final message to the user if they completed the loop and won the giveaway
            Console.WriteLine();
            Console.WriteLine("The giveaway gift will be sent your way. Thanks for entering it!");

            // Stops the code from exiting too fast
            Console.ReadLine();
        }
    }
}


