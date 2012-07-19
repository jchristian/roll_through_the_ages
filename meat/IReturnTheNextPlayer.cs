using System.Collections.Generic;
using System.Linq;

namespace meat
{
    public interface IReturnTheNextPlayer {
        Player next();
    }

    public class TurnQueue : IReturnTheNextPlayer
    {
        int current_player_index;
        IEnumerable<Player> players;

        public TurnQueue(IEnumerable<Player> players)
        {
            this.players = players;
            current_player_index = 0;
        }

        public Player next()
        {
            if (current_player_index == players.Count())
                current_player_index = 0;

            return players.ElementAt(current_player_index++);
        }
    }
}