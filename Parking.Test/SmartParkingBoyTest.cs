using Parking.Boys;
using Parking.Lots;
using Parking.Models;
using Xunit;

namespace Parking.Test
{
    public class SmartParkingBoyTest
    {
        [Fact]
        void should_can_pick_the_car_when_parking_boy_park_a_car()
        {
            var parkingBoy = new SmartParkingBoy(new ParkingLot(10));
            var car = new Car();
            var token = parkingBoy.Park(car);

            var pickedCar = parkingBoy.Pick(token);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_park_car_to_the_parking_lot_which_has_the_larget_space_count()
        {
            var parkingLot = new ParkingLot(10);
            var parkingBoy = new SmartParkingBoy(new ParkingLot(5), parkingLot, new ParkingLot(3));
            var car = new Car();
            var token = parkingBoy.Park(car);

            var pickedCar = parkingLot.Pick(token);

            Assert.Same(car, pickedCar);
        }
    }
}
