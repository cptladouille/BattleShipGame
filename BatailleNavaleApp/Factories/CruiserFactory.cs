using System;
using System.Collections.Generic;
using System.Text;

namespace BatailleNavaleApp.Factories
{
    public class CruiserFactory : ShipFactory
    {
        public override Ship GetShip()
        {
            return new Cruiser();
        }
    }
}
