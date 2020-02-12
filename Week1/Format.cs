using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    class Format
    {
        public string GetTicketsFormat()
        {
            return "    {0,-4}\t{1,-50}\t{2,-4}\t{3,-4}\t{4,-4}\t{5,-4}\t{6,-4}";
            
        }


        public void GetTicketHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    View Tickets\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.WriteLine(GetTicketsFormat(), "Ticket #", "Summary", "Status", "Priorty", "Assigned To", "Created By", "Watching");
            Console.WriteLine(GetTicketsFormat(), "------", "------------------------------------", "------", "------", "------------", "------------", "------------");
            Console.ResetColor();
        }
    }
}
