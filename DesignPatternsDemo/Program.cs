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
            var myOtherCar = new Vehicle("ZZ-4321");
            fleetManager.AddVehicle(myCar);
            fleetManager.AddVehicle(myOtherCar);
            myCar.LocationChanged += MyCarOnLocationChanged;
            myOtherCar.LocationChanged += MyCarOnLocationChanged;
            myCar.Location = new Location(10, 10);
            myOtherCar.Location = new Location(-20, 10);

            fleetManager.RemoveVehicle(myCar.Id);

            for (int step = 0; step < 50; step++)
            {
                myCar.Location = new Location(myCar.Location.Latitude - 1, myCar.Location.Longitude -1);
                myOtherCar.Location = new Location(myOtherCar.Location.Latitude + 2, myOtherCar.Location.Longitude - 1);
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
