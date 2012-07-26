using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.nsubstitue;
using meat;
using meat.initial_roll;
using meat.initial_roll.disaster_resolution;
using meat.initial_roll.disaster_resolution.resolutions;

namespace specs.initial_roll.disaster_resolution
{
    public class DisasterResolverSpecs
    {
        public abstract class concern : Observes<DisasterResolver>
        {
            Establish c = () =>
            {
                depends.on(new ResolutionFromDice(new DisasterResolutionRegistry(new DisasterResolutions())));
                depends.on(new ResolutionFromFamine());
            };
        }

        [Subject(typeof(DisasterResolver))]
        public class when_resolving_disasters : concern
        {
            public class and_the_player_has_no_famine
            {
                Establish c = () =>
                {
                    initial_disasters = 2;
                    var player = new Player { cities = 5, food = 5, disasters = initial_disasters };

                    initial_roll = new InitialRoll { player = player };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_not_have_any_additional_disasters = () =>
                    initial_roll.player.disasters.ShouldEqual(initial_disasters + (initial_roll.player.cities - initial_roll.player.food));

                static InitialRoll initial_roll;
                static int initial_disasters;
            }

            public class and_the_player_has_famine
            {
                Establish c = () =>
                {
                    initial_disasters = 2;
                    var player = new Player { cities = 7, food = 5, disasters = initial_disasters };

                    initial_roll = new InitialRoll { player = player };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_add_a_disaster_for_each_city_that_cannot_be_fed = () =>
                    initial_roll.player.disasters.ShouldEqual(initial_disasters + (initial_roll.player.cities - initial_roll.player.food));

                static InitialRoll initial_roll;
                static int initial_disasters;
            }

            public class and_the_player_rolls_one_skull
            {
                Establish c = () =>
                {
                    initial_disasters = 2;
                    var player = new Player { cities = 5, food = 5, disasters = initial_disasters };

                    var dice = Enumerable.Range(1, 1).Select(x => new Die { disasters = 1 });
                    dice = dice.Concat(new[] { new Die { disasters = 0 } });

                    initial_roll = new InitialRoll { dice = dice, player = player };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_not_change_the_disasters = () =>
                    initial_roll.player.disasters.ShouldEqual(initial_disasters);

                static InitialRoll initial_roll;
                static int initial_disasters;
            }

            public class and_the_player_rolls_two_skulls
            {
                Establish c = () =>
                {
                    initial_disasters = 2;
                    var player = new Player { cities = 5, food = 5, disasters = initial_disasters };

                    var dice = Enumerable.Range(1, 2).Select(x => new Die { disasters = 1 });

                    initial_roll = new InitialRoll { dice = dice, player = player };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_give_the_player_two_disasters = () =>
                    initial_roll.player.disasters.ShouldEqual(initial_disasters + 2);

                static InitialRoll initial_roll;
                static int initial_disasters;
            }

            public class and_the_player_rolls_two_skulls_and_has_irrigation
            {
                Establish c = () =>
                {
                    initial_disasters = 2;
                    var player = new Player { cities = 5, food = 5, disasters = initial_disasters };
                    player.add(Development.Irrigation);

                    var dice = Enumerable.Range(1, 2).Select(x => new Die { disasters = 1 });

                    initial_roll = new InitialRoll { dice = dice, player = player };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_not_give_the_player_any_disasters = () =>
                    initial_roll.player.disasters.ShouldEqual(initial_disasters);

                static InitialRoll initial_roll;
                static int initial_disasters;
            }

            public class and_the_player_rolls_three_skulls
            {
                Establish c = () =>
                {
                    opponent_one_initial_disasters = 2;
                    opponent_two_initial_disasters = 4;
                    opponent_one = new Player { disasters = opponent_one_initial_disasters };
                    opponent_two = new Player { disasters = opponent_two_initial_disasters };

                    initial_disasters = 2;
                    var player = new Player { cities = 5, food = 5, disasters = initial_disasters };
                    player.add(Development.Irrigation);

                    var dice = Enumerable.Range(1, 3).Select(x => new Die { disasters = 1 });

                    initial_roll = new InitialRoll { dice = dice, player = player, opponents = new[] { opponent_one, opponent_two } };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_give_all_other_players_three_disasters = () =>
                {
                    opponent_one.disasters.ShouldEqual(opponent_one_initial_disasters + 3);
                    opponent_two.disasters.ShouldEqual(opponent_two_initial_disasters + 3);
                };

                static InitialRoll initial_roll;
                static int initial_disasters;
                static Player opponent_one;
                static Player opponent_two;
                static int opponent_one_initial_disasters;
                static int opponent_two_initial_disasters;
            }

