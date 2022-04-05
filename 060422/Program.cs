using System;

namespace _060422
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            menu:
            Console.WriteLine("=======MENU=======");
            Console.WriteLine("1-Add Order\n2-Get Orders Avg\n3-Get Orders Avg(Date Time)");
            Console.WriteLine("4-Remove Order By No\n5-Filter Order By Price\n6-Get All Orders \n0-Quit");
            Console.Write("\nYour choice: ");
            string choise = Console.ReadLine();            
            bool quit = false;

            do
            {
                switch (choise)
                {
                    case "1":
                        Order newOrder = new Order();
                        Console.Write("Product count: ");
                        newOrder.ProductCount = int.Parse(Console.ReadLine());
                        Console.Write("Total amount: ");
                        newOrder.TotalAmount = double.Parse(Console.ReadLine());
                        Console.Write("Created at: ");
                        newOrder.CreatedAt = DateTime.Parse(Console.ReadLine());
                        shop.AddOrder(newOrder);
                        Console.WriteLine("successfully added...");
                        goto menu;

                    case "2":
                        Console.WriteLine("Average: " + shop.GetOrderAvg());
                        goto menu;

                    case "3":
                        Console.Write("Enter Date Time: ");
                        DateTime dateTime = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Average: " + shop.GetOrdersAvg(dateTime));                        
                        goto menu;

                    case "4":
                        Console.Write("Removed No: ");
                        int removedNo = int.Parse(Console.ReadLine());
                        shop.RemoveOrderByNo(removedNo);
                        goto menu;

                    case "5":
                        Console.Write("Min Price: ");
                        double minPrice = double.Parse(Console.ReadLine());
                        Console.Write("Max Price: ");
                        double maxPrice = double.Parse(Console.ReadLine());
                        foreach (var item in shop.FilterOrderByPrice(minPrice,maxPrice))
                        {
                            Console.WriteLine(item.ShowInfo());
                        }
                        goto menu;

                    case "6":                        
                        foreach (var item in shop.GetAllOrders())
                        {
                            Console.WriteLine(item.ShowInfo());
                        }
                        goto menu;

                    case "0":
                        quit = true;
                        Console.WriteLine("Prosses ended...");
                        break;
                    default:
                        Console.WriteLine("\nWrong Choice. Choose between 0 and 5");
                        goto menu;
                }
            } while (!quit);
        }
    }
}
