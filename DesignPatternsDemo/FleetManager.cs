using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo
{
    // A fleet manager manages vehicles.
    // We need to be able to add / remove a vehicle
    // and if a vehicle's location is < 100m to our offices
    // which are located at (0,0) it should inform us
    public class FleetManager
    {
        private List<Vehicle> _vehicles = new List<Vehicle>();
        private Location _location;

        public FleetManager(Location location)
        {
            _location = location;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
            vehicle.LocationChanged += VehicleOnLocationChanged;
        }

        public void RemoveVehicle(string id)
        {
            var index = _vehicles.FindIndex(v => v.Id == id);
            if (index > 0)
            {
                _vehicles.RemoveAt(index);
            }
        }

        private void VehicleOnLocationChanged(object sender, EventArgs e)
        {
            var vehicle = sender as Vehicle;
            if (_location.Distance(vehicle.Location) < 1000)
            {
                Console.WriteLine($"Vehicle {vehicle.Id} is close to our headquarters!");
            }
        }
    }
}
