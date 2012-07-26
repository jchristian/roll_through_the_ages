using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.nsubstitue;
using meat;
using meat.initial_roll;
using meat.initial_roll.city_feeding;
using meat.initial_roll.food_collection;

namespace specs.initial_roll.city_feeding
{
    public class CityFeederSpecs
    {
        public abstract class concern : Observes<CityFeeder> { }

        [Subject(typeof(CityFeeder))]
        public class when_feeding_cities : concern
        {
            Establish c = () =>
            {
                initial_food = 6;

                var player = new Player("", fake.an<GoodStore>());
                player.food = initial_food;
                player.cities = 5;

                initial_roll = new InitialRoll { dice = Enumerable.Empty<Die>(), player = player };
                depends.on(new FoodCollector(new FoodCalculatorRegistry()));
            };

            Because of = () =>
                sut.feed(initial_roll.player);

            It should_remove_one_food_per_city = () =>
                initial_roll.player.food.ShouldEqual(initial_food - initial_roll.player.cities);

            static InitialRoll initial_roll;
            static int initial_food;
        }
    }
}