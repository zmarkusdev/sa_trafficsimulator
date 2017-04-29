using DataAccessLayer.Services;
using Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //IDataAccessLayerRepository dal = DataAccessLayerRepositoryFactory.CreateRepository();
            //dal.SavetoFile();

            PositionDataAccess positionDataAccess = new PositionDataAccess();
            Position posi1 = new Position();
            Position posi2 = new Position();
            Position posi3 = new Position();
            Position posi4 = new Position();
            Position posi5 = new Position();
            Position posi6 = new Position();

            posi1.MaxVelocity = 50;
            posi1.PredecessorEdgeIds = new List<int>();
            posi1.Rotation = 0;
            posi1.RuleIds = new List<int>();
            posi1.SuccessorEdgeIds = new List<int>(1);
            posi1.X = 40;
            posi1.Y = 300;
            positionDataAccess.Create(posi1);

            posi2.MaxVelocity = 50;
            posi2.PredecessorEdgeIds = new List<int>(1);
            posi2.Rotation = 0;
            posi2.RuleIds = new List<int>();
            List<int> liste = new List<int>();
            liste.Add(2);
            liste.Add(4);
            posi2.SuccessorEdgeIds = liste;
            posi2.X = 250;
            posi2.Y = 300;
            positionDataAccess.Create(posi2);

            posi3.MaxVelocity = 50;
            posi3.PredecessorEdgeIds = new List<int>(2);
            posi3.Rotation = 0;
            posi3.RuleIds = new List<int>();
            posi3.SuccessorEdgeIds = new List<int>(3);
            posi3.X = 350;
            posi3.Y = 370;
            positionDataAccess.Create(posi3);

            posi4.MaxVelocity = 50;
            posi4.PredecessorEdgeIds = new List<int>(4);
            posi4.Rotation = 0;
            posi4.RuleIds = new List<int>();
            posi4.SuccessorEdgeIds = new List<int>(5);
            posi4.X = 350;
            posi4.Y = 550;
            positionDataAccess.Create(posi4);

            posi5.MaxVelocity = 50;
            posi5.PredecessorEdgeIds = new List<int>(5);
            posi5.Rotation = 0;
            posi5.RuleIds = new List<int>();
            posi5.SuccessorEdgeIds = new List<int>();
            posi5.X = 430;
            posi5.Y = 230;
            positionDataAccess.Create(posi5);

            posi6.MaxVelocity = 50;
            posi6.PredecessorEdgeIds = new List<int>(3);
            posi6.Rotation = 0;
            posi6.RuleIds = new List<int>();
            posi6.SuccessorEdgeIds = new List<int>();
            posi6.X = 420;
            posi6.Y = 20;
            positionDataAccess.Create(posi6);

            positionDataAccess.SavetoFile("savezumTesten.txt");
        }
    }
}
