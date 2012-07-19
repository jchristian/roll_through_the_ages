using System.Collections.Generic;
using System.Linq;

namespace meat
{
    public class Game
    {
        readonly IEnumerable<Player> players;
        IReturnTheNextPlayer turn_queue;
        ICheckForEndingConditions ending_condition_checker;
        IScoreATurn scorer;

        public Game(IEnumerable<Player> players, ICreateATurnQueue turn_queue_factory, ICheckForEndingConditions ending_condition_checker, IScoreATurn scorer)
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

        public void score_turn(Turn turn)
        {
            scorer.score(turn, players);
        }
    }
}