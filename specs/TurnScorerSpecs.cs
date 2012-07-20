using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using meat;
using meat.food_collection;

namespace specs
{
    public class TurnScorerSpecs
    {
        public abstract class concern : Observes<IScoreATurn,
                                            TurnScorer> { }

        [Subject(typeof(TurnScorer))]
        public class when_scoring_a_turn : concern
        {
            public class and_the_player_rolls_goods
            {
                Establish c = () =>
                {
                    quantity_of_goods_rolled = 3;

                    active_player = new Player("", fake.an<GoodStore>());
                    turn = new Turn { goods = quantity_of_goods_rolled, player = active_player };
                };

                Because of = () =>
                    sut.score(turn, null);

                It should_add_the_rolled_quantity_of_goods = () =>
                    active_player.good_store.received(x => x.Add(quantity_of_goods_rolled));

                static Turn turn;
                static Player active_player;
                static int quantity_of_goods_rolled;
            }

            public class and_the_player_rolls_food
            {
                Establish c = () =>
                {
                    initial_food = 5;

                    active_player = new Player("", fake.an<GoodStore>());
                    active_player.food = initial_food;

                    die_one = new Die { food = 3 };
                    die_two = new Die { food = 2 };

                    turn = new Turn { dice = new[] { die_one, die_two }, player = active_player };

                    depends.on(new FoodCollector(new FoodCalculatorRegistry()));
                };

                Because of = () =>
                    sut.score(turn, null);

                It should_add_the_rolled_quantity_of_food = () =>
                    active_player.food.ShouldEqual(initial_food + die_one.food + die_two.food);

                static Turn turn;
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

                    turn = new Turn { dice = new[] { die_one, die_two }, player = active_player };

                    depends.on(new FoodCollector(new FoodCalculatorRegistry()));
                };

                Because of = () =>
                    sut.score(turn, null);

                It should_add_the_an_extra_food_for_every_food_die = () =>
                    active_player.food.ShouldEqual(initial_food + (die_one.food + 1) + (die_two.food + 1));
                
                static Turn turn;
                static Player active_player;
                static int initial_food;
                static Die die_one;
                static Die die_two;
            }
        }
    }

    public class TurnScorer : IScoreATurn
    {
        FoodCollector food_collector;

        public TurnScorer(FoodCollector foodCollector)
        {
            food_collector = foodCollector;
        }

        public void score(Turn turn, IEnumerable<Player> players)
        {
            turn.player.good_store.Add(turn.goods);
            food_collector.collect(turn);
        }
    }
}
