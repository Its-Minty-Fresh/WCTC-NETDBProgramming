using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TicketApp2._0
{
    class WatchGrp
    {
        private int WatchingGrp { get; set; }
        private int UserID { get; set; }

        // watch group constructor 1
        public WatchGrp()
        {
            this.WatchingGrp = 0;
            this.UserID = 0;
        }

        // watch group constructor 2
        public WatchGrp(int wathGrpID, int userID)
        {
            this.WatchingGrp = wathGrpID;
            this.UserID = userID;
        }

        // Watch Group ID Setter
        public void SetWatchGrpID(int wathGrpID)
        {
            this.WatchingGrp = wathGrpID;
        }
        // Watch Group ID Getter
        public int GetWatchGrpID()
        {
            return this.WatchingGrp;
        }

        // User ID Setter
        public void SetUserID(int userID)
        {
            this.UserID = userID;
        }
        // User ID Getter
        public int GetUserID()
        {
            return this.UserID;
        }

        static List<WatchGrp> LoadWatchGroups()
        {
            string file = "WatchGroups.txt";
            List<WatchGrp> Wg = new List<WatchGrp>();
            if (File.Exists(file))
            {
                StreamReader WGrpReader = new StreamReader(file);
                while (!WGrpReader.EndOfStream)
                {
                    string wGrpRecord = WGrpReader.ReadLine();
                    string[] wgAttributes = wGrpRecord.Split(',');
                    int userID = Int32.Parse(wgAttributes[0]);
                    int watchGrpID = Int32.Parse(wgAttributes[1]);

                    WatchGrp wGroup = new WatchGrp(userID, watchGrpID);
                    Wg.Add(wGroup);
                }
                WGrpReader.Close();
            }
            return Wg;
        }

        public override string ToString()
        {
            string wGrp = this.WatchingGrp.ToString();
            wGrp = wGrp + ",";
            wGrp = wGrp + this.UserID;

            return wGrp;
        }
    }
}
