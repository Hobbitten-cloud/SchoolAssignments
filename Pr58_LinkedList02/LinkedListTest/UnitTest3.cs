using ADT;

namespace LinkedListTest;

[TestClass]
public class UnitTest3
{
    ClubMember c1, c2, c3;
    ILinkedList list;
    ILinkedList<ClubMember> listGeneric;

    [TestInitialize]
    public void Init()
    {
        list = new LinkedList();
        listGeneric = new ADT.LinkedList<ClubMember>();

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
    }

    [TestMethod]
    public void TestSwap()
    {
        list.Insert(c3);
        list.Insert(c1);
        list.Insert(c2); // c2, c1, c3
        list.Swap(1); // c2, c3, c1
        Assert.AreEqual(3, list.Count);
        Assert.AreEqual("2: Bjørn Borg (Male, 30 years)\n3: Cristian Nielsen (Male, 20 years)\n1: Anders And (Male, 15 years)", list.ToString());

        list.Swap(0); // c3, c2, c1
        Assert.AreEqual("3: Cristian Nielsen (Male, 20 years)\n2: Bjørn Borg (Male, 30 years)\n1: Anders And (Male, 15 years)", list.ToString());
    }

    [TestMethod]
    public void TestSwapGeneric()
    {
        listGeneric.Insert(c3);
        listGeneric.Insert(c1);
        listGeneric.Insert(c2); // c2, c1, c3
        listGeneric.Swap(1); // c2, c3, c1
        Assert.AreEqual(3, listGeneric.Count);
        Assert.AreEqual("2: Bjørn Borg (Male, 30 years)\n3: Cristian Nielsen (Male, 20 years)\n1: Anders And (Male, 15 years)", listGeneric.ToString());

        listGeneric.Swap(0); // c3, c2, c1
        Assert.AreEqual("3: Cristian Nielsen (Male, 20 years)\n2: Bjørn Borg (Male, 30 years)\n1: Anders And (Male, 15 years)", listGeneric.ToString());
    }
}
