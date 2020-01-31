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
            List<WatchGrp> WatchGroups = LoadWatchGroups();

            int selection = 0;

            do
            {
                selection = MainMenu();
                if (selection == 1)
                {
                    Console.Clear();
                    TicketList = ViewTickets(TicketList, UserList, WatchGroups);
                    SaveWatchGrp(WatchGroups);
                    SaveTicket(TicketList);
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
                if (selection == 5)
                {
                    Console.Clear();
                    WatchGroups = CreateWatchGrp2(WatchGroups);
                    SaveWatchGrp(WatchGroups);
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
                "    5) Create WG\n" +
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

            Console.Write("\n    Please enter the user ID of the user creating this ticket: ");
            int createdByID = validateInt(Console.ReadLine());
            while (!userID.Contains(createdByID))
            {
                Console.Write("    Please select a valid User ID! ");
                createdByID = validateInt(Console.ReadLine());
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Create Ticket\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();

            Console.Write("    Please enter a ticket summary: ");
            String summary = Console.ReadLine();
            while (summary == "")
            {
                Console.Write("\n    Please enter a ticket summary: ");
                summary = Console.ReadLine();
            }

            summary = summary.Replace(",", ";"); /*remove any user entered commas to help with Split(',')*/

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


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Create Ticket\n" +
                "    ---------------------------------------------------------------------------------------------\n");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(userFormat, "User ID", "First Name", "Last Name");
            Console.WriteLine(userFormat, "------", "-------------", "-------------");
            Console.ResetColor();


            // Display users
            foreach (Users u in user)
            {
                Console.WriteLine(userFormat, u.GetUserID(), u.GetFName(), u.GetLName());
                userID.Add(u.GetUserID());
            }

            Console.Write("\n    Please enter the user ID of the user this ticket is assigned to: ");
            int assignedToID = validateInt(Console.ReadLine());
            while (!userID.Contains(assignedToID))
            {
                Console.Write("    Please select a valid User ID! ");
                assignedToID = validateInt(Console.ReadLine());
            }


            // Get max value of current ticket ID's and add 1 to it for the new ticket ID
            int max = 0;
            foreach (Ticket t in ticket)
            {
                max = ticket.Max(a => a.GetTicketID()) + 1;
            }

            // Create Ticket
            Ticket newTicket = new Ticket(max, summary, "Open", pri, createdByID, assignedToID, 0);
            ticket.Add(newTicket);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Create Ticket\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("    Ticket successfully created!\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ticketFormat, "Ticket #", "Summary", "Status", "Priorty", "Assigned To", "Created By", "Watching");
            Console.WriteLine(ticketFormat, "------", "------------------------------------", "------", "------", "------------", "------------", "------------");
            Console.ResetColor();

            var query = from t in ticket
                        join ua in user on t.GetAssignedID() equals ua.GetUserID()
                        join us in user on t.GetSubmitterID() equals us.GetUserID()
                        select new { tkt = t.GetTicketID(), tsum = t.GetSummary(), status = t.GetStatus(), priority = t.GetPriority(), assigned = ua.GetFName() + " " + ua.GetLName(), submitted = us.GetFName() + " " + us.GetLName(), watch = t.GetWatchingGrp() };


            foreach (var t in query)
            {
                string tsummary;
                if (t.tsum.Length > 50) // Limmit summary output to 50 charachters
                {
                    tsummary = t.tsum.Remove(50);
                }
                else
                {
                    tsummary = t.tsum;
                }
                if (t.tkt == max)
                {
                    Console.WriteLine(ticketFormat, t.tkt, tsummary, t.status, t.priority, t.assigned, t.submitted, t.watch);
                }
                
            }

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

        static List<Ticket> ViewTickets(List<Ticket> ticket, List<Users> user, List<WatchGrp> watchGroup)
        {
            string ticketFormat = "    {0,-4}\t{1,-50}\t{2,-4}\t{3,-4}\t{4,-4}\t{5,-4}\t{6,-4}\t{7,-4}";
            string watchGrpFormat = "    \t\t\t\t\t\t\t\t\t\t\t\t\t\t\t{0,-4}";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    View Tickets\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.WriteLine(ticketFormat, "Ticket #", "Summary", "Status", "Priorty", "Assigned To", "Created By", "Watching","Count");
            Console.WriteLine(ticketFormat, "------", "------------------------------------", "------", "------", "------------", "------------", "------------","----");
            Console.ResetColor();

            // Get a list of tickets with the user names
            var tktQuery = from t in ticket
                           join ua in user on t.GetAssignedID() equals ua.GetUserID()
                           join us in user on t.GetSubmitterID() equals us.GetUserID()
                           select new
                           {
                               tkt = t.GetTicketID(),
                               tsum = t.GetSummary(),
                               status = t.GetStatus(),
                               priority = t.GetPriority(),
                               assigned = ua.GetFName() + " " + ua.GetLName(),
                               submitted = us.GetFName() + " " + us.GetLName(),
                               wgID = t.GetWatchingGrp()
                           };


            var wGrpQuery = from t in ticket
                            join wg in watchGroup on t.GetWatchingGrp() equals wg.GetWatchGrpID()
                            join uw in user on wg.GetUserID() equals uw.GetUserID()
                            where t.GetWatchingGrp() != 0
                            select new 
                            { 
                                tkt = t.GetTicketID(), 
                                watcher = uw.GetFName() + " " + uw.GetLName(), 
                                wg = wg.GetWatchGrpID() 
                            };

            foreach (var t in tktQuery)
            {
                string summary;
                if (t.tsum.Length > 50) // Limit summary output to 50 charachters
                {
                    summary = t.tsum.Remove(50);
                }
                else
                {
                    summary = t.tsum;
                }
                string watcher;


                
                int watcherCount = 0;
                List<string> watchers = new List<string>();
                foreach (var u in wGrpQuery)
                {
                    if(t.wgID == u.wg)
                    {
                        watchers.Add(u.watcher);
                        watcherCount = watchers.Count;
                    }
                }
                if (t.wgID == 0)
                {
                    watcher = "";
                }
                else if(watcherCount == 1)
                {
                    watcher = watchers[0];
                }
                else
                {
                    watcher = watchers[0] + " +" + (watchers.Count - 1);
                }

                Console.WriteLine(ticketFormat, t.tkt, summary, t.status, t.priority, t.assigned, t.submitted, watcher, watcherCount);
                int i = 0;
                foreach (var u in wGrpQuery)
                {
                    if (t.wgID == u.wg)
                    {
                        if (watchers.Count > 1)
                        {
                            //foreach(var g in watchers.Skip(1))
                            //{
                            //    Console.WriteLine(watchGrpFormat, watchers[i]);
                            //}
                        }
                    }
                    i++;
                }
            }

            Console.Write("\n    What would you like to do?\n\n" +
                "    1: View or Edit Ticket Watchers\n" +
                "    2: Return to Main Menu\n");
            
            Console.Write("    ");
            int userSelection = validateInt(Console.ReadLine());
            while ((userSelection < 0 || userSelection > 2))
            {
                Console.Write("    Please Enter a valid response 1 - 2 ");
                userSelection = validateInt(Console.ReadLine());
            }

            if(userSelection == 1)
            {
                // Create list of ticket IDs for validation
                List<int> ticketID = new List<int>();

                foreach (Ticket t in ticket)
                {
                    ticketID.Add(t.GetTicketID());
                }

                Console.Write("    Enter Ticket # to view: ");
                int tktID = validateInt(Console.ReadLine());
                while (!ticketID.Contains(tktID))
                {
                    Console.Write("    Please select a valid Ticket #: ");
                    tktID = validateInt(Console.ReadLine());
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                    "    View Tickets\n" +
                    "    ---------------------------------------------------------------------------------------------\n");
                Console.WriteLine(ticketFormat, "Ticket #", "Summary", "Status", "Priorty", "Assigned To", "Created By", "Watching");
                Console.WriteLine(ticketFormat, "------", "------------------------------------", "------", "------", "------------", "------------", "------------");
                Console.ResetColor();

                // Create list of user IDs for validation
                List<int> userID = new List<int>();
                foreach (Users u in user)
                {
                    userID.Add(u.GetUserID());
                }

                int wgID = 0;
                foreach (var t in tktQuery)
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
                    string watcher;
                    if (t.wgID == 0)
                    {
                        watcher = "";
                    }
                    else
                    {
                        watcher = "Being Watched";
                    }
                    if (t.tkt == tktID)
                    {
                        Console.WriteLine(ticketFormat, t.tkt, summary, t.status, t.priority, t.assigned, t.submitted, watcher);
                        wgID = t.wgID;
                    }
                }

                if (wgID == 0)
                {
                    Console.Write("\n    Enter User ID to add to Watch List: ");
                    int resp = validateInt(Console.ReadLine());
                    while (!userID.Contains(resp))
                    {
                        Console.Write("    Please select a valid User ID! ");
                        resp = validateInt(Console.ReadLine());
                    }

                    int max = 0;
                    foreach (WatchGrp w in watchGroup)
                    {
                        max = watchGroup.Max(a => a.GetWatchGrpID() + 1);
                    }

                    WatchGrp newwg = new WatchGrp(max, resp);
                    watchGroup.Add(newwg);
                }
                else
                {
                    Console.Write("\n    What would you like to do?\n\n" +
                       "    1: Add Watchers\n" +
                       "    2: Remove Watchers\n");

                    Console.Write("    ");
                    userSelection = validateInt(Console.ReadLine());
                    while ((userSelection < 0 || userSelection > 2))
                    {
                        Console.Write("    Please Enter a valid response 1 - 2 ");
                        userSelection = validateInt(Console.ReadLine());
                    }
                    if(userSelection == 1)
                    {
                        Console.Write("\n    Enter User ID to add to Watch List: ");
                        int resp = validateInt(Console.ReadLine());
                        while (!userID.Contains(resp))
                        {
                            Console.Write("    Please select a valid User ID! ");
                            resp = validateInt(Console.ReadLine());
                        }
                        WatchGrp newwg = new WatchGrp(wgID, resp);
                        watchGroup.Add(newwg);
                    }
                    else if (userSelection == 2)
                    {
                        Console.Write("\n    Enter User ID to remove from the Watch List: ");
                        int resp = validateInt(Console.ReadLine());
                        while (!userID.Contains(resp))
                        {
                            Console.Write("    Please select a valid User ID! ");
                            resp = validateInt(Console.ReadLine());
                        }
                        WatchGrp newwg = new WatchGrp(wgID, resp);
                        watchGroup.Remove(newwg);
                        SaveWatchGrp(watchGroup);
                    }
                }

                Console.ReadKey();
            }

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
                max = user.Max(a => a.GetUserID()) + 1;
            }

            // Create User
            Users newUser = new Users(max, fname, lname);
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
                if (u.GetUserID() == max)
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



        static List<WatchGrp> LoadWatchGroups()
        {
            string file = "WatchGroups.txt";
            List<WatchGrp> Wg = new List<WatchGrp>();
            if (File.Exists(file))
            {
                StreamReader WGrpReader = new StreamReader(file);
                while (!WGrpReader.EndOfStream)
                {
                    string wGrpRecord = WGrpReader.ReadLine();
                    string[] wgAttributes = wGrpRecord.Split(',');
                    int userID = Int32.Parse(wgAttributes[0]);
                    int watchGrpID = Int32.Parse(wgAttributes[1]);

                    WatchGrp wGroup = new WatchGrp(userID, watchGrpID);
                    Wg.Add(wGroup);
                }
                WGrpReader.Close();
            }
            return Wg;
        }



        static List<WatchGrp> CreateWatchGrp2(List<WatchGrp> watchGrp)
        {
            string watchGrpFormat = "    {0,-8}\t{1,-20}";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Create WatchGro\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();

            Console.Write("    Please enter the WG ID: ");
            int wgid = validateInt(Console.ReadLine());


            Console.Write("\n    Please enter a  user ID: ");
            int usid = validateInt(Console.ReadLine());



            // Create User
            WatchGrp newwg = new WatchGrp(wgid, usid);
            watchGrp.Add(newwg);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Create User\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("    User successfully created!\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(watchGrpFormat, "WG ID", "User ID");
            Console.WriteLine(watchGrpFormat, "------", "------");
            Console.ResetColor();

            foreach (WatchGrp w in watchGrp)
            {
                if (w.GetWatchGrpID() == wgid)
                {
                    Console.WriteLine(watchGrpFormat, w.GetWatchGrpID(), w.GetUserID());
                }
            }

            Console.Write("\n    Press any Key to return to the Main Menu: ");
            Console.ReadKey();
            Console.Clear();

            return watchGrp;
        }

        static List<WatchGrp> CreateWatchGrp(List<WatchGrp> watchGrp)
        {
            string watchGrpFormat = "    {0,-8}\t{1,-20}";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Create WatchGro\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();

            Console.Write("    Please enter the WG ID: ");
            int wgid = validateInt(Console.ReadLine());


            Console.Write("\n    Please enter a  user ID: ");
            int usid = validateInt(Console.ReadLine());



            // Create WatchGroup
            WatchGrp newwg = new WatchGrp(wgid, usid);
            watchGrp.Add(newwg);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    ---------------------------------------------------------------------------------------------\n" +
                "    Create User\n" +
                "    ---------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("    User successfully created!\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(watchGrpFormat, "WG ID", "User ID");
            Console.WriteLine(watchGrpFormat, "------", "------");
            Console.ResetColor();

            foreach (WatchGrp w in watchGrp)
            {
                if (w.GetWatchGrpID() == wgid)
                {
                    Console.WriteLine(watchGrpFormat, w.GetWatchGrpID(), w.GetUserID());
                }
            }

            Console.Write("\n    Press any Key to return to the Main Menu: ");
            Console.ReadKey();
            Console.Clear();

            return watchGrp;
        }

        static void SaveWatchGrp(List<WatchGrp> wg)
        {
            StreamWriter ul = new StreamWriter("WatchGroups.txt");
            foreach (WatchGrp u in wg)
            {
                string group = u.ToString();
                ul.WriteLine(group);
            }
            ul.Close();
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