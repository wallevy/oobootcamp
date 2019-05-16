using System;
using System.Collections.Generic;
using Parking.Exceptions;
using Parking.Interfaces;
using Parking.Models;

namespace Parking.Lots
{
    public class ParkingLot : IParkable
    {
        readonly long capacity;
        readonly Dictionary<string, Car> lot;

        public ParkingLot(long capacity)
        {
            this.capacity = capacity;
            lot = new Dictionary<string, Car>();
        }

        public long SpaceCount => capacity - lot.Count;

        public double SpacePercent => (double) SpaceCount / lot.Count;

        public bool CanPark()
        {
            return lot.Count < capacity;
        }

        public bool CanPick(string token)
        {
            return lot.ContainsKey(token ?? "");
        }

        public string Park(Car car)
        {
            if (!CanPark())
            {
                throw new NoSpaceException();
            }

            var token = Guid.NewGuid().ToString();

            lot.Add(token, car);

            return token;
        }

        public Car Pick(string token)
        {
            if (!CanPick(token))
            {
                throw new NotFoundException();
            }

            var car = lot[token];

            lot.Remove(token);

            return car;
        }

        public Report Report => new Report("P", capacity, capacity - SpaceCount);
    }
}
