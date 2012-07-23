using System.Linq;

namespace meat.initial_roll.goods_collection
{
    public class GoodCollector
    {
        public virtual void collect(InitialRoll initial_roll)
        {
            initial_roll.player.add_goods(initial_roll.dice.Sum(x => x.goods));
        }
    }
}