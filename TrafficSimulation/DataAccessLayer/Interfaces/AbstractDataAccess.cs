using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Linq;
using System.Collections.Concurrent;

namespace DataAccessLayer
{
    // generic Class implementing the basic CRUD and persistence handling for 
    // objects identified by an ID element of int Type.
    public abstract class AbstractDataAccess<T> : IDataAccess<T>
    {
        ConcurrentDictionary<int, T> liste = new ConcurrentDictionary<int, T>();
        private int uniqueId = 1;
        private string datafileprefix = "datafile_";
        private string datafileextension = ".txt";


        public int getuniqueId()
        {
            return uniqueId++;
        }
        public virtual void Init()
        {
            liste = new ConcurrentDictionary<int, T>();
            uniqueId = 0;
        }
        public virtual T Create(T objekt)
        {
            int id = getObjectId(objekt);
            if (id == 0)
            {
                id = getuniqueId();
                objekt = setObjectId(objekt, id);
            }
            liste.AddOrUpdate(id, objekt, (k,v) => objekt);
            return objekt;
        }

        public virtual void Update(T objekt)
        {
            // Create is called here, because createorupdate is handled in that method
            Create(objekt);
        }

        public virtual void Delete(T objekt)
        {
            int id = getObjectId(objekt);
            liste.TryRemove(id, out objekt);
        }

        public virtual T deserializefromString(string serialized)
        {
            return new JavaScriptSerializer().Deserialize<T>(serialized);
        }

        public string serialize2String(T objekt)
        {
            return new JavaScriptSerializer().Serialize(objekt);
        }

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
                            uniqueId = Math.Max(uniqueId, getObjectId(readObjekt));
                            liste.AddOrUpdate(uniqueId, readObjekt, (k,v) => readObjekt);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Filelesen geht ned:" + filename + "(" + line + ")");
                Console.WriteLine(e.Message);
            }
        }

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

        public virtual T ReadbyId(int Id)
        {
            T result;
            liste.TryGetValue(Id, out result);
            return result;
        }

        public virtual List<T> ReadAll()
        {
            return liste.Select(o => o.Value).ToList();
        }
        
        private int getObjectId(T objekt)
        {
            var propertyO = objekt.GetType().GetProperty("Id");
            int interestingId = (int)propertyO.GetValue(objekt, null);
            return interestingId;
        }

        private T setObjectId(T objekt, int id)
        {
            Type myType = objekt.GetType();
            PropertyInfo pinfo = myType.GetProperty("Id");
            pinfo.SetValue(objekt, id, null);
            return objekt;
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
