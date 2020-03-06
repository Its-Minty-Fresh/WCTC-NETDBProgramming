using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp3.Models
{
    class EnhancementMenu
    {
        public void Process(int selection)
        {
            string file = "../../Files/enhancements.txt";
            EnhancementFile ef = new EnhancementFile(file);
            EnhancementMenu em = new EnhancementMenu();
            em.EnhancementMenuHeader();
            ef.ShowEnhancements();
            em.ViewEnhancementtMenu();
            selection = em.GetEncmntMenuInpput();

            switch (selection)
            {
                case 1:
                    em.AddEnhancement();
                    break;
                case 2:
                    em.EditEnhancement();
                    break;
                case 3:
                    em.DeleteEnhancement();
                    break;
            }
        }


        public void EnhancementMenuHeader()
        {
            Console.Clear();
            Format f = new Format();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    View Enhancements\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine(f.GetEnhancementsFormat(), "Ticket #", "Summary", "Status", "Priorty", "Submitter", "Assigned", "WatchGroup", "Software", "Cost", "Reason", "Estimate");
            Console.WriteLine(f.GetEnhancementsFormat(), "------", "--------------------------------------------------", "----------", "----------", "----------", "----------", "----------", "----------", "----------", "----------", "----------");
            Console.ResetColor();
        }

        public void ViewEnhancementtMenu()
        {
            Console.WriteLine("    What would you like to do?\n\n" +
                "    1) Add Enhancement\n" +
                "    2) Edit Enhancement\n" +
                "    3) Delete Enhancement\n" +
                "    4) Return to Main Menu");

            Console.Write("    ");
        }

        public void AddEnhancement()
        {
            Format f = new Format();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    Add Enhancement\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();


            string file = "../../Files/Enhancements.txt";
            EnhancementFile ef = new EnhancementFile(file);
            Enhancement enhancement = new Enhancement();

            Console.Write("    Enter Enhancement Summary: ");
            enhancement.summary = Console.ReadLine();

            Console.Write("\n    Enter Ticket Priority: ");

            enhancement.priority = f.validateInt(Console.ReadLine());
            if (enhancement.priority > 3)
            {
                Console.Write("    Please Enter a valid proiroity 1 - 3 ");
                enhancement.priority = f.validateInt(Console.ReadLine());
            }

            ef.AddEnhancement(enhancement);
            Console.Write("    Enhancement succesfully added! Press any key ro return to the main menu: ");
            Console.ReadKey();

        }

        public void EditEnhancement()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    Edit Enhancement\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();

            Console.Write("\n    Editing Functionality to be added in a future release. \n" +
                          "    Press any key ro return to the main menu: ");
            Console.ReadKey();
        }

        public void DeleteEnhancement()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n" +
                "    Delete Enhancement\n" +
                "    --------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.ResetColor();

            Console.Write("\n    Deleteing Functionality to be added in a future release. \n" +
                          "    Press any key ro return to the main menu: ");
            Console.ReadKey();
        }

        public int GetEncmntMenuInpput()
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
