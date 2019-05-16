using System.Collections.Generic;
using System.Linq;
using Parking.Exceptions;
using Parking.Interfaces;
using Parking.Models;

namespace Parking.Boys
{
    public abstract class ParkProxy<TParkable> : IParkable where TParkable : IParkable
    {
        protected IList<TParkable> Parkables { get; }

        protected ParkProxy(IList<TParkable> parkables)
        {
            Parkables = parkables ?? new List<TParkable>();
        }

        public bool CanPark()
        {
            return Parkables.Any(e => e.CanPark());
        }

        public bool CanPick(string token)
        {
            return Parkables.Any(e => e.CanPick(token));
        }

        public string Park(Car car)
        {
            if (!CanPark())
            {
                throw new NoSpaceException();
            }
            return GetParkable().Park(car);
        }

        public Car Pick(string token)
        {
            if (!CanPick(token))
            {
                throw new NotFoundException();
            }
            return Parkables.First(e => e.CanPick(token)).Pick(token);
        }

        protected abstract IParkable GetParkable();

        protected abstract string Role { get; }

        public Report Report
        {
            get
            {
                var subReports = Parkables.Select(i => i.Report).ToList();
                return new Report(Role, subReports);
            }
        }
    }
}