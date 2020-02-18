using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    class Media
    {
        public long ID { get; set; } 
        public string Title { get; set; } 
        public List<string> Genres { get; set; }
            
        public Media() 
        {
            Title = "Dafult";
            Genres = new List<string>(); 
        } 
        public void Display()
        {
            Console.WriteLine($"Id {ID}");
        }
 
    }
}
