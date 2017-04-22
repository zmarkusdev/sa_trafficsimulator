﻿using DataManager.MappingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    /// <summary>
    /// Data manager interface for local memory management of the simulation components.
    /// </summary>
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

        /// <summary>
        /// Stops the synchronization
        /// </summary>
        void Stop();

        /// <summary>
        /// Updates the given agent in the data access component
        /// </summary>
        /// <param name="updateAgent">The agent that needs to be updated</param>
        void Update(SimAgent updateAgent);
    }
}
