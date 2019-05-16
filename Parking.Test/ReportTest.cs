using System;
using Parking.Boys;
using Xunit;

namespace Parking.Test
{
    public class ReportTest
    {
        static string NewLine => Environment.NewLine;

        [Fact]
        void should_report_when_manager_manages_nothing()
        {
            var parkingManager = new ParkingManager();

            Assert.Equal("M 0 0", parkingManager.Report.ToString());
        }

        [Fact]
        void should_report_when_manager_manages_one_parking_lot()
        {
            var parkingLot = ParkingLotBuilder.Build(2, 1);

            var parkingManager = new ParkingManager(parkingLot);

            Assert.Equal("M 1 2" + NewLine +
                         "  P 1 2", parkingManager.Report.ToString());
        }

        [Fact]
        void should_report_when_manager_manages_one_parking_boy()
        {
            var parkingLot = ParkingLotBuilder.Build(2, 1);
            var parkingBoy = new ParkingBoy(parkingLot);
            var parkingManager = new ParkingManager(parkingBoy);

            Assert.Equal("M 1 2" + NewLine +
                         "  B 1 2" + NewLine +
                         "    P 1 2", parkingManager.Report.ToString());
        }

        [Fact]
        void should_report_when_manager_manages_one_smart_parking_boy()
        {
            var parkingLot = ParkingLotBuilder.Build(2, 1);
            var parkingBoy = new SmartParkingBoy(parkingLot);
            var parkingManager = new ParkingManager(parkingBoy);

            Assert.Equal("M 1 2" + NewLine +
                         "  B 1 2" + NewLine +
                         "    P 1 2", parkingManager.Report.ToString());
        }

        [Fact]
        void should_report_when_manager_manages_one_super_parking_boy()
        {
            var parkingLot = ParkingLotBuilder.Build(2, 1);
            var parkingBoy = new SuperParkingBoy(parkingLot);
            var parkingManager = new ParkingManager(parkingBoy);

            Assert.Equal("M 1 2" + NewLine +
                         "  B 1 2" + NewLine +
                         "    P 1 2", parkingManager.Report.ToString());
        }

        [Fact]
        void should_report_when_manager_manages_one_parking_lot_and_different_parking_boys()
        {
            var parkingLot = ParkingLotBuilder.Build(100, 10);
            var parkingBoy = new ParkingBoy(ParkingLotBuilder.Build(200, 20));
            var smartParkingBoy = new SmartParkingBoy(ParkingLotBuilder.Build(300, 30));
            var superParkingBoy = new SuperParkingBoy(ParkingLotBuilder.Build(400, 40));
            var parkingManager = new ParkingManager(parkingLot, parkingBoy, smartParkingBoy, superParkingBoy);

            Assert.Equal("M 100 1000" + NewLine +
                         "  P 10 100" + NewLine +
                         "  B 20 200" + NewLine +
                         "    P 20 200" + NewLine +
                         "  B 30 300" + NewLine +
                         "    P 30 300" + NewLine +
                         "  B 40 400" + NewLine +
                         "    P 40 400", parkingManager.Report.ToString());
        }
    }
}
