using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TicketApp2._0.Models
{
    public class TicketFile
    {
        public List<Ticket> Contents { get; }
        private readonly string _filename = Path.Combine(Environment.CurrentDirectory, "Files", "tickets.txt");

        public TicketFile()
        {
            if (!Validate()) throw new FileNotFoundException($"Unable to locate {_filename}");

            Contents = ReadFile();
        }

        public bool Validate()
        {
            if (File.Exists(_filename))
            {
                return true;
            }

            return false;
        }

        private List<Ticket> ReadFile()
        {
            List<Ticket> tickets = new List<Ticket>();
            string[] lines = File.ReadAllLines(_filename);

            foreach (var line in lines) 
            {
                var id = line.Split(',')[0];
                var name = line.Split(',')[1];
                tickets.Add(new Ticket() { Id = id, Name = name });
            }

            return tickets;
        }


        static List<Ticket> LoadTickets()
        {
            string file = "tickets.txt";
            List<Ticket> Tks = new List<Ticket>();
            if (File.Exists(file))
            {
                StreamReader TicketReader = new StreamReader(file);
                while (!TicketReader.EndOfStream)
                {
                    string ticketRecord = TicketReader.ReadLine();
                    string[] ticketAttributes = ticketRecord.Split(',');
                    int ticketID = Int32.Parse(ticketAttributes[0]);
                    string name = ticketAttributes[1];
                    //string status = ticketAttributes[2];
                    //string priority = ticketAttributes[3];
                    //int submitterID = Int32.Parse(ticketAttributes[4]);
                    //int assignedID = Int32.Parse(ticketAttributes[5]);
                    //int watchingGrp = Int32.Parse(ticketAttributes[6]);

                    //Ticket tickets = new Ticket(ticketID, summary, status, priority, submitterID, assignedID, watchingGrp);
                    Ticket tickets = new Ticket(ticketID, name);
                    Tks.Add(tickets);
                }
                TicketReader.Close();
            }
            return Tks;
        }

        public void WriteFile(Ticket ticket)
        {
            var sw = new StreamWriter(_filename);
            Contents.Add(ticket);
            Contents.ForEach(c => sw.WriteLine($"{c.Id},{c.Name}"));
            sw.Flush();
            sw.Close();
        }

    }
}
