using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataAccessLayerRepository dal = DataAccessLayerRepositoryFactory.CreateRepository();

            dal.SavetoFile();
        }
    }
}
