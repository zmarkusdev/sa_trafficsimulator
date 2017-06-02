using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;

namespace DataAccessLayer
{
    public interface ICrosswayDataAccess : IDataAccess<Crossway> { }

    class CrosswayDataAccess : AbstractDataAccess<Crossway>, ICrosswayDataAccess
    {
    }
}
