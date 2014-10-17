using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjects
{
    public class Program
    {
        //Program to read input from readers and makes use of conditional if statement.
        static void Main(string[] args)
        {
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("Type in the numbers and press Return: ");
            string numbers = Console.ReadLine();

            if (numbers=="4 8 15 16 23 42")
            {
                Console.WriteLine("Recalibrating energy core ... Complete.");
            }
            else
            {
                Console.WriteLine("FAILURE!");
                Console.Beep();
            }
            
            //Wait for user to acknowledge the results.
            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }
    }
}


