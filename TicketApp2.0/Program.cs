using System;
using System.Linq;
using TicketApp2._0.Models;

namespace TicketApp2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new MainMenu();
            var format = new Format();
            int selection = 0;

            do
            {
                menu.ViewMainMenu();
                selection  = menu.GetMainMenuInpput();
                Console.ReadLine();
                if (selection == 1)
                {
                    TicketManager ticketManager = new TicketManager();
                    Console.Clear();
                    format.ViewTicketHeader();
                    ticketManager.Process(selection);
                    Console.WriteLine("View Tickets");
                    Console.ReadLine();
                }
                else if (selection == 2)
                {
                    Console.WriteLine("View Enhancements");
                    Console.ReadLine();
                }
                else if (selection == 3)
                {
                    Console.WriteLine("View Task");
                    Console.ReadLine();
                }

            } while (selection != 4);

        }
    }
}
