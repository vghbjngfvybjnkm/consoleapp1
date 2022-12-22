using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp_Gritskov
{
    /// <summary>
    /// Распределитель заказов.
    /// </summary>
    internal static class OrderDestributor
    {
        /// <summary>
        /// Распределяет заказ.
        /// </summary>
        public static void Distributoin(Order order)
        {
            // находит набилучший заказ
            var bestCourier = order.BestCourier();
            // проверяет его на правильность
            if (bestCourier == null)
            {
                // если заказ не нашёл курьера, добавляет его в непринятые заказы
                Company.RejectedOrders.Add(order);
                return;
            }
            // прикрепляется к курьеру
            bestCourier.AttachingOrder(order);
        }
    }
}
