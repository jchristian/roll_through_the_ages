namespace meat.worker_distribution
{
    public class WorkerDistributionUpdater
    {
        public virtual void update_for(WorkerDistribution worker_distribution)
        {
            worker_distribution.player.add_workers_to_cities(worker_distribution.workers_added_to_cities);
            worker_distribution.player.add_workers_to_monuments(worker_distribution.workers_added_to_monuments);
        }
    }
}