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


        public TicketFile(string path)
        {
            Ticket = new List<Tickets>();
            filePath = path;

            //try
            //{
                StreamReader sr = new StreamReader(filePath);
                // first line contains column headers
                sr.ReadLine();
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


        public void AddTicket(List<Tickets> t)
        {
            //try
            //{
                // first generate movie id
                //t.recordID = Ticket.Max(m => m.recordID) + 1;
                // if title contains a comma, wrap it in quotes
                //string title = ticket.title.IndexOf(',') != -1 ? $"\"{ticket.title}\"" : ticket.title;

                StreamWriter sw = new StreamWriter(filePath);
                //sw.WriteLine($"\n{t.recordID},{t.summary},{t.status},{t.priority},{t.submitter},{t.assigned},{t.watchrgoup},{t.severity}");
                //sw.Close();
                //// add movie details to Lists
                //Ticket.Add(t);
                //// log transaction
                //logger.Info("Movie id {Id} added", t.recordID);


                foreach(Tickets tk in t)
                {
                    string tkt = tk.ToString();
                    sw.WriteLine(tkt);
                }


            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex.Message);
            //}
        }

        public void AddTicket2(Tickets t)
        {
            try
            {
                //first generate movie id
                t.recordID = Ticket.Max(m => m.recordID) + 1;

                StreamWriter sw = new StreamWriter(filePath);
                sw.WriteLine($"\n{t.recordID},{t.summary},{t.status},{t.priority},{t.submitter},{t.assigned},{t.watchrgoup},{t.severity}");
                sw.Close();
                // add movie details to Lists
                Ticket.Add(t);
                // log transaction
                logger.Info("Movie id {Id} added", t.recordID);

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

    }

}
