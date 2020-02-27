using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using TicketApp3.Models;

namespace TicketApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int selection;
            do
            {
                var mainMenu = new MainMenu();
                selection = mainMenu.GetMainMenuResp();

                if (selection == 1) // View tickets
                {
                    TicketMenu ticketMenu = new TicketMenu();
                    ticketMenu.Process(selection);
                }
                else if (selection == 2)
                {
                    // View Enhancements
                }
                else if (selection == 3)
                {
                    // View Tasks
                }
            } while (selection != 4);

        }
    }
}
