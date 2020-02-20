using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp2._0.Models
{
    class Test
    {

        private int TestID { get; set; }
        private string FName { get; set; }
        private string LName { get; set; }

        // user constructor 1
        public Test()
        {
            this.TestID = 0;
            this.FName = "";
            this.LName = "";
        }

        // user constructor 2
        public Test(int userID, string fName, string lName)
        {
            this.TestID = userID;
            this.FName = fName;
            this.LName = lName;
        }

        public void SetUserID(int userID)
        {
            this.TestID = userID;
        }
        public int GetUserID()
        {
            return this.TestID;
        }

        public void SetFName(string fname)
        {
            this.FName = fname;
        }
        public string GetFName()
        {
            return this.FName;
        }

        public void SetLName(string lname)
        {
            this.LName = lname;
        }
        public string GetLName()
        {
            return this.LName;
        }
    }
}
