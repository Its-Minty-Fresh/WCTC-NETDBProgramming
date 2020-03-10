using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConsole_1.Models;
using DBConsole_1.Data;
using System.Data.Entity;

namespace DBConsole_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a blog name: ");
            var name = Console.ReadLine();

            var blog = new Blog() { Name = name };

            using (var db = new BloggingContext())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }

            using (var db = new BloggingContext())
            {
                var query = db.Blogs;
                foreach (var item in query)
                {
                    Console.WriteLine($"Blog : {item.Name}");
                }
                
            }
            Console.ReadLine();

        }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }

}


////persist the blog to a file
//IDataStorage dataFile = new FileStorage();
//dataFile.Save(newBlog);

//            //persist the blog to a database
//            IDataStorage dataBase = new DatabaseStorage();
//dataBase.Save(newBlog);

//            Console.WriteLine("Enter a blog name to find: ");
//            var blogName = Console.ReadLine();

//var existingBlog = new Blog();
////existingBlog.Get(blogName);