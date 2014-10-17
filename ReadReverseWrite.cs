using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjects
{
    // A program which reads lines from a text file, reverses them, and then writes them to a seperate file
    public class Program2
    {
        static void Main(string[] args)
        {
            StreamReader myReader = new StreamReader("DecryptThis.txt");
            StreamWriter myWriter = new StreamWriter("C:\\Users\\user\\Desktop\\Decrypted.txt");
            string line="";

            while (line!=null)
            {
                line = myReader.ReadLine();                
                if (line!=null)
                {
                    char[] cArray = line.ToCharArray();
                    Array.Reverse(cArray);
                    myWriter.WriteLine(cArray);
                }
            }
            myReader.Close();
            myWriter.Close();          
            
            //Wait for user to acknowledge the results.
            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }
    }
}