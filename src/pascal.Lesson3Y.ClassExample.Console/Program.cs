using pascal.Lesson3Y.ClassExample.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace pascal.Lesson3Y.ClassExample.UIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle("abc");            
            string license = vehicle.LicensePlate;
                      
            Console.WriteLine(license);

            Vehicle vehicle1 = new Vehicle("xyz", -1, 50, 75);
            Console.WriteLine(vehicle1.LicensePlate);
            Console.WriteLine(vehicle1.OdometerKm);
            Console.WriteLine(vehicle1.DailyRate);
            Console.WriteLine(vehicle1.FuelLevelPercentage);

        }
    }
}
