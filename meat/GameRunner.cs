using System.Collections.Generic;

namespace meat
{
    public class GameRunner
    {
        Game current_game;

        public Game play_new_game(IEnumerable<Player> players)
        {
            current_game = new Game(players, null, null, null);
            current_game.start_next_turn();

            return current_game;
        }

        public void turn_submitted(Turn turn)
        {
            current_game.score_turn(turn);

            if(!current_game.is_over)
                current_game.start_next_turn();
        }
    }
}