using System;
using System.Collections.Generic;
using System.Text;
using ToDoList;

namespace MyApp
{
    public class ToDoItem
    {
        public string Name { get; set; }
        
        public int Difficulty { get; set; }

        public int Length { get; set; }

        public const int TimeMultiplier = 30;

        public bool Completed { get; set; }

        static private int _counter;

        public int Id { get; set; }
        

        public String CompletedText()
        {
            if (Completed) return "✔  Completed ";
            else return "❌  Not completed. ";
        }

        public ToDoItem(string name, int difficulty)
        {
            Name = name;
            Difficulty = difficulty;
            if (difficulty > 5) Length = 5 * TimeMultiplier;
            else if (difficulty <= 0)
            {
                Length = 1 * TimeMultiplier;
            }
            else
            {
                Length = difficulty * TimeMultiplier;
            }
            _counter++;
            Id = _counter;
            Completed = false;
            
        }

        public void PrintInfo() 

        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"ID: {Id} | {Name} | {Length} minutes | {CompletedText()} ");
        }

        public void Complete()
        {
            if (Completed == true) Console.WriteLine($"Task | {Name} | is already completed");
            else
            {
                Completed = true;
                ConsoleHelper.WriteSuccess($"Task | {Name} | marked as completed. ");
            }
        }
        
    }
}
