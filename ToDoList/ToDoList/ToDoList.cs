using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp
{   
   
    public class ToDoList
    {
        public List<ToDoItem> items = new List<ToDoItem>();

        public void PrintList()
        {
            if (items.Count == 0) Console.WriteLine("List is empty. ");
            else
            {

                foreach (var item in items)
                {
                    item.PrintInfo();
                }
            }
        }

        public void AddTask()
        {
            string inputName;
            string inputDifficulty;
            string name;
            int difficulty;


            do
            {
                Console.Write("Enter a task name: ");
                inputName = Console.ReadLine();

            } while (String.IsNullOrWhiteSpace(inputName));
            name = inputName;
            Console.WriteLine($"Name: {name} registered.");

            do
            {
                Console.Write("Enter a task difficulty: ");
                inputDifficulty = Console.ReadLine();

            } while (String.IsNullOrWhiteSpace(inputDifficulty) || !int.TryParse(inputDifficulty, out difficulty));

            items.Add(new ToDoItem(name, difficulty));
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
                Console.WriteLine("Task with this id does not exist");
                return false;
            }
            items.Remove(itemToRemove);
            Console.WriteLine($"Task with ID {id} removed.");
            return true;
        }

        public int GetRemovalNumber() 
        {
            string input;
            int id;
            do
            {
                PrintList();
                Console.Write("Enter an ID of task you want to remove: ");
                input = Console.ReadLine();

            } while (String.IsNullOrWhiteSpace(input) || !int.TryParse(input, out id));
            return id;
        }
    }

    
}
