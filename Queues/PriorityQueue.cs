﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public interface PriorityQueue : Queue
    {
        new object dequeue();
        new object peek();
    }
}
