using Datamodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace DataAccessLayer
{
    class MockedDataAccessLayer : IDataAccessLayerRepository
    {
        Map map = null;
        List<Position> positions = null;
        List<Edge> edges = null;
        List<DynamicEdge> dynamicEdges = null;
        List<Agent> agents = null;
        List<Rule> rules = null;

        private static MockedDataAccessLayer dalInstance = null;
        private MockedDataAccessLayer() { }
        public static MockedDataAccessLayer getInstance()
        {
            if (dalInstance == null)
            {
                dalInstance = new MockedDataAccessLayer();
                dalInstance.Init();
            }
            return dalInstance;
        }

        public void Init()
        {
        }

        public void LoadfromFile()
        {
            throw new NotImplementedException();
        }

        public void SavetoFile()
        {
            List<string> zeilenweise = new List<string>();
            List<Position> plasmaplopp = new List<Position>();

            Position posi = new Position();
            posi.MaxVelocity = 50;
            posi.PredecessorEdgeIds = new List<int>(1);
            posi.Rotation = 99;
            posi.X = 300;
            posi.Y = 200;
            var json = new JavaScriptSerializer().Serialize(posi);

            zeilenweise.Add(json);

            posi.MaxVelocity = 80;
            posi.Id = 899;
            posi.PredecessorEdgeIds = new List<int>(6);
            posi.Rotation = 12;
            posi.X = 22;
            posi.Y = 2;

            json = new JavaScriptSerializer().Serialize(posi);
            zeilenweise.Add(json);

            posi.MaxVelocity = 20;
            posi.Id = 239;
            posi.PredecessorEdgeIds = new List<int>(9);
            posi.Rotation = 2;
            posi.X = 360;
            posi.Y = 19;

            json = new JavaScriptSerializer().Serialize(posi);
            zeilenweise.Add(json);

            try
            {
                using (StreamWriter writetext = new StreamWriter("database.txt"))
                {
                    foreach (var x in zeilenweise)
                        writetext.WriteLine(x);
                }
            }
            catch (Exception e)
            {

                // Let the user know what went wrong.
                Console.WriteLine("The file could not be written:");
                Console.WriteLine(e.Message);
            }
            // -------------- und nachher wieder reinlesen 
            try
            {
                using (StreamReader readtext = new StreamReader("database.txt"))
                {
                    string line;
                    // Read and display lines from the file until 
                    // the end of the file is reached. 
                    while ((line = readtext.ReadLine()) != null)
                    {
                        Position piso = new JavaScriptSerializer().Deserialize<Position>(line);
                        plasmaplopp.Add(piso);
                    }
                }
            }
            catch (Exception e)
            {

                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
