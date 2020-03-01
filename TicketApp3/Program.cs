using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using TicketApp3.Models;
using TicketApp3.Models.Enhancements;
using TicketApp3.Models.Tasks;

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
                selection = mainMenu.GetMainMenuInpput();

                if (selection == 1) // View tickets
                {
                    TicketMenu ticketMenu = new TicketMenu();
                    ticketMenu.Process(selection);
                }
                else if (selection == 2) // View Enhancements
                {
                    EnhancementMenu enhMenu = new EnhancementMenu();
                    enhMenu.Process(selection);
                }
                else if (selection == 3) // View Tasks
                {
                    TaskMenu taskMenu = new TaskMenu();
                    taskMenu.Process(selection);
                }
            } while (selection != 4);

        }
    }
}
