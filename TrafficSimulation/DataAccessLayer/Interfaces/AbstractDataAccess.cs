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
    public abstract class AbstractDataAccess<T>
    {
        List<T> liste = new List<T>();
        private int uniqueId = 0;
        private string datafileprefix = "datafile_";
        private string datafileextension = ".txt";


        public int getuniqueId()
        {
            return uniqueId++;
        }
        public virtual void Init()
        {
            liste = new List<T>();
            uniqueId = 0;
        }

        public virtual T Create(T objekt)
        {
            if (getObjectId(objekt) == 0)
                objekt = setObjectId(objekt, getuniqueId());
            liste.Add(objekt);
            return objekt;
        }

        public virtual void Update(T objekt)
        {
            T gefunden = default(T);
            int interestingId = getObjectId(objekt);

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

            int interestingId = getObjectId(objekt);

            if (liste != null)
            {
                foreach (var currT in liste)
                {
                    int extractedId = getObjectId(objekt);
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
                using (StreamReader readfile = new StreamReader(getfilenamePrefix() + filename + getfilenameExtension()))
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
                using (StreamWriter writefile = new StreamWriter(getfilenamePrefix() + filename + getfilenameExtension()))
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
                int extractedId = getObjectId(currT);

                if (extractedId == Id)
                    return currT;
            }
            return default(T);
        }

        public virtual List<T> ReadAll()
        {
            return liste;
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
