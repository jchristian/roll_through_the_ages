using System.Collections.Generic;

namespace meat
{
    public class GameRunner
    {
        Game current_game;
        IUpdateTheScoreForATurn score_updater;

        public GameRunner(IUpdateTheScoreForATurn scoreUpdater)
        {
            score_updater = scoreUpdater;
        }

        public Game play_new_game(IEnumerable<Player> players)
        {
            current_game = new Game(players, null, null);
            current_game.start_next_turn();

            return current_game;
        }

        public void move_submitted(Move move)
        {
            score_updater.update(move);

            if(!current_game.is_over)
                current_game.start_next_turn();
        }
    }
}