using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp_Gritskov
{
    internal static class CourierCalculator
    {
        /// <summary>
        /// Возвращает наилучшего по профитности курьера, к которому заказ будет прикрепляться
        /// </summary>
        public static Courier BestCourier(this Order order)
        {
            // создаёт и заполняет список вариантов постановки заказа
            List<Variant> variants = new();
            for (int i = 0; i < Company.QuantityC; i++)
            {
                if (Company.Couriers[i].CheckCombination(order))
                {
                    var profit = Company.Couriers[i].CalcutuateProfitOfOrder(order);
                    var newVariant = new Variant(Company.Couriers[i], profit);
                    variants.Add(newVariant);
                }
            }
            // сортирует список вариантов, и, если профит от наилучшего варианта больше 0, то возвращает курьера, иначе возвращает NULL
            var _variants = variants.OrderByDescending(x => x.Profit);
            if (_variants.First().Profit > 0)
            {
                order.Profit = _variants.First().Profit;
                return variants[0].Courier;
            }
            else
                return null;

        }
        /// <summary>
        /// Считает профит для заказа от данной координаты, если его будет доставлять данный курьер.
        /// </summary>
        private static int CalcutuateProfitOfOrder(this Courier courier, Order order)
        {
            return (int)Math.Round(order.Coast - (order.Distance + CoordHelper.GetDistance(order.Start, courier.ActualCoord)) * courier.Price);
        }
    }
}
