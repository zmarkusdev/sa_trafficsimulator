using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
namespace DataAccessLayer
{
    public interface IDataAccessLayerRepository
    {
        void Init();
        void LoadfromFile();


    }
}
