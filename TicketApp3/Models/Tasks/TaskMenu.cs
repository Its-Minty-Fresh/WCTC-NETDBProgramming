using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp3.Models.Tasks
{
    class TaskMenu
    {
        public void Process(int selection)
        {
            string file = "../../Files/tasks.txt";
            TaskFile tf = new TaskFile(file);
            TaskMenu tm = new TaskMenu();
            tm.TaskMenuHeader();
            tf.ShowTasks();
            tm.ViewTaskMenu();
            selection = tm.GetTaskMenuInpput();

            switch (selection)
            {
                case 1:
                    tm.AddTask();
                    tm.GetTaskMenuInpput();
                    break;
                case 2:
                    tm.EditTask();
                    break;
                case 3:
                    tm.DeleteTask();
                    break;
            }
        }


        public void TaskMenuHeader()
        {
            Console.Clear();
            Format f = new Format();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    View Tasks\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine(f.GetTasksFormat(), "Ticket #", "Summary", "Status", "Priorty", "Submitter", "Assigned", "WatchGroup", "Project", "Due Date");
            Console.WriteLine(f.GetTasksFormat(), "------", "--------------------------------------------------", "----------", "----------", "----------", "----------", "----------", "----------", "----------");
            Console.ResetColor();
        }

        public void ViewTaskMenu()
        {
            Console.WriteLine("    What would you like to do?\n\n" +
                "    1) Add Task\n" +
                "    2) Edit Task\n" +
                "    3) Delete Task\n" +
                "    4) Return to Main Menu");

            Console.Write("    ");
        }

        public void AddTask()
        {
            Format f = new Format();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    Add Task\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();


            string file = "../../Files/tasks.txt";
            TaskFile tf = new TaskFile(file);
            Tasks task = new Tasks();

            Console.Write("    Enter Task Summary: ");
            task.summary = Console.ReadLine();

            Console.Write("\n    Enter Task Priority: ");

            task.priority = f.validateInt(Console.ReadLine());
            if (task.priority > 3)
            {
                Console.Write("    Please Enter a valid proiroity 1 - 3 ");
                task.priority = f.validateInt(Console.ReadLine());
            }

            tf.AddTask(task);
            Console.Write("    Task succesfully added! Press any key ro return to the main menu: ");
            Console.ReadKey();

        }

        public void EditTask()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    Edit Task\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();

            Console.Write("\n    Editing Functionality to be added in a future release. \n" +
                          "    Press any key ro return to the main menu: ");
            Console.ReadKey();
        }

        public void DeleteTask()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    Delete Task\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();

            Console.Write("\n    Deleteing Functionality to be added in a future release. \n" +
                          "    Press any key ro return to the main menu: ");
            Console.ReadKey();
        }

        public int GetTaskMenuInpput()
        {
            Format i = new Format();
            int selection;

            selection = i.validateInt(Console.ReadLine());

            while ((selection < 0 || selection > 4))
            {
                Console.Write("    Please Enter a valid response 1 - 4 ");
                selection = i.validateInt(Console.ReadLine());
            }
            return selection;
        }
    }
}
