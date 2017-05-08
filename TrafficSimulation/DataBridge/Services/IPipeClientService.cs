using DataModel.Pipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBridge.Services
{
    public interface IPipeClientService
    {
        void handleReturnValue(PipeDTO dto);
    }
}
