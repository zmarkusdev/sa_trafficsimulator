using Datamodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationUserInterface.Models
{
    public class PositionRepository
    {
        private double XScaleFactor { get; set; }
        private double YScaleFactor { get; set; }

        public ObservableCollection<PositionModel> MapPositions { get; set; }

        public PositionRepository()
        {
            MapPositions = new ObservableCollection<PositionModel>();
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

        public void DrawPositions(IEnumerable<Position> positions)
        {
            try
            {
                MapPositions.Clear();

                foreach (Position singleposition in positions)
                {
                    MapPositions.Add(new PositionModel(singleposition.X, singleposition.Y, XScaleFactor, YScaleFactor));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
