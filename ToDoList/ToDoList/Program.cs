// See https://aka.ms/new-console-template for more information

namespace MyApp {
    class Program
    {
        static void Main()
        {
            bool run = true;
            bool registered = false;
            ToDoList todolist = new ToDoList();
            while (run)
            {

                Console.WriteLine("Enter an action: 1 - Show my list | 2 - Add Task | 3 - Remove Task | 4 - Exit");
                int choice;
                string input = Console.ReadLine()?.Trim();
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Please enter a valid number!");
                    continue;
                }


                switch (choice)
                {
                    case 1:
                        todolist.PrintList();
                        break;
                    case 2:
                        todolist.AddTask();
                        break;
                    
                    case 3:
                        int id = todolist.GetRemovalNumber();
                        todolist.RemoveTask(id);
                        break;
                    case 4:
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

    } 
}

