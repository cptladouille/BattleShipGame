using System.Collections.Generic;

namespace BatailleNavaleApp.Factories
{
    public abstract class ShipFactory
    {
        public ShipFactory()
        {
        }

        public abstract Ship GetShip();

    }
}
