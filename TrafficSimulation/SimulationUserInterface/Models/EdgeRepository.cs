using Datamodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationUserInterface.Models
{
    public class EdgeRepository
    {
        private double XScaleFactor { get; set; }
        private double YScaleFactor { get; set; }

        public ObservableCollection<EdgeModel> MapEdges { get; set; }

        public EdgeRepository()
        {
            MapEdges = new ObservableCollection<EdgeModel>();
        }

        public void SetScaleFactors(double xmapsscale, double ymapscale)
        {
            try
            {
                XScaleFactor = (xmapsscale == 0.0) ? 1 : xmapsscale;
                YScaleFactor = (ymapscale == 0.0) ? 1 : ymapscale;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DrawEdges(IEnumerable<Position> position, IEnumerable<Edge> edges)
        {
            try
            {
                MapEdges.Clear();

                foreach (Edge singleEdge in edges)
                {
                    int startPositionId = singleEdge.StartPositionId;
                    int endPositionId = singleEdge.EndPositionId;

                    Position startposition = position.Where(var => var.Id == startPositionId).ToList().First();
                    Position endposition = position.Where(var => var.Id == endPositionId).ToList().First();

                    MapEdges.Add(new EdgeModel(startposition.X, startposition.Y, endposition.X, endposition.Y, XScaleFactor, YScaleFactor));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
