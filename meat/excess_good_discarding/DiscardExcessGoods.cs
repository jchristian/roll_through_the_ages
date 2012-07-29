using System.Collections.Generic;

namespace meat.excess_good_discarding
{
    public class DiscardExcessGoods
    {
        public Player player { get; set; }
        public IEnumerable<DiscardGoods> goods { get; set; }
    }
}