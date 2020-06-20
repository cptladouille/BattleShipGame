using BatailleNavaleApp.Entities;
using BatailleNavaleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BatailleNavaleApp
{
    public class Ship : IShip
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public ShipType ShipType { get; set; }
        public int Damages { get; set; }
        public Ship() { }
        public void PromptSize()
        {
            Console.WriteLine("Le " + Name + " mesure " + Size + " cellules de longueur");
        }
        public bool IsDestroyed()
        {
            return Damages >= Size;         
        }
    }

}
