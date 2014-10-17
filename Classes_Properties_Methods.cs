using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjects
{
    public class Program3
    {
        static void Main(string[] args)
        {
            Spy newSpy = new Spy();
            Agency Bridgeburners = new Agency();
            
            newSpy.CodeName = "Whiskeyjack";
            newSpy.SpyAgency = Bridgeburners;
            newSpy.DateLastSeen = DateTime.Now;
            newSpy.Notes = "Burdened, diligent, softspoken";
            Bridgeburners.AgencyName = "BridgeBurners";
            Bridgeburners.Country = "Genebackis";
            Bridgeburners.OrganizationSize = 6;

            newSpy.DisplaySpyInfo();

            //Wait for user to acknowledge the results.
            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }
    }

    public class Spy
    {
        public string CodeName;
        public Agency SpyAgency;
        public DateTime DateLastSeen;
        public string Notes;



        public void DisplaySpyInfo()
        {
            Console.WriteLine("Spy name: " + CodeName);
            Console.WriteLine("Spy Agency: " + SpyAgency);
            Console.WriteLine("Last seen: " + DateLastSeen.ToString());
            Console.WriteLine("Notes: " + Notes);
            string agencyInfo = SpyAgency.GetAgencyInfo();
            Console.WriteLine(agencyInfo);

        }
    }

    public class Agency
    {
        public string AgencyName;
        public string Country;
        public int OrganizationSize;


        public string GetAgencyInfo()
        {
            string agencyInfo = "The agency's name is " + AgencyName + ", they operate in " + Country + ", and they are " + OrganizationSize + " people big.";
            return agencyInfo;
        }
    }
}