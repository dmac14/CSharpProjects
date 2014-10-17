using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjects
{
    public class Program5
    {
        static void Main(string[] args)
        {
            //Initialize list for mutants
            List<Mutant> mutants = new List<Mutant>()
            {
                //create 6 new mutants and set their properties
                new PsychicMutant() {CodeName="Luke Skywalker",IQ=20, Level=30, UsageCount=40},
                new PsychicMutant() {CodeName="DarthVadar",IQ=30, Level=25, UsageCount=35},
                new PhysicalMutant() {CodeName="Chewbacca",IQ=35, Level=20, Strength=45}, 
                new PhysicalMutant() {CodeName="Han Solo",IQ=25, Level=15, Strength=60},
                new ElementalMutant() {CodeName="Ewok",Level=5, Region=1},
                new ElementalMutant() {CodeName="Ton-Ton",Level=10, Region=2}
            };                      

            //iterate through list and print their info using their respective DisplayInfo() method.
            foreach (Mutant mutant in mutants)
            {
                mutant.DisplayInfo();
            }
            
            //Wait for user to acknowledge the results.
            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }
    }

    public interface IDisplayable
    {
        void DisplayInfo();
    }

    abstract class Mutant : IDisplayable
    {
        public string CodeName { get; set; }
        public int Level { get; set; }

        abstract public int DangerQuotient();

        public void DisplayInfo()
        {
            //Displays the mutant's name and danger quotient (by calling said mutant's DangerQuotient() method)
            Console.WriteLine("{0} - DQ: {1}", CodeName, DangerQuotient());
        }

    }

    class PsychicMutant : Mutant
    {
        public int IQ { get; set; }
        public int UsageCount { get; set; }

        override public int DangerQuotient()
        {
            return Level * IQ * UsageCount;
        }
    }

    class PhysicalMutant : Mutant
    {
        public int IQ { get; set; }
        public int Strength { get; set; }

        override public int DangerQuotient()
        {
            return Level * IQ * Strength;
        }
    }

    class ElementalMutant : Mutant
    {
        public int Region { get; set; }
        
        override public int DangerQuotient()
        {
            return Level * Region;
        }
    }
}