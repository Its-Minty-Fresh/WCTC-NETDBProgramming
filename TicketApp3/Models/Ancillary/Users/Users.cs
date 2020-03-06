using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp3.Models
{
    public class Users
    {
        // instance variables
        public int userID { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }

        // user constructor 1
        public Users()
        {
            userID = 0;
            fName = "";
            lName = "";
        }


        // user constructor 2
        public Users(int userid, string fname, string lname)
        {
            userID = userid;
            fName = fname;
            lName = lname ;
        }

        // UserID Setter
        public void SetUserID(int userid)
        {
            userID = userid;
        }
        // UserID Getter
        public int GetUserID()
        {
            return userID;
        }

        // fName Setter
        public void SetFName(string fname)
        {
            fName = fname;
        }
        // fName Getter
        public string GetFName()
        {
            return fName;
        }

        // lName Setter
        public void SetLName(string lname)
        {
            lName = lname;
        }
        // lName Getter
        public string GetLName()
        {
            return lName;
        }

        public override string ToString()
        {
            string user = this.userID.ToString();
            user = user + ",";
            user = user + this.fName;
            user = user + ",";
            user = user + this.lName;

            return user;
        }
    }
}
