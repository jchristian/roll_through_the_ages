using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using meat;

namespace ui.console
{
    class Program
    {
        static void Main(string[] args)
        {
            int number_of_players = 0;
            bool is_valid_number_of_players = false;
            while (!is_valid_number_of_players)
            {
                Console.WriteLine("How many players do you have?");
            
                var is_valid_input = Int32.TryParse(Console.ReadLine(), out number_of_players);

                is_valid_number_of_players = !is_valid_input || number_of_players < 2 || number_of_players > 4;
                if(is_valid_number_of_players)
                    Console.WriteLine("Please enter 2, 3 or 4 players");
            }

            var game = new GameRunner().play_new_game(Enumerable.Range(1, number_of_players).Select(player_number => new Player(string.Format("Player {0}", player_number))).ToList());
            var view_engine = new ViewEngine();

            do
            {
                view_engine.display(game);
            } while(!game.is_over);
        }
    }

    public class ViewEngine : IDisplayObjects
    {
        public void display(object display_object)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDisplayObjects
    {
        void display(object display_object);
    }
}
