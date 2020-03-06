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
            TicketFile tf = new TicketFile();
            TicketMenu tm = new TicketMenu();

            tm.TicketMenuHeader();
            tf.ShowTickets();
            tm.ViewTicketMenu();
            selection = tm.GetTktMenuInpput();

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
                case 4:
                    tm.SearchTickets();
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
            Console.WriteLine("\n    What would you like to do?\n\n" +
                "    1) Add Ticket\n" +
                "    2) Edit Ticket\n" +
                "    3) Delete Ticket\n" +
                "    4) Search Tickets\n" +
                "    5) Return to Main Menu");
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

        public void SearchTickets()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    Search Tickets\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
            Console.Write("\n    Enter any portion of a Ticket Summary: \n");

             string search = Console.ReadLine().ToLower();



            //TicketFile tix = TicketFile.LoadTickets();

            //foreach(var t in tix)
            //{
            //    Console.WriteLine(t.summary);
            //}


            TicketFile tf = new TicketFile("../../Files/tickets.txt");
            var ticket = tf.Ticket.Where(t => t.summary.ToLower().Contains("THIS"));
            Format f = new Format();
            foreach (Tickets t in tf.Ticket)
            {
                Console.WriteLine(f.GetTicketsFormat(), t.recordID, t.summary, t.status, t.priority, t.submitter, t.assigned, t.watchrgoup, t.severity);
            }

            if (ticket.Count() > 0)
            {
                foreach (Tickets t in ticket)
                {
                    Console.WriteLine(t);
                }
            }
            else
            {
                Console.WriteLine("    There is no Ticket with a summary containing: " + search);
            }



            Console.Write("    Press any key ro return to the main menu: ");
            
            Console.ReadKey();
        }

        public int GetTktMenuInpput()
        {
            Format i = new Format();
            int selection;

            selection = i.validateInt(Console.ReadLine());

            while ((selection < 0 || selection > 5))
            {
                Console.Write("    Please Enter a valid response 1 - 5 ");
                selection = i.validateInt(Console.ReadLine());
            }
            return selection;
        }
    }
}
