using Parking.Models;

namespace Parking.Interfaces
{
    public interface IParkable : IReportable
    {
        bool CanPark();

        bool CanPick(string token);

        string Park(Car car);

        Car Pick(string token);
    }
}