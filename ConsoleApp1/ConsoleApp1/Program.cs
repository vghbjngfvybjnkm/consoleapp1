using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp_Gritskov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company.StartProgram();
            int orderNum = 1;
            while (orderNum >= 0)
            {
                Console.WriteLine($"Введите действие: Добавить заказ(1)/Закончить работу(2)");
                string command1 = Console.ReadLine();
                if (command1 == "1")
                {
                    Console.WriteLine($"Введите тип заказа: Доставить(1)/Забрать(2)");
                    string command2 = Console.ReadLine();
                    if (command2 == "1")
                    {
                        var orderD = OrderForDelivery.NewOrder(orderNum);
                        var order = (Order) orderD;
                        OrderDestributor.Distributoin(order);
                        orderNum++;
                    }
                    else if (command2 == "2")
                    {
                        var orderT = OrderForTaking.NewOrder(orderNum);
                        var order = (Order)orderT;
                        OrderDestributor.Distributoin(order);
                        orderNum++;
                    }
                    GetInfo();
                }
                else if (command1 == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Введите действие заново.");
                }
            }
        }
        /// <summary>
        /// Показывает текущую информацию о курьерах и заказах.
        /// </summary>
        public static void GetInfo()
        {
            Console.WriteLine("==============================");
            for (int i = 0; i < Company.QuantityC; i++)
            {
                if (Company.Couriers[i].Orders.Count > 0)
                {
                    Console.Write($"{Company.Couriers[i].Name} будет выполнять заказ(ы):");
                    for (int j = 0; j < Company.Couriers[i].Orders.Count; j++)
                    {
                        Console.Write($" {Company.Couriers[i].Orders[j].Id} ({Company.Couriers[i].Orders[j].Profit})");
                    }
                    Console.Write($" Суммарное время:{Company.Couriers[i].BusyTime}");
                    Console.WriteLine(".");
                }
            }
            if (Company.RejectedOrders.Count > 0)
            {
                Console.Write($"Непринятые заказы:");
                foreach (var order in Company.RejectedOrders)
                {
                    Console.Write($" {order.Id}");
                }
                Console.WriteLine(".");
            }
            int fullProfit = Company.CalcFullProfit();
            Console.WriteLine($"Суммарная прибыль: {fullProfit}.");
            Console.WriteLine("==============================");
        }
    }
}