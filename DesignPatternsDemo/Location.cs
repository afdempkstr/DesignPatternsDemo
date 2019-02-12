using System;

namespace DesignPatternsDemo
{
    public class Location : IEquatable<Location>
    {
        public double Latitude { get; }

        public double Longitude { get; }

        public Location(double latitude, double longitude)
        {
            if (latitude > 90 || latitude < -90)
            {
                throw new CoordinateOutOfRangeException("Latitude is out of range");
            }

            if (longitude > 180 || longitude < -180)
            {
                throw new CoordinateOutOfRangeException("Longitude is out of range");
            }

            Latitude = latitude;
            Longitude = longitude;
        }

        public bool Equals(Location other)
        {
            if (other == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return (Math.Abs(this.Latitude - other.Latitude) < 1e-6 &&
                    Math.Abs(this.Longitude - other.Longitude) < 1e-6);
        }

        public double Distance(Location other)
        {
            var d1 = this.Latitude * (Math.PI / 180.0);
            var num1 = this.Longitude * (Math.PI / 180.0);
            var d2 = other.Latitude * (Math.PI / 180.0);
            var num2 = other.Longitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }

        public override string ToString()
        {
            return $"({Longitude},{Latitude})";
        }
    }
}
