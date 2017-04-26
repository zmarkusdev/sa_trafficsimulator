using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public abstract class DataAccessLayerRepositoryFactory
    {
        public static IDataAccessLayerRepository CreateRepository()
        {
            MockedDataAccessLayer dalInstance = MockedDataAccessLayer.getInstance();
            return dalInstance;
        }

    }
}
