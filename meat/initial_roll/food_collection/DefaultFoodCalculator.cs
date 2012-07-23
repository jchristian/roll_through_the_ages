namespace meat.initial_roll.food_collection
{
    public class DefaultFoodCalculator : ICalculateTheFoodFromADice
    {
        public int calculate(Die die)
        {
            return die.food;
        }
    }
}