using DataAccessLayer;
using Datamodel;

namespace DataAccessLayer
{
    // agents do not need anything more than the baseclass offers
    class AgentDataAccess : AbstractDataAccess<Agent>
    {
        DataAccessCommon dataAccessCommon = DataAccessCommon.getInstance();

        public override Agent Create(Agent agent)
        {
            if (agent.Id == 0)
                agent.Id = dataAccessCommon.getuniqueId();
            agent = base.Create(agent);

            return (agent);
        }
    }
}
