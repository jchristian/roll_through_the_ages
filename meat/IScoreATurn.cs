using System.Collections.Generic;

namespace meat
{
    public interface IScoreATurn
    {
        void score(Turn turn, IEnumerable<Player> players);
    }
}