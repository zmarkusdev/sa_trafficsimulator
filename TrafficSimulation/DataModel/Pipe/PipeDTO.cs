using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Pipe
{
    public class PipeDTO
    {
        public Guid transferId { get; set; }
        public PipeCommand command { get; set; }
        public Object transferObject { get; set; }

        public PipeDTO(Guid id, PipeCommand command, Object obj)
        {
            this.transferId = id;
            this.transferObject = obj;
            this.command = command;
        }

    }
}
