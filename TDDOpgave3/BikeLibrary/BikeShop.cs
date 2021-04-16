using System;
using System.Collections.Generic;
using System.Text;

namespace BikeLibrary
{
    public class BikeShop
    {
        public string Name { get; set; }
        public string Area { get; set; }
        public int Zipcode { get; set; }
        public Decimal Earnings { get; set; }
        public Dictionary<Bike, int> BikeDict { get; set; }

        public BikeShop(string name, string area, int zipcode)
        {
            Name = name;
            Area = area;
            Zipcode = zipcode;
            Earnings = 0;
            BikeDict = new Dictionary<Bike, int>();
        }

        public void AddBike(Bike bike, int quantity = 1)
        {
            if(BikeDict.ContainsKey(bike))
            {
                BikeDict[bike] = BikeDict[bike] + quantity;
            }
            else
            {
                BikeDict.Add(bike, quantity);
            }
        }

        public bool SellBike(Bike bike)
        {

            if (BikeDict.ContainsKey(bike))
            {
                if(BikeDict[bike] > 0)
                {
                    BikeDict[bike] = BikeDict[bike] - 1;
                    Earnings += bike.Price;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public string LookAtBike(Bike bike)
        {
            return bike.Description;
        }

        public void UpdateBike(Bike bike, string description = null, Decimal price = -1.0M)
        {
            if(BikeDict.ContainsKey(bike) && description != null && price >= 0.0M)
            {
                int originalStock = BikeDict[bike];
                BikeDict.Remove(bike);
                if (description != null)
                {
                    bike.Description = description;
                }
                if (price >= 0.0M)
                {
                    bike.Price = price;
                }
                BikeDict.Add(bike, originalStock);
            }
        }

        public bool RemoveBikeFromInventory(Bike bike)
        {
            if(BikeDict.ContainsKey(bike))
            {
                BikeDict.Remove(bike);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OrderBikesFromStorage(Bike bike, int quantity)
        {
            var bikeToAdd = Fjernlager.FillOrder(bike, quantity);
            
            if(BikeDict.ContainsKey(bikeToAdd.Key))
            {
                BikeDict[bikeToAdd.Key] += bikeToAdd.Value;
            }
            else
            {
                BikeDict.Add(bikeToAdd.Key, bikeToAdd.Value);
            }
        }


        
    }
}
