using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TicketApp3.Models.Tasks
{
    class TaskFile
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        // public property
        public string filePath { get; set; }
        public List<Tasks> Task { get; set; }

        public string TaskFilePath()
        {
            return "../../Files/tasks.txt";
        }

        public TaskFile(string path)
        {
            Task = new List<Tasks>();
            filePath = path;

            //try
            //{
            StreamReader sr = new StreamReader(filePath);
            // first line contains column headers
            // sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // create instance of Movie class
                Tasks task = new Tasks();
                string line = sr.ReadLine();

                string[] taskDetails = line.Split(',');
                task.recordID = Int32.Parse(taskDetails[0]);
                task.summary = taskDetails[1];
                task.status = Int32.Parse(taskDetails[2]);
                task.priority = Int32.Parse(taskDetails[3]);
                task.submitter = Int32.Parse(taskDetails[4]);
                task.assigned = Int32.Parse(taskDetails[5]);
                task.watchrgoup = Int32.Parse(taskDetails[6]);
                task.project = Int32.Parse(taskDetails[7]);
                task.dueDate = taskDetails[8];


                Task.Add(task);
            }
            // close file when done
            sr.Close();
            logger.Info("Tickets in file {Count}", Task.Count);
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex.Message);
            //}
        }


        public void AddTask(Tasks t)
        {
            StreamWriter sw = new StreamWriter(filePath, append:true);
            sw.WriteLine($"{t.recordID},{t.summary},{t.status},{t.priority},{t.submitter},{t.assigned},{t.watchrgoup},{t.project},{t.dueDate}");
            sw.Close();
            Task.Add(t);


            //try
            //{
            //    //first generate movie id
            //    t.recordID = Ticket.Max(m => m.recordID) + 1;

            //    StreamWriter sw = new StreamWriter(filePath);
            //    sw.WriteLine($"\n{t.recordID},{t.summary},{t.status},{t.priority},{t.submitter},{t.assigned},{t.watchrgoup},{t.severity}");
            //    sw.Close();
            //    Ticket.Add(t);
            //    logger.Info("Ticket id {Id} added", t.recordID);

            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex.Message);
            //}
        }


        public void ShowTasks()
        {

            TaskFile taskFile = new TaskFile(TaskFilePath());
            Format f = new Format();
            foreach (Tasks t in taskFile.Task)
            {
                Console.WriteLine(f.GetTasksFormat(), t.recordID, t.summary, t.status, t.priority, t.submitter, t.assigned, t.watchrgoup, t.project, t.dueDate);
            }
            Console.WriteLine();
        }
    }
}
