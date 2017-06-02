///////////////////////////////////////////////////////////
//  IAgentRepository.cs
//  Implementation of the Interface IAgentRepository
//  Generated by Enterprise Architect
//  Created on:      15-Apr-2017 16:36:47
//  Original author: David
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using Datamodel;
namespace Repositories {
	/// <summary>
	/// end IAgentRepository
	/// </summary>
	public interface IAgentRepository         {

		/// 
		/// <param name="agent"></param>
		Datamodel.Agent Create(Agent agent);

		/// 
		/// <param name="agent"></param>
		void Delete(Agent agent);

		/// 
		/// <param name="agentId"></param>
		Datamodel.Agent GetAgent(int agentId);

		/// <summary>
		/// TODO: List
		/// </summary>
		/// <param name="positionIds"></param>
		IEnumerable<Agent> GetAgentsForPositionIds(int positionIds);

        /// <summary>
        /// TODO: List
        /// </summary>
        IEnumerable<Agent> GetAllAgents();

		/// 
		/// <param name="agent"></param>
		Datamodel.Agent Update(Agent agent);

        void BulkUpdate(IEnumerable<Agent> agents);
	}//end IAgentRepository

}//end namespace Repositories