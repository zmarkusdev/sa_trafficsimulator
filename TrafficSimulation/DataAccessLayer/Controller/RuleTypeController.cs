﻿using DataModel.Pipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Controller
{
    class RuleTypeController : AbstractPipeServer
    {
        public RuleTypeController() : base()
        {
            createPipe(PipeUtil.RULE_TYPE());
        }

        public override void read<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public override void run(string pipeName)
        {
            throw new NotImplementedException();
        }

        public override void write<T>(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
