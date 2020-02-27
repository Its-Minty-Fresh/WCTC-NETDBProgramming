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

            Console.WriteLine("    What would you like to do?\n\n" +
                              "    1) View Tickets\n" +
                              "    2) View Enhancements\n" +
                              "    3) View Tasks\n" +
                              "    4) Quit");

            string resp = Console.ReadLine();

            string file = "../../Files/tickets.txt";
            
            Format format = new Format();
            TicketFile ticketFile = new TicketFile(file);

            if (resp == "1")
            {
                
                format.ViewTicketHeader();
                ticketFile.ShowTickets();
                Console.ReadLine();
            }
            else if (resp == "2")
            {
                
                Tickets ticket = new Tickets();


                Console.WriteLine("Enter ticket summary");
                ticket.summary = Console.ReadLine();
                ticketFile.AddTicket(ticket);

                Console.WriteLine("Add Tickets");
                Console.ReadLine();
            }
        }
    }
}
