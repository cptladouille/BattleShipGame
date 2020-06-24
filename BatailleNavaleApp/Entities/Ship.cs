using BatailleNavaleApp.Entities;
using BatailleNavaleApp.Enums;
using System;
using System.Collections.Generic;

namespace BatailleNavaleApp
{
    public class Ship : BaseEntity {
        public string Name { get; set; }
        public int Size { get; set; }
        public ShipType ShipType { get; set; }
        public int Damages { get; set; }
        public List<BoardCell> OccupedCells { get; set; }
        public Ship()
        {
            this.OccupedCells = new List<BoardCell>();
        }

        public void PromptSize()
        {
            Console.WriteLine("Le " + Name + " mesure " + Size + " cellules de longueur");
        }
        public bool IsDestroyed
        {
            get
            {
                return Damages >= Size;
            }
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
