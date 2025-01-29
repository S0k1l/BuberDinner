using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    public sealed class Location : ValueObject
    {
        public string Name { get; }
        public string Address { get; }
        public double Latitude { get; }
        public double Longitude { get; }

        public Location(
            string name,
            string address,
            double latitude,
            double longitude)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }
        public static Location CreateUnique(
            string name,
            string address,
            double latitude,
            double longitude)
        {
            return new(
                name,
                address,
                latitude,
                longitude);
        }

        public override IEnumerable<object> GetEqualityObjects()
        {
            yield return Name;
            yield return Address;
            yield return Latitude;
            yield return Longitude;
        }
    }
}
