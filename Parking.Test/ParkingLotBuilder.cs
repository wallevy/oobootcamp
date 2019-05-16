using Parking.Lots;
using Parking.Models;

namespace Parking.Test
{
    class ParkingLotBuilder
    {
        public static ParkingLot Build(long capacity, long usedCount)
        {
            var lot = new ParkingLot(capacity);
            for (var i = 0; i < usedCount; i++)
            {
                lot.Park(new Car());
            }
            return lot;
        }
    }
}