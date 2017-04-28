using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
namespace DataAccessLayer
{
    public interface IDataAccess<T>
    {
        void Init();

        void LoadfromFile(string filename);
        void SavetoFile(string filename);

        T deserializefromString(string serialized);
        string serialize2String(T objekt);

        T Create(T objekt);
        T ReadbyId(int Id);
        void Update(T objekt);
        void Delete(T objekt);
        List<T> ReadAll();
    }
}
