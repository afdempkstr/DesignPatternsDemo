using System;

namespace DesignPatternsDemo
{
    public class Vehicle
    {
        private Location _location;

        public string Id { get; }

        public Location Location
        {
            get { return _location; }
            set
            {
                if (value != null && !value.Equals(Location))
                {
                    _location = value;
                    OnLocationChanged();
                }
            }
        }

        public Vehicle(string id)
        {
            Id = id;
        }

        public event EventHandler LocationChanged;

        private void OnLocationChanged()
        {
            LocationChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
