// See https://aka.ms/new-console-template for more information

using ToDoList;

namespace MyApp {
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, welcome to my To do App!");
            bool run = true;
            bool registered = false;
            ToDoList todolist = new ToDoList();
            
            while (run)
            {

                Console.Write("\n--- Menu ---" +            
                    "\n1 - Show my list | 2 - Add Task | 3 - Remove Task | " +
                    "\n4 - Complete task | 5 - Exit: " +
                    "\n ------------"
                    );

                int choice = ConsoleHelper.GetInputNumber("\nEnter an action: ");
               
                switch (choice)
                {
                    case 1:
                        todolist.PrintList();
                        break;
                    case 2:
                        todolist.AddTask();
                        break;
                    case 3:
                        todolist.PrintList();                   
                        int removalID = ConsoleHelper.GetInputNumber("Enter an ID of task you want to remove:");
                        todolist.RemoveTask(removalID);
                        break;
                    case 4:
                        todolist.PrintList();                    
                        int completeID = ConsoleHelper.GetInputNumber("Enter an ID of a task you want to set completed:");
                        todolist.CompleteTask(completeID);
                        break;
                    case 5:
                        todolist.Save();
                        run = false;
                        Console.WriteLine("Press any key to exit..");
                        Console.ReadKey();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        ConsoleHelper.WriteError("Invalid choice!");
                        Console.ResetColor();
                        break;
                }
            }
            
        }
     

       
     
    } 
}

