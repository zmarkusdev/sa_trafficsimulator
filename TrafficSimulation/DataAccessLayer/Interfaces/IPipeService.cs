using DataModel.Pipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IPipeService
    {

        /// <summary>
        /// Entrypoint for the controller to call a specific function.
        /// </summary>
        /// <param name="dto">Object which holds all neccessary information</param>
        void executeCommand(PipeDTO dto);
    }
}
