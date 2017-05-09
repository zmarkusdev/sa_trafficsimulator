using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHandoverLibrary
{
    public enum Groups { GROUP01, GROUP02, GROUP03 }

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
