/*
-Build data file with initial system tickets and data in a CSV
-Write Console application to process and add records to the CSV file

Tickets.csv
TicketID, Summary, Status, Priority, Submitter, Assigned, Watching
1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Week1
{
    class Program
    {
        static void Main(string[] args)
        {

            // load Users

            List<Users> UserList = LoadUsers();
            List<Ticket> TicketList = LoadTickets();


            int selection = 0;

            do
            {
                selection = MainMenu();
                if (selection == 1)
                {
                    Console.Clear();
                    TicketList = ViewTickets(TicketList, UserList);
                }
                if (selection == 2)
                {
                    Console.Clear();
                    TicketList = CreateTicket(TicketList, UserList);
                    SaveTicket(TicketList);
                }
                if (selection == 3)
                {
                    Console.Clear();
                    UserList = ViewUsers(UserList);
                }
                if (selection == 4)
                {
                    Console.Clear();
                    UserList = CreateUser(UserList);
                    SaveUser(UserList);
                }
            } while (selection != 9);
        }

        static int MainMenu()
        {
            int selection = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Welcome to Matts Support Ticket System!!\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("    What would you like to do?\n\n" +
                "    1) View Tickets\n" +
                "    2) Create Ticket\n" +
                "    3) View Users\n" +
                "    4) Create User\n" +
                "    5) Quit");

            Console.Write("    ");
            string resp = Console.ReadLine();
            while (!Int32.TryParse(resp, out selection) || (selection < 0 || selection > 9))
            {
                Console.Write("    Please Enter a valid response 1 - 9 ");
                resp = Console.ReadLine();
            }
            Console.Clear();
            return selection;

        }




        static List<Ticket> LoadTickets()
        {
            string file = "Tickets.txt";
            List<Ticket> Tks = new List<Ticket>();
            if (File.Exists(file))
            {
                StreamReader TicketReader = new StreamReader(file);
                while (!TicketReader.EndOfStream)
                {
                    string ticketRecord = TicketReader.ReadLine();
                    string[] ticketAttributes = ticketRecord.Split(',');
                    int ticketID = Int32.Parse(ticketAttributes[0]);
                    string summary = ticketAttributes[1];
                    string status = ticketAttributes[2];
                    string priority = ticketAttributes[3];
                    int submitterID = Int32.Parse(ticketAttributes[4]);
                    int assignedID = Int32.Parse(ticketAttributes[5]);
                    int watchingGrp = Int32.Parse(ticketAttributes[6]);

                    Ticket tickets = new Ticket(ticketID, summary, status, priority, submitterID, assignedID, watchingGrp);
                    Tks.Add(tickets);
                }
                TicketReader.Close();
            }
            return Tks;
        }

        static List<Ticket> CreateTicket(List<Ticket> ticket, List<Users> user)
        {
            string ticketFormat = "    {0,-4}\t{1,-50}\t{2,-4}\t{3,-4}\t{4,-4}\t{5,-4}\t{6,-4}";
            string userFormat = "    {0,-4}\t{1,-15}\t{2,-15}";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Create Ticket\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(userFormat, "User ID", "First Name", "Last Name");
            Console.WriteLine(userFormat, "------", "-------------", "-------------");
            Console.ResetColor();

            // Create list of user IDs for validation
            List<int> userID = new List<int>();

            // Display users
            foreach (Users u in user)
            {
                Console.WriteLine(userFormat, u.GetUserID(), u.GetFName(), u.GetLName());
                userID.Add(u.GetUserID());
            }

            Console.Write("    Please enter the user ID of the user creating this ticket: ");
            int createdByID = validateInt(Console.ReadLine());
            while (!userID.Contains(createdByID))
            {
                Console.Write("    Please select a valid User ID! ");
                createdByID = validateInt(Console.ReadLine());
            }



            Console.Write("    Please enter a ticket summary: ");
            String summary = Console.ReadLine();
            while (summary == "")
            {
                Console.Write("\n    Please enter a ticket summary: ");
                summary = Console.ReadLine();
            }

            Console.Write("\n    Please enter a Priority: \n" +
                "    1: High\n" +
                "    2: Medium\n" +
                "    3: Low\n");
            String pri = Console.ReadLine();
            while (((!int.TryParse(pri, out _)) || ((Convert.ToInt32(pri) < 0))) || ((Convert.ToInt32(pri) > 3)))
            {
                Console.Write("\n    Please choose a priority 1 to 3: ");
                pri = Console.ReadLine();
            }
            int selected = int.Parse(pri);
            if (selected == 1)
            {
                pri = "High";
            }
            else if (selected == 2)
            {
                pri = "Medium";
            }
            else if (selected == 3)
            {
                pri = "Low";
            }



            // Get max value of current ticket ID's and add 1 to it for the new ticket ID
            int max = 0;
            foreach (Ticket t in ticket)
            {
                max = ticket.Max(a => a.GetTicketID());
            }

            // Create Ticket
            Ticket newTicket = new Ticket(max + 1, summary, "Open", pri, createdByID, 1, 1);
            ticket.Add(newTicket);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Create Ticket\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("    Ticket successfully created!\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ticketFormat, "Ticket #", "Summary", "Status", "Priorty", "Assigned To", "Submitted By", "Watching");
            Console.WriteLine(ticketFormat, "------", "------------------------------------", "------", "------", "------", "------", "------");
            Console.ResetColor();
            Console.Write("\n    Press any Key to return to the Main Menu: ");
            Console.ReadKey();
            Console.Clear();

            return ticket;
        }

        static void SaveTicket(List<Ticket> tk)
        {
            StreamWriter ul = new StreamWriter("Tickets.txt");
            foreach (Ticket t in tk)
            {
                string tkt = t.ToString();
                ul.WriteLine(tkt);
            }
            ul.Close();
        }

        static List<Ticket> ViewTickets(List<Ticket> ticket, List<Users> user)
        {
            string ticketFormat = "    {0,-4}\t{1,-50}\t{2,-4}\t{3,-4}\t{4,-4}\t{5,-4}\t{6,-4}";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    View Tickets\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.WriteLine(ticketFormat, "Ticket #", "Summary", "Status", "Priorty", "Assigned To", "Submitted By", "Watching");
            Console.WriteLine(ticketFormat, "------", "------------------------------------", "------", "------", "------------", "------------", "------");
            Console.ResetColor();


            var query = from t in ticket
                        join ua in user on t.GetAssignedID() equals ua.GetUserID()
                        join us in user on t.GetSubmitterID() equals us.GetUserID()
                        select new { tkt = t.GetTicketID(), tsum = t.GetSummary(), status = t.GetStatus(), priority = t.GetPriority(), assigned = ua.GetFName() + " " + ua.GetLName(), submitted = us.GetFName() + " " + us.GetLName(), watch = t.GetWatchingGrp() };


            foreach (var t in query)
            {
                string summary;
                if (t.tsum.Length > 50) // Limmit summary output to 50 charachters
                {
                    summary = t.tsum.Remove(50);
                }
                else
                {
                    summary = t.tsum;
                }
                Console.WriteLine(ticketFormat, t.tkt, summary, t.status, t.priority, t.assigned, t.submitted, t.watch);
            }

            Console.Write("\n    Press any Key to return to the Main Menu ");
            Console.ReadKey();
            Console.Clear();
            return ticket;
        }


        static List<Users> LoadUsers()
        {
            string file = "Users.txt";
            List<Users> Us = new List<Users>();
            if (File.Exists(file))
            {
                StreamReader UserReader = new StreamReader(file);
                while (!UserReader.EndOfStream)
                {
                    string userRecord = UserReader.ReadLine();
                    string[] userAttributes = userRecord.Split(',');
                    int userID = Int32.Parse(userAttributes[0]);
                    string fName = userAttributes[1];
                    string lName = userAttributes[2];
                    Users user = new Users(userID, fName, lName);
                    Us.Add(user);
                }
                UserReader.Close();
            }
            return Us;
        }

        static List<Users> CreateUser(List<Users> user)
        {
            string userFormat = "    {0,-8}\t{1,-20}\t{2,-20}";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Create User\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();

            Console.Write("    Please enter the first name: ");
            String fname = Console.ReadLine();
            while (fname == "")
            {
                Console.Write("\n    Please enter a first name: ");
                fname = Console.ReadLine();
            }

            Console.Write("\n    Please enter the last name: ");
            String lname = Console.ReadLine();
            while (lname == "")
            {
                Console.Write("\n    Please enter a last name: ");
                lname = Console.ReadLine();
            }

            // Get max value of current user ID's and add 1 to it for the new User ID
            int max = 0;
            foreach (Users u in user)
            {
                max = user.Max(a => a.GetUserID());
            }

            // Create User
            Users newUser = new Users(max + 1, fname, lname);
            user.Add(newUser);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Create User\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("    User successfully created!\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(userFormat, "User ID", "First Name", "Last Name");
            Console.WriteLine(userFormat, "------", "------------------", "------------------");
            Console.ResetColor();

            foreach (Users u in user)
            {
                if (u.GetUserID() == max + 1)
                {
                    Console.WriteLine(userFormat, u.GetUserID(), u.GetFName(), u.GetLName());
                }
            }

            Console.Write("\n    Press any Key to return to the Main Menu: ");
            Console.ReadKey();
            Console.Clear();

            return user;
        }

        static void SaveUser(List<Users> us)
        {
            StreamWriter ul = new StreamWriter("Users.txt");
            foreach (Users u in us)
            {
                string cust = u.ToString();
                ul.WriteLine(cust);
            }
            ul.Close();
        }

        static List<Users> ViewUsers(List<Users> user)
        {
            string userFormat = "    {0,-4}\t{1,-15}\t{2,-15}";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    View Users\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.WriteLine(userFormat, "User ID", "First Name", "Last Name");
            Console.WriteLine(userFormat, "------", "-------------", "-------------");
            Console.ResetColor();

            foreach (Users u in user)
            {
                Console.WriteLine(userFormat, u.GetUserID(), u.GetFName(), u.GetLName());
            }
            Console.Write("\n    Press any Key to return to the Main Menu: ");
            Console.ReadKey();
            Console.Clear();
            return user;
        }


        static public int validateInt(string input)
        {
            int output = 0;
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