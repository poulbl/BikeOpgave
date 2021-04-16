using System;

namespace BikeLibrary
{
    public class Bike
    {
        public int NrOfWheels { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public Decimal Price { get; set; }
        public string Description { get; set; }

        public Bike(int nrOfWheels, string brand, string name, string color, decimal price, string description)
        {
            NrOfWheels = nrOfWheels;
            Brand = brand;
            Name = name;
            Color = color;
            Price = price;
            Description = description;
        }

    }
}
