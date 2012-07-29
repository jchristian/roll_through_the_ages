using System.Collections.Generic;
using meat.initial_roll;

namespace meat
{
    public class GameRunner
    {
        Game current_game;

        public Game play_new_game(IEnumerable<Player> players)
        {
            current_game = new Game(players, null, null, null, null, null);
            current_game.start_next_turn();

            return current_game;
        }

        public void score_initial_roll(InitialRoll initial_roll)
        {
            current_game.update_for(initial_roll);

            if(!current_game.is_over)
                current_game.start_next_turn();
        }
    }
}