using BatailleNavaleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BatailleNavaleApp.Entities
{
    public class ShipFactory : IShipFactory
    {
        public ShipFactory()
        {
        }

        public List<Ship> InitPlayerShips()
        {
            List<Ship> ships = new List<Ship>()
            {
                new Cruiser(),
                new AircraftCarrier(),
                new TorpedoBoat(),
                new CounterTorpedo(),
                new CounterTorpedo()
            };
            return ships;
        }
    }

    public class Cruiser : Ship
    {
        public Cruiser()
        {
            this.Name = "Croiseur";
            this.Size = 4;
            this.ShipType = ShipType.CRUISER;
        }
    }

    public class AircraftCarrier : Ship
    {
        public AircraftCarrier()
        {
            this.Name = "Porte-Avions";
            this.Size = 5;
            this.ShipType = ShipType.AICRAFT_CARRIER;
        }
    }
    public class CounterTorpedo : Ship
    {
        public CounterTorpedo()
        {
            this.Name = "Contre-Torpilleur";
            this.Size = 3;
            this.ShipType = ShipType.COUNTER_TORPEDO;
        }
    }
    public class TorpedoBoat : Ship
    {
        public TorpedoBoat()
        {
            this.Name = "Torpilleur";
            this.Size = 2;
            this.ShipType = ShipType.TORPEDO_BOAT;
        }
    }

}
