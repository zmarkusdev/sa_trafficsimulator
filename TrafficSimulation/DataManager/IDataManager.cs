using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public interface IDataManager
    {
        /// <summary>
        /// Prepare dependencies to data access and build object graph
        /// </summary>
        void Initialize();

        /// <summary>
        /// Start synchronization (dynamic rules should be fetched here periodically)
        /// </summary>
        void Start();

        void Stop();
    }
}
