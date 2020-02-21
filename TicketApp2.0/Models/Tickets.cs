using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TicketApp2._0.Models;

namespace TicketApp2._0
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


        public void SetRecordID(int recordID)
        {
            RecordID = recordID;
        }
        public int GetRecordID()
        {
            return RecordID;
        }

        public void SetSummary(string summary)
        {
            Summary = summary;
        }
        public string GetSummary()
        {
            return Summary;
        }

        public void SetStatus(int status)
        {
            Status = status;
        }
        public int GetStatus()
        {
            return Status;
        }

        public void SetPriority(string priority)
        {
            Priority = priority;
        }
        public string GetPriority()
        {
            return Priority;
        }

        public void SetSubmitter(int submitterID)
        {
            Submitter = submitterID;
        }
        public int GetSubmitter()
        {
            return Submitter;
        }

        public void SetAssignee(int assigneeID)
        {
            Assignee = assigneeID;
        }
        public int GetAssignee()
        {
            return Assignee;
        }

        public void SetWatchGrp(int watchGrp)
        {
            WatchGroup = watchGrp;
        }
        public int GetWatchGrp()
        {
            return WatchGroup;
        }

        public void SetTSeverity(int severity)
        {
            Severity = severity;
        }
        public int GetSeverity()
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


       
        public void ViewTickets()
        {
            List<Tickets> ticket = new List<Tickets>();
            List<Users> user = new List<Users>();
            List<WatchGrp> watchGroup = new List<WatchGrp>();

            Format getTicketHeader = new Format();
            Format getTicketFormat = new Format();
            Format getWGformat = new Format();

            
            
            // Get a list of tickets with the user names
            var tktQuery = from t in ticket
                           join ua in user on t.GetAssignee() equals ua.GetUserID()
                           join us in user on t.GetSubmitter() equals us.GetUserID()
                           select new
                           {
                               tkt = t.GetRecordID(),
                               tsum = t.GetSummary(),
                               status = t.GetStatus(),
                               priority = t.GetPriority(),
                               assigned = ua.GetFName() + " " + ua.GetLName(),
                               submitted = us.GetFName() + " " + us.GetLName(),
                               wgID = t.GetWatchGrp()
                           };

            var wGrpQuery = from t in ticket
                            join wg in watchGroup on t.WatchGroup equals wg.GetWatchGrpID()
                            join uw in user on wg.GetUserID() equals uw.GetUserID()
                            // where t.GetWatchingGrp() != 0
                            select new
                            {
                                tkt = t.GetRecordID(),
                                userID = wg.GetUserID(),
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
                    if (t.wgID == u.wg)
                    {
                        watchers.Add(u.watcher);
                        watcherCount = watchers.Count;
                    }
                }
                if (t.wgID == 0)
                {
                    watcher = "";
                }
                else if (watcherCount == 1)
                {
                    watcher = watchers[0];
                }
                else
                {
                    watcher = watchers[0] + " +" + (watchers.Count - 1);
                }
                Console.WriteLine(getTicketFormat.GetTicketsFormat(), t.tkt, summary, t.status, t.priority, t.assigned, t.submitted, watcher);
            } 
        } 



        public void ShowTickets(List<Tickets> tickets)
        {
            foreach (var ticket in tickets.Take(10)) Console.WriteLine(ticket.ToString());
        }

    }
}
