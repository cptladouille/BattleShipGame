using BatailleNavaleApp.Entities;
using System;

namespace BatailleNavaleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleShipGame game = new BattleShipGame(new ShipFactory());
            game.PlayGame();
        }
    }
}
