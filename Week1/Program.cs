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


            int selection = 0;

            do
            {
                selection = MainMenu();
                if (selection == 2)
                {
                    Console.Clear();
                    UserList = ViewUsers(UserList);
                }
                if (selection == 3)
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
            Console.WriteLine("\n    -------------------------------------------------------------------------------------------------------\n" +
                "    Welcome to Matts Support Ticket System!!\n" +
                "    -------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("    What would you like to do?\n\n" +
                "    1) View Tickets\n" +
                "    2) View Users\n" +
                "    3) Create User\n" +
                "    4) Quit");

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
            Console.WriteLine("\n    -------------------------------------------------------------------------------------------------------\n" +
                "    Create User\n" +
                "    -------------------------------------------------------------------------------------------------------\n");
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
            Console.WriteLine("\n    -------------------------------------------------------------------------------------------------------\n" +
                "    Create User\n" +
                "    -------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();
            Console.WriteLine("    User successfully created!\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(userFormat, "User ID", "First Name", "Last Name");
            Console.WriteLine(userFormat, "------", "------------------", "------------------");
            Console.ResetColor();
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
            Console.WriteLine("\n    -------------------------------------------------------------------------------------------------------\n" +
                "    View Users\n" +
                "    -------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine(userFormat, "User ID", "First Name", "Last Name");
            Console.WriteLine(userFormat, "------", "-------------", "-------------");
            Console.ResetColor();

            foreach (Users u in user)
            {
                Console.WriteLine(userFormat, u.GetUserID(), u.GetFName(), u.GetLName());
            }
            Console.ReadKey();
            return user;
        }
    }
}
