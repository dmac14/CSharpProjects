using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day9ExerciseMethodSyntax
{
    class Day9ExMethSyn
    {
        static void Main(string[] args)
        {
            //See setupOrders method and Order class below for details
            List<Order> orders = setupOrders();


            // PART 1
            Console.WriteLine("Get a list of all orders after December 8, 2007");

            var myList1 = orders.Where(o=>o.OrderDate>DateTime.Parse("12/8/2007"));
            foreach (var item in myList1)
            {
                Console.WriteLine("{0} - {1}",item.OrderDate.ToShortDateString(),item.OrderID);
            }

            Console.WriteLine("");


            // PART 2

            Console.WriteLine("Same, this time retrieve only the orderID and the amount into an anonymous type.");

            var myList2= orders.Where(o=>o.OrderDate>DateTime.Parse("12/8/2007")).Select(o=>new {o.OrderID,o.OrderAmount});
            foreach (var item in myList2)
	        {
                Console.WriteLine("{0} - {1}",item.OrderID,item.OrderAmount);
	        }

            Console.WriteLine("");

            // PART 3

            Console.WriteLine("Find the order with the largest order amount. (HINT: we didn't say much about OrderByDescending very much, but you'll need it.  Also, consider using the First() extension method.");

            var myList3 = orders.OrderByDescending(o => o.OrderAmount).First();
            Console.WriteLine("{0} - {1} - {2}",myList3.OrderID,myList3.OrderDate.ToShortDateString(),myList3.OrderAmount);

            Console.WriteLine("");


            // PART 4--didnt figure out

            Console.WriteLine("Find all orders containing widgets.  HINT: You're going to need to create a lambda inside of a lambda.  The inner-most lambda will use the Any method.  The outer-most lambda will use Where");

            var myList4 = orders.Where(o => o.OrderItems.Any(oi => oi.ProductName == "Widgets"));
            foreach (var item in myList4)
            {
                Console.WriteLine("{0}",item.OrderID);
            }

            Console.WriteLine("");


            // PART 5

            Console.WriteLine("Sum up the value of all order items.");

            Console.WriteLine(orders.Select(o => o.OrderAmount).Sum());      


            Console.WriteLine("");


            // PART 6

            Console.WriteLine("What is the average order total?");

            Console.WriteLine(orders.Select(o=>o.OrderAmount).Average());

            Console.WriteLine("");


            // PART 7--Both he and I have this one wrong 
            // Wrong when multiple items with only quantity of 1
            // OR when one item with quantity>1
            
            Console.WriteLine("How many orders have multiple items?");
            
            Console.WriteLine(orders.Count(o=>o.OrderItems.Any(oi=>oi.Quantity>1)));
            Console.WriteLine(orders.Where(o => o.OrderItems.Count() > 1).Count());
            
            Console.WriteLine("");


            // PART 8--Didn't figure out

            Console.WriteLine("Create a flat list of a new anonymous type using LINQ to project the fields OrderID, OrderItemID, ProductName of every order item");

            var myList8=orders.SelectMany(o=>o.OrderItems,(o,oi)=>new {o.OrderID,oi.OrderItemID,oi.ProductName});
            foreach (var item in myList8)
            {
                Console.WriteLine("{0} - {1} - {2}",item.OrderID,item.OrderItemID,item.ProductName);
            }

            Console.WriteLine("");


            // PART 9

            Console.WriteLine("Create a new set of orders based on the existing orders ... BUT add 1000 to each OrderID AND set the OrderDate to Now.");
            Console.WriteLine("(Bwahahah ... <evil laugh>.");

            var myList9 = orders.Select(o => new Order { OrderID = o.OrderID + 1000, OrderDate = DateTime.Now, CustomerName = o.CustomerName, OrderAmount = o.OrderAmount, OrderItems = o.OrderItems, BillingAddress = o.BillingAddress, ShippingAddress = o.ShippingAddress });
            foreach (var item in myList9)
            {
                Console.WriteLine("{0} - {1}",item.OrderID,item.OrderDate.ToShortDateString());
            }
            Console.ReadLine();

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
