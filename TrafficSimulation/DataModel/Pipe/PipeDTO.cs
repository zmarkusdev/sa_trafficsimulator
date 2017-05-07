using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Pipe
{
    public class PipeDTO
    {
        private Guid transferId { get; set; }
        private PipeCommand command { get; set; }
        private Object transferObject { get; set; }

        public PipeDTO(Guid id, PipeCommand command, Object obj)
        {
            this.transferId = id;
            this.transferObject = obj;
            this.command = command;
        }

    }
}
