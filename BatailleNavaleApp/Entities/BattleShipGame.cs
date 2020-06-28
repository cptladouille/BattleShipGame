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
            Player2 = new Player(InputHandler.GetPlayerInput()) { Ships = InitPlayerShips() };
            var firstPlayer = ChooseFirstPlayer();
            var secondPlayer = firstPlayer == Player1 ? Player2 : Player1;
            Player1 = firstPlayer;
            Player2 = secondPlayer;
            Console.WriteLine(Player1.Name + " commence à jouer !");
            do
            {
                Player1.SetupPlayer();
            } while (!Player1.IsShipPlacementOk());
            do
            {
                Player2.SetupPlayer();
            } while (!Player2.IsShipPlacementOk());
            Console.WriteLine("La partie commence !");
        }



        public Player ChooseFirstPlayer()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Lancé de dés pour le choix du premier joueur !");
            Random rand = new Random();
            int newRand;
            newRand = rand.Next(2);
            return newRand == 0 ? Player1 : Player2;
        }

        public void PlayRound()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Le tour commence !");
            PlayPlayerTurn(Player1, Player2);
            Console.WriteLine(Environment.NewLine);
            if (!Player2.LostGame)
            {
                Console.WriteLine("C'est maintenant à " + Player2.Name + " de jouer");
                PlayPlayerTurn(Player2, Player1);
            }
            else
            {
                Console.WriteLine(Player2.Name + " n'a plus de bateau pour jouer");
            }
            Console.WriteLine("Fin du tour !");
            Console.WriteLine(Environment.NewLine);

        }

        public void PlayPlayerTurn(Player player1, Player player2)
        {
            Console.WriteLine("C'est à " + player1.Name + " de jouer");
            Console.WriteLine(player1.BuildGameBoard());
            BoardCoordinates shootedCoordinates;
            do
            {
                BoardCoordinates fireCoordinates;
                do
                {
                    Console.WriteLine(player1.Name + ", entrez vos coordonnées de tir");
                    fireCoordinates = BoardCoordinates.Parse(InputHandler.GetPlayerInput());
                } while (fireCoordinates == null);
                shootedCoordinates = player1.CheckFireCoordinates(fireCoordinates);
            } while (shootedCoordinates == null);
            var shotResult = player2.ReactToShot(shootedCoordinates);
            player1.UpdateBoardWithShotResult(shotResult, shootedCoordinates);
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
