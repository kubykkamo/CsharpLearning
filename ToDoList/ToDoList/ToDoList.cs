using System;
using System.Collections.Generic;
using System.Text;
using ToDoList;

namespace MyApp
{   
   
    public class ToDoList
    {
        public List<ToDoItem> items = new List<ToDoItem>();

        public void PrintList()
        {
            Console.OutputEncoding = Encoding.UTF8;
            if (items.Count == 0) ConsoleHelper.WriteError("List is empty.");
            else
            {
                Console.WriteLine("\n--- My tasks ---");
                Console.WriteLine("\n📝 Incompleted tasks -----");
                Console.ForegroundColor = ConsoleColor.Red;
                
                foreach (var item in items)
                {
                    if (!item.Completed)
                    { item.PrintInfo(); }
                }
                Console.ResetColor();
                Console.WriteLine("\n✅ Finished tasks -----");
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var item in items)
                {
                    if (item.Completed)
                    { item.PrintInfo(); }
                }
                Console.ResetColor();

            }
        }

        public bool CompleteTask(int taskID)
        {
            if (items.Count == 0)
            {
                ConsoleHelper.WriteError("No tasks yet.");
                return false;
            }
            ToDoItem taskToComplete = null;
            foreach (var item in items)
            {
                if (taskID == item.Id)
                {
                    taskToComplete = item;
                    break;
                }
              
            }
            if (taskToComplete == null)
            {
               
                return false;
            }
            else
            {
                
                taskToComplete.Complete();
                return true;
            }
        }
        public void AddTask()
        {
            string inputName;
            string name;
            int difficulty;


            do
            {
                Console.Write("Enter a task name: ");
                inputName = Console.ReadLine();

            } while (String.IsNullOrWhiteSpace(inputName));
            name = inputName;
            ConsoleHelper.WriteSuccess($"Name: {name} registered.");

            
             difficulty = ConsoleHelper.GetInputNumber("Enter a task difficulty (1 - 5): ");
         

            items.Add(new ToDoItem(name, difficulty));
            ConsoleHelper.WriteSuccess($"Task - {name} successfully added.");
        }

        public bool RemoveTask(int id)
        {
            ToDoItem itemToRemove = null;
            foreach (var item in items)
            {
                if (item.Id == id)
                {
                    itemToRemove = item;
                    break;
               
                }
                
            }
            if (itemToRemove == null)
            {
                ConsoleHelper.WriteError("Task with this ID does not exist.");
                return false;
            }
            items.Remove(itemToRemove);
            ConsoleHelper.WriteSuccess($"Task with ID {id} removed.");
            return true;
        }

        
    }

}
