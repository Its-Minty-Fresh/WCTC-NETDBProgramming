using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TicketApp2._0.Models;

namespace TicketApp2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            int selection = mainMenu.GetMainMenuSelection();

            while (selection == 1)
            {
                Format format = new Format();
                TestManager testManager = new TestManager();

                Console.Clear();
                format.ViewTicketHeader();
                testManager.Process(selection);







                Console.ReadLine();
            }

            Console.WriteLine(selection);
            Console.ReadLine();
        }


        static List<Tickets> LoadTickets()
        {
            string file = "Tickets.txt";
            List<Tickets> Tks = new List<Tickets>();
            if (File.Exists(file))
            {
                StreamReader TicketReader = new StreamReader(file);
                while (!TicketReader.EndOfStream)
                {
                    string ticketRecord = TicketReader.ReadLine();
                    string[] ticketAttributes = ticketRecord.Split(',');
                    int ticketID = Int32.Parse(ticketAttributes[0]);
                    string summary = ticketAttributes[1];
                    int status = Int32.Parse(ticketAttributes[2]);
                    string priority = ticketAttributes[3];
                    int submitterID = Int32.Parse(ticketAttributes[4]);
                    int assignedID = Int32.Parse(ticketAttributes[5]);
                    int watchingGrp = Int32.Parse(ticketAttributes[6]);
                    int severity = Int32.Parse(ticketAttributes[7]);

                    Tickets tickets = new Tickets(ticketID, summary, status, priority, submitterID, assignedID, watchingGrp, severity);
                    Tks.Add(tickets);
                }
                TicketReader.Close();
            }
            return Tks;
        }
    }
}
