using System.Collections.Generic;
using meat.initial_roll;

namespace meat
{
    public class Game
    {
        readonly IEnumerable<Player> players;
        IReturnTheNextPlayer turn_queue;
        ICheckForEndingConditions ending_condition_checker;
        InitialRollScorer scorer;

        public Game(IEnumerable<Player> players, ICreateATurnQueue turn_queue_factory, ICheckForEndingConditions ending_condition_checker, InitialRollScorer scorer)
        {
            this.players = players;
            this.ending_condition_checker = ending_condition_checker;
            this.scorer = scorer;
            turn_queue = turn_queue_factory.create(players);
        }

        public Player current_turn { get; private set; }
        public bool is_over { get { return ending_condition_checker.has_any(players); } }

        public void start_next_turn()
        {
            current_turn = turn_queue.next();
        }

        public void score_initial_roll(InitialRoll initial_roll)
        {
            scorer.score(initial_roll);
        }
    }
}