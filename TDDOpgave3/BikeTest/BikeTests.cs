using NUnit.Framework;
using BikeLibrary;

namespace BikeTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateBikeTest()
        {
            Bike bike = new Bike(2, "HurtigDrengen", "Lynet", "Gul", 19999.99M, "En meget hurtig cykel!");
            BikeShop bs = new BikeShop("TestShop", "TestArea", 0000);
            bs.AddBike(bike);

            Assert.That(bs.BikeDict.ContainsKey(bike));
        }

        [Test]
        public void ReadBikeTest()
        {
            Bike bike = new Bike(2, "TestBike", "TestFirma", "Gul", 19999.99M, "En test cykel!");
            BikeShop bs = new BikeShop("TestShop", "TestArea", 0000);
            bs.AddBike(bike);

            Assert.That(bs.BikeDict.ContainsKey(bike));
            Assert.NotNull(bs.LookAtBike(bike));
        }

        [Test]
        public void UpdateBikeTest()
        {
            Bike bike = new Bike(2, "TestBike", "TestFirma", "Gul", 19999.99M, "En test cykel!");
            Bike originalBike = new Bike(2, "TestBike", "TestFirma", "Gul", 19999.99M, "En test cykel!");
            BikeShop bs = new BikeShop("TestShop", "TestArea", 0000);
            bs.AddBike(bike);

            Assert.That(bs.BikeDict.ContainsKey(bike));
            bs.UpdateBike(bike, "Ny description!", 5.0M);

            Assert.That(bs.BikeDict.ContainsKey(bike));
            Assert.False(bs.BikeDict.ContainsKey(originalBike));
        }

        [Test]
        public void DeleteBikeTest()
        {

            Bike bike = new Bike(2, "TestBike", "TestFirma", "Gul", 19999.99M, "En test cykel!");
            BikeShop bs = new BikeShop("TestShop", "TestArea", 0000);
            bs.AddBike(bike);

            Assert.That(bs.BikeDict.ContainsKey(bike));

            bs.RemoveBikeFromInventory(bike);

            Assert.False(bs.BikeDict.ContainsKey(bike));
        }

        [Test]
        public void SellBikeTest()
        {

            Bike bike = new Bike(2, "TestBike", "TestFirma", "Gul", 19999.99M, "En test cykel!");
            BikeShop bs = new BikeShop("TestShop", "TestArea", 0000);
            bs.AddBike(bike);

            Assert.That(bs.BikeDict.ContainsKey(bike));

            bs.SellBike(bike);

            Assert.AreEqual(0, bs.BikeDict[bike]);
            Assert.AreEqual(bike.Price, bs.Earnings);

            int quantity = 100;
            bs.AddBike(bike, quantity);

            bs.SellBike(bike);
            Assert.AreEqual(quantity-1, bs.BikeDict[bike]);
            Assert.AreEqual(bike.Price * 2, bs.Earnings);
        }

        [Test]
        public void FjernlagerRestockTest()
        {
            Bike bike = new Bike(2, "TestBike", "TestFirma", "Gul", 19999.99M, "En test cykel!");
            int quantity = 10;
            if (Fjernlager.BikeDict.ContainsKey(bike))
            {
                quantity += Fjernlager.BikeDict[bike];
            }
            Fjernlager.AddToStock(bike, quantity);


            Assert.That(Fjernlager.BikeDict.ContainsKey(bike));
            Assert.AreEqual(Fjernlager.BikeDict[bike], quantity);

            Fjernlager.AddToStock(bike, 5);

            Assert.AreEqual(Fjernlager.BikeDict[bike], quantity + 5);
        }

        [Test]
        public void FjernlagerOrderTest()
        {

            Bike bike = new Bike(2, "TestBike", "TestFirma", "Gul", 19999.99M, "En test cykel!");
            BikeShop bs = new BikeShop("TestShop", "TestArea", 0000);

            Fjernlager.AddToStock(bike, 10);

            Assert.False(bs.BikeDict.ContainsKey(bike));

            bs.OrderBikesFromStorage(bike, 10);

            Assert.That(bs.BikeDict.ContainsKey(bike));

            Assert.AreEqual(10, bs.BikeDict[bike]);
        }
    }
}