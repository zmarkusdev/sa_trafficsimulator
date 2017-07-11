using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Linq;
using System.Collections.Concurrent;
using Datamodel;

namespace DataAccessLayer
{
    /// <summary>
    /// generic Class implementing the basic CRUD and persistence handling for
    /// objects identified by an ID element of int Type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractDataAccess<T> : IDataAccess<T> where T : BaseModel
    {
        ConcurrentDictionary<int, T> liste = new ConcurrentDictionary<int, T>();
        private int uniqueId = 1;
        private string datafileprefix = "cityfile_";
        private string datafileextension = ".txt";

        /// <summary>
        /// Creates unique id.
        /// </summary>
        /// <returns>Unique id</returns>
        public int getuniqueId()
        {
            return uniqueId++;
        }

        /// <summary>
        /// Initializes the DataAccess.
        /// </summary>
        public virtual void Init()
        {
            liste = new ConcurrentDictionary<int, T>();
            uniqueId = 0;
        }

        /// <summary>
        /// Creates new entity.
        /// </summary>
        /// <param name="objekt">Entity to create</param>
        /// <returns>Created entity</returns>
        public virtual T Create(T objekt)
        {
            int id = objekt.Id;
            if (id == 0)
            {
                id = getuniqueId();
                objekt.Id = id;
            }
            liste.AddOrUpdate(id, objekt, (k,v) => objekt);
            return objekt;
        }

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="objekt">Entity to update</param>
        public virtual void Update(T objekt)
        {
            // Create is called here, because createorupdate is handled in that method
            Create(objekt);
        }

        /// <summary>
        /// Deletes the given entity.
        /// </summary>
        /// <param name="objekt">Entity to delete</param>
        public virtual void Delete(T objekt)
        {
            int id = objekt.Id;
            liste.TryRemove(id, out objekt);
        }

        /// <summary>
        /// Deserialize an entity.
        /// </summary>
        /// <param name="serialized">Serialized entity</param>
        /// <returns>Concrete entity</returns>
        public virtual T deserializefromString(string serialized)
        {
            return new JavaScriptSerializer().Deserialize<T>(serialized);
        }

        /// <summary>
        /// Serializes an entity
        /// </summary>
        /// <param name="objekt">Entity to serialize</param>
        /// <returns>Serialized entity</returns>
        public string serialize2String(T objekt)
        {
            return new JavaScriptSerializer().Serialize(objekt);
        }

        /// <summary>
        /// Loads object from file.
        /// </summary>
        /// <param name="filename">Name of specific file</param>
        public void LoadfromFile(string filename)
        {
            string line = "";
            try
            {
                // TODO: move to config/resources....
                string relPath = Directory.GetCurrentDirectory();
                relPath = "..\\..\\..\\DataAccessLayer\\";
                using (StreamReader readfile = new StreamReader(relPath + getfilenamePrefix() + filename + getfilenameExtension()))
                {
                    while ((line = readfile.ReadLine()) != null)
                    {
                        // Comments start with #, others will be deserialized
                        if (line.Substring(0, 1) != "#")
                        {
                            T readObjekt = new JavaScriptSerializer().Deserialize<T>(line);
                            uniqueId = Math.Max(uniqueId, readObjekt.Id);
                            liste.AddOrUpdate(uniqueId, readObjekt, (k,v) => readObjekt);
                        }
                    }
                    Console.WriteLine("File: " + filename + ", read: " + liste.Count);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Filelesen geht ned:" + filename + "(" + line + ")");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Writes objects to file.
        /// </summary>
        /// <param name="filename">File name of responsible file</param>
        public virtual void SavetoFile(string filename)
        {
            try
            {
                using (StreamWriter writefile = new StreamWriter(getfilenamePrefix() + filename + getfilenameExtension()))
                {
                    foreach (var objekt in liste)
                        writefile.WriteLine(serialize2String(objekt.Value));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fileschreiben geht ned:" + filename);
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Searches for an object in list.
        /// </summary>
        /// <param name="Id">Id to search for</param>
        /// <returns>Object or null</returns>
        public virtual T ReadbyId(int Id)
        {
            T result;
            liste.TryGetValue(Id, out result);
            return result;
        }

        /// <summary>
        /// Reads all from file.
        /// </summary>
        /// <returns>List of objects or null</returns>
        public virtual IEnumerable<T> ReadAll()
        {
            return liste.Select(o => o.Value);
        }

        private string getfilenamePrefix()
        {
            return datafileprefix;
        }

        private string getfilenameExtension()
        {
            return datafileextension;
        }
    }
}
