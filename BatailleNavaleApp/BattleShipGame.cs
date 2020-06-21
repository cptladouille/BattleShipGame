using BatailleNavaleApp.Entities;
using BatailleNavaleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BatailleNavaleApp.Handlers;
namespace BatailleNavaleApp
{
    public class BattleShipGame
    {
        Player Player1 { get; set; }
        Player Player2 { get; set; }
        private IShipFactory _shipFactory { get; set; }


        public BattleShipGame(IShipFactory shipFactory)
        {
            this._shipFactory = shipFactory;
        }


        public void SetupGame()
        {
            Console.Write("Joueur 1 : Saisissez votre nom : ");
            Player1 = new Player(InputHandler.GetPlayerInput(), _shipFactory.InitPlayerShips());
            Console.Write("Joueur 2 : Saisissez votre nom : ");
            Player2 = new Player(InputHandler.GetPlayerInput(), _shipFactory.InitPlayerShips());
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

        public void PlayGame()
        {
            SetupGame();
            Console.WriteLine("La partie commence !");

            while (!Player1.LostGame && !Player2.LostGame)
            {
                PlayRound();
            }
            if (Player1.LostGame)
            {
                Console.WriteLine(Player2.Name + " a gagné la partie, BRAVO !");
            }
            else
            {
                Console.WriteLine(Player1.Name + " a gagné la partie, BRAVO !");
            }
        }
    }
}
