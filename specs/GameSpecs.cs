﻿using System.Collections.Generic;
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
            public class and_no_players_have_ending_conditions
            {
                Establish c = () =>
                {
                    var players = Enumerable.Range(1, 10).Select(x => fake.an<Player>());

                    depends.on(players);
                    var ending_condition_checker = depends.@on<ICheckForEndingConditions>();

                    ending_condition_checker.setup(x => x.has_any(Moq.It.IsAny<Player>())).Return(false);
                };

                Because of = () =>
                    is_game_over = sut.is_over;

                It should_not_be_over = () =>
                    is_game_over.ShouldBeFalse();

                static bool is_game_over;
            }

            public class and_a_player_has_an_ending_condition
            {
                Establish c = () =>
                {
                    var players = Enumerable.Range(1, 10).Select(x => fake.an<Player>());

                    var player_with_an_ending_condition = fake.an<Player>();
                    player_with_an_ending_condition.setup(x => x.has_an_ending_condition).Return(true);

                    depends.on(players.Concat(new[] { player_with_an_ending_condition }));
                    var ending_condition_checker = depends.@on<ICheckForEndingConditions>();

                    ending_condition_checker.setup(x => x.has_any(Moq.It.IsAny<Player>())).Return(false);
                    ending_condition_checker.setup(x => x.has_any(player_with_an_ending_condition)).Return(true);
                };

                Because of = () =>
                    is_game_over = sut.is_over;

                It should_be_over = () =>
                    is_game_over.ShouldBeTrue();

                static bool is_game_over;
            }
        }
    }
}
