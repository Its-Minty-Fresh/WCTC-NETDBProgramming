using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Week1
{
    class FileMgmt
    {


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
    }
}
