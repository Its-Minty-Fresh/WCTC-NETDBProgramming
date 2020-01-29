using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
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

        public override string ToString()
        {
            string wGrp = this.WatchingGrp.ToString();
            wGrp = wGrp + ",";
            wGrp = wGrp + this.UserID;

            return wGrp;
        }
    }
}
