using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp2._0.Models
{
    class Test
    {

        public int TestID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

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
            TestID = userID;
            FName = fName;
            LName = lName;
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
