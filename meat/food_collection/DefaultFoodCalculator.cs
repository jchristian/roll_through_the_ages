namespace meat.food_collection
{
    public class DefaultFoodCalculator : ICalculateTheFoodFromADice
    {
        public int calculate(Die die)
        {
            return die.food;
        }
    }
}