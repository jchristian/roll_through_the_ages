namespace meat.excess_good_discarding
{
    public class ExcessGoodsDiscarder
    {
        public virtual void update_for(DiscardExcessGoods discard_excess_goods)
        {
            foreach(var good in discard_excess_goods.goods)
                discard_excess_goods.player.remove(good.good, good.quantity);
        }
    }
}