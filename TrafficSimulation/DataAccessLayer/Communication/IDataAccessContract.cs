using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Communication
{
    [ServiceContract]
    public interface IDataAccessContract
    {
        [OperationContract]
        Datamodel.Agent CreateAgent(Agent agent);

        [OperationContract]
        void DeleteAgent(Agent agent);

        [OperationContract]
        Datamodel.Agent GetAgent(int agentId);

        [OperationContract]
        IEnumerable<Agent> GetAgentsForPositionIds(int positionIds);

        [OperationContract]
        IEnumerable<Agent> GetAllAgents();

        [OperationContract]
        Datamodel.Agent UpdateAgent(Agent agent);
    }
}
