using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjects
{
    public class Program4
    {
        static void Main(string[] args)
        {
            //Create a personnel object using constructor
            Personnel pBob = new Personnel("Bob", "USA", "Software Development", "Pentagon", "BDFL");
            //Create an agent object and then assign values to properties
            Agent aJames = new Agent();
            aJames.CodeName = "007";
            aJames.Region = "UK";
            aJames.SkillSet = "Spy";

            //Call print method (inherited from Asset)
            pBob.Print();

            //Call print method (overriden)
            aJames.Print();

            //Use Analyzer static method to call each object's appropriate Print() method
            Analyzer.Analyze(pBob);
            Analyzer.Analyze(aJames);

            //Wait for user to acknowledge the results.
            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }
    }

    class Asset
    {
        public string CodeName { get; set; }
        public string Region { get; set; }
        public string SkillSet { get; set; }

        public virtual void Print()
        {
            Console.WriteLine("Asset: " + CodeName + " " + Region + " " + SkillSet);
        }
    }

    class Personnel : Asset
    {
        public string Department { get; set; }
        public string Supervisor { get; set; }

        public Personnel(string _CodeName, string _Region, string _SkillSet, string _Department, string _Supervisor)
        {
            CodeName = _CodeName;
            Region = _Region;
            SkillSet = _SkillSet;
            Department = _Department;
            Supervisor = _Supervisor;
        }
    }

    class Agent : Asset
    {
        public override void Print()
        {
            Console.WriteLine("Agent: " + CodeName + "..." + Region + "..." + SkillSet);
        }
    }

    static class Analyzer
    {
        static public void Analyze(Asset asset)
        {
            asset.Print();
        }
    }
}