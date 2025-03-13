using ModelPersistence.Models;
using ModelPersistence.Persistence;

namespace TeacherSubstituteTest
{
    [TestClass]
    public class UnitTest1
    {
        private SubstituteRepo substituteRepo;
        private Substitute substitute;

        [TestInitialize]
        public void SetupForSubstituteTests()
        {
            // Arrange: Initialize the repository and test data
            substituteRepo = new SubstituteRepo();
            substitute = new Substitute
            {
                Name = "John",
                Email = "john@example.com",
                Region = "RegionX",
                Phone = "123456789",
                PersonNumber = "987654321",
                Verified = true
            };
        }

        [TestMethod]
        public void TestSubsituteCreate()
        {
            // Act: Add substitute to the repository
            substituteRepo.Create(substitute);

            // Assert: Check if the substitute was added
            List<Substitute> substitutes = substituteRepo.RetrieveAll();
            Assert.AreEqual(1, substitutes.Count);
            Assert.AreEqual("John", substitutes[0].Name);
        }
    }
}