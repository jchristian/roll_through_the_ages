namespace meat.food_collection
{
    public class FoodCalculatorRegistry
    {
        public virtual ICalculateTheFoodFromADice get(Player player)
        {
            if(player.has(Development.Agriculture))
                return new AgricultureFoodCalculator();
            return new DefaultFoodCalculator();
        }
    }
}