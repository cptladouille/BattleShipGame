using System;
using BatailleNavaleApp.Handlers;
using BatailleNavaleApp.Factories;
using System.Collections.Generic;

namespace BatailleNavaleApp.Entities
{
    public class BattleShipGame : BaseEntity
    {

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public void SetupGame()
        {
            Console.Write("Joueur 1 : Saisissez votre nom : ");
            Player1 = new Player(InputHandler.GetPlayerInput()) { Ships = InitPlayerShips() };
            Console.Write("Joueur 2 : Saisissez votre nom : ");
            Player2 =new Player(InputHandler.GetPlayerInput()) { Ships = InitPlayerShips() };

            var firstPlayer = ChooseFirstPlayer();
            var secondPlayer = firstPlayer == Player1 ? Player2 : Player1;

            Player1 = firstPlayer;
            Player2 = secondPlayer; 

            do
            {
                Player1.ResetGameBoards();
                Player1.PlaceShips();
                Player1.ShowGameBoard();
            } while (!Player1.IsShipPlacementOk());
            do
            {
                Player2.ResetGameBoards();
                Player2.PlaceShips();
                Player2.ShowGameBoard();
            } while (!Player2.IsShipPlacementOk());
            Console.WriteLine("La partie commence !");
        }



       public Player ChooseFirstPlayer()
       {
            Random rand = new Random();
            int newRand = 0;
            for(int i = 0; i < 3; i++)
            {
                newRand = rand.Next(1);
            }
            return newRand == 0 ? Player1 : Player2;
       }


        public void PlayRound()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Le tour commence !");
            Console.WriteLine("C'est à " + Player1.Name + " de jouer");
            Player1.ShowGameBoard();
            var fireCoordinates = Player1.Shot();
            var shotResult = Player2.ReactToShot(fireCoordinates);
            Player1.ReactToShotResult(shotResult, fireCoordinates);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("C'est maintenant à " + Player2.Name+ " de jouer");
            Player2.ShowGameBoard();
            fireCoordinates = Player2.Shot();
            shotResult = Player1.ReactToShot(fireCoordinates);
            Player2.ReactToShotResult(shotResult, fireCoordinates);
            Console.WriteLine("Fin du tour !");
            Console.WriteLine(Environment.NewLine);
        }

        
        public List<Ship> InitPlayerShips()
        {
            ShipFactory cruiserFactory = new CruiserFactory();
            ShipFactory aircraftCarrierFactory = new AircraftCarrierFactory();
            ShipFactory torpedoBoatFactory = new TorpedoBoatFactory();
            ShipFactory counterTorpedoFactory = new CounterTorpedoFactory();
            List<Ship> ships = new List<Ship>()
            {
                cruiserFactory.GetShip(),
                counterTorpedoFactory.GetShip(),
                counterTorpedoFactory.GetShip(),
                aircraftCarrierFactory.GetShip(),
                torpedoBoatFactory.GetShip()
            };
            return ships;
        }
    }
}
