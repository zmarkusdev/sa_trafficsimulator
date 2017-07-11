using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datamodel;
namespace DataAccessLayer
{
    /// <summary>
    /// The basic set of operations, any implenting Class which wants to use the DataAccessLayer has to offer.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataAccess<T>
    {
        void Init();

        // persistance
        void LoadfromFile(string filename);
        void SavetoFile(string filename);

        // serialisation
        T deserializefromString(string serialized);
        string serialize2String(T objekt);

        // CRUD 
        T Create(T objekt);
        T ReadbyId(int Id);
        void Update(T objekt);
        void Delete(T objekt);
        IEnumerable<T> ReadAll();
    }
}
