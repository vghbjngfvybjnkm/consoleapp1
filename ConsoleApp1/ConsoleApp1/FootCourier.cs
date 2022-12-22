using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp_Gritskov
{
    /// <summary>
    /// Пеший курьер.
    /// </summary>
    internal class FootCourier : Courier
    {
        public FootCourier(int num)
        {
            CourierID = Company.CouriersList.Count;
            Name = $"Пеший курьер № {num + 1}";
            ActualCoord = CoordHelper.RandCoord();
            Speed = Company.StandartFootCourierSpeed;
            Capacity = Company.StandartFootCourierCapacity;
            Price = Company.StandartFootCourierPricePerDistance;
            StartTime = DateTime.Today + TimeSpan.FromHours(8);
            EndTime = DateTime.Today + TimeSpan.FromHours(22);
        }
    }
}
