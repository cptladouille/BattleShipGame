using System;
using System.Collections.Generic;
using System.Text;

namespace BatailleNavaleApp.Factories
{
    public class AircraftCarrierFactory : ShipFactory
    {
        public override Ship GetShip()
        {
            return new AircraftCarrier();
        }
    }
}
