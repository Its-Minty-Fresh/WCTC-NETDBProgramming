using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp2._0
{
    class MainMenu
    {
        public void ViewMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Welcome to Matts Support Ticket System!!\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("    What would you like to do?\n\n" +
                "    1) View Tickets\n" +
                "    2) View Enhancements\n" +
                "    3) View Tasks\n" +
                "    4) Quit");

            Console.Write("    ");
        }

        public int GetMainMenuInpput()
        {
            int selection;
            selection = validateInt(Console.ReadLine());
            while ((selection < 0 || selection > 4))
            {
                Console.Write("    Please Enter a valid response 1 - 4 ");
                selection = validateInt(Console.ReadLine());
            }
            return selection;
        }

        static public int validateInt(string input)
        {
            int output = 0;
            do
            {
                if (!int.TryParse(input, out output))
                {
                    Console.Write("    Please enter a numeric value: ");
                    input = Console.ReadLine();
                }
                else if ((Convert.ToDouble(input)) <= 0)
                {
                    Console.Write("    Please enter a positive value: ");
                    input = Console.ReadLine();
                }
                else
                {
                    output = int.Parse(input);
                }
            } while ((!int.TryParse(input, out output)) || ((int.Parse(input)) <= 0));

            return output;
        }

    }
}
