using Parking.Exceptions;
using Parking.Lots;
using Parking.Models;
using Xunit;

namespace Parking.Test
{
    public class ParkingLotTest
    {
        [Fact]
        void should_pick_the_right_car_when_park_some_cars()
        {
            var car = new Car();
            var parkingLot = new ParkingLot(10);
            var token = parkingLot.Park(car);
            parkingLot.Park(new Car());
            parkingLot.Park(new Car());

            var carPicked = parkingLot.Pick(token);

            Assert.Same(car, carPicked);
        }

        [Fact]
        void should_can_not_park_any_car_when_the_parking_lot_there_is_no_space()
        {
            var parkingLot = new ParkingLot(0);

            Assert.Throws<NoSpaceException>(() => parkingLot.Park(new Car()));
        }

        [Fact]
        void should_can_not_pick_any_car_when_the_car_is_not_exist()
        {
            var parkingLot = new ParkingLot(10);

            Assert.Throws<NotFoundException>(() => parkingLot.Pick("124"));
        }
    }
}
