using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NLog;

namespace TicketApp3.Models
{
    public class UserFile
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        // public property
        public string filePath { get; set; }
        public List<Users> User { get; set; }

        public string UserFilePath()
        {
            return "../../Files/users.txt";
        }

        public UserFile()
        {

        }


        public UserFile(string path)
        {
            User = new List<Users>();
            filePath = path;

            //try
            //{
            StreamReader sr = new StreamReader(filePath);
            // first line contains column headers
            // sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // create instance of Movie class
                Users user = new Users();
                string line = sr.ReadLine();

                string[] userDetails = line.Split(',');
                user.userID = Int32.Parse(userDetails[0]);
                user.fName = userDetails[1];
                user.lName = userDetails[2];

                User.Add(user);
            }
            sr.Close();
            logger.Info("Tickets in file {Count}", User.Count);

            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex.Message);
            //}
        }


        public void ShowUsers()
        {
            UserFile userFile = new UserFile(UserFilePath());
            Format f = new Format();
            foreach (Users u in userFile.User)
            {
                Console.WriteLine(f.GetUserFormat(), u.userID, u.fName, u.lName);
            }
            Console.WriteLine();
        }

        public int GetMaxUserID()
        {
            List<Users> users = new List<Users>();
            var max = users.Max(x => x.userID);

            return max + 1;
        }
    }
}
