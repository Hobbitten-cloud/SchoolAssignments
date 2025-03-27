using System.Collections.Generic;
using System.Reflection;
using ADT;

namespace LinkedListTest
{
    [TestClass]
    public class UnitTest1
    {
        ClubMember c1, c2, c3, c4, c5;
        ILinkedList list;

        [TestInitialize]
        public void Init()
        {
            list = new LinkedList();

            c1 = new ClubMember
            {
                Id = 1,
                FirstName = "Anders",
                LastName = "And",
                Gender = Gender.Male,
                Age = 15
            };
            c2 = new ClubMember
            {
                Id = 2,
                FirstName = "Bjørn",
                LastName = "Borg",
                Gender = Gender.Male,
                Age = 30
            };
            c3 = new ClubMember
            {
                Id = 3,
                FirstName = "Cristian",
                LastName = "Nielsen",
                Gender = Gender.Male,
                Age = 20
            };
            c4 = new ClubMember
            {
                Id = 4,
                FirstName = "Kurt",
                LastName = "Nielsen",
                Gender = Gender.Male,
                Age = 33
            };
            c5 = new ClubMember
            {
                Id = 5,
                FirstName = "Lis",
                LastName = "Sørensen",
                Gender = Gender.Female,
                Age = 18
            };
        }

        [TestMethod]
        public void TestClubMember()
        {
            Assert.AreEqual("1: Anders And (Male, 15 years)", c1.ToString());
        }

        [TestMethod]
        public void TestInsertOne()
        {
            Assert.AreEqual(0, list.Count);
            list.InsertAt(0, c1);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("1: Anders And (Male, 15 years)", list.ToString());
        }

        [TestMethod]
        public void TestInsertTwo()
        {
            list.InsertAt(0, c1);
            list.InsertAt(0, c2);
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("2: Bjørn Borg (Male, 30 years)\n1: Anders And (Male, 15 years)", list.ToString());
        }

        [TestMethod]
        public void TestDeleteAt1()
        {
            list.InsertAt(0, c1);
            list.InsertAt(0, c2);
            list.DeleteAt(0);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("1: Anders And (Male, 15 years)", list.ToString());
        }

        [TestMethod]
        public void TestDeleteAt2()
        {
            list.InsertAt(0, c1);
            list.InsertAt(0, c2);
            list.InsertAt(1, c3);
            list.InsertAt(0, c4);
            list.InsertAt(4, c5);
            list.DeleteAt(3);
            list.DeleteAt(3);
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("4: Kurt Nielsen (Male, 33 years)\n2: Bjørn Borg (Male, 30 years)\n3: Cristian Nielsen (Male, 20 years)", list.ToString());
        }

        [TestMethod]
        public void TestItemAt()
        {
            list.InsertAt(0, c1);
            list.InsertAt(0, c2);
            Assert.AreEqual(c2, list.ItemAt(0));
            Assert.AreEqual(c1, list.ItemAt(1));
            Assert.AreEqual("2: Bjørn Borg (Male, 30 years)\n1: Anders And (Male, 15 years)", list.ToString());
        }

        [TestMethod]
        public void TestInsertAt()
        {
            list.InsertAt(0, c1);
            list.InsertAt(0, c2);
            list.InsertAt(1, c3);
            list.InsertAt(0, c4);
            list.InsertAt(4, c5);
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual("4: Kurt Nielsen (Male, 33 years)\n2: Bjørn Borg (Male, 30 years)\n3: Cristian Nielsen (Male, 20 years)\n1: Anders And (Male, 15 years)\n5: Lis Sørensen (Female, 18 years)", list.ToString());
        }

        [TestMethod]
        public void TestMixedElementTypes()
        {
            Assert.AreEqual(null, list.First);
            Assert.AreEqual(null, list.Last);
            Assert.AreEqual(0, list.Count);

            list.Append(3);
            list.Append("Hello World");
            list.Append(c5);
            list.Append(0.256);

            Assert.AreEqual(3, list.First);
            Assert.AreEqual(0.256, list.Last);
            Assert.AreEqual(4, list.Count);

            Assert.AreEqual(3, list.ItemAt(0));
            Assert.AreEqual("Hello World", list.ItemAt(1));
            Assert.AreEqual(c5, list.ItemAt(2));
            Assert.AreEqual(0.256, list.ItemAt(3));
        }
    }

}