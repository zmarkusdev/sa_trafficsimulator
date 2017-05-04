using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Pipe
{
    public class PipeUtil
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
        public static String AGENT_SIM_CONFIG()
        {
            return _AGENT_SIM_CONFIG;
        }
        public static String AGENT_TYPE()
        {
            return _AGENT_TYPE;
        }
        public static String DYNAMIC_EDGE()
        {
            return _DYNAMIC_EDGE;
        }
        public static String EDGE()
        {
            return _EDGE;
        }
        public static String MAP()
        {
            return _MAP;
        }
        public static String POSITION()
        {
            return _POSITION;
        }
        public static String RULE()
        {
            return _RULE;
        }
        public static String RULE_TYPE()
        {
            return _RULE_TYPE;
        }
    }
}
