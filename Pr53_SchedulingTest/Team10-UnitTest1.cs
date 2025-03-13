using Pr53_Scheduling;

namespace Pr53_SchedulingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class PCBTests
        {
            // Tester om man får den rigtige toString() tilbage altså om navngivningen er korrekt
            [TestMethod]
            public void ToString_ShouldReturnCorrectFormat()
            {
                // Arrange
                var pcb = new PCB
                {
                    ProcessName = "A",
                    ProcessPriority = 2,
                    ProcessState = ProcessStateType.Running
                };

                // Act
                var result = pcb.ToString();

                // Assert
                Assert.AreEqual("A(2)", result);
            }

            // Tester vores ENUM om vi får den rigtige stadie tilbage fra den Enum vi har opsat
            [TestMethod]
            public void ProcessState_ShouldSetAndGetCorrectly()
            {
                // Arrange
                var pcb = new PCB
                {
                    ProcessName = "Test",
                    ProcessPriority = 1,
                    ProcessState = ProcessStateType.Ready
                };

                // Act
                var state = pcb.ProcessState;

                // Assert
                Assert.AreEqual(ProcessStateType.Ready, state);
            }

            // Tester om vores priotet bliver sat korrekt.
            [TestMethod]
            public void ProcessPriority_ShouldSetAndGetCorrectly()
            {
                // Arrange
                var pcb = new PCB
                {
                    ProcessName = "Test",
                    ProcessPriority = 5
                };

                // Act
                var priority = pcb.ProcessPriority;

                // Assert
                Assert.AreEqual(5, priority);
            }

            // Tester ens process navn og om den bliver sat korrekt
            [TestMethod]
            public void ProcessName_ShouldSetAndGetCorrectly()
            {
                // Arrange
                var pcb = new PCB
                {
                    ProcessName = "MyProcess"
                };

                // Act
                var name = pcb.ProcessName;

                // Assert
                Assert.AreEqual("MyProcess", name);
            }
        }
    }
}