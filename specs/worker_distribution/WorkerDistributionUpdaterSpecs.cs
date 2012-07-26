using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.nsubstitue;
using meat;
using meat.worker_distribution;

namespace specs.worker_distribution
{
    public class WorkerDistributionUpdaterSpecs
    {
        public abstract class concern : Observes<WorkerDistributionUpdater> {}

        [Subject(typeof(WorkerDistributionUpdater))]
        public class when_updating_for_worker_distribution : concern
        {
            public class and_workers_should_be_added_to_cities
            {
                Establish c = () =>
                {
                    worker_distribution = new WorkerDistribution { player = fake.an<Player>(), workers_added_to_cities = 3 };
                };

                Because of = () =>
                    sut.update_for(worker_distribution);

                It should_distribute_the_workers_to_cities = () =>
                    worker_distribution.player.received(x => x.add_workers_to_cities(worker_distribution.workers_added_to_cities));

                static WorkerDistribution worker_distribution;
            }

            public class and_workers_should_be_added_to_monuments
            {
                Establish c = () =>
                {
                    worker_distribution = new WorkerDistribution
                    {
                        player = fake.an<Player>(),
                        workers_added_to_monuments = new[]
                        {
                            new AddWorkersToMonument { monument = Monument.StepPyramid, workers = 3 },
                            new AddWorkersToMonument { monument = Monument.GreatWall, workers = 2 }
                        }
                    };
                };

                Because of = () =>
                    sut.update_for(worker_distribution);

                It should_distribute_the_workers_to_cities = () =>
                    worker_distribution.player.received(x => x.add_workers_to_monuments(worker_distribution.workers_added_to_monuments));

                static WorkerDistribution worker_distribution;
            }
        }
    }
}
