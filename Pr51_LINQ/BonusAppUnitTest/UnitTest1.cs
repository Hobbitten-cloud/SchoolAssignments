using BonusApp;

namespace BonusAppUnitTest
{

    [TestClass]
    public class UnitTest1
    {
        Order order;

        [TestInitialize]
        public void InitializeTest()
        {
            order = new Order();
            order.AddProduct(new Product
            {
                Name = "Mælk",
                Value = 10.0,
                AvailableFrom = new DateTime(2018, 3, 1),
                AvailableTo = new DateTime(2018, 3, 5)
            });
            order.AddProduct(new Product
            {
                Name = "Smør",
                Value = 15.0,
                AvailableFrom = new DateTime(2018, 3, 3),
                AvailableTo = new DateTime(2018, 3, 4)
            });
            order.AddProduct(new Product
            {
                Name = "Pålæg",
                Value = 20.0,
                AvailableFrom = new DateTime(2018, 3, 4),
                AvailableTo = new DateTime(2018, 3, 7)
            });
        }

        [TestMethod]
        public void TenPercent_Test()
        {
            Assert.AreEqual(4.5, Bonuses.TenPercent(45.0));
            Assert.AreEqual(40.0, Bonuses.TenPercent(400.0));
        }

        [TestMethod]
        public void FlatTwoIfAMountMoreThanFive_Test()
        {
            Assert.AreEqual(2.0, Bonuses.FlatTwoIfAmountMoreThanFive(10.0));
            Assert.AreEqual(0.0, Bonuses.FlatTwoIfAmountMoreThanFive(4.0));
        }

        [TestMethod]
        public void GetValueOfProducts_Test()
        {
            Assert.AreEqual(45.0, order.GetValueOfProducts());
        }

        [TestMethod]
        public void GetBonus_Test()
        {
            order.Bonus = Bonuses.TenPercent;
            Assert.AreEqual(4.5, order.GetBonus());

            order.Bonus = Bonuses.FlatTwoIfAmountMoreThanFive;
            Assert.AreEqual(2.0, order.GetBonus());
        }

        [TestMethod]
        public void GetTotalPrice_Test()
        {
            order.Bonus = Bonuses.TenPercent;
            Assert.AreEqual(40.5, order.GetTotalPrice());

            order.Bonus = Bonuses.FlatTwoIfAmountMoreThanFive;
            Assert.AreEqual(43.0, order.GetTotalPrice());
        }

        [TestMethod]
        public void GetValueOfProductsByDate_Test()
        {
            Assert.AreEqual(0.0, order.GetValueOfProducts(new DateTime(2018, 2, 28)));
            Assert.AreEqual(10.0, order.GetValueOfProducts(new DateTime(2018, 3, 2)));
            Assert.AreEqual(25.0, order.GetValueOfProducts(new DateTime(2018, 3, 3)));
            Assert.AreEqual(45.0, order.GetValueOfProducts(new DateTime(2018, 3, 4)));
        }

        [TestMethod]
        public void GetTotalPriceByDate_Test()
        {
            Assert.AreEqual(0.0, order.GetTotalPrice(new DateTime(2018, 2, 28), bonusValue => bonusValue * 0.20));
            Assert.AreEqual(8.0, order.GetTotalPrice(new DateTime(2018, 3, 2), bonusValue => bonusValue * 0.20));
            Assert.AreEqual(20.0, order.GetTotalPrice(new DateTime(2018, 3, 3), bonusValue => bonusValue * 0.20));
            Assert.AreEqual(36.0, order.GetTotalPrice(new DateTime(2018, 3, 4), bonusValue => bonusValue * 0.20));
        }

        [TestMethod]
        public void SortProductOrderBy_Test()
        {
            // Arrange
            var order = new Order();
            order.AddProduct(new Product { Name = "Banana", Value = 20, AvailableFrom = new DateTime(2025, 3, 1), AvailableTo = new DateTime(2025, 3, 10) });
            order.AddProduct(new Product { Name = "Apple", Value = 10, AvailableFrom = new DateTime(2025, 3, 2), AvailableTo = new DateTime(2025, 3, 11) });
            order.AddProduct(new Product { Name = "Orange", Value = 15, AvailableFrom = new DateTime(2025, 3, 3), AvailableTo = new DateTime(2025, 3, 12) });

            // Act + Assert – sorter efter navn
            var sortedByName = order.SortProductOrderBy(x => x.Name);
            Assert.AreEqual("Apple", sortedByName[0].Name);
            Assert.AreEqual("Banana", sortedByName[1].Name);
            Assert.AreEqual("Orange", sortedByName[2].Name);

            // Act + Assert – sorter efter værdi
            var sortedByValue = order.SortProductOrderBy(x => x.Value);
            Assert.AreEqual(10, sortedByValue[0].Value);
            Assert.AreEqual(15, sortedByValue[1].Value);
            Assert.AreEqual(20, sortedByValue[2].Value);

            // Act + Assert – sorter efter AvailableFrom
            var sortedByAvailableFrom = order.SortProductOrderBy(x => x.AvailableFrom);
            Assert.AreEqual(new DateTime(2025, 3, 1), sortedByAvailableFrom[0].AvailableFrom);
            Assert.AreEqual(new DateTime(2025, 3, 2), sortedByAvailableFrom[1].AvailableFrom);
            Assert.AreEqual(new DateTime(2025, 3, 3), sortedByAvailableFrom[2].AvailableFrom);

            // Act + Assert – sorter efter AvailableTo
            var sortedByAvailableTo = order.SortProductOrderBy(x => x.AvailableTo);
            Assert.AreEqual(new DateTime(2025, 3, 10), sortedByAvailableTo[0].AvailableTo);
            Assert.AreEqual(new DateTime(2025, 3, 11), sortedByAvailableTo[1].AvailableTo);
            Assert.AreEqual(new DateTime(2025, 3, 12), sortedByAvailableTo[2].AvailableTo);
        }

    }
}