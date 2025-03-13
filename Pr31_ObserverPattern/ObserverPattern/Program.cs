namespace ObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Academy p = new Academy("UCL", "Seebladsgade");


            Student s1 = new Student("Jens");
            Student s2 = new Student("Niels");
            Student s3 = new Student("Susan");

            // Bliver ikke kørt
            p.PropertyChanged += s1.Update;
            p.PropertyChanged += s2.Update;

            // Chainingen bliver clearet med null og kun s3 bliver lavet. Men hvis null beskeden udkommenteres bliver alle 3 lavet
            // p.MessageChanged = null;

            // Bliver kørt
            p.PropertyChanged += s3.Update;


            p.Message = "Så er der julefrokost!";

            // Niels Fredagsbar bliver fjernet
            p.PropertyChanged -= s2.Update;


            p.Message = "Så er der fredagsbar!";


            Console.ReadLine();
        }
    }
}
