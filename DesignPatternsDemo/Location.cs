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

        //public double Distance(Location other)
        //{

        //}

        //private double EuclideanDistance(Location other)
        //{
            
        //}
    }
}
