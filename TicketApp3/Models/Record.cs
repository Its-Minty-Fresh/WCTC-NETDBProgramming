using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp3.Models
{
    public abstract class Record
    {
        public int recordID { get; set; }
        public string summary { get; set; }
        public int status { get; set; }
        public int priority { get; set; }
        public int submitter { get; set; }
        public int assigned { get; set; }
        public int watchrgoup { get; set; }

        public Record()
        {
            //Format f = new Format();
            //recordID = f.GetMaxRecordID();
            recordID = 0;
            summary = "N/A";
            status = 0;
            priority = 0;
            submitter = 0;
            assigned = 0;
            watchrgoup = 0;
        }

        public virtual void Display()
        {
            Console.WriteLine($"ID: {recordID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatchgroup: {watchrgoup}");
        }
    }
}

