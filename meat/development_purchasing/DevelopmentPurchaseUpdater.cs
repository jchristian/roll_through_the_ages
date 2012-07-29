namespace meat.development_purchasing
{
    public class DevelopmentPurchaseUpdater
    {
        public virtual void update_for(DevelopmentPurchase development_purchase)
        {
            if(development_purchase.was_development_purchased)
            {
                development_purchase.player.add(development_purchase.development);
                development_purchase.player.remove_goods(development_purchase.goods_sold);
                development_purchase.player.remove_food(development_purchase.food_sold);
            }
        }
    }
}