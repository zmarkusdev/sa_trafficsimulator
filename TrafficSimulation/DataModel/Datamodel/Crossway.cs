﻿///////////////////////////////////////////////////////////
//  Crossway.cs
//  Implementation of the Crossway (Ampellichter, die von 
//  einer Ampel verwaltet werden
//  Generated by Enterprise Architect
//  Created on:      01-Jun-2017 17:37:23
//  Original author: maxi
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datamodel
{
        public class Crossway
    {
        public Crossway()
        {
            greenphase = new List<CrosswayDirection>();
        }
        /// <summary>
        /// Kommentar
        /// </summary>
        public int Id
        {
            get;
            set;
        }
        
        public List<CrosswayDirection> greenphase;

    } //end Crossway

}//end namespace Datamodel