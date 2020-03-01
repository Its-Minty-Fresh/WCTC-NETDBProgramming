using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TicketApp3.Models.Enhancements
{
    public class EnhancementFile
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        // public property
        public string filePath { get; set; }
        public List<Enhancement> Enhancemnet { get; set; }

        public string EnhancementFilePath()
        {
            return "../../Files/enhancements.txt";
        }

        public EnhancementFile(string path)
        {
            Enhancemnet = new List<Enhancement>();
            filePath = path;

            //try
            //{
            StreamReader sr = new StreamReader(filePath);
            // first line contains column headers
            // sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // create instance of Movie class
                Enhancement enhancement = new Enhancement();
                string line = sr.ReadLine();

                string[] ticketDetails = line.Split(',');
                enhancement.recordID = Int32.Parse(ticketDetails[0]);
                enhancement.summary = ticketDetails[1];
                enhancement.status = Int32.Parse(ticketDetails[2]);
                enhancement.priority = Int32.Parse(ticketDetails[3]);
                enhancement.submitter = Int32.Parse(ticketDetails[4]);
                enhancement.assigned = Int32.Parse(ticketDetails[5]);
                enhancement.watchrgoup = Int32.Parse(ticketDetails[6]);
                enhancement.software = Int32.Parse(ticketDetails[7]);
                enhancement.cost = Convert.ToDouble(ticketDetails[8]);
                enhancement.reason = Int32.Parse(ticketDetails[9]);
                enhancement.estimate = Convert.ToDouble(ticketDetails[10]);

                Enhancemnet.Add(enhancement);
            }
            // close file when done
            sr.Close();
            logger.Info("Tickets in file {Count}", Enhancemnet.Count);
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex.Message);
            //}
        }


        public void AddEnhancement(Enhancement e)
        {
            List<Enhancement> enhancement = new List<Enhancement>();

            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine($"\n{e.recordID},{e.summary},{e.status},{e.priority},{e.submitter},{e.assigned},{e.watchrgoup},{e.software},{e.cost},{e.reason},{e.estimate}");

            //try
            //{
            //    //first generate movie id
            //    t.recordID = Ticket.Max(m => m.recordID) + 1;

            //    StreamWriter sw = new StreamWriter(filePath);
            //    sw.WriteLine($"\n{t.recordID},{t.summary},{t.status},{t.priority},{t.submitter},{t.assigned},{t.watchrgoup},{t.severity}");
            //    sw.Close();
            //    Ticket.Add(t);
            //    logger.Info("Ticket id {Id} added", t.recordID);

            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex.Message);
            //}
        }


        public void ShowEnhancements()
        {

            EnhancementFile enhancementFile = new EnhancementFile(EnhancementFilePath());
            Format f = new Format();
            foreach (Enhancement e in enhancementFile.Enhancemnet)
            {
                Console.WriteLine(f.GetEnhancementsFormat(), e.recordID, e.summary, e.status, e.priority, e.submitter, e.assigned, e.watchrgoup, e.software, e.cost, e.reason, e.estimate);
            }
            Console.WriteLine();
        }
    }
}
