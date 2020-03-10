using DBConsole_1.Models;

namespace DBConsole_1.Data
{
    public interface IDataStorage
    {
    void Save(Blog blog);

    }

    public class FileStorage : IDataStorage
    {
        public void Save(Blog blog)
        {
            // save to our location of choise
        }
    }

    public class DatabaseStorage : IDataStorage
    {
        public void Save(Blog blog)
        {

        }
    }

}