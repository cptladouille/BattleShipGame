using BatailleNavaleApp;
using BatailleNavaleApp.Factories;
using Xunit;

namespace BatailleNavaleAppTest.UnitTests
{
    public class ShipTests
    {
        private readonly Ship _ship;

        public ShipTests()
        {
            _ship = new Ship();
        }

        [Fact]
        public void GetSizeToShow_With_3_Size_length_TorpedoBoat_Should_Return_string()
        {
            Ship ship = new TorpedoBoat();

            var res = ship.GetSizeToShow();

            Assert.IsType<string>(res);
        }

        [Fact]
        public void GetSizeToShow_With_3_Size_length_TorpedoBoat_Should_Return_string_With_Size_And_Name()
        {
            Ship ship = new TorpedoBoat();
            string expectedString = "Le Torpilleur mesure 2 cellules de longueur\r\n";

            var res = ship.GetSizeToShow();

            Assert.Equal(expectedString, res);
        }
        [Fact]
        public void IsDestroyed_With_Intact_AircraftCarrier_Should_Return_False()
        {
            Ship ship = new AircraftCarrier();

            var res = ship.IsDestroyed;

            Assert.False(res);
        }
        [Fact]
        public void IsDestroyed_With_Destroyed_AircraftCarrier_Should_Return_True()
        {
            Ship ship = new AircraftCarrier() { Damages = 5 };

            var res = ship.IsDestroyed;

            Assert.True(res);
        }

        [Fact]
        public void GetShip_From_ShipFactory_Of_Type_AircraftCarrier_Should_Return_Ship_OfType_AircraftCarrier()
        {
            ShipFactory factory = new AircraftCarrierFactory();

            var res = factory.GetShip();

            Assert.IsType<AircraftCarrier>(res);
        }

        [Fact]
        public void GetShip_From_ShipFactory_Of_Type_AircraftCarrier_Should_Return_new_AircraftCarrier()
        {
            ShipFactory factory = new AircraftCarrierFactory();
            AircraftCarrier newShip = new AircraftCarrier();

            var res = factory.GetShip();

            Assert.True(res.Name == newShip.Name && res.Size == newShip.Size && res.ShipType == newShip.ShipType);
        }

        [Fact]
        public void GetShip_From_ShipFactory_Of_Type_TorpedoBoat_Should_Return_Ship_OfType_TorpedoBoat()
        {
            ShipFactory factory = new TorpedoBoatFactory();

            var res = factory.GetShip();

            Assert.IsType<TorpedoBoat>(res);
        }

        [Fact]
        public void GetShip_From_ShipFactory_Of_Type_TorpedoBoat_Should_Return_new_TorpedoBoat()
        {
            ShipFactory factory = new TorpedoBoatFactory();
            TorpedoBoat newShip = new TorpedoBoat();

            var res = factory.GetShip();

            Assert.True(res.Name == newShip.Name && res.Size == newShip.Size && res.ShipType == newShip.ShipType);
        }
        [Fact]
        public void GetShip_From_ShipFactory_Of_Type_Cruiser_Should_Return_Ship_OfType_Cruiser()
        {
            ShipFactory factory = new CruiserFactory();

            var res = factory.GetShip();

            Assert.IsType<Cruiser>(res);
        }

        [Fact]
        public void GetShip_From_ShipFactory_Of_Type_Cruiser_Should_Return_new_Cruiser()
        {
            ShipFactory factory = new CruiserFactory();
            Cruiser newShip = new Cruiser();

            var res = factory.GetShip();

            Assert.True(res.Name == newShip.Name && res.Size == newShip.Size && res.ShipType == newShip.ShipType);
        }
        [Fact]
        public void GetShip_From_ShipFactory_Of_Type_CounterTorpedo_Should_Return_Ship_OfType_CounterTorpedo()
        {
            ShipFactory factory = new CounterTorpedoFactory();

            var res = factory.GetShip();

            Assert.IsType<CounterTorpedo>(res);
        }

        [Fact]
        public void GetShip_From_ShipFactory_Of_Type_CounterTorpedo_Should_Return_new_CounterTorpedo()
        {
            ShipFactory factory = new CounterTorpedoFactory();
            CounterTorpedo newShip = new CounterTorpedo();

            var res = factory.GetShip();

            Assert.True(res.Name == newShip.Name && res.Size == newShip.Size && res.ShipType == newShip.ShipType);
        }


    }
}
