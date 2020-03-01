using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp3.Models
{
    class MainMenu
    {

        public MainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Welcome to Matts Software Manegement System!!\n" +
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
            Format i = new Format();
            int selection;

            selection = i.validateInt(Console.ReadLine());

            while ((selection < 0 || selection > 4))
            {
                Console.Write("    Please Enter a valid response 1 - 4 ");
                selection = i.validateInt(Console.ReadLine());
            }
            return selection;
        }
    }
}
