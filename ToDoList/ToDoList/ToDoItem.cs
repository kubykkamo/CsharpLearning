using System;
using System.Collections.Generic;
using System.Text;

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
            if (Completed) return "Completed";
            else return "Not completed";
        }

        public ToDoItem(string name, int difficulty)
        {
            Name = name;
            Difficulty = difficulty;
            Length = difficulty * TimeMultiplier;
            _counter++;
            Id = _counter;
            Completed = false;
            
        }

        public void PrintInfo() 
        {
            Console.WriteLine($" ID: {Id} | {Name} | {Length} minutes | {CompletedText()} ");
        }
        
    }
}
