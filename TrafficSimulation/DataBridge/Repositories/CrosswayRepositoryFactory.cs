using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
using Repositories;
using DataBridge;
using DataBridge.Services;

namespace Repositories
{
    public abstract class CrosswayRepositoryFactory
    {
        public static ICrosswayRepository CreateRepository()
        {
            return new CrosswayService();
        }
    }
}
