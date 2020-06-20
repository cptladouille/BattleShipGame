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
            Console.WriteLine("Joueur 1 : Saisissez votre nom");
            Player1 = new Player(InputHandler.GetPlayerInput(), _shipFactory.InitPlayerShips());
            Console.WriteLine("Joueur 2 : Saisissez votre nom");
            Player2 = new Player(InputHandler.GetPlayerInput(), _shipFactory.InitPlayerShips());
            string input;
            do{
                Player1.PlaceShips();
                Player1.ShowGameBoard();
                do {
                    Console.WriteLine("Êtes vous satisfait de votre placement ? y/n");
                    input = InputHandler.GetPlayerInput();
                } while (input != "y" && input != "n");

            } while (input != "y");
            do{
                Player2.PlaceShips();
                Player2.ShowGameBoard();
                do{
                    Console.WriteLine("Êtes vous satisfait de votre placement ? y/n");
                    input = InputHandler.GetPlayerInput();
                } while (input != "y" && input != "n");

            } while (input != "y");

            Console.ReadKey();
        }

        public void PlayRound()
        {

        }

        public void PlayGame()
        {
            SetupGame();
        }





    }
}
