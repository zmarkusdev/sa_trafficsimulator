using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using DataAccessLayer;

namespace DataBridge
{
    /// <summary>
    /// Implementation of the IPositionRepository.
    /// </summary>
    class BetterMockedPositionService : IPositionRepository
    {
        IPostionDataAccess positionDataAccess = PositionDataAccessFactory.CreateRepository();
        IPostionDataAccess endpositionDataAccess = PositionDataAccessFactory.CreateRepository();
        IPostionDataAccess startpositionDataAccess = PositionDataAccessFactory.CreateRepository();

        public BetterMockedPositionService ()
        {
            positionDataAccess.LoadfromFile("position");
            foreach(var position in positionDataAccess.ReadAll())
            {
                if (position.PredecessorEdgeIds.Count() == 0)
                    startpositionDataAccess.Create(position);
                if (position.SuccessorEdgeIds.Count() == 0)
                    endpositionDataAccess.Create(position);
            }
        }

        public Position Create(Position position)
        {
            position = positionDataAccess.Create(position);
            if (position.PredecessorEdgeIds == null)
                position.PredecessorEdgeIds = new List<int>();
            if (position.PredecessorEdgeIds.Count() == 0)
                startpositionDataAccess.Create(position);
            if (position.SuccessorEdgeIds == null)
                position.SuccessorEdgeIds = new List<int>();
            if (position.SuccessorEdgeIds.Count() == 0)
                endpositionDataAccess.Create(position);
            return position;
        }

        public void Delete(Position position)
        {
            // Todo: optimieren, da es performacetechnisch sehr grob ist.
            if (position.SuccessorEdgeIds.Count() == 0)
                endpositionDataAccess.Delete(position);
            if (position.PredecessorEdgeIds.Count() == 0)
                startpositionDataAccess.Delete(position);
            positionDataAccess.Delete(position);
        }

        public IEnumerable<Position> GetAll()
        {
            return positionDataAccess.ReadAll();
        }

        public IEnumerable<Position> GetEndPositions()
        {
            return endpositionDataAccess.ReadAll();
        }

        public Position GetPosition(int positionId)
        {
            return positionDataAccess.ReadbyId(positionId);
        }

        public IEnumerable<Position> GetPredeccessors(int numSteps, int startPositionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> GetStartPositions()
        {
            return startpositionDataAccess.ReadAll();
        }

        public IEnumerable<Position> GetSuccessors(int numSteps, int startPositionId)
        {
            throw new NotImplementedException();
        }

        public Position Update(Position position)
        {
            positionDataAccess.Update(position);
            if (position.PredecessorEdgeIds.Count() == 0)
                startpositionDataAccess.Update(position);
            if (position.SuccessorEdgeIds.Count() == 0)
                endpositionDataAccess.Update(position);
            return position;
        }
    }
}
