using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DBConsole_1.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }

    }

    public class DataOperations //: IDataOperations
    {
        public Blog Get(string title)
        {
            //(b=>b.name == title)
            return new Blog();
        }

        public List<Blog> GetAll()
        {
            return new List<Blog>()
            {
                new Blog {Name = "Blog A"},
                new Blog {Name = "Blog B"},
            };
        }
    }
}
