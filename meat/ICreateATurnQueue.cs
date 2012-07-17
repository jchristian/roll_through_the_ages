using System.Collections.Generic;

namespace meat
{
    public interface ICreateATurnQueue {
        IReturnTheNextPlayer create(IEnumerable<Player> players);
    }
}