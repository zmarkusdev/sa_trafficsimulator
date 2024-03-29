﻿///////////////////////////////////////////////////////////
//  IEdgeRepository.cs
//  Implementation of the Interface IEdgeRepository
//  Generated by Enterprise Architect
//  Created on:      18-Apr-2017 20:10:14
//  Original author: David
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Datamodel;

namespace Repositories
{
    /// <summary>
    /// IEdgeRepository
    /// </summary>
    public interface IEdgeRepository
    {

        /// <summary>
        /// Creates new edge.
        /// </summary>
        /// <param name="edge">Edge to create</param>
        /// <returns>Created edge</returns>
        Datamodel.Edge Create(Edge edge);

        /// <summary>
        /// Deletes given edge.
        /// </summary>
        /// <param name="edge">Edge to delete</param>
        void Delete(Edge edge);

        /// <summary>
        /// Get edge by id.
        /// </summary>
        /// <param name="edgeId">Id of edge</param>
        /// <returns>Edge or null</returns>
        Edge GetEdge(int edgeId);

        /// <summary>
        /// Updates given edge.
        /// </summary>
        /// <param name="edge">Edge to update</param>
        /// <returns>Updated edge</returns>
        Edge Update(Edge edge);

        /// <summary>
        /// Get all edges.
        /// </summary>
        /// <returns>List of edges or null</returns>
        IEnumerable<Edge> GetAll();
    }
}
