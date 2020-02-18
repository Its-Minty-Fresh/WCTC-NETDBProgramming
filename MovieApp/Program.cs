using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Models;

namespace MovieApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenu();

            Media media = new Media();
            media.ID = 1;

            Book book = new Book();
            book.numberPages = 100;
            book.ID = 2;
            book.Title = "Book number 1 title";
            book.Display();


            Album album = new Album();
            album.ID = 3;
            album.Title = "Nevermind";
            album.Track = 1;
            album.Display();

            Console.ReadLine();
        }
    }
}
