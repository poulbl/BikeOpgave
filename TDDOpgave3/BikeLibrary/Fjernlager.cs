using System;
using System.Collections.Generic;
using System.Text;

namespace BikeLibrary
{
    public static class Fjernlager
    {
        public static Dictionary<Bike, int> BikeDict = new Dictionary<Bike, int>();

        public static KeyValuePair<Bike, int> FillOrder(Bike bike, int quantity)
        {
            KeyValuePair<Bike, int> kvp = new KeyValuePair<Bike, int>(bike, quantity);

            if(BikeDict.ContainsKey(bike))
            {
                if(BikeDict[bike] >= quantity)
                {
                    return kvp;
                }
                else
                {
                    return new KeyValuePair<Bike, int>(bike, 0);++
                }
            }

            else
            {
                return new KeyValuePair<Bike, int>(bike, 0);
            }
        }

        public static void AddToStock(Bike bike, int quantity)
        {
            if(BikeDict.ContainsKey(bike))
            {
                BikeDict[bike] += quantity;
            }
            else
            {
                BikeDict.Add(bike, quantity);
            }
        }
    }
}
