namespace meat.initial_roll.food_collection
{
    public class AgricultureFoodCalculator : ICalculateTheFoodFromADice
    {
        public int calculate(Die die)
        {
            return is_food_die(die) ? die.food + 1 : die.food;
        }

        public bool is_food_die(Die die)
        {
            return die.food > 0;
        }
    }
}