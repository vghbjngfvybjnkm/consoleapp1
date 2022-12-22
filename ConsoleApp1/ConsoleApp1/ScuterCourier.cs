using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp_Gritskov
{
    /// <summary>
    /// Курьер на скутере.
    /// </summary>
    internal class ScuterCourier : Courier
    {
        public ScuterCourier(int num)
        {
            CourierID = Company.CouriersList.Count;
            Name = $"Курьер на скутере № {num + 1}";
            ActualCoord = CoordHelper.RandCoord();
            Speed = Company.StandartScuterCourierSpeed;
            Capacity = Company.StandartScuterCourierCapacity;
            Price = Company.StandartScyterCourierPricePerDistance;
            StartTime = DateTime.Today + TimeSpan.FromHours(8);
            EndTime = DateTime.Today + TimeSpan.FromHours(22);
        }
    }
}
