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

                Console.WriteLine("\n\nEnter an action: 1 - Show my list | 2 - Add Task | 3 - Remove Task | \n4 - Complete task | 5 - Exit");
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
                        Console.Write("Enter an ID of task you want to remove: ");
                        int id = todolist.GetInputNumber();
                        todolist.RemoveTask(id);
                        break;
                    case 4:
                        Console.WriteLine("Enter an ID of a task you want to set completed: ");
                        int completeID = todolist.GetInputNumber();
                        todolist.CompleteTask(completeID);
                        break;

                    case 5:
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

