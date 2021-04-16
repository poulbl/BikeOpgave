using System;
using BikeLibrary;

namespace BikeMan
{
    class Program
    {
        static void Main(string[] args)
        {

            Bike bike = new Bike(2, "TestBike", "TestFirma", "Gul", 19999.99M, "En test cykel!");
            BikeShop bs = new BikeShop("TestShop", "TestArea", 0000);
            bs.AddBike(bike);

            bs.UpdateBike(bike, "Ny description!", 5.0M);

            Bike updatedBike = new Bike(2, "TestBike", "TestFirma", "Gul", 5.0M, "Ny description!");

            if(bs.BikeDict.ContainsKey(bike))
            {
                Console.WriteLine("no");
            }
            else
            {
                Console.WriteLine("yes");
            }


            bs.OrderBikesFromStorage(bike, 10);

            Console.Read();
        }
    }
}
