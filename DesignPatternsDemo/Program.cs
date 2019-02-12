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
            var myCar = new Vehicle("AB-1234");
            myCar.LocationChanged += MyCarOnLocationChanged;
            myCar.LocationChanged += PrintCar;
            myCar.Location = new Location(28, 32);
            myCar.Location = new Location(28, 32);
            myCar.Location = new Location(30, 32);
            myCar.Location = null;
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
