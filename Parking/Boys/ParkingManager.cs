using System.Linq;
using Parking.Interfaces;

namespace Parking.Boys
{
    public class ParkingManager : ParkProxy<IParkable>
    {
        public ParkingManager(params IParkable[] parkables) : base(parkables)
        {
        }

        protected override IParkable GetParkable()
        {
            return Parkables.First(e => e.CanPark());
        }

        protected override string Role => "M";
    }
}