using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.nsubstitue;
using meat;
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

                active_player = new Player("", fake.an<GoodStore>());
                active_player.food = initial_food;
                active_player.cities = 5;

                initial_roll = new InitialRoll { dice = Enumerable.Empty<Die>(), player = active_player };
                depends.on(new FoodCollector(new FoodCalculatorRegistry()));
            };

            Because of = () =>
                sut.feed(initial_roll.player);

            It should_remove_one_food_per_city = () =>
                active_player.food.ShouldEqual(initial_food - active_player.cities);

            static InitialRoll initial_roll;
            static Player active_player;
            static int initial_food;
        }
    }
}