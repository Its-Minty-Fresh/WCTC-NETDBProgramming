using System;
using System.Collections.Generic;
using System.IO;
using TicketApp2._0.Models;

namespace Week1
{
    class Tickets : Record
    {
        public int Severity { get; set; }



        public Tickets()
        {
            RecordID = 0;
            Summary = "";
            Status = 0;
            Priority = "";
            Submitter = 0;
            Assignee = 0;
            WatchGroup = 0;
            Severity = 0;
        }

        public Tickets(int recordID, string summary, int status, string priority, int submitterID, int assignee, int watchingGrp, int severity)
        {
            RecordID = recordID;
            Summary = summary;
            Status = status;
            Priority = priority;
            Submitter = submitterID;
            Assignee = assignee;
            WatchGroup = watchingGrp;
            Severity = severity;
        }

        public void SetTicketSeverity(int severity)
        {
            Severity = severity;
        }

        public int GetTicketSeverity()
        {
            return Severity;
        }


        public override string ToString()
        {
            string tkt = RecordID.ToString();
            tkt = tkt + ",";
            tkt = tkt + Summary;
            tkt = tkt + ",";
            tkt = tkt + Status;
            tkt = tkt + ",";
            tkt = tkt + Priority;
            tkt = tkt + ",";
            tkt = tkt + Submitter;
            tkt = tkt + ",";
            tkt = tkt + Assignee;
            tkt = tkt + ",";
            tkt = tkt + WatchGroup;
            tkt = tkt + ",";
            tkt = tkt + Severity;
            return tkt;
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
