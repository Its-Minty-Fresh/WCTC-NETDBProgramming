using System;
using System.Collections.Generic;
using System.Text;

namespace Week1
{
    class Users
    {

        // instance variables
        private int UserID { get; set; }
        private string FName { get; set; }
        private string LName { get; set; }

        // user constructor 1
        public Users()
        {
            this.UserID = 0;
            this.FName = "";
            this.LName = "";
        }

        // user constructor 2
        public Users(int userID, string fName, string lName)
        {
            this.UserID = userID;
            this.FName = fName;
            this.LName = lName;
        }

        // UserID Setter
        public void SetUserID(int userID)
        {
            this.UserID = userID;
        }
        // UserID Getter
        public int GetUserID()
        {
            return this.UserID;
        }

        // fName Setter
        public void SetFName(string fName)
        {
            this.FName = fName;
        }
        // fName Getter
        public string GetFName()
        {
            return this.FName;
        }

        // lName Setter
        public void SetLName(string lName)
        {
            this.LName = lName;
        }
        // lName Getter
        public string GetLName()
        {
            return this.LName;
        }

        public override string ToString()
        {
            string user = this.UserID.ToString();
            user = user + ",";
            user = user + this.FName;
            user = user + ",";
            user = user + this.LName;

            return user;
        }

    }
}
