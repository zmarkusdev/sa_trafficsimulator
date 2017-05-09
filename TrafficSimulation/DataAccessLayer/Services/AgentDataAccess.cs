using System;
using Datamodel;
using DataModel.Pipe;

namespace DataAccessLayer
{
    public interface IAgentDataAccess : IDataAccess<Agent> { }

    class AgentDataAccess : AbstractDataAccess<Agent>, IAgentDataAccess
    {
        public override void executeCommand(PipeDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
