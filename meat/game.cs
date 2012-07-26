using System.Collections.Generic;
using meat.initial_roll;
using meat.worker_distribution;

namespace meat
{
    public class Game
    {
        IEnumerable<Player> players;
        IReturnTheNextPlayer turn_queue;
        ICheckForEndingConditions ending_condition_checker;
        InitialRollUpdater initial_roll_updater;
        WorkerDistributionUpdater worker_distribution_updater;

        public Game(IEnumerable<Player> players,
            ICreateATurnQueue turn_queue_factory,
            ICheckForEndingConditions ending_condition_checker,
            InitialRollUpdater initial_roll_updater,
            WorkerDistributionUpdater worker_distribution_updater)
        {
            this.players = players;
            this.ending_condition_checker = ending_condition_checker;
            turn_queue = turn_queue_factory.create(players);

            this.initial_roll_updater = initial_roll_updater;
            this.worker_distribution_updater = worker_distribution_updater;
        }

        public Player current_turn { get; private set; }
        public bool is_over { get { return ending_condition_checker.has_any(players); } }

        public void start_next_turn()
        {
            current_turn = turn_queue.next();
        }

        public void update_for(InitialRoll initial_roll)
        {
            initial_roll_updater.update_for(initial_roll);
        }

        public void update_for(WorkerDistribution worker_distribution)
        {
            worker_distribution_updater.update_for(worker_distribution);
        }
    }
}