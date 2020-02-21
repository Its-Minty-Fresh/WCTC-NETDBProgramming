using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TicketApp2._0.Models
{
    class TestFileMgmt
    {
        public List<Test> Contents { get; }
        private readonly string _filename = Path.Combine(Environment.CurrentDirectory, "Files", "Test");

        public TestFileMgmt()
        {
            if (!Validate()) throw new FileNotFoundException($"Unable to locate {_filename}");

            Contents = ReadTest();
        }

        public bool Validate()
        {
            if (File.Exists(_filename))
            {
                return true;
            }

            return false;
        }

        private List<Test> ReadTest()
        {
            List<Test> tickets = new List<Test>();
            string[] lines = File.ReadAllLines(_filename);

            foreach (var line in lines)
            {
                int id = Int32.Parse(line.Split(',')[0]);
                string fname = line.Split(',')[1];
                string lname = line.Split(',')[2];
                tickets.Add(new Test() { TestID = id, FName = fname, LName = lname });
            }

            return tickets;
        }

        public void WriteTest(Test test)
        {
            var sw = new StreamWriter(_filename);
            Contents.Add(test);
            Contents.ForEach(c => sw.WriteLine($"{c.TestID},{c.FName}, {c.LName}"));
            sw.Flush();
            sw.Close();
        }
    }
}
