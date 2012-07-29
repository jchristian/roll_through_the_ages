using System.Collections.Generic;

namespace meat.development_purchasing
{
    public class DevelopmentPurchase
    {
        public Player player { get; set; }
        public bool was_development_purchased { get; set; }
        public Development development { get; set; }
        public IEnumerable<Good> goods_sold { get; set; }
        public int food_sold { get; set; }
    }
}