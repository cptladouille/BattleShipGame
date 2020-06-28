
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
