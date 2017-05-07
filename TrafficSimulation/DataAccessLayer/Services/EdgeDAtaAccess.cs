using System;
using Datamodel;
using DataModel.Pipe;

namespace DataAccessLayer
{
    // edges do not need much more than the baseclass offers
    class EdgeDataAccess : AbstractDataAccess<Edge>
    {
        DataAccessCommon dataAccessCommon = DataAccessCommon.getInstance();

        public override Edge Create(Edge edge)
        {
            if (edge.Id == 0)
                edge.Id = dataAccessCommon.getuniqueId();
            edge = base.Create(edge);

            return (edge);
        }

        public override void executeCommand(PipeDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
