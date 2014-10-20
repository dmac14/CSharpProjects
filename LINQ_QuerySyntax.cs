using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpProjects
{
    class QuerySyntax
    {
        static void Main(string[] args)
        {
            //See setupOrders method and Order class below for details
            List<Order> orders = setupOrders();
            

            // PART 1
            Console.WriteLine("Get a list of all orders after December 8, 2007");            

            var myList1 = from o in orders
                         where o.OrderDate > DateTime.Parse("12/8/2007")
                         select o;
            foreach (var o in myList1)
            {
                Console.WriteLine("{0} - {1}",o.OrderDate.ToShortDateString(),o.OrderID);
            }
            Console.WriteLine("");
            


            // PART 2

            Console.WriteLine("Same, this time retrieve only the orderID and the amount into an anonymous type.");

            var myList2 = from o in orders
                         where o.OrderDate > DateTime.Parse("12/8/2007")
                         select new { o.OrderID, o.OrderAmount };
            foreach (var o in myList2)
            {
                Console.WriteLine("{0} - {1}", o.OrderID,o.OrderAmount);
            }
            Console.WriteLine("");
            


            // PART 3

            Console.WriteLine("Find the order with the largest order amount. (HINT: we didn't cover orderby very much, but you'll need it.  Also, consider using the First() extension method.");

            var myList3 = (from o in orders
                          orderby o.OrderAmount descending
                          select new { o.OrderID, o.OrderDate, o.OrderAmount }).First();            

            Console.WriteLine("{0} - {1} - {2}",myList3.OrderID,myList3.OrderDate.ToShortDateString(),myList3.OrderAmount);
           
            Console.WriteLine("");


            // PART 4

            Console.WriteLine("Find all orders containing widgets.");

            var myList4 = from o in orders
                          from oi in o.OrderItems
                          where oi.ProductName == "Widgets"
                          select o.OrderID;
            foreach (var o in myList4)
            {
                Console.WriteLine("{0}",o);
            }

            Console.WriteLine("");


            // PART 5

            Console.WriteLine("Sum up the value of all order items.");

            var myList5 = (from o in orders
                          select o.OrderAmount).Sum();
            Console.WriteLine("{0}",myList5);

            Console.WriteLine("");


            // PART 6

            Console.WriteLine("What is the average order total?");

            var myList6 = (from o in orders
                           select o.OrderAmount).Average();
            Console.WriteLine("{0}",myList6);
            Console.WriteLine("");


            // PART 7


            Console.WriteLine("How many orders have multiple items?");

            var mylist7 = (from o in orders
                          where o.OrderItems.Count() > 1
                           select o).Count();
            Console.WriteLine("{0}",mylist7);
                         
            Console.WriteLine("");


            // PART 8

            Console.WriteLine("Create a flat list of a new anonymous type using LINQ to project the fields OrderID, OrderItemID, ProductName of every order item");

            var myList8 = from o in orders
                          from oi in o.OrderItems
                          select new { o.OrderID, oi.OrderItemID, oi.ProductName };
            foreach (var o in myList8)
            {
                Console.WriteLine("{0} - {1} - {2}", o.OrderID,o.OrderItemID,o.ProductName);
            }

            Console.WriteLine("");


            // PART 9

            Console.WriteLine("Create a new set of orders based on the existing orders ... BUT add 1000 to each OrderID AND set the OrderDate to Now.");
            Console.WriteLine("(Bwahahah ... <evil laugh>.");

            var newOrderList = from o in orders
                               select new Order
                               {
                                   OrderID = o.OrderID + 1000,
                                   CustomerName = o.CustomerName,
                                   OrderItems = o.OrderItems,
                                   BillingAddress = o.BillingAddress,
                                   ShippingAddress = o.ShippingAddress,
                                   OrderAmount = o.OrderAmount,
                                   OrderDate = DateTime.Now
                               };
            foreach (var o in newOrderList)
            {
                Console.WriteLine("{0} - {1}", o.OrderID,o.OrderDate.ToShortDateString());
            }                             


            //Wait for user to acknowledge the results.
            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }


        //======Provided Code Below=======
        static private List<Order> setupOrders()
        {
            List<Order> orderList = new List<Order>();

            Order o1 = new Order();
            o1.OrderDate = DateTime.Parse("12/7/2007 1:05 PM");
            o1.OrderAmount = 150.0M;
            o1.OrderID = 9009;

            OrderItem oi1 = new OrderItem();
            oi1.OrderItemID = 123;
            oi1.ProductName = "FooBar";
            oi1.Quantity = 2;
            o1.OrderItems.Add(oi1);

            OrderItem oi2 = new OrderItem();
            oi2.OrderItemID = 124;
            oi2.ProductName = "BazQuirk";
            oi2.Quantity = 3;
            o1.OrderItems.Add(oi2);

            Order o2 = new Order();
            o2.OrderDate = DateTime.Parse("12/8/2007 9:15 AM");
            o2.OrderAmount = 175.0M;
            o2.OrderID = 9010;

            OrderItem oi3 = new OrderItem();
            oi3.OrderItemID = 125;
            oi3.ProductName = "FooBar";
            oi3.Quantity = 1;
            o2.OrderItems.Add(oi3);

            OrderItem oi4 = new OrderItem();
            oi4.OrderItemID = 126;
            oi4.ProductName = "Gadgets";
            oi4.Quantity = 5;
            o2.OrderItems.Add(oi4);

            OrderItem oi5 = new OrderItem();
            oi5.OrderItemID = 127;
            oi5.ProductName = "Bazquirk";
            oi5.Quantity = 1;
            o2.OrderItems.Add(oi5);

            OrderItem oi6 = new OrderItem();
            oi6.OrderItemID = 128;
            oi6.ProductName = "Widgets";
            oi6.Quantity = 6;
            o2.OrderItems.Add(oi6);

            Order o3 = new Order();
            o3.OrderDate = DateTime.Parse("12/9/2007 4:50 PM");
            o3.OrderAmount = 250.0M;
            o3.OrderID = 9011;

            OrderItem oi7 = new OrderItem();
            oi7.OrderItemID = 129;
            oi7.ProductName = "Widgets";
            oi7.Quantity = 3;
            o3.OrderItems.Add(oi7);

            OrderItem oi8 = new OrderItem();
            oi8.OrderItemID = 130;
            oi8.ProductName = "Gadgets";
            oi8.Quantity = 5;
            o3.OrderItems.Add(oi8);

            Order o4 = new Order();
            o4.OrderDate = DateTime.Parse("12/10/2007 1:23 PM");
            o4.OrderAmount = 225.0M;
            o4.OrderID = 9012;

            OrderItem oi9 = new OrderItem();
            oi9.OrderItemID = 131;
            oi9.ProductName = "Widgets";
            oi9.Quantity = 1;
            o4.OrderItems.Add(oi9);

            orderList.Add(o1);
            orderList.Add(o2);
            orderList.Add(o3);
            orderList.Add(o4);

            return orderList;
        }

    }

    class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public decimal OrderAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public Order(int orderID, DateTime orderDate)
        {
            OrderID = orderID;
            OrderDate = orderDate;
        }
    }

    class OrderItem
    {
        public int OrderItemID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }

    class Address
    {
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }


}
