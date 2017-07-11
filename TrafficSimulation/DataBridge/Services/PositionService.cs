using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using DataBridge.Communication;

namespace DataBridge.Services
{
    /// <summary>
    /// Implementation of the IPositionRepository.
    /// </summary>
    class PositionService : IPositionRepository
    {
        public Position Create(Position position)
        {
            return DataAccessClient.Instance.Channel.CreatePosition(position);
        }

        public void Delete(Position position)
        {
            DataAccessClient.Instance.Channel.DeletePosition(position);
        }

        public IEnumerable<Position> GetAll()
        {
            return DataAccessClient.Instance.Channel.GetAllPositions();
        }

        public IEnumerable<Position> GetEndPositions()
        {
            return DataAccessClient.Instance.Channel.GetEndPositions();
        }

        public Position GetPosition(int positionId)
        {
            return DataAccessClient.Instance.Channel.GetPosition(positionId);
        }

        public IEnumerable<Position> GetPredeccessors(int numSteps, int startPositionId)
        {
            return DataAccessClient.Instance.Channel.GetPredeccessors(numSteps, startPositionId);
        }

        public IEnumerable<Position> GetStartPositions()
        {
            return DataAccessClient.Instance.Channel.GetStartPositions();
        }

        public IEnumerable<Position> GetSuccessors(int numSteps, int startPositionId)
        {
            return DataAccessClient.Instance.Channel.GetSuccessors(numSteps, startPositionId);
        }

        public Position Update(Position position)
        {
            return DataAccessClient.Instance.Channel.UpdatePosition(position);
        }
    }
}
