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
    /// Implementation of the ICrosswayRepository.
    /// </summary>
    class CrosswayService : ICrosswayRepository
    {
        public Crossway Create(Crossway crossway)
        {
            return DataAccessClient.Instance.Channel.CreateCrossway(crossway);
        }

        public void Delete(Crossway crossway)
        {
            DataAccessClient.Instance.Channel.DeleteCrossway(crossway);
        }

        public IEnumerable<Crossway> GetAll()
        {
            return DataAccessClient.Instance.Channel.GetAllCrossways();
        }

        public Crossway GetCrossway(int crosswayId)
        {
            return DataAccessClient.Instance.Channel.GetCrossway(crosswayId);
        }

        public Crossway Update(Crossway crossway)
        {
            return DataAccessClient.Instance.Channel.UpdateCrossway(crossway);
        }
    }
}


