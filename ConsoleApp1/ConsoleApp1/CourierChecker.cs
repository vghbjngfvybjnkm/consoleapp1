using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp_Gritskov
{
    internal static class CourierChecker
    {
        /// <summary>
        /// Проверяет, может ли курьер взять заказ с заданной координаты.
        /// </summary>
        public static bool CheckCombination(this Courier courier, Order order)
        {
            //Если грузоподъёмность курьера больше веса груза, и он успеет его доставить до конца рабочего дня, то идём дальше
            if (courier.Capacity < order.Weigth || courier.StartTime + courier.BusyTime + TimeCalculator.TimeToCompliteOrder(order, courier) > courier.EndTime)
                return false;
            // если заказ на доставку, то берёт первый пункт, если на взятие, то второй пункт
            if (order is OrderForDelivery)
            {
                // успеет ли выполнить до дедлайны заказа
                return (courier.StartTime + courier.BusyTime + TimeCalculator.TimeToCompliteOrder(order, courier) < order.DeadLine);
            }
            else
            {
                //успеет ли взять до дедлайна заказа
                return (courier.StartTime + courier.BusyTime + TimeCalculator.TimeToWay(order, courier) < order.DeadLine);
            }
        }
    }
}