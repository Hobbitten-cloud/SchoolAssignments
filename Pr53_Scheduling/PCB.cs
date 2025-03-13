using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pr53_Scheduling
{
    public enum ProcessStateType 
    { 
        New, 
        Ready, 
        Running, 
        Waiting, 
        Terminated 
    };

    public class PCB
    {
        public string ProcessName { get; set; }

        public int ProcessPriority { get; set; }

        public ProcessStateType ProcessState { get; set; }

        public override string ToString()
        {
            return $"{ProcessName}({ProcessPriority})";
        }
    }
}
