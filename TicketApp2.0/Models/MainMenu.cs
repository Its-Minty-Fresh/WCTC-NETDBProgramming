using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp2._0.Models
{
    public class MainMenu
    {

        public MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Welcome to Matts Support Ticket System!!\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("    What would you like to do?\n\n" +
                "    1) View Tickets\n" +
                "    2) Create Ticket\n" +
                "    3) View Users\n" +
                "    4) Create User\n" +
                "    5) Quit");

            Console.Write("    ");
        }

        public int GetMainMenuSelection()
        {
            int selection = 0;

            string resp = Console.ReadLine();
            while (!Int32.TryParse(resp, out selection) || (selection < 0 || selection > 9))
            {
                Console.Write("    Please Enter a valid response 1 - 9 ");
                resp = Console.ReadLine();
            }

            return selection;
        }


    }
}
