using System.Linq;

namespace meat.food_collection
{
    public class FoodCollector
    {
        FoodCalculatorRegistry food_calculator_registry;

        protected FoodCollector() {}
        public FoodCollector(FoodCalculatorRegistry foodCalculatorRegistry)
        {
            food_calculator_registry = foodCalculatorRegistry;
        }

        public virtual void collect(Turn turn)
        {
            var food_collector_for_die = food_calculator_registry.get(turn.player);
            turn.player.food += turn.dice.Sum(x => food_collector_for_die.calculate(x));
        }
    }
}