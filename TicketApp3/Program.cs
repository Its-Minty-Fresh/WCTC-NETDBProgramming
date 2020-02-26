using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("    What would you like to do?\n\n" +
                              "    1) View Tickets\n" +
                              "    2) View Enhancements\n" +
                              "    3) View Tasks\n" +
                              "    4) Quit");

            string resp = Console.ReadLine();
            if (resp == "1")
            {
                //show tickets
            }
            else if (resp == "2")
            {
                //add ticket
            }
        }
    }
}
