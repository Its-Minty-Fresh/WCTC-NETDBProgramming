using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp3.Models
{
    class TicketMenu
    {
        public void Process(int selection)
        {
            string file = "../../Files/tickets.txt";
            TicketFile tf = new TicketFile(file);
            TicketMenu tm = new TicketMenu();
            tm.TicketMenuHeader();
            tf.ShowTickets();
            tm.ViewTicketMenu();
            selection = tm.GetTktMenuResp();

            switch (selection)
            {
                case 1:
                    tm.AddTicket();
                    break;
                case 2:
                    tm.EditTicket();
                    break;
                case 3:
                    tm.DeleteTicket();
                    break;
            }
        }
        

        public void TicketMenuHeader()
        {
            Console.Clear();
            Format f = new Format();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    View Tickets\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine(f.GetTicketsFormat(), "Ticket #", "Summary", "Status", "Priorty", "Submitter", "Assigned", "WatchGroup", "Severity");
            Console.WriteLine(f.GetTicketsFormat(), "------", "--------------------------------------------------", "----------", "----------", "----------", "----------", "----------", "----------");
            Console.ResetColor();
        }

        public void ViewTicketMenu()
        {
            Console.WriteLine("    What would you like to do?\n\n" +
                "    1) Add Ticket\n" +
                "    2) Edit Ticket\n" +
                "    3) Delete Ticket\n" +
                "    4) Return to Main Menu");

            Console.Write("    ");
        }

        public void AddTicket()
        {
            Format f = new Format();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    Add Ticket\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();


            string file = "../../Files/tickets.txt";
            TicketFile tf = new TicketFile(file);
            Tickets ticket = new Tickets();

            Console.Write("    Enter Ticket Summary: ");
            ticket.summary = Console.ReadLine();

            Console.Write("\n    Enter Ticket Priority: ");
          
            ticket.priority = f.validateInt(Console.ReadLine());
            if (ticket.priority > 3)
            {
                Console.Write("    Please Enter a valid proiroity 1 - 3 ");
                ticket.priority = f.validateInt(Console.ReadLine());
            }

            tf.AddTicket(ticket);
            Console.Write("    Ticket succesfully added! Press any key ro return to the main menu: ");
            Console.ReadKey();

        }

        public void EditTicket()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    Edit Ticket\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();

            Console.Write("\n    Editing Functionality to be added in a future release. \n" +
                          "    Press any key ro return to the main menu: ");
            Console.ReadKey();
        }

        public void DeleteTicket()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    Delete Ticket\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();

            Console.Write("\n    Deleteing Functionality to be added in a future release. \n" +
                          "    Press any key ro return to the main menu: ");
            Console.ReadKey();
        }

        public int GetTktMenuResp()
        {
            Format format = new Format();
            int selection;

            selection = format.validateInt(Console.ReadLine());

            return selection;
        }

        public int GetTktMenuInpput()
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
