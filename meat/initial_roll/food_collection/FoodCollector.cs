using System.Linq;

namespace meat.initial_roll.food_collection
{
    public class FoodCollector
    {
        FoodCalculatorRegistry food_calculator_registry;

        protected FoodCollector() {}
        public FoodCollector(FoodCalculatorRegistry foodCalculatorRegistry)
        {
            food_calculator_registry = foodCalculatorRegistry;
        }

        public virtual void collect(InitialRoll initial_roll)
        {
            var food_collector_for_die = food_calculator_registry.get(initial_roll.player);
            initial_roll.player.food += initial_roll.dice.Sum(x => food_collector_for_die.calculate(x));
        }
    }
}