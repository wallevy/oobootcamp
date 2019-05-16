using Parking.Boys;
using Parking.Lots;
using Parking.Models;
using Xunit;

namespace Parking.Test
{
    public class SuperParkingBoyTest
    {
        [Fact]
        void should_can_pick_the_car_when_parking_boy_park_a_car()
        {
            var parkingBoy = new SuperParkingBoy(new ParkingLot(10));
            var car = new Car();
            var token = parkingBoy.Park(car);

            var pickedCar = parkingBoy.Pick(token);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_park_car_to_the_parking_lot_which_has_the_larget_space_percent()
        {
            var lotPercent50 = new ParkingLot(2);
            lotPercent50.Park(new Car());

            var lotPercent100 = new ParkingLot(1);
            var parkingBoy = new SuperParkingBoy(lotPercent50, lotPercent100);
            var car = new Car();
            var token = parkingBoy.Park(car);

            var pickedCar = lotPercent100.Pick(token);

            Assert.Same(car, pickedCar);
        }
    }
}
