using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketApp2._0.Models;

namespace TicketApp2._0.Models
{
    public class TestManager
    {
        private readonly TestFileMgmt _testFile;


        public TestManager()
        {
            _testFile = new TestFileMgmt();
        }

        public void Process(int selection)
        {
            switch (selection)
            {
                case 1:
                    ShowTest(_testFile.Contents);
                    break;
                //case 'R':
                //    ShowTickets(_ticketFile.Contents);
                //    break;
                //case 'Q':
                //    break;
            }
        }


        private void ShowTest(List<Test> test)
        {
            foreach (var t in test.Take(10)) Console.WriteLine(test.ToString());
        }


    }

}
