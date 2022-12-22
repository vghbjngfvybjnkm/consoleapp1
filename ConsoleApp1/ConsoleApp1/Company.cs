using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp_Gritskov
{
    internal static class Company
    {
        public const double PricePerDistance = 200;
        public const double StandartFootCourierSpeed = 7;             //Стандартные характеристики пешего курьера.
        public const double StandartFootCourierCapacity = 4;
        public const double StandartFootCourierPricePerDistance = 40;
        public const double StandartScuterCourierSpeed = 15;              //Стандартные характеристики курьера на скутере.
        public const double StandartScuterCourierCapacity = 8;
        public const double StandartScyterCourierPricePerDistance = 60;
        public static List<Courier> CouriersList = new();               // списки курьеров, заказов, не принятых заказов
        public static Courier[] Couriers = new Courier[QuantityC];
        public static List<Order> Orders = new();
        public static List<Order> RejectedOrders = new();
        // количество курьеров
        private static int quantityFC;
        private static int quantitySC;
        public static int QuantityC;
        /// <summary>
        /// Считает суммарную прибыль
        /// </summary>
        /// <returns></returns>
        public static int CalcFullProfit()
        {
            int fullProfit = 0;
            foreach (var courier in Couriers)
                foreach (var order in courier.Orders)
                    fullProfit += order.Profit;
            return fullProfit;
        }

        public static void StartProgram()
        {
            CreateCouriersList();
        }
        /// <summary>
        /// Запускает начальное создание всех курьеров
        /// </summary>
        private static void CreateCouriersList()
        {
            //Добавляет заданное кол-во пеших курьеров.
            Console.WriteLine("Введите количество пеших курьеров.");
            quantityFC = int.Parse(Console.ReadLine());
            for (int i = 0; i < quantityFC; i++)
            {
                CouriersList.Add(new FootCourier(i));
            }
            //Добавляет заданное кол-во курьеров на скутерах.
            Console.WriteLine("Введите количество курьеров на скутерах.");
            quantitySC = int.Parse(Console.ReadLine());
            for (int i = 0; i < quantitySC; i++)
            {
                CouriersList.Add(new ScuterCourier(i));
            }
            //Считает общее кол-во курьеров и переделывает список в массив.
            QuantityC = quantityFC + quantitySC;
            Couriers = CouriersList.ToArray();
        }
    }
}
