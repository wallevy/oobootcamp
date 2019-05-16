using Parking.Boys;
using Parking.Exceptions;
using Parking.Lots;
using Parking.Models;
using Xunit;

namespace Parking.Test.Specs
{
    public class ParkingManagerSpec
    {
        [Fact]
        void should_can_pick_the_car_when_manager_park_a_car()
        {
            var manager = new ParkingManager(new ParkingLot(10));
            var car = new Car();
            var token = manager.Park(car);

            var pickedCar = manager.Pick(token);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_can_pick_the_car_when_manage_parking_boy_and_park_a_car()
        {
            var manager = new ParkingManager(new ParkingBoy(new ParkingLot(10)));
            var car = new Car();
            var token = manager.Park(car);

            var pickedCar = manager.Pick(token);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_can_pick_the_car_when_manage_smart_parking_boy_and_park_a_car()
        {
            var manager = new ParkingManager(new SmartParkingBoy(new ParkingLot(10)));
            var car = new Car();
            var token = manager.Park(car);

            var pickedCar = manager.Pick(token);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_can_pick_the_car_when_manage_super_parking_boy_and_park_a_car()
        {
            var manager = new ParkingManager(new SuperParkingBoy(new ParkingLot(10)));
            var car = new Car();
            var token = manager.Park(car);

            var pickedCar = manager.Pick(token);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_can_pick_the_car_when_manage_parking_lots_and_parking_boys_and_park_a_car()
        {
            var lotNoSpace = new ParkingLot(0);
            var lotHasSpace = new ParkingLot(2);
            var boy = new SuperParkingBoy(lotHasSpace);
            var superBoy = new SuperParkingBoy(lotHasSpace);
            var smartBoy = new SuperParkingBoy(lotNoSpace);
            var manager = new ParkingManager(lotNoSpace, boy, smartBoy, superBoy);
            var car = new Car();

            var token = manager.Park(car);
            Assert.Same(car, manager.Pick(token));

            token = manager.Park(car);
            Assert.Same(car, boy.Pick(token));

            token = manager.Park(car);
            Assert.Same(car, superBoy.Pick(token));

            token = manager.Park(car);
            Assert.Same(car, lotHasSpace.Pick(token));

            token = manager.Park(car);
            Assert.Throws<NotFoundException>(() => smartBoy.Pick(token));

            token = manager.Park(car);
            Assert.Throws<NotFoundException>(() => lotNoSpace.Pick(token));
        }
    }
}