            public class and_the_player_rolls_three_skulls_and_an_opponent_has_medicine
            {
                Establish c = () =>
                {
                    opponent_with_medicine_initial_disasters = 2;
                    opponent_without_medicine_initial_disasters = 4;
                    opponent_with_medicine = new Player { disasters = opponent_with_medicine_initial_disasters };
                    opponent_without_medicine = new Player { disasters = opponent_without_medicine_initial_disasters };

                    opponent_with_medicine.add(Development.Medicine);

                    initial_disasters = 2;
                    var player = new Player { cities = 5, food = 5, disasters = initial_disasters };
                    player.add(Development.Irrigation);

                    var dice = Enumerable.Range(1, 3).Select(x => new Die { disasters = 1 });

                    initial_roll = new InitialRoll { dice = dice, player = player, opponents = new[] { opponent_with_medicine, opponent_without_medicine } };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_only_give_the_oppenent_without_medicine_three_disasters = () =>
                {
                    opponent_with_medicine.disasters.ShouldEqual(opponent_with_medicine_initial_disasters);
                    opponent_without_medicine.disasters.ShouldEqual(opponent_without_medicine_initial_disasters + 3);
                };

                static InitialRoll initial_roll;
                static int initial_disasters;
                static Player opponent_with_medicine;
                static Player opponent_without_medicine;
                static int opponent_with_medicine_initial_disasters;
                static int opponent_without_medicine_initial_disasters;
            }

            public class and_the_player_rolls_four_skulls
            {
                Establish c = () =>
                {
                    initial_disasters = 2;

                    var player = fake.an<Player>();
                    player.cities = 5;
                    player.food = 5;
                    player.disasters = initial_disasters;

                    var dice = Enumerable.Range(1, 4).Select(x => new Die { disasters = 1 });

                    initial_roll = new InitialRoll { dice = dice, player = player };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_give_the_player_four_disasters = () =>
                    initial_roll.player.disasters.ShouldEqual(initial_disasters + 4);

                static InitialRoll initial_roll;
                static int initial_disasters;
            }

            public class and_the_player_rolls_four_skulls_and_has_built_the_great_wall
            {
                Establish c = () =>
                {
                    initial_disasters = 2;
                    var player = fake.an<Player>();
                    player.cities = 5;
                    player.food = 5;
                    player.disasters = initial_disasters;
                    player.setup(x => x.has(Monument.GreatWall)).Return(true);

                    var dice = Enumerable.Range(1, 4).Select(x => new Die { disasters = 1 });

                    initial_roll = new InitialRoll { dice = dice, player = player };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_give_the_player_no_disasters = () =>
                    initial_roll.player.disasters.ShouldEqual(initial_disasters);

                static InitialRoll initial_roll;
                static int initial_disasters;
            }

            public class and_the_player_rolls_five_skulls
            {
                Establish c = () =>
                {
                    var dice = Enumerable.Range(1, 5).Select(x => new Die { disasters = 1 });

                    initial_roll = new InitialRoll { dice = dice, player = fake.an<Player>() };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_remove_all_goods_from_the_player = () =>
                    initial_roll.player.received(x => x.remove_all_goods());

                static InitialRoll initial_roll;
            }

            public class and_the_player_rolls_five_skulls_and_has_religion
            {
                Establish c = () =>
                {
                    opponent_one = fake.an<Player>();
                    opponent_two = fake.an<Player>();

                    var player = fake.an<Player>();
                    player.add(Development.Religion);

                    var dice = Enumerable.Range(1, 5).Select(x => new Die { disasters = 1 });

                    initial_roll = new InitialRoll { dice = dice, player = player, opponents = new[] { opponent_one, opponent_two } };
                };

                Because of = () =>
                    sut.resolve(initial_roll);

                It should_remove_all_goods_from_opponents = () =>
                {
                    initial_roll.player.never_received(x => x.remove_all_goods());
                    opponent_one.received(x => x.remove_all_goods());
                    opponent_two.received(x => x.remove_all_goods());
                };

                static InitialRoll initial_roll;
                static Player opponent_one;
                static Player opponent_two;
            }
        }
    }
}