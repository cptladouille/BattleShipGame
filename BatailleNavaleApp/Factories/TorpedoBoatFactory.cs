
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
