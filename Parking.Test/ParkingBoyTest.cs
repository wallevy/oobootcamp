using Parking.Boys;
using Parking.Exceptions;
using Parking.Lots;
using Parking.Models;
using Xunit;

namespace Parking.Test
{
    public class ParkingBoyTest
    {
        [Fact]
        void should_can_pick_the_car_from_parking_lot_when_parking_boy_park_a_car()
        {
            var parkingLot = new ParkingLot(10);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var token = parkingBoy.Park(car);

            var pickedCar = parkingLot.Pick(token);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_can_pick_the_car_by_parking_boy_when_park_a_car_in_parking_lot()
        {
            var parkingLot = new ParkingLot(10);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var token = parkingLot.Park(car);

            var pickedCar = parkingBoy.Pick(token);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_can_pick_the_car_by_parking_boy_when_parking_boy_park_a_car()
        {
            var parkingBoy = new ParkingBoy(new ParkingLot(10));
            var car = new Car();
            var token = parkingBoy.Park(car);

            var pickedCar = parkingBoy.Pick(token);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_can_pick_the_car_from_the_first_has_space_parking_lot()
        {
            var parkingLot = new ParkingLot(10);
            var parkingBoy = new ParkingBoy(new ParkingLot(0), parkingLot, new ParkingLot(10));
            var car = new Car();
            var token = parkingBoy.Park(car);

            var pickedCar = parkingLot.Pick(token);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_can_not_park_any_car_when_all_parking_lot_there_are_no_space()
        {
            var parkingBoy = new ParkingBoy(new ParkingLot(0));

            Assert.Throws<NoSpaceException>(() => parkingBoy.Park(new Car()));
        }

        [Fact]
        void should_can_not_pick_any_car_when_the_car_is_not_exist()

        {
            var parkingBoy = new ParkingBoy();

            Assert.Throws<NotFoundException>(() => parkingBoy.Pick("123"));
        }

        [Fact]
        void should_can_not_pick_the_same_car_twice()
        {
            var parkingBoy = new ParkingBoy(new ParkingLot(10));
            var token = parkingBoy.Park(new Car());
            parkingBoy.Pick(token);

            Assert.Throws<NotFoundException>(() => parkingBoy.Pick(token));
        }
    }
}