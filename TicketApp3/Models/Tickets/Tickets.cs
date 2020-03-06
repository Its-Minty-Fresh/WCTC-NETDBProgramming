using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace TicketApp3.Models
{
    public class Tickets : Record
    {
        public int severity { get; set; }

        public Tickets()
        {
            severity = 0;
        }

        // public method
        public override void Display()
        {
            Console.WriteLine($"Ticket Id: {recordID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatchgroup: {watchrgoup}\nSeverity: {severity}"); 
        }

        public virtual void Display2()
        {
            Console.WriteLine($"Ticket Id: {recordID}\nSummary: {summary}");
        }

        //public static List<Tickets> LoadTickets()
        //{
        //    List<TicketFile> tickets = new List<TicketFile>();

        //    foreach (TicketFile t in tickets)
        //    {
        //        tickets.Add(t);
        //    }
        //   // return tickets;
        //}
    }
}
