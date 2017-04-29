using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using System.Web.Script.Serialization;
using System.IO;

namespace DataAccessLayer.Services
{
    class PositionDataAccess : AbstractDataAccess<Position> 
    {
        List<Position> endPositions = new List<Position>();
        List<Position> startPositions = new List<Position>();

        DataAccessCommon dataAccessCommon = DataAccessCommon.getInstance();

        public override Position Create(Position position)
        {
            if (position.Id == 0)
                position.Id = dataAccessCommon.getuniqueId();
            // unsere Positions haben immer eine Liste, auch wenn diese leer ist
            if (position.SuccessorEdgeIds == null)
                position.SuccessorEdgeIds = new List<int>();
            if (position.PredecessorEdgeIds == null)
                position.PredecessorEdgeIds = new List<int>();
            position = base.Create(position);

            /* Todo: überleg noch, ob das als eigener Typ geführt werden soll oder als 
                     spezialisierung der Positions */
            if (position.SuccessorEdgeIds.Count() == 0)
                endPositions.Add(position);
            if (position.PredecessorEdgeIds.Count() == 0)
                startPositions.Add(position);

            return (position);
        }

        public override void Delete(Position position)
        {
            if (endPositions != null)
                endPositions.RemoveAll(i => i.Id == position.Id);
            if (startPositions != null)
                startPositions.RemoveAll(i => i.Id == position.Id);
            base.Delete(position);
        }

        public override void Init()
        {
            base.Init();
            endPositions = new List<Position>();
            startPositions = new List<Position>();
        }

 
    }
}
