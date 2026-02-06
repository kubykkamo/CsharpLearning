using System;
using System.Collections.Generic;
using System.Text;
using ToDoList;

namespace MyApp
{   
   
    public class ToDoList
    {
        public List<ToDoItem> items = new List<ToDoItem>();
        public ToDoList()
        {
            Load();
        }

        public void Save()
        {
            List<string> linesToSave = new List<string>();

            foreach (var item in items)
            {
                string line = $"{item.Name}${item.Difficulty}${item.Completed}";
                linesToSave.Add(line);
            }

            File.WriteAllLines("tasks.txt", linesToSave);
            ConsoleHelper.WriteSuccess("Tasks sucessfully saved.");
        }

        public void Load()
        {
            if (!File.Exists("tasks.txt"))
            {
                ConsoleHelper.WriteError("Save file was not found.");
                return;
            }

            string[] lines = File.ReadAllLines("tasks.txt");

            items.Clear();
            int counter = 0;

            foreach (string line in lines)
            {
                string[] parts = line.Split('$');
                if (parts.Length == 3)
                {
                    string name = parts[0];

                    if (int.TryParse(parts[1], out int difficulty) && bool.TryParse(parts[2], out bool isCompleted))
                    {
                        ToDoItem loadedTask = new ToDoItem(name, difficulty);
                        loadedTask.Completed = isCompleted;
                        items.Add(loadedTask);
                        counter++;
                        
                    }
                    

                }
            }
            ConsoleHelper.WriteSuccess($"{counter} tasks loaded.");
            ConsoleHelper.WriteSuccess("Save file successfully loaded.");
        }
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
                Console.WriteLine("\nEnter 'q' to enter main menu. ");
                Console.Write("Enter a task name: ");
                inputName = Console.ReadLine();
                if (inputName == "Q" || inputName == "q") return;

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
            if (id == -1) return false;
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
