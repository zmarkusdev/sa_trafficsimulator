using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datamodel;

namespace Repositories
{
    public interface ICrosswayRepository
    {
        Datamodel.Crossway Create(Crossway crossway);
        void Delete(Crossway crossway);
        Crossway GetCrossway(int crosswayId);
        Crossway Update(Crossway crossway);

        IEnumerable<Crossway> GetAll();
    }
}

