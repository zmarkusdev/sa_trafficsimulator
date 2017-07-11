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
        /// <summary>
        /// Initialize context.
        /// </summary>
        void Init();

        /// <summary>
        /// Loads data from file.
        /// </summary>
        /// <param name="filename">File with data</param>
        void LoadfromFile(string filename);

        /// <summary>
        /// Writes data to file.
        /// </summary>
        /// <param name="filename">File where data should be stored</param>
        void SavetoFile(string filename);

        /// <summary>
        /// Deserialize object.
        /// </summary>
        /// <param name="serialized">Serialized object</param>
        /// <returns>Deserialized object</returns>
        T deserializefromString(string serialized);

        /// <summary>
        /// Serializes object.
        /// </summary>
        /// <param name="objekt">Object to serialize</param>
        /// <returns>Serialized object</returns>
        string serialize2String(T objekt);

        // CRUD 
        /// <summary>
        /// Creates object.
        /// </summary>
        /// <param name="objekt">Object to create</param>
        /// <returns>Created object</returns>
        T Create(T objekt);

        /// <summary>
        /// Get object by id.
        /// </summary>
        /// <param name="Id">Id of object.</param>
        /// <returns>Object or null</returns>
        T ReadbyId(int Id);

        /// <summary>
        /// Updates given object.
        /// </summary>
        /// <param name="objekt">Object to update</param>
        void Update(T objekt);

        /// <summary>
        /// Deletes given object.
        /// </summary>
        /// <param name="objekt">Object to delete</param>
        void Delete(T objekt);

        /// <summary>
        /// Gell all objects.
        /// </summary>
        /// <returns>List of objects or null</returns>
        IEnumerable<T> ReadAll();
    }
}
