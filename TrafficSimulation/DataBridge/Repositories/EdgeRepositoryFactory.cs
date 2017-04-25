using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using Repositories;


namespace Repositories
{
    public abstract class EdgeRepositoryFactory
    {
        public static IEdgeRepository CreateRepository()
        {
            return new MockedEdgeService();
        }
    }
}