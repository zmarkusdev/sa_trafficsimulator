using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSpawner
{
    public interface IAgentSpawner
    {
        void Start();

        void Stop();
    }
}
