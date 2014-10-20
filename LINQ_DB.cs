using TaxManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProjects
{
    class LINQwithDB
    {
        static void Main(string[] args)
        {
            myDBEntities db = new myDBEntities();

            Sale newSale = new Sale();
            Console.WriteLine("Record a sale...");


            Console.WriteLine("Enter Date: ");
            string inputDate = (Console.ReadLine());
            inputDate = inputDate.Trim();
            DateTime salesDate;
            if (!DateTime.TryParse(inputDate,out salesDate))
	        {
                Console.WriteLine("Error, not a valid date! Press Enter to terminate...");
                Console.Read();
                return;
	        }
            newSale.SalesDate = DateTime.Parse(inputDate);


            Console.WriteLine("Enter Amount: ");
            string inputAmount = Console.ReadLine();
            inputAmount = inputAmount.Trim();
            decimal salesAmount;
            if(!decimal.TryParse(inputAmount,out salesAmount))
            {
                Console.WriteLine("Error, not a valid amount! Press Enter to terminate...");
                Console.Read();
                return;
            }
            newSale.SalesAmount = decimal.Parse(inputAmount);

            newSale.TaxAmount = Tax.CalculateTax(newSale.SalesAmount);

            db.Sales.Add(newSale);
            db.SaveChanges();

            var sales = db.Sales.Select(s => s);
            foreach (var item in sales)
            {
                Console.WriteLine("{0} -- SaleAmount: {1:C} Tax: {2:C}",item.SalesDate.ToShortDateString(),item.SalesAmount,item.TaxAmount);
            }
            
            //Wait for user to acknowledge the results.
            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }
    }

    public class Tax
    {
        public static decimal CalculateTax(decimal amount)
        {
            decimal taxAmount = amount * .0825M;
            return taxAmount;
        }
    }
}
