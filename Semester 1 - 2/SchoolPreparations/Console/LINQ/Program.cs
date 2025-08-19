namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Makes a region to collapse code
            #region List Data

            // Creates a new list for club member
            List<ClubMember> memberList = new List<ClubMember>();

            // Adds members to the list
            memberList.Add(new ClubMember { Id = 1, FirstName = "Harold", LastName = "Bluetooth", Gender = Gender.Male, Age = 50 });
            memberList.Add(new ClubMember { Id = 2, FirstName = "Getrud", LastName = "Hansen", Gender = Gender.Female, Age = 53 });
            memberList.Add(new ClubMember { Id = 3, FirstName = "Frederikke", LastName = "Nielsen", Gender = Gender.Female, Age = 45 });
            memberList.Add(new ClubMember { Id = 4, FirstName = "Simon", LastName = "Petersen", Gender = Gender.Male, Age = 10 });
            memberList.Add(new ClubMember { Id = 5, FirstName = "Peter", LastName = "Hansen", Gender = Gender.Male, Age = 30 });

            // Ends the region
            #endregion

            // Sort after age from low to high. Line 24, 25 & 26 are the same just shorter than the other
            IEnumerable<ClubMember> list1 = memberList.OrderBy(sortASC => sortASC.Age);
            List<ClubMember> list2 = memberList.OrderBy(sortASC => sortASC.Age).ToList();
            List<ClubMember> list3 = memberList.OrderBy(delegate (ClubMember sortASC) { return sortASC.Age; }).ToList();
            //List<ClubMember> list = memberList.OrderByDescending(sortDESC => sort.Age).ToList();

            // Writes each member from the list to the console
            //foreach (ClubMember cm in list1) // Remember to swap list depending on what search you want to look at.
            //{
            //    Console.WriteLine(cm);
            //}

            // A shorter way to write whats above
            list1.ToList().ForEach(cm => Console.WriteLine(cm));

            // Makes a space to showcase both ways
            Console.WriteLine();
            Console.WriteLine("Space");
            Console.WriteLine();

            // Sort after specific people works kinda like SQL 
            IEnumerable<string> names = memberList.Where(sortAge => sortAge.Age < 50)
                                                      .Where(sortGender => sortGender.Gender == Gender.Female)
                                                      .OrderBy(sortASC => sortASC.Age)
                                                      .Select(select => select.FirstName + " " + select.LastName)
                                                      .OrderBy(sort => sort);

            // Writes the specific name from the statement above
            names.ToList().ForEach(cm => Console.WriteLine(cm));

            // Writes out the average age from the club
            double average = memberList.Average(averageAge => averageAge.Age);
            Console.WriteLine();
            Console.WriteLine("Average age from the club members: " + average);

            // Stops the console window from exiting
            Console.ReadLine();
        }
    }
}
