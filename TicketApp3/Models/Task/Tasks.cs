using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace TicketApp3.Models
{
    public class Tasks : Record
    {
        public int project { get; set; }
        public string  dueDate { get; set; }

        public Tasks()
        {
            project = 0;
            dueDate = "N/A";
        }

        // public method
        public virtual void Display()
        {
            Console.WriteLine($"Task Id: {recordID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatchgroup: {watchrgoup}\nProjectName: {project}\nDueDate: {dueDate}");
        }

        public virtual void Display2()
        {
            Console.WriteLine($"Task Id: {recordID}\nSummary: {summary}");
        }
    }
}
