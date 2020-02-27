using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp3.Models
{
    class Format
    {
        public string GetTicketsFormat()
        {
            return "    {0,-4}\t{1,-50}\t{2,-10}\t{3,-10}\t{4,-10}\t{5,-10}\t{6,-10}\t{7,-10}";
        }

        public string GetWGFormat()
        {
            return "    \t\t\t\t\t\t\t\t\t\t\t\t\t\t\t{0,-4}";
        }


        public int validateInt(string input)
        {
            int output;
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
