using System;
using System.Collections.Generic;
using meat.worker_distribution;

namespace meat
{
    public class MonumentStore
    {
        public virtual void add(IEnumerable<AddWorkersToMonument> workers_added_to_monuments)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Monument> get_completed()
        {
            throw new NotImplementedException();
        }

        public virtual bool has(Monument monument)
        {
            throw new NotImplementedException();
        }
    }
}