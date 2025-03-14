using Pr53_Scheduling;
using System.Collections.Generic;

namespace Pr53_SchedulingTest
{
    [TestClass]
    public class UnitTest1
    {
        //-------------------------------------------------
        // STUDENT PART
        //-------------------------------------------------
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

            //-------------------------------------------------
            // TEACHERS PART
            //-------------------------------------------------
            public PriorityQueue pq;

            [TestInitialize]
            public void InitializeTest()
            {
                pq = new PriorityQueue();
            }

            [TestMethod]
            public void TestPCBToString()
            {
                // Arrange
                PCB pcb = new PCB { ProcessName = "A", ProcessPriority = 2 };

                // Act

                // Assert
                Assert.AreEqual("A(2)", pcb.ToString());
            }

            [TestMethod]
            public void TestEmptyQueue()
            {
                // Arrange

                // Act

                // Assert
                Assert.AreEqual("{}", pq.ToString());
            }

            [TestMethod]
            public void TestEnqueueAndToString()
            {
                // Arrange
                PCB pcb = new PCB { ProcessName = "A", ProcessPriority = 2 };

                // Act
                pq.Enqueue(pcb);

                // Assert
                Assert.AreEqual("{A(2)}", pq.ToString());
            }

            [TestMethod]
            public void Test3EnqueuesAndToString()
            {
                // Arrange
                PCB pcbA = new PCB { ProcessName = "A", ProcessPriority = 2 };
                PCB pcbB = new PCB { ProcessName = "B", ProcessPriority = 2 };
                PCB pcbC = new PCB { ProcessName = "C", ProcessPriority = 2 };

                // Act
                pq.Enqueue(pcbA);
                pq.Enqueue(pcbB);
                pq.Enqueue(pcbC);

                // Assert
                Assert.AreEqual("{A(2),B(2),C(2)}", pq.ToString());
            }

            [TestMethod]
            public void Test3EnqueuesAndPriority()
            {
                // Arrange
                PCB pcbA = new PCB { ProcessName = "A", ProcessPriority = 2 };
                PCB pcbB = new PCB { ProcessName = "B", ProcessPriority = 3 };
                PCB pcbC = new PCB { ProcessName = "C", ProcessPriority = 1 };

                // Act
                pq.Enqueue(pcbA);
                pq.Enqueue(pcbB);
                pq.Enqueue(pcbC);

                // Assert
                Assert.AreEqual("{C(1),A(2),B(3)}", pq.ToString());
            }

            [TestMethod]
            public void TestEnqueueDequeue()
            {
                // Arrange
                PCB pcbA = new PCB { ProcessName = "A", ProcessPriority = 2 };
                PCB pcbB = new PCB { ProcessName = "B", ProcessPriority = 2 };
                PCB pcbC = new PCB { ProcessName = "C", ProcessPriority = 3 };
                PCB pcbD = new PCB { ProcessName = "D", ProcessPriority = 3 };
                PCB pcbE = new PCB { ProcessName = "E", ProcessPriority = 1 };

                // Act
                pq.Enqueue(pcbA);
                pq.Enqueue(pcbB);
                pq.Enqueue(pcbC);
                pq.Enqueue(pcbD);
                pq.Enqueue(pcbE);
                pq.Dequeue();
                pq.Dequeue();

                // Assert
                Assert.AreEqual("{B(2),C(3),D(3)}", pq.ToString());
            }

            [TestMethod]
            public void TestEnqueueDequeueReprioritize()
            {
                // Arrange
                PCB pcbA = new PCB { ProcessName = "A", ProcessPriority = 2 };
                PCB pcbB = new PCB { ProcessName = "B", ProcessPriority = 2 };
                PCB pcbC = new PCB { ProcessName = "C", ProcessPriority = 3 };
                PCB pcbD = new PCB { ProcessName = "D", ProcessPriority = 3 };
                PCB pcbE = new PCB { ProcessName = "E", ProcessPriority = 1 };

                // Act
                pq.Enqueue(pcbA);
                pq.Enqueue(pcbB);
                pq.Enqueue(pcbC);
                pq.Enqueue(pcbD);
                pq.Enqueue(pcbE);
                pq.Dequeue();
                pq.Dequeue();
                pq.Reprioritize("D", 2);

                // Assert
                Assert.AreEqual("{B(2),D(2),C(3)}", pq.ToString());
            }

            [TestMethod]
            public void TestEnqueueDequeueReprioritize2()
            {
                // Arrange
                PCB pcbA = new PCB { ProcessName = "A", ProcessPriority = 4 };
                PCB pcbB = new PCB { ProcessName = "B", ProcessPriority = 1 };
                PCB pcbC = new PCB { ProcessName = "C", ProcessPriority = 3 };
                PCB pcbD = new PCB { ProcessName = "D", ProcessPriority = 3 };
                PCB pcbE = new PCB { ProcessName = "E", ProcessPriority = 1 };

                // Act
                pq.Enqueue(pcbA);
                pq.Enqueue(pcbB);
                pq.Dequeue();
                pq.Enqueue(pcbC);
                pq.Reprioritize("A", 2);
                pq.Enqueue(pcbD);
                pq.Dequeue();
                pq.Enqueue(pcbE);

                // Assert
                Assert.AreEqual("{E(1),C(3),D(3)}", pq.ToString());
            }

        }
    }
}