using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp_Gritskov
{
    public static class CoordHelper
    {
        static Random rndm = new();
        /// <summary>
        /// Считает дистанцию меду двумя точками.
        /// </summary>
        public static double GetDistance(this Coord from, Coord destination)
        {
            return Math.Sqrt(
                Math.Pow(destination.X - from.X, 2)
                + Math.Pow(destination.Y - from.Y, 2));
        }
        /// <summary>
        /// Создаёт рандомные координаты.
        /// </summary>
        public static Coord RandCoord()
        {
            var coord = new Coord(rndm.Next(1, 16), rndm.Next(1, 16));
            return coord;
        }
    }
}
