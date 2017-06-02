
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
    class     BetterMockedCrosswayService : ICrosswayRepository
    {
        ICrosswayDataAccess crosswayDataAccess = CrosswayDataAccessFactory.CreateRepository();

        public BetterMockedCrosswayService()
        {
            crosswayDataAccess.LoadfromFile("crossway");
        }

        public Crossway Create(Crossway crossway)
        {
            return crosswayDataAccess.Create(crossway);
        }

        public void Delete(Crossway crossway)
        {
            crosswayDataAccess.Delete(crossway);
        }

        public IEnumerable<Crossway> GetAll()
        {
            return crosswayDataAccess.ReadAll();
        }

        public Crossway GetCrossway(int crosswayId)
        {
            return crosswayDataAccess.ReadbyId(crosswayId);
        }

        public Crossway Update(Crossway crossway)
        {
            crosswayDataAccess.Update(crossway);
            return crossway;
        }
    }
}




