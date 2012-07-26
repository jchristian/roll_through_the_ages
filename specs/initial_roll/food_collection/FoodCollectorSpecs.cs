using Machine.Specifications;
using developwithpassion.specifications.nsubstitue;
using meat;
using meat.initial_roll;
using meat.initial_roll.food_collection;

namespace specs.initial_roll.food_collection
{
    public class FoodCollectorSpecs
    {
        public abstract class concern : Observes<FoodCollector> { }

        [Subject(typeof(FoodCollector))]
        public class when_collecting_food : concern
        {
            public class and_the_player_rolls_food
            {
                Establish c = () =>
                {
                    initial_food = 5;

                    var player = new Player("", fake.an<GoodStore>());
                    player.food = initial_food;

                    die_one = new Die { food = 3 };
                    die_two = new Die { food = 2 };

                    initial_roll = new InitialRoll { dice = new[] { die_one, die_two }, player = player };

                    depends.on(new FoodCalculatorRegistry());
                };

                Because of = () =>
                    sut.collect(initial_roll);

                It should_add_the_rolled_quantity_of_food = () =>
                    initial_roll.player.food.ShouldEqual(initial_food + die_one.food + die_two.food);

                static InitialRoll initial_roll;
                static int initial_food;
                static Die die_one;
                static Die die_two;
            }

            public class and_the_player_rolls_food_with_agriculture
            {
                Establish c = () =>
                {
                    initial_food = 5;

                    var player = new Player("", fake.an<GoodStore>());
                    player.add(Development.Agriculture);
                    player.food = initial_food;

                    die_one = new Die { food = 3 };
                    die_two = new Die { food = 2 };

                    initial_roll = new InitialRoll { dice = new[] { die_one, die_two }, player = player };

                    depends.on(new FoodCalculatorRegistry());
                };

                Because of = () =>
                    sut.collect(initial_roll);

                It should_add_the_an_extra_food_for_every_food_die = () =>
                    initial_roll.player.food.ShouldEqual(initial_food + (die_one.food + 1) + (die_two.food + 1));

                static InitialRoll initial_roll;
                static int initial_food;
                static Die die_one;
                static Die die_two;
            }
        }
    }
}