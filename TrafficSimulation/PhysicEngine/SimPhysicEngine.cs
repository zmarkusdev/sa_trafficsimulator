using DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PhysicEngine
{
    public class SimPhysicEngine : IPhysicEngine
    {
        private readonly IDataManager dataManager_;
        private Timer physicsTimer;
        private const int timerInterval = 1000 / 25; // 25 fps

        public SimPhysicEngine(IDataManager dataManager)
        {
            dataManager_ = dataManager;
        }

        public void Start()
        {
            physicsTimer = new Timer();
            physicsTimer.Elapsed += new ElapsedEventHandler(TimerTick);
            physicsTimer.Interval = timerInterval;
            physicsTimer.Enabled = true;
            
        }

        public void Stop()
        {
            physicsTimer.Enabled = false;
        }

        private void TimerTick(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Physic engine tick!");
        }
    }
}
