using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.nsubstitue;
using meat;
using meat.initial_roll.goods_collection;

namespace specs.initial_roll.goods_collection
{
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
}