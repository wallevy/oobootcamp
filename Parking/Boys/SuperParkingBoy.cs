using MoreLinq;
using Parking.Interfaces;
using Parking.Lots;

namespace Parking.Boys
{
    public class SuperParkingBoy : ParkProxy<ParkingLot>
    {
        public SuperParkingBoy(params ParkingLot[] parkables) : base(parkables)
        {
        }

        protected override IParkable GetParkable()
        {
            return Parkables.MaxBy(e => e.SpacePercent).First();
        }

        protected override string Role => "B";
    }
}
