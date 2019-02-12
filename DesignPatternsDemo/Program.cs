using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var fleetManager = new FleetManager(new Location(0, 0));
            var myCar = new Vehicle("AB-1234");
            fleetManager.AddVehicle(myCar);
            myCar.LocationChanged += MyCarOnLocationChanged;

            myCar.Location = new Location(10, 10);

            fleetManager.RemoveVehicle(myCar.Id);

            for (double i = myCar.Location.Latitude; i >= -10; i--)
            {
                myCar.Location = new Location(i, i);
            }

            Console.ReadLine();
        }

        private static void PrintCar(object sender, EventArgs e)
        {
            Console.WriteLine("The location of a car has changed");
        }

        private static void MyCarOnLocationChanged(object sender, EventArgs e)
        {
            var car = sender as Vehicle;
            Console.WriteLine($"The location of the car {car.Id} is {car.Location}");
        }
    }
}
