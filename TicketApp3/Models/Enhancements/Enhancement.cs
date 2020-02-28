using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp3.Models.Enhancements
{
    class Enhancement : Record
    {
        public int software { get; set; }
        public double cost { get; set; }
        public int reason { get; set; }
        public double estimate { get; set; }
        public Enhancement()
        {
            software = 0;
            cost = 0;
            reason = 0;
            estimate = 0;
        }

        // public method
        public virtual void Display()
        {
            Console.WriteLine($"Ticket Id: {recordID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nSoftware: {software}\nCost: {cost}\nReason: {reason}\nEstimate: {estimate}");
        }

        public virtual void Display2()
        {
            Console.WriteLine($"Ticket Id: {recordID}\nSummary: {summary}");
        }

    }
}
