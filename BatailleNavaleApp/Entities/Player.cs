using BatailleNavaleApp.Extensions;
using BatailleNavaleApp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatailleNavaleApp.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public BoardGame PersonnalBoardGame { get; set; }
        public BoardGame EnnemyBoardGame { get; set; }
        bool LostGame
        {
            get
            {
                return Ships.All(ship => ship.IsDestroyed());
            }
        }
        public List<Ship> Ships { get; set; }

        public Player(string name, List<Ship> ships)
        {
            this.Name = name;
            this.Ships = ships;
            this.PersonnalBoardGame = new BoardGame();
            this.EnnemyBoardGame = new BoardGame();
        }

        public void ShowGameBoard()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Votre plateau :      | Plateau ennemi :");
            for (int row = 1; row < 10; row++)
            {
                for (int playerCol = 1; playerCol <= 10; playerCol++)
                {
                    Console.Write(PersonnalBoardGame.Cells.At(row, playerCol).OccupantDescription + " ");
                }
                Console.Write(" | ");
                for (int enemyCol = 1; enemyCol <= 10; enemyCol++)
                {
                    Console.Write(EnnemyBoardGame.Cells.At(row, enemyCol).OccupantDescription + " ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        public void PlaceShips()
        {
            foreach (var playerShip in Ships)
            {
                Console.WriteLine(Name + " placez votre " + playerShip.Name);

                BoardCoordinates startCoordinate;
                BoardCoordinates endCoordinate;
                do
                {
                    playerShip.PromptSize();
                    bool validStartCoordinate = false;
                    bool validEndCoordinate = false;
                    do
                    {
                        do
                        {
                            Console.WriteLine("Saisissez les coordonnées de l'avant du bateau (ex -> A5) : ");
                            startCoordinate = BoardCoordinates.Parse(InputHandler.GetPlayerInput());
                        } while (startCoordinate == null);
                        if (PersonnalBoardGame.Cells.At(startCoordinate).IsOccupied())
                        {
                            Console.WriteLine("ERREUR : La cellule " + startCoordinate.Coordinates + " est déja occupée");
                        }
                        else
                        {
                            validStartCoordinate = true;
                        }
                    } while (!validStartCoordinate);
                    do
                    {
                        do
                        {
                            Console.WriteLine("Saisissez les coordonnées de l'arrière (ex -> C5) : ");
                            endCoordinate = BoardCoordinates.Parse(InputHandler.GetPlayerInput());
                        } while (endCoordinate == null);
                        if (PersonnalBoardGame.Cells.At(endCoordinate).IsOccupied())
                        {
                            Console.WriteLine("ERREUR : La cellule " + endCoordinate.Coordinates + " est déja occupée");
                        }
                        else
                        {
                            validEndCoordinate = true;
                        }

                    } while (!validEndCoordinate);
                }
                while (!PersonnalBoardGame.PlaceShipAtCoordinates(playerShip, startCoordinate, endCoordinate));
            }
        }


    }
}
