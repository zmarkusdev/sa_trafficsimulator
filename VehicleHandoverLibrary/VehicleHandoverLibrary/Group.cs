using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHandoverLibrary
{

    /// <summary>
    /// Enum for selecting the groups
    /// </summary>
    public enum Groups
    {
        /// <summary>
        /// Group 1
        /// </summary>
        GROUP01,
        /// <summary>
        /// Group 2
        /// </summary>
        GROUP02,
        /// <summary>
        /// Group 3
        /// </summary>
        GROUP03
    }

    class Group
    {

        // Returns the Queue URL for a group
        public static String getUrlForGroup (Groups group)
        {
            switch(group)
            {
                case Groups.GROUP01:
                    return "https://sqs.us-east-2.amazonaws.com/047952185359/vehicle-handover-01.fifo";
                case Groups.GROUP02:
                    return "https://sqs.us-east-2.amazonaws.com/047952185359/vehicle-handover-02.fifo";
                case Groups.GROUP03:
                    return "https://sqs.us-east-2.amazonaws.com/047952185359/vehicle-handover-03.fifo";
            }
            throw new ArgumentException("Provided Invalid Group");
        }
    }
}
