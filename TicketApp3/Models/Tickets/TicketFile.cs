using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using System.IO;

namespace TicketApp3.Models
{
    public class TicketFile
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        // public property
        public string filePath { get; set; }
        public List<Tickets> Ticket { get; set; }

        public int MaxID { get; set; }

        public string TicketFilePath()
        {
            return "../../Files/tickets.txt";
        }

        public TicketFile(string path)
        {
            Ticket = new List<Tickets>();
            filePath = path;

            //try
            //{
                StreamReader sr = new StreamReader(filePath);
                // first line contains column headers
               // sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    // create instance of Movie class
                    Tickets ticket = new Tickets();
                    string line = sr.ReadLine();

                    string[] ticketDetails = line.Split(',');
                    ticket.recordID = Int32.Parse(ticketDetails[0]);
                    ticket.summary = ticketDetails[1];
                    ticket.status = Int32.Parse(ticketDetails[2]);
                    ticket.priority = Int32.Parse(ticketDetails[3]);
                    ticket.submitter = Int32.Parse(ticketDetails[4]);
                    ticket.assigned = Int32.Parse(ticketDetails[5]);
                    ticket.watchrgoup = Int32.Parse(ticketDetails[6]);
                    ticket.severity = Int32.Parse(ticketDetails[7]);

                    Ticket.Add(ticket);
                }
                // close file when done
                sr.Close();
                logger.Info("Tickets in file {Count}", Ticket.Count);
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex.Message);
            //}
        }


        public void AddTicket(Tickets t)
        {
            TaskFile tf = new TaskFile();
            EnhancementFile ef = new EnhancementFile();
            int i = new[] { tf.GetMaxTaskID(), ef.GetMaxEnhID(), GetMaxTicketID() }.Max() + 1;

            StreamWriter sw = new StreamWriter(filePath,append:true);
            sw.WriteLine($"\n{i},{t.summary},{t.status},{t.priority},{t.submitter},{t.assigned},{t.watchrgoup},{t.severity}");
            Ticket.Add(t);
            sw.Close();

            //try
            //{
            //    //first generate movie id
            //    t.recordID = Ticket.Max(m => m.recordID) + 1;

            //    StreamWriter sw = new StreamWriter(filePath);
            //    sw.WriteLine($"\n{t.recordID},{t.summary},{t.status},{t.priority},{t.submitter},{t.assigned},{t.watchrgoup},{t.severity}");
            //    sw.Close();
            //    Ticket.Add(t);
            //    logger.Info("Ticket id {Id} added", t.recordID);

            //}t.recordID, t.summary, t.status, t.priority, t.submitter, t.assigned, t.watchrgoup, t.severity);
            //catch (Exception ex)
            //{
            //    logger.Error(ex.Message);
            //}
        }


        public void ShowTickets()
        {
            TicketFile ticketFile = new TicketFile(TicketFilePath());

            Format f = new Format();
            foreach (Tickets t in ticketFile.Ticket)
            {
                Console.WriteLine(f.GetTicketsFormat(), t.recordID, t.summary, t.status, t.priority, t.submitter, t.assigned, t.watchrgoup, t.severity);
            }
        }

        public static List<Tickets> LoadTickets()
        {
            List<Tickets> tickets = new List<Tickets>();
            
            foreach(Tickets t in tickets)
            {
                tickets.Add(t);
            }
            return tickets;
        }


        public TicketFile()
        {

        }

        public int GetMaxTicketID()
        {
            TicketFile tf = new TicketFile(TicketFilePath());
            List<int> maxID = new List<int>();

            foreach (Tickets t in tf.Ticket)
            {
                maxID.Add(t.recordID);
            }
            return maxID.Max();
        }
    }

}
