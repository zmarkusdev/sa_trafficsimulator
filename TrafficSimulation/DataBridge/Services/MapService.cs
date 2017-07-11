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
    /// Implementation of the IMapRepository.
    /// </summary>
    class MapService : IMapRepository
    {
        public Map GetMap()
        {
            return DataAccessClient.Instance.Channel.GetMap();
        }
    }
}
