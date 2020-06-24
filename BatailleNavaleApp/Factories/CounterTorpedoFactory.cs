using System;
using System.Collections.Generic;
using System.Text;

namespace BatailleNavaleApp.Factories
{
    public class CounterTorpedoFactory : ShipFactory
    {
        public override Ship GetShip()
        {
            return new CounterTorpedo();
        }
    }
}
