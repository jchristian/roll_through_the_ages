using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using meat;
using meat.initial_roll;
using meat.initial_roll.city_feeding;
using meat.initial_roll.disaster_resolution;
using meat.initial_roll.food_collection;
using meat.initial_roll.goods_collection;

namespace specs
{
    public class InitialScorerSpecs
    {
        public abstract class concern : Observes<InitialRollScorer> { }

        [Subject(typeof(InitialRollScorer))]
        public class when_scoring_an_initial_roll : concern
        {
            Establish c = () =>
            {
                active_player = new Player("", fake.an<GoodStore>());
                initial_roll = new InitialRoll { player = active_player };
                
                good_collector = depends.on<GoodCollector>();
                food_collector = depends.on<FoodCollector>();
                disaster_resolver = depends.on<DisasterResolver>();
                city_feeder = depends.on<CityFeeder>();
            };

            Because of = () =>
                sut.score(initial_roll);

            It should_collect_the_goods = () =>
                good_collector.received(x => x.collect(initial_roll));

            It should_collect_the_food = () =>
                food_collector.received(x => x.collect(initial_roll));

            It should_resolve_disasters = () =>
                disaster_resolver.received(x => x.resolve(initial_roll));

            It should_feed_the_cities = () =>
                city_feeder.received(x => x.feed(active_player));

            static InitialRoll initial_roll;
            static Player active_player;
            static GoodCollector good_collector;
            static FoodCollector food_collector;
            static DisasterResolver disaster_resolver;
            static CityFeeder city_feeder;
        }
    }

    public class GoodCollectorSpecs
    {
        public abstract class concern : Observes<GoodCollector> {}

        [Subject(typeof(GoodCollector))]
        public class when_collecting_goods : concern
        {
            Establish c = () =>
            {
                die_one = new Die { goods = 2 };
                die_two = new Die { goods = 1 };

                active_player = new Player("", fake.an<GoodStore>());

                initial_roll = new InitialRoll { dice = new[] { die_one, die_two }, player = active_player };
            };

            Because of = () =>
                sut.collect(initial_roll);

            It should_add_the_rolled_quantity_of_goods = () =>
                active_player.good_store.received(x => x.Add(die_one.goods + die_two.goods));

            static InitialRoll initial_roll;
            static Player active_player;
            static Die die_one;
            static Die die_two;
        }
    }

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

                    active_player = new Player("", fake.an<GoodStore>());
                    active_player.food = initial_food;

                    die_one = new Die { food = 3 };
                    die_two = new Die { food = 2 };

                    initial_roll = new InitialRoll { dice = new[] { die_one, die_two }, player = active_player };

                    depends.on(new FoodCalculatorRegistry());
                };

                Because of = () =>
                    sut.collect(initial_roll);

                It should_add_the_rolled_quantity_of_food = () =>
                    active_player.food.ShouldEqual(initial_food + die_one.food + die_two.food);

                static InitialRoll initial_roll;
                static Player active_player;
                static int initial_food;
                static Die die_one;
                static Die die_two;
            }

            public class and_the_player_rolls_food_with_agriculture
            {
                Establish c = () =>
                {
                    initial_food = 5;

                    active_player = new Player("", fake.an<GoodStore>());
                    active_player.add_development(Development.Agriculture);
                    active_player.food = initial_food;

                    die_one = new Die { food = 3 };
                    die_two = new Die { food = 2 };

                    initial_roll = new InitialRoll { dice = new[] { die_one, die_two }, player = active_player };

                    depends.on(new FoodCalculatorRegistry());
                };

                Because of = () =>
                    sut.collect(initial_roll);

                It should_add_the_an_extra_food_for_every_food_die = () =>
                    active_player.food.ShouldEqual(initial_food + (die_one.food + 1) + (die_two.food + 1));

                static InitialRoll initial_roll;
                static Player active_player;
                static int initial_food;
                static Die die_one;
                static Die die_two;
            }
        }
    }

    public class DisasterResolverSpecs
    {
        public abstract class concern : Observes<DisasterResolver> {}

        [Subject(typeof(DisasterResolver))]
        public class when_resolving_disasters : concern
        {
            public class and_the_player_has_no_famine
            {
                Establish c = () =>
                {
                    initial_disasters = 2;
                    active_player = new Player { cities = 5, food = 5, disasters = initial_disasters };

                    initial_roll = new InitialRoll { player = active_player };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_not_have_any_additional_disasters = () =>
                    active_player.disasters.ShouldEqual(initial_disasters + (active_player.cities - active_player.food));

                static InitialRoll initial_roll;
                static Player active_player;
                static int initial_disasters;
            }

            public class and_the_player_has_famine
            {
                Establish c = () =>
                {
                    initial_disasters = 2;
                    active_player = new Player { cities = 7, food = 5, disasters = initial_disasters };

                    initial_roll = new InitialRoll { player = active_player };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_add_a_disaster_for_each_city_that_cannot_be_fed = () =>
                    active_player.disasters.ShouldEqual(initial_disasters + (active_player.cities - active_player.food));

                static InitialRoll initial_roll;
                static Player active_player;
                static int initial_disasters;
            }

            public class and_the_player_rolls_one_skull
            {
                Establish c = () =>
                {
                    initial_disasters = 2;
                    active_player = new Player { cities = 5, food = 5, disasters = initial_disasters };

                    var dice = Enumerable.Range(1, 1).Select(x => new Die { disasters = 1 });
                    dice = dice.Concat(new[] { new Die { disasters = 0 } });

                    initial_roll = new InitialRoll { dice = dice, player = active_player };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_not_change_the_disasters = () =>
                    active_player.disasters.ShouldEqual(initial_disasters);

                static InitialRoll initial_roll;
                static Player active_player;
                static int initial_disasters;
            }

            public class and_the_player_rolls_two_skulls
            {
                Establish c = () =>
                {
                    initial_disasters = 2;
                    active_player = new Player { cities = 5, food = 5, disasters = initial_disasters };

                    var dice = Enumerable.Range(1, 2).Select(x => new Die { disasters = 1 });
                    dice = dice.Concat(new[] { new Die { disasters = 0 } });

                    initial_roll = new InitialRoll { dice = dice, player = active_player };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_give_the_player_two_disasters = () =>
                    active_player.disasters.ShouldEqual(initial_disasters + 2);

                static InitialRoll initial_roll;
                static Player active_player;
                static int initial_disasters;
            }
        }
    }

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
