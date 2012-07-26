using System.Collections.Generic;

namespace meat.worker_distribution
{
    public class WorkerDistribution
    {
        public Player player { get; set; }
        public int workers_added_to_cities { get; set; }
        public IEnumerable<AddWorkersToMonument> workers_added_to_monuments { get; set; }
    }

    public class AddWorkersToMonument
    {
        public Monument monument { get; set; }
        public int workers { get; set; }
    }
}