using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using System.Web.Script.Serialization;
using System.IO;

namespace DataAccessLayer
{
    public interface IPostionDataAccess : IDataAccess<Position> { }

    class PositionDataAccess : AbstractDataAccess<Position>, IPostionDataAccess
    {
        // das hat hier natürlich nichts verloren, das ist Business Logik
        List<Position> endPositions = new List<Position>();
        List<Position> startPositions = new List<Position>();

        DataAccessCommon dataAccessCommon = DataAccessCommon.getInstance();

        public Position CreateXX(Position position)
        {
            if (position.Id == 0)
                position.Id = getuniqueId();
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

        public void DeleteXX(Position position)
        {
            if (endPositions != null)
                endPositions.RemoveAll(i => i.Id == position.Id);
            if (startPositions != null)
                startPositions.RemoveAll(i => i.Id == position.Id);
            base.Delete(position);
        }

        public void InitXX()
        {
            base.Init();
            endPositions = new List<Position>();
            startPositions = new List<Position>();
        }
    }
}
