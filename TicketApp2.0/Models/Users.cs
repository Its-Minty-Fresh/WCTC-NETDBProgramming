using System;
using System.Collections.Generic;
using System.IO;

namespace TicketApp2._0
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

        static List<Users> LoadUsers()
        {
            string file = "Users.txt";
            List<Users> Us = new List<Users>();
            if (File.Exists(file))
            {
                StreamReader UserReader = new StreamReader(file);
                while (!UserReader.EndOfStream)
                {
                    string userRecord = UserReader.ReadLine();
                    string[] userAttributes = userRecord.Split(',');
                    int userID = Int32.Parse(userAttributes[0]);
                    string fName = userAttributes[1];
                    string lName = userAttributes[2];
                    Users user = new Users(userID, fName, lName);
                    Us.Add(user);
                }
                UserReader.Close();
            }
            return Us;
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
