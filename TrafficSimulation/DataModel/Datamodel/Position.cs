///////////////////////////////////////////////////////////
//  Position.cs
//  Implementation of the Class Position
//  Generated by Enterprise Architect
//  Created on:      15-Apr-2017 16:36:48
//  Original author: David
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Datamodel {
    public class Position : BaseModel {

        public Position() {

        }

        ~Position() {

        }

        public int MaxVelocity {
            get;
            set;
        }

        public IEnumerable<int> PredecessorEdgeIds{
			get;
			set;
		}

		public int Rotation{
			get;
			set;
		}

		public IEnumerable<int> RuleIds
        {
			get;
			set;
		}

		public IEnumerable<int> SuccessorEdgeIds
        {
			get;
			set;
		}

		public int X{
			get;
			set;
		}

		public int Y{
			get;
			set;
		}

	}//end Position

}//end namespace Datamodel