using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp2._0.Models
{
    class Record
    {
        public int RecordID { get; set; }
        public string RecordType { get; set; }
        public string Summary { get; set; }
        public int Status { get; set; }
        public string Priority { get; set; }
        public int Submitter { get; set; }
        public int Assignee { get; set; }
        public int WatchGroup { get; set; }

        public Record()
        {
            RecordID = 0;
            RecordType = "Ticket";
            Summary = "";
            Status = 0;
            Priority = "Low";
            Submitter = 0;
            Assignee = 0;
            WatchGroup = 0;
        }


    }
}
