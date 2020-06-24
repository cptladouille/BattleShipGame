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
            string input;
            do
            {
                Player1.PlaceShips();
                Player1.ShowGameBoard();
                do
                {
                    Console.Write("Êtes vous satisfait de votre placement ? y/n : ");
                    input = InputHandler.GetPlayerInput();
                } while (input != "y" && input != "n");

            } while (input != "y");
            do
            {
                Player2.PlaceShips();
                Player2.ShowGameBoard();
                do
                {
                    Console.Write("Êtes vous satisfait de votre placement ? y/n : ");
                    input = InputHandler.GetPlayerInput();
                } while (input != "y" && input != "n");

            } while (input != "y");
            Console.WriteLine("La partie commence !");
        }

        


        public void PlayRound()
        {
            Console.WriteLine("Au tour de " + Player1.Name);
            Player1.ShowGameBoard();
            var fireCoordinates = Player1.Shot();
            var shotResult = Player2.ReactToShot(fireCoordinates);
            Player1.ReactToShotResult(shotResult, fireCoordinates);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Au tour de " + Player2.Name);
            Player2.ShowGameBoard();
            fireCoordinates = Player2.Shot();
            shotResult = Player1.ReactToShot(fireCoordinates);
            Player2.ReactToShotResult(shotResult, fireCoordinates);
            Console.WriteLine(Environment.NewLine);
        }

        
        public List<Ship> InitPlayerShips()
        {
            ShipFactory cruiserFactory = new CruiserFactory();
            ShipFactory aircraftCarrierFactory = new AircraftCarrierFactory();
            ShipFactory torpedoBoatFactory = new TorpedoBoatFactory();
            ShipFactory counterTorpedoFactory = new TorpedoBoatFactory();
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
