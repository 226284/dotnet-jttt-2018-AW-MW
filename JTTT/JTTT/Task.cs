﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Task
    {
        protected Action Action;
        protected Condition Condition;
        protected Log Log;

        public Task(Action action, Condition condition, Log log)
        {
            Log = log;
            Action = action;
            Condition = condition;
        }

        public override string ToString()
        {
            return String.Format("If: {0} Then: {1}", Action.ToString(), Condition.ToString());
        }
    }
}
