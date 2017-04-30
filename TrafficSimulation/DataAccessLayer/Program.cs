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
            DataAccessCommon commons = DataAccessCommon.getInstance();

            AbstractDataAccess<Position> positionDataAccess = PositionDataAccessFactory.CreateRepository(); // new PositionDataAccess();
            AbstractDataAccess<Edge> edgeDataAccess = EdgeDataAccessFactory.CreateRepository();
            AbstractDataAccess<Agent> agentDataAccess = AgentDataAccessFactory.CreateRepository();

            bool laden = true;

            if (!laden == true)
            {
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

                positionDataAccess.SavetoFile(commons.getfilenamePrefix() + "position" + commons.getfilenameExtension());

                Edge edge1 = new Edge();
                Edge edge2 = new Edge();
                Edge edge3 = new Edge();
                Edge edge4 = new Edge();
                Edge edge5 = new Edge();

                edge1.Id = 1;
                edge1.StartPositionId = 1;
                edge1.EndPositionId = 2;
                edge1.CurveLength = 160;
                edge1 = edgeDataAccess.Create(edge1);

                edge2.Id = 2;
                edge2.StartPositionId = 2;
                edge2.EndPositionId = 3;
                edge2.CurveLength = (int)Math.Round(Math.Sqrt(8) * 10);
                edge2 = edgeDataAccess.Create(edge2);

                edge3.Id = 3;
                edge3.StartPositionId = 3;
                edge3.EndPositionId = 4;
                edge3.CurveLength = 300;
                edge3 = edgeDataAccess.Create(edge3);

                edge4.Id = 4;
                edge4.StartPositionId = 2;
                edge4.EndPositionId = 5;
                edge4.CurveLength = (int)Math.Round(Math.Sqrt(8) * 10);
                edge4 = edgeDataAccess.Create(edge4);

                edge5.Id = 5;
                edge5.StartPositionId = 5;
                edge5.EndPositionId = 6;
                edge5.CurveLength = 100;
                edge5 = edgeDataAccess.Create(edge5);

                edgeDataAccess.SavetoFile(commons.getfilenamePrefix() + "edge" + commons.getfilenameExtension());

                Agent agent1 = new Agent();
                Agent agent2 = new Agent();

                Random random = new Random();
                for (int i = 0; i < 100; i++)
                {
                    Agent agentX = new Agent();
                    agentX.Acceleration = (int)2 + random.Next(2);
                    agentX.CurrentVelocity = 0;
                    agentX.Deceleration = (int)7 - random.Next(2);
                    agentX.EdgeId = (i % 5) + 1;
                    agentX.RunLength = 25 + random.Next(50);
                    agentX.Type = (AgentType)1;
                    agentX.VehicleLength = 4;
                    agentX.VehicleWidth = 2;
                    agentDataAccess.Create(agentX);
                }

                agent2.Acceleration = 5;
                agent2.CurrentVelocity = 0;
                agent2.Deceleration = 4;
                agent2.EdgeId = 1;
                agent2.RunLength = 5;
                agent2.Type = (AgentType)1;
                agent2.VehicleLength = 4;
                agent2.VehicleWidth = 2;
                agentDataAccess.Create(agent2);

                agentDataAccess.SavetoFile(commons.getfilenamePrefix() + "agent" + commons.getfilenameExtension());

            }
            else
            {
                positionDataAccess.LoadfromFile(commons.getfilenamePrefix() + "position" + commons.getfilenameExtension());
                edgeDataAccess.LoadfromFile(commons.getfilenamePrefix() + "edge" + commons.getfilenameExtension());
                agentDataAccess.LoadfromFile(commons.getfilenamePrefix() + "agent" + commons.getfilenameExtension());

                Position readPosi = positionDataAccess.ReadbyId(3);
                Agent readAgent = agentDataAccess.ReadbyId(999);

            }
        }
    }
}
