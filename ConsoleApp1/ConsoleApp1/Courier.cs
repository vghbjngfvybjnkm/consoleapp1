using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp_Gritskov
{
    /// <summary>
    /// Типичный курьер.
    /// </summary>
    internal abstract class Courier
    {
        public int CourierID { get; protected set; }

        public string Name { get; protected set; }

        public Coord ActualCoord { get; protected set; }

        public double Capacity { get; protected set; }

        public double Speed { get; protected set; }

        public double Price { get; protected set; }

        public DateTime StartTime { get; protected set; }

        public DateTime EndTime { get; protected set; }

        public List<Order> Orders = new();

        public TimeSpan BusyTime { get { return CalculateBusyTime(); } }

        /// <summary>
        /// Считает суммарное время, которое курьер потратит на выполнение всех заказов в его списке заказов.
        /// </summary>
        protected TimeSpan CalculateBusyTime()
        {
            TimeSpan time = TimeSpan.FromMinutes(0);
            if ((Orders != null) && (Orders.Count > 0))
            {
                foreach (Order order in Orders)
                {
                    time += order.Time;
                }
            }
            return time;
        }
        /// <summary>
        /// Прикрепляет заказ к курьеру.
        /// </summary>
        public void AttachingOrder(Order order)
        {
            order.Time = TimeCalculator.TimeToCompliteOrder(order, this);
            Orders.Add(order);
        }
    }
}
