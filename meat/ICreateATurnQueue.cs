using System.Collections.Generic;

namespace meat
{
    public interface ICreateATurnQueue
    {
        IReturnTheNextPlayer create(IEnumerable<Player> players);
    }

    public class TurnQueueFactory : ICreateATurnQueue
    {
        public IReturnTheNextPlayer create(IEnumerable<Player> players)
        {
            return new TurnQueue(players);
        }
    }
}