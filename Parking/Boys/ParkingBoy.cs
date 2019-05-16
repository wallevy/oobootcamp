using System.Linq;
using Parking.Interfaces;
using Parking.Lots;

namespace Parking.Boys
{
    public class ParkingBoy : ParkProxy<ParkingLot>
    {
        public ParkingBoy(params ParkingLot[] parkables) : base(parkables)
        {
        }

        protected override IParkable GetParkable()
        {
            return Parkables.First(e => e.CanPark());
        }

        protected override string Role => "B";
    }
}