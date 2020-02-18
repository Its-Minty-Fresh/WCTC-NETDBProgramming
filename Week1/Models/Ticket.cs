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
using System.Text;
using System.IO;

namespace Week1
{
    class Ticket
    {
        // instance variables
        private int TicketID { get; set; }
        private string Summary { get; set; }
        private string Status { get; set; }
        private string Priority { get; set; }
        private int SubmitterID { get; set; }
        private int AssignedID { get; set; }
        private int WatchingGrp { get; set; }

        // ticket constructor 1
        public Ticket()
        {
            this.TicketID = 0;
            this.Summary = "";
            this.Status = "";
            this.Priority = "";
            this.SubmitterID = 0;
            this.AssignedID = 0;
            this.WatchingGrp = 0;
        }

        // ticket constructor 2
        public Ticket(int ticketID, string summary, string status, string priority, int submitterID, int assignedID, int watchingGrp)
        {
            this.TicketID = ticketID;
            this.Summary = summary;
            this.Status = status;
            this.Priority = priority;
            this.SubmitterID = submitterID;
            this.AssignedID = assignedID;
            this.WatchingGrp = watchingGrp;
        }

        // Ticket ID Setter
        public void SetTicketID(int ticketID)
        {
            this.TicketID = ticketID;
        }
        // Ticket ID Getter
        public int GetTicketID()
        {
            return this.TicketID;
        }


        // Summary Setter
        public void SetSummary(string summary)
        {
            this.Summary = summary;
        }
        // Summary Getter
        public string GetSummary()
        {
            return this.Summary;
        }

        // Status Setter
        public void SetStatus(string status)
        {
            this.Status = status;
        }
        // Status Getter
        public string GetStatus()
        {
            return this.Status;
        }

        // Priority Setter
        public void SetPriority(string priority)
        {
            this.Priority = priority;
        }
        // Priority Getter
        public string GetPriority()
        {
            return this.Priority;
        }

        // Submitter ID Setter
        public void SetSubmitterID(int submitterID)
        {
            this.SubmitterID = submitterID;
        }
        // Submitter ID Getter
        public int GetSubmitterID()
        {
            return this.SubmitterID;
        }

        // Assigned ID Setter
        public void SetAssignedID(int assignedID)
        {
            this.AssignedID = assignedID;
        }
        // Assigned ID Getter
        public int GetAssignedID()
        {
            return this.AssignedID;
        }

        // Watching Group ID Setter
        public void SetWatchingGrp(int watchingGrp)
        {
            this.WatchingGrp = watchingGrp;
        }
        // Watching Group ID Getter
        public int GetWatchingGrp()
        {
            return this.WatchingGrp;
        }

        public override string ToString()
        {
            string tkt = this.TicketID.ToString();
            tkt = tkt + ",";
            tkt = tkt + this.Summary;
            tkt = tkt + ",";
            tkt = tkt + this.Status;
            tkt = tkt + ",";
            tkt = tkt + this.Priority;
            tkt = tkt + ",";
            tkt = tkt + this.SubmitterID;
            tkt = tkt + ",";
            tkt = tkt + this.AssignedID;
            tkt = tkt + ",";
            tkt = tkt + this.WatchingGrp;
            return tkt;
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

    }
}
