using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.nsubstitue;
using meat;
using meat.initial_roll;
using meat.initial_roll.city_feeding;
using meat.initial_roll.disaster_resolution;
using meat.initial_roll.food_collection;
using meat.initial_roll.goods_collection;

namespace specs.initial_roll
{
    public class InitialScorerSpecs
    {
        public abstract class concern : Observes<InitialRollUpdater> { }

        [Subject(typeof(InitialRollUpdater))]
        public class when_updating_for_an_initial_roll : concern
        {
            Establish c = () =>
            {
                initial_roll = new InitialRoll { player = new Player("", fake.an<GoodStore>()) };
                
                good_collector = depends.on<GoodCollector>();
                food_collector = depends.on<FoodCollector>();
                disaster_resolver = depends.on<DisasterResolver>();
                city_feeder = depends.on<CityFeeder>();
            };

            Because of = () =>
                sut.update_for(initial_roll);

            It should_collect_the_goods = () =>
                good_collector.received(x => x.collect(initial_roll));

            It should_collect_the_food = () =>
                food_collector.received(x => x.collect(initial_roll));

            It should_resolve_disasters = () =>
                disaster_resolver.received(x => x.resolve(initial_roll));

            It should_feed_the_cities = () =>
                city_feeder.received(x => x.feed(initial_roll.player));

            static InitialRoll initial_roll;
            static GoodCollector good_collector;
            static FoodCollector food_collector;
            static DisasterResolver disaster_resolver;
            static CityFeeder city_feeder;
        }
    }
}
