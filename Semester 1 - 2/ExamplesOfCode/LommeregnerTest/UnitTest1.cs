using Lommeregner

namespace LommeregnerTest
{

    [TestClass]
    public class UnitTest1
    {
        Calculator calc = new Calculator();
        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(3, calc.Add(1, 2));
        }

        [TestMethod]
        public void TestSubtract()
        {
            Assert.AreEqual(6, calc.Subtract(8, 2));
        }

        [TestMethod]
        public void TestDivide1()
        {
            Assert.AreEqual(4, calc.Divide(8, 2));
        }

        [TestMethod]
        public void TestDivide2()
        {
            Assert.AreEqual(2.67, Math.Round(calc.Divide(8, 3), 2));
        }

        [TestMethod]
        public void TestMultiply()
        {
            Assert.AreEqual(8, calc.Multiply(4, 2));
        }

    }
}
