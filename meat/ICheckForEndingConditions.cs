using System.Collections.Generic;

namespace meat
{
    public interface ICheckForEndingConditions
    {
        bool has_any(IEnumerable<Player> players);
    }
}