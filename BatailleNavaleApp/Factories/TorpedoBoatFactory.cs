using System;
using System.Collections.Generic;
using System.Text;

namespace BatailleNavaleApp.Factories
{
    public class TorpedoBoatFactory : ShipFactory
    {
        public override Ship GetShip()
        {
            return new TorpedoBoat();
        }
    }
}
