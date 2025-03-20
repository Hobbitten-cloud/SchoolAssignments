using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    public class Buffer
    {
        private Queue<Car> bufferData;
        private int capacity;

        private object bufferLock = new object();

        public Buffer(int capacity)
        {
            this.capacity = capacity;
            bufferData = new Queue<Car>();
        }

        public void Put(Car car)
        {
            Monitor.Enter(bufferLock);

            bufferData.Enqueue(car);
            if (bufferData.Count > capacity)
            {
                throw new System.ArgumentException("Køen er fuld");
            }

            Monitor.Exit(bufferLock);
        }

        public Car Get()
        {
            while (IsEmpty())
            {
                Monitor.Enter(bufferLock);
            }

            Car car;
            car = bufferData.Dequeue();

            Monitor.Exit(bufferLock);

            return car;
        }

        public bool IsEmpty()
        {
            bool isempty;
            lock (bufferLock)
            {
                isempty = bufferData.Count == 0;
            }
            return isempty;
        }

        public bool IsFull()
        {
            bool isfull;
            lock (bufferLock)
            {
                isfull = bufferData.Count == capacity;
            }
            return isfull;
        }
    }

}
