using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;

namespace DataBridge
{
    class MockedPositionService : IPositionRepository
    {
        List<Position> positions = new List<Position>();
        List<Position> endPositions = new List<Position>();
        List<Position> startPositions = new List<Position>();
        int freePosId = 1;

        public MockedPositionService()
        {
            createSmallVillage();
        }

        public Position Create(Position position)
        {
            position.Id = getuniquePosId();
            // unsere Positions haben immer eine Liste, auch wenn diese leer ist
            if (position.SuccessorEdgeIds == null)
                position.SuccessorEdgeIds = new List<int>();
            if (position.PredecessorEdgeIds == null)
                position.PredecessorEdgeIds = new List<int>();

            positions.Add(position);
            if (position.SuccessorEdgeIds.Count() == 0)
                endPositions.Add(position);
            if (position.PredecessorEdgeIds.Count() == 0)
                startPositions.Add(position);

            return (position);
        }

        public void Delete(Position position)
        {
            if (endPositions != null)
                endPositions.RemoveAll(i => i.Id == position.Id);
            if (startPositions != null)
                startPositions.RemoveAll(i => i.Id == position.Id);
            if (positions != null)
                positions.RemoveAll(i => i.Id == position.Id);
        }

        public IEnumerable<Position> GetEndPositions()
        {
            return (endPositions);
        }

        public Position GetPosition(int positionId)
        {
            foreach (Position position in positions)
            {
                if (position.Id == positionId)
                    return position;
            }
            return null;
        }


        public IEnumerable<Position> GetPredeccessors(int numSteps, int startPositionId)
        {
            // Todo: brauchma des no?
            throw new NotImplementedException();
        }

        public IEnumerable<Position> GetStartPositions()
        {
            return (startPositions);
        }

        public IEnumerable<Position> GetSuccessors(int numSteps, int startPositionId)
        {
            // Todo: brauchma des no?
            throw new NotImplementedException();
        }

        public Position Update(Position position)
        {
            Position gefunden = null;
            if (positions != null)
            {

                foreach (Position currPosition in positions)
                {
                    if (currPosition.Id == position.Id)
                        gefunden = currPosition;
                }
                if (position == null)
                    return Create(position);

                // -----  gefunden: dann mach ein Update -----
                // Update 
                gefunden.MaxVelocity = position.MaxVelocity;
                gefunden.PredecessorEdgeIds = position.PredecessorEdgeIds;
                gefunden.Rotation = position.Rotation;
                gefunden.RuleIds = position.RuleIds;
                gefunden.SuccessorEdgeIds = position.SuccessorEdgeIds;
                gefunden.X = position.X;
                gefunden.Y = position.Y;
                // Todo: muss das noch retourgeschrieben werden?
                // Startposition??
                if (gefunden.PredecessorEdgeIds == null)
                    removePositionfromList(gefunden.Id, startPositions);
                else startPositions.Add(position);

                // Endposition??
                if (gefunden.SuccessorEdgeIds == null)
                    removePositionfromList(gefunden.Id, endPositions);
                else endPositions.Add(position);

            }
            // Todo:

            if (endPositions != null)
                endPositions.RemoveAll(i => i.Id == position.Id);
            if (startPositions != null)
                startPositions.RemoveAll(i => i.Id == position.Id);

            return position;
        }

        //************************* meine **********************************

        private void createSmallVillage()
        {
            Position posi1 = new Position();
            Position posi2 = new Position();
            Position posi3 = new Position();
            Position posi4 = new Position();
            Position posi5 = new Position();
            Position posi6 = new Position();

            posi1.MaxVelocity = 50;
            posi1.PredecessorEdgeIds = new List<int>();
            posi1.Rotation = 0;
            posi1.RuleIds = new List<int>();
            posi1.SuccessorEdgeIds = new List<int>(2);
            posi1.X = 40;
            posi1.Y = 300;
            Create(posi1);

            posi2.MaxVelocity = 50;
            posi2.PredecessorEdgeIds = new List<int>(1);
            posi2.Rotation = 0;
            posi2.RuleIds = new List<int>();
            posi2.SuccessorEdgeIds = new List<int>(3);
            posi2.X = 200;
            posi2.Y = 300;
            Create(posi2);

            posi3.MaxVelocity = 50;
            posi3.PredecessorEdgeIds = new List<int>(2);
            posi3.Rotation = 0;
            posi3.RuleIds = new List<int>();
            posi3.SuccessorEdgeIds = new List<int>(4);
            posi3.X = 220;
            posi3.Y = 320;
            Create(posi3);

            posi4.MaxVelocity = 50;
            posi4.PredecessorEdgeIds = new List<int>(2);
            posi4.Rotation = 0;
            posi4.RuleIds = new List<int>();
            posi4.SuccessorEdgeIds = new List<int>(5);
            posi4.X = 220;
            posi4.Y = 320;
            Create(posi4);

            posi5.MaxVelocity = 50;
            posi5.PredecessorEdgeIds = new List<int>(4);
            posi5.Rotation = 0;
            posi5.RuleIds = new List<int>();
            posi5.SuccessorEdgeIds = new List<int>();
            posi5.X = 220;
            posi5.Y = 580;
            Create(posi5);

            posi6.MaxVelocity = 50;
            posi6.PredecessorEdgeIds = new List<int>(3);
            posi6.Rotation = 0;
            posi6.RuleIds = new List<int>();
            posi6.SuccessorEdgeIds = new List<int>(6);
            posi6.X = 220;
            posi6.Y = 80;
            Create(posi6);
        }

        private int getuniquePosId()
        {
            return (freePosId++);
        }
        private Position createDummyposition()
        {
            Position position = new Position();
            position.Id = getuniquePosId();
            position.MaxVelocity = 10;
            position.PredecessorEdgeIds = null;
            position.SuccessorEdgeIds = null;
            position.Rotation = 167;
            position.RuleIds = null;
            position.X = 100;
            position.Y = 100;

            return position;
        }

        private void removePositionfromList(int posID, List<Position> positionList)
        {
            positionList.RemoveAll(item => item.Id == posID);
        }



        public IEnumerable<Position> GetAll()
        {
            return positions;
        }
    }
}
