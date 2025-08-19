using ADT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LinkedListTest
{
    [TestClass]
    public class UnitTest2
    {
        // Instantiating 25 test persons
        ClubMember p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13,
                   p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25;

        [TestInitialize]
        public void Initialize()
        {
            p1 = new ClubMember { Id = 1, FirstName = "Farrand", LastName = "Semkins", Gender = Gender.Female, Age = 77 };
            p2 = new ClubMember { Id = 2, FirstName = "Trev", LastName = "Quail", Gender = Gender.Male, Age = 84 };
            p3 = new ClubMember { Id = 3, FirstName = "Dani", LastName = "Ballister", Gender = Gender.Female, Age = 76 };
            p4 = new ClubMember { Id = 4, FirstName = "Hyacinthie", LastName = "Mish", Gender = Gender.Female, Age = 70 };
            p5 = new ClubMember { Id = 5, FirstName = "Jarib", LastName = "Boustred", Gender = Gender.Male, Age = 32 };
            p6 = new ClubMember { Id = 6, FirstName = "Erl", LastName = "Meeson", Gender = Gender.Male, Age = 62 };
            p7 = new ClubMember { Id = 7, FirstName = "Aile", LastName = "Highman", Gender = Gender.Female, Age = 79 };
            p8 = new ClubMember { Id = 8, FirstName = "Rheta", LastName = "Battelle", Gender = Gender.Female, Age = 42 };
            p9 = new ClubMember { Id = 9, FirstName = "Olimpia", LastName = "Foulsham", Gender = Gender.Female, Age = 60 };
            p10 = new ClubMember { Id = 10, FirstName = "Dagny", LastName = "Ilchenko", Gender = Gender.Male, Age = 34 };
            p11 = new ClubMember { Id = 11, FirstName = "Davis", LastName = "Gilbride", Gender = Gender.Male, Age = 46 };
            p12 = new ClubMember { Id = 12, FirstName = "Kamillah", LastName = "Bahls", Gender = Gender.Female, Age = 24 };
            p13 = new ClubMember { Id = 13, FirstName = "Flore", LastName = "Ansley", Gender = Gender.Female, Age = 89 };
            p14 = new ClubMember { Id = 14, FirstName = "Glad", LastName = "Clowser", Gender = Gender.Female, Age = 48 };
            p15 = new ClubMember { Id = 15, FirstName = "Christian", LastName = "Congram", Gender = Gender.Female, Age = 33 };
            p16 = new ClubMember { Id = 16, FirstName = "Tore", LastName = "Saggs", Gender = Gender.Male, Age = 28 };
            p17 = new ClubMember { Id = 17, FirstName = "Vevay", LastName = "Klezmski", Gender = Gender.Female, Age = 43 };
            p18 = new ClubMember { Id = 18, FirstName = "Bren", LastName = "Merrikin", Gender = Gender.Female, Age = 46 };
            p19 = new ClubMember { Id = 19, FirstName = "Benoit", LastName = "Filler", Gender = Gender.Male, Age = 16 };
            p20 = new ClubMember { Id = 20, FirstName = "Lucien", LastName = "Bottrell", Gender = Gender.Male, Age = 41 };
            p21 = new ClubMember { Id = 21, FirstName = "Emmy", LastName = "Pechell", Gender = Gender.Male, Age = 61 };
            p22 = new ClubMember { Id = 22, FirstName = "Merle", LastName = "Bennet", Gender = Gender.Female, Age = 42 };
            p23 = new ClubMember { Id = 23, FirstName = "Solomon", LastName = "Sarrell", Gender = Gender.Male, Age = 61 };
            p24 = new ClubMember { Id = 24, FirstName = "Shurlock", LastName = "Shreenan", Gender = Gender.Male, Age = 84 };
            p25 = new ClubMember { Id = 25, FirstName = "Chadd", LastName = "Hanney", Gender = Gender.Male, Age = 80 };
        }

        [TestMethod]
        public void TestGenericEmptyLinkedList()
        {
            ILinkedList<ClubMember> list = new ADT.LinkedList<ClubMember>();

            Assert.AreEqual(null, list.First);
            Assert.AreEqual(null, list.Last);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void TestGenericAppend()
        {
            ILinkedList<ClubMember> list = new ADT.LinkedList<ClubMember>();
            list.Append(p1);  // p1
            list.Append(p7);  // p1,p7
            list.Append(p13); // p1,p7,p13

            Assert.AreEqual(p1, list.First);
            Assert.AreEqual(p13, list.Last);
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual(p1, list.ItemAt(0));
            Assert.AreEqual(p7, list.ItemAt(1));
            Assert.AreEqual(p13, list.ItemAt(2));
        }

        [TestMethod]
        public void TestGenericInsert()
        {
            ILinkedList<ClubMember> list = new ADT.LinkedList<ClubMember>();
            list.Insert(p5);  // p5
            list.Insert(p21); // p21,p5
            list.Insert(p9);  // p9,p21,p5
            list.Insert(p24); // p24,p9,p21,p5

            Assert.AreEqual(p24, list.First);
            Assert.AreEqual(p5, list.Last);
            Assert.AreEqual(4, list.Count);

            Assert.AreEqual(p24, list.ItemAt(0));
            Assert.AreEqual(p9, list.ItemAt(1));
            Assert.AreEqual(p21, list.ItemAt(2));
            Assert.AreEqual(p5, list.ItemAt(3));
        }

        [TestMethod]
        public void TestGenericMixedInserts()
        {
            ILinkedList<ClubMember> list = new ADT.LinkedList<ClubMember>();
            list.Insert(p3);    // p3
            list.Append(p22);   // p3,p22
            list.Insert(p9);    // p9,p3,p22
            list.Insert(p1);    // p1,p9,p3,p22
            list.Append(p24);   // p1,p9,p3,p22,p24
            list.Insert(p5);    // p5,p1,p9,p3,p22,p24
            list.Append(p16);   // p5,p1,p9,p3,p22,p24,p16

            Assert.AreEqual(p5, list.First);
            Assert.AreEqual(p16, list.Last);
            Assert.AreEqual(7, list.Count);

            Assert.AreEqual(p5, list.ItemAt(0));
            Assert.AreEqual(p1, list.ItemAt(1));
            Assert.AreEqual(p9, list.ItemAt(2));
            Assert.AreEqual(p3, list.ItemAt(3));
            Assert.AreEqual(p22, list.ItemAt(4));
            Assert.AreEqual(p24, list.ItemAt(5));
            Assert.AreEqual(p16, list.ItemAt(6));
        }

        [TestMethod]
        public void TestGenericRemoves()
        {
            ILinkedList<ClubMember> list = new ADT.LinkedList<ClubMember>();
            list.Insert(p5);    // p5
            list.Insert(p21);   // p21,p5
            list.Insert(p9);    // p9,p21,p5
            list.Insert(p24);   // p24,p9,p21,p5
            list.DeleteAt(2);   // p24,p9,p5

            Assert.AreEqual(p24, list.First);
            Assert.AreEqual(p5, list.Last);
            Assert.AreEqual(3, list.Count);

            Assert.AreEqual(p24, list.ItemAt(0));
            Assert.AreEqual(p9, list.ItemAt(1));
            Assert.AreEqual(p5, list.ItemAt(2));
        }

        [TestMethod]
        public void TestGenericMixedInsertsAndRemoves()
        {
            ILinkedList<ClubMember> list = new ADT.LinkedList<ClubMember>();
            list.Insert(p3);    // p3
            list.Append(p22);   // p3,p22
            list.Insert(p9);    // p9,p3,p22
            list.DeleteAt(0);   // p3,p22
            list.Insert(p1);    // p1,p3,p22
            list.Append(p24);   // p1,p3,p22,p24
            list.Insert(p5);    // p5,p1,p3,p22,p24
            list.DeleteAt(4);   // p5,p1,p3,p22
            list.Append(p16);   // p5,p1,p3,p22,p16
            list.DeleteAt(2);   // p5,p1,p22,p16

            Assert.AreEqual(p5, list.First);
            Assert.AreEqual(p16, list.Last);
            Assert.AreEqual(4, list.Count);

            Assert.AreEqual(p5, list.ItemAt(0));
            Assert.AreEqual(p1, list.ItemAt(1));
            Assert.AreEqual(p22, list.ItemAt(2));
            Assert.AreEqual(p16, list.ItemAt(3));
            Assert.AreEqual("5: Jarib Boustred (Male, 32 years)\n1: Farrand Semkins (Female, 77 years)\n22: Merle Bennet (Female, 42 years)\n16: Tore Saggs (Male, 28 years)", list.ToString());
        }

        //[TestMethod]
        //public void TestGenericMixedElementTypes()
        //{
        //    ILinkedList<ClubMember> list = new ADT.LinkedList<ClubMember>();
        //    list.Append(3);
        //    list.Append("Hello World");
        //    list.Append(p5);
        //    list.Append(0.256);

        //    Assert.AreEqual(3, list.First);
        //    Assert.AreEqual(0.256, list.Last);
        //    Assert.AreEqual(4, list.Count);

        //    Assert.AreEqual(3, list.ItemAt(0));
        //    Assert.AreEqual("Hello World", list.ItemAt(1));
        //    Assert.AreEqual(p5, list.ItemAt(2));
        //    Assert.AreEqual(0.256, list.ItemAt(3));
        //}

        [TestMethod]
        public void TestGenericListOnInt()
        {
            // ** int list test *********
            ILinkedList<int> listInt = new ADT.LinkedList<int>();

            // Insert ints and test
            listInt.Append(105);
            listInt.Append(45);
            listInt.Append(11);
            listInt.Append(3);

            Assert.AreEqual(105, listInt.First);
            Assert.AreEqual(3, listInt.Last);
            Assert.AreEqual(4, listInt.Count);
            Assert.AreEqual(105, listInt.ItemAt(0));
            Assert.AreEqual(45, listInt.ItemAt(1));
            Assert.AreEqual(11, listInt.ItemAt(2));
            Assert.AreEqual(3, listInt.ItemAt(3));
        }

        [TestMethod]
        public void TestGenericListOnString()
        {
            // ** string list test **********
            ILinkedList<string> listString = new ADT.LinkedList<string>();

            // Insert strings and test
            listString.Append("Hello World!");
            listString.Append("This is a ");
            listString.Append("test of ");
            listString.Append("LinkedList<string>");

            Assert.AreEqual("Hello World!", listString.First);
            Assert.AreEqual("LinkedList<string>", listString.Last);
            Assert.AreEqual(4, listString.Count);
            Assert.AreEqual("Hello World!", listString.ItemAt(0));
            Assert.AreEqual("This is a ", listString.ItemAt(1));
            Assert.AreEqual("test of ", listString.ItemAt(2));
            Assert.AreEqual("LinkedList<string>", listString.ItemAt(3));
        }

        [TestMethod]
        public void TestGenericListOnDecimal()
        {
            // ** decimal list test ***********
            ILinkedList<decimal> listDecimal = new ADT.LinkedList<decimal>();

            // Insert decimals and test
            listDecimal.Append(3.1415m); // Pi
            listDecimal.Append(1.4142m); // square root of 2
            listDecimal.Append(2.7182m); // e (Euler)
            listDecimal.Append(1.6180m); // Golden ratio

            Assert.AreEqual(3.1415m, listDecimal.First);
            Assert.AreEqual(1.6180m, listDecimal.Last);
            Assert.AreEqual(4, listDecimal.Count);
            Assert.AreEqual(3.1415m, listDecimal.ItemAt(0));
            Assert.AreEqual(1.4142m, listDecimal.ItemAt(1));
            Assert.AreEqual(2.7182m, listDecimal.ItemAt(2));
            Assert.AreEqual(1.6180m, listDecimal.ItemAt(3));
        }
    }
}