using System.Collections.Generic;

namespace meat
{
    public class game
    {
        public game(IEnumerable<Player> players)
        { }

        public object current_turn { get; set; }
        public bool is_over { get; private set; }

        public void start_next_turn()
        {
             
        }
    }

    public class game_runner
    {
        public void play_new_game(IEnumerable<Player> players)
        {
            var game = new game(players);

            while(!game.is_over)
            {
                game.start_next_turn();
                display(game.current_turn);
            }
        }

        public void display(object model) { }
    }

    public class Player {}
}