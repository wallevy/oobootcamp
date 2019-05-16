using MoreLinq;
using Parking.Interfaces;
using Parking.Lots;

namespace Parking.Boys
{
    public class SmartParkingBoy : ParkProxy<ParkingLot>
    {
        public SmartParkingBoy(params ParkingLot[] parkables) : base(parkables)
        {
        }

        protected override IParkable GetParkable()
        {
            return Parkables.MaxBy(e => e.SpaceCount).First();
        }

        protected override string Role => "B";
    }
}
