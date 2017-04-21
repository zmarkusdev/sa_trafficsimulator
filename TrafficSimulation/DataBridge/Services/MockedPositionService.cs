using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;

namespace DataBridge.Services
{
    class MockedPositionService : IPositionRepository
    {
        List<Position> positions = new List<Position>();
        int freePosId = 0;


        public Position Create(Position position)
        {
            position.Id = getuniquePosId();
            positions.Add(position);
            return (position);
        }

        public void Delete(Position position)
        {
            return;
        }

        public IEnumerable<Position> GetEndPositions()
        {
            List<Position> positions = new List<Position>();

            positions.Add(createDummyposition());
            positions.Add(createDummyposition());

            return(positions);
        }

        public Position GetPosition(int positionId)
        {
            Position position =  createDummyposition();
            position.Id = positionId;
            return (position);
        }

        public IEnumerable<Position> GetPredeccessors(int numSteps, int startPositionId)
        {
            List<Position> positions = new List<Position>();

            positions.Add(createDummyposition());
            positions.Add(createDummyposition());

            return (positions);
        }

        public IEnumerable<Position> GetStartPositions()
        {
            List<Position> positions = new List<Position>();

            positions.Add(createDummyposition());
            positions.Add(createDummyposition());

            return (positions);
        }

        public IEnumerable<Position> GetSuccessors(int numSteps, int startPositionId)
        {
            List<Position> positions = new List<Position>();

            positions.Add(createDummyposition());
            positions.Add(createDummyposition());

            return (positions);
        }

        public Position Update(Position position)
        {
            return position;
        }

        //************************* meine **********************************
        private int getuniquePosId()
        {
            return (freePosId++);
        }
        private Position createDummyposition()
        {
            Position position = new Position();
            position.Id = getuniquePosId();
            position.MaxVelocity = 10;
            position.PredecessorIds = null;
            position.SuccessorIds = null;
            //position = 100;
            //positions.Y = 100;

            return position;
        }
    }
}
