using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    public static class ConsoleHelper
    {
        public static void WriteError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }

        static public int GetInputNumber(string question)
        {
            int id;
            while (true)
            {
                Console.Write(question + " ");
                string input = Console.ReadLine();


                if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out id))
                {
                    return id;
                }

                ConsoleHelper.WriteError("Invalid input, enter a number!");
            }
        }
        public static void WriteSuccess(string successMessge)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(successMessge);
            Console.ResetColor();
        }
    }
}
