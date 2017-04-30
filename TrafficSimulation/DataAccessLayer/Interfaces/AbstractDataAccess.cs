using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DataAccessLayer
{
    // generic Class implementing the basic CRUD and persistence handling for 
    // objects identified by an ID element of int Type.
    public abstract class AbstractDataAccess<T> : IDataAccess<T>
    {
        List<T> liste = new List<T>();

        public virtual void Init()
        {
            liste = new List<T>();
        }


        public virtual T Create(T objekt)
        {
            liste.Add(objekt);
            return objekt;
        }

        public virtual void Update(T objekt)
        {
            T gefunden = default(T);
            // Todo: absicherstellen, falls nicht alle eine Id haben
            var propertyO = objekt.GetType().GetProperty("Id");
            int interestingId = (int)propertyO.GetValue(objekt, null);

            if (liste != null)
            {
                foreach (T currT in liste)
                {
                    var propertyC = currT.GetType().GetProperty("Id");
                    var extractedId = (int)propertyC.GetValue(currT, null);
                    if (extractedId == interestingId)
                    {
                        gefunden = currT;
                        break;
                    }
                }
            }
            if (!gefunden.Equals(objekt))
                Create(objekt);

        }

        public virtual void Delete(T objekt)
        {
            int gefundenIndex = -1;
            int index = -1;
            var propertyO = objekt.GetType().GetProperty("Id");

            int interestingId = (int)propertyO.GetValue(objekt, null);
            if (liste != null)
            {
                foreach (var currT in liste)
                {
                    var propertyC = currT.GetType().GetProperty("Id");
                    var extractedId = (int)propertyC.GetValue(currT, null);
                    if (extractedId == interestingId)
                    {
                        gefundenIndex = index;
                        break;
                    }
                    index++;

                }
            }
            if (index != -1)
                liste.RemoveAt(index);
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
            try
            {
                using (StreamReader readfile = new StreamReader(filename))
                {
                    string line;
                    while ((line = readfile.ReadLine()) != null)
                        liste.Add(new JavaScriptSerializer().Deserialize<T>(line));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Filelesen geht ned:" + filename);
                Console.WriteLine(e.Message);
            }
        }

        public virtual void SavetoFile(string filename)
        {
            try
            {
                using (StreamWriter writefile = new StreamWriter(filename))
                {
                    foreach (var objekt in liste)
                        writefile.WriteLine(serialize2String(objekt));
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
            foreach (T currT in liste)
            {
                var propertyC = currT.GetType().GetProperty("Id");
                var extractedId = (int)propertyC.GetValue(currT, null);
                if (extractedId == Id)
                    return currT;
            }
            return default(T);
        }

        public virtual List<T> ReadAll()
        {
            return liste;
        }
    }
}
