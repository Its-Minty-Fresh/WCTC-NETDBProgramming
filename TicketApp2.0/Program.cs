using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp2._0.Models;

namespace TicketApp2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            int selection = mainMenu.GetMainMenuSelection();

            while (selection == 1)
            {
                Format format = new Format();

                Console.Clear();
                format.ViewTicketHeader();
                Console.ReadLine();
            }

            Console.WriteLine(selection);
            Console.ReadLine();
        }
    }
}
