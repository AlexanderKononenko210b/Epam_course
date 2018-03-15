using System;
using MetrologyEntitties;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the object type FuelTank
            FuelTank fuelTank = new FuelTank().Get();

            //Enter information about fuel tank object
            Console.WriteLine($"FuelTank: TypeTank = {fuelTank.TypeTank}, Scope = {fuelTank.AllScopeTank}");

            // Get the object type Hydrometer
            Hydrometer hydrometer = new Hydrometer().Get();

            //Enter information about hydrometer object
            Console.WriteLine($"Hydrometr: Model = {hydrometer.Model}, ClassAccuracy = {hydrometer.ClassAccuracy}");

        }
    }
}
