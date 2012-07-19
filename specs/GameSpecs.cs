using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using meat;

namespace specs
{
    public class GameSpecs
    {
        public abstract class concern : Observes<Game> {}

        [Subject(typeof(Game))]
        public class when_starting_the_next_turn : concern
        {
            Establish c = () =>
            {
                the_next_player = fake.an<Player>();

                var turn_queue_factory = depends.on<ICreateATurnQueue>();
                var players = depends.on<IEnumerable<Player>>();

                var turn_queue = fake.an<IReturnTheNextPlayer>();
                turn_queue_factory.setup(x => x.create(players)).Return(turn_queue);

                turn_queue.setup(x => x.next()).Return(the_next_player);
            };

            Because of = () =>
                sut.start_next_turn();

            It should_cycle_the_next_player = () =>
                sut.current_turn.ShouldEqual(the_next_player);
            
            static Player the_next_player;
        }

        [Subject(typeof(Game))]
        public class when_checking_if_the_game_is_over : concern
        {
            public class and_there_is_not_an_ending_condition
            {
                Establish c = () =>
                {
                    var players = depends.on<IEnumerable<Player>>();
                    var ending_condition_checker = depends.@on<ICheckForEndingConditions>();

                    ending_condition_checker.setup(x => x.has_any(players)).Return(false);
                };

                Because of = () =>
                    is_game_over = sut.is_over;

                It should_not_be_over = () =>
                    is_game_over.ShouldBeFalse();

                static bool is_game_over;
            }

            public class and_there_is_an_ending_condition
            {
                Establish c = () =>
                {
                    var players = depends.on<IEnumerable<Player>>();
                    var ending_condition_checker = depends.@on<ICheckForEndingConditions>();

                    ending_condition_checker.setup(x => x.has_any(players)).Return(true);
                };

                Because of = () =>
                    is_game_over = sut.is_over;

                It should_be_over = () =>
                    is_game_over.ShouldBeTrue();

                static bool is_game_over;
            }
        }

        [Subject(typeof(Game))]
        public class when_scoring_a_turn : concern
        {
            Establish c = () =>
            {
                turn = fake.an<Turn>();
                players = depends.on<IEnumerable<Player>>();
                scorer = depends.on<IScoreATurn>();
            };
            
            Because of = () =>
                sut.score_turn(turn);

            It should_delegate_to_the_turn_scorer = () =>
                scorer.received(x => x.score(turn, players));
            
            static Turn turn;
            static IEnumerable<Player> players;
            static IScoreATurn scorer;
        }
    }
}
