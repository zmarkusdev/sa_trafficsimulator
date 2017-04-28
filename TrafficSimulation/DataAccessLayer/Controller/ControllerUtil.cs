using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controller
{
    public class ControllerUtil
    {
        private const String _AGENT = "agent";

        private const String _AGENT_SIM_CONFIG = "agent_sim_config";

        private const String _AGENT_TYPE = "agent_type";

        private const String _DYNAMIC_EDGE = "dynamic_edge";

        private const String _EDGE = "edge";

        private const String _MAP = "map";

        private const String _POSITION = "position";

        private const String _RULE = "rule";

        private const String _RULE_TYPE = "rule_type";

        public static String AGENT()
        {
            return _AGENT;
        }
    }
}
