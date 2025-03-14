using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr53_Scheduling
{
    public class PriorityQueue
    {
        // List to store PCB objects
        private List<PCB> pcbList = new List<PCB>();

        // Adds a new PCB object to the list and sorts it based on priority
        public void Enqueue(PCB pcb)
        {
            // Add the new PCB to the list
            pcbList.Add(pcb);

            // Sort the list:
            // - First by ProcessPriority (ascending order — lower value = higher priority)
            pcbList = pcbList.OrderBy(p => p.ProcessPriority).ToList();
        }

        // Removes the PCB with the highest priority (lowest value)
        public void Dequeue()
        {
            // Remove the first element (highest priority because list is sorted)
            pcbList.RemoveAt(0);
        }

        // Changes the priority of an existing PCB and re-sorts the list
        public void Reprioritize(string processName, int newPriority)
        {
            foreach (PCB pcb in pcbList)
            {
                if (pcb.ProcessName == processName)
                {
                    // Update the priority of the found PCB object
                    pcb.ProcessPriority = newPriority;

                    // Re-sort the list after the priority change
                    pcbList = pcbList.OrderBy(p => p.ProcessPriority).ToList();
                }
            }
        }

        // Returns a string representation of the queue
        public override string ToString()
        {
            // Initialize the result string with the opening bracket
            string result = "{";

            // Loop through each PCB object in the list
            foreach (var pcb in pcbList)
            {
                // If the result already has content (meaning it's not the first element), add a comma
                if (result.Length > 1)
                {
                    result += ",";
                }

                // Add the PCB's ProcessName and ProcessPriority in the format "ProcessName(Priority)"
                result += pcb.ProcessName + "(" + pcb.ProcessPriority + ")";
            }

            // Close the bracket after adding all elements
            result += "}";

            // Return the final formatted string
            return result;
        }
    }
}