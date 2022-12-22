using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp_Gritskov
{
    /// <summary>
    /// Класс для хранения каждого возможного варианта вставки заказа.
    /// </summary>
    internal class Variant
    {
        public Variant(Courier courier, int profit)
        {
            Courier = courier;
            Profit = profit;
        }

        public Courier Courier { get; set; }

        public int Profit { get; set; }
    }
}
