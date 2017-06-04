using Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation
{
    class Log : ILog
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }
    }
}
