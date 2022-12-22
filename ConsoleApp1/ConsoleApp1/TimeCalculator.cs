using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp_Gritskov
{
    /// <summary>
    /// Формулы.
    /// </summary>
    internal static class TimeCalculator
    {
        /// <summary>
        /// Переводит дедлайн заказа в минуты.
        /// </summary>
        public static TimeSpan TimeToMinute(string time)
        {
            // находит двоеточие, и разделяет строку, потом переводит в часы минуты и затем возвращает кол-во времени.
            int split = time.IndexOf(":");
            int hour = int.Parse(time.Substring(0, split));
            int minute = int.Parse(time.Substring(split + 1));
            return TimeSpan.FromMinutes((hour * 60) + minute);
        }
        /// <summary>
        /// Считает, сколько времени курьер потратит на путь до начальной координаты заказа.
        /// </summary>
        public static TimeSpan TimeToWay(Order order, Courier courier)
        {
            return TimeSpan.FromMinutes((int)Math.Round(courier.ActualCoord.GetDistance(order.Start) / courier.Speed * 60));
        }
        /// <summary>
        /// Считает, сколько времени курьер потратит на полное выполнение заказа с начальной координаты.
        /// </summary>
        public static TimeSpan TimeToCompliteOrder(Order order, Courier courier)
        {
            return TimeSpan.FromMinutes((int)Math.Round((courier.ActualCoord.GetDistance(order.Start) + order.Distance) / courier.Speed * 60));
        }
    }
}
