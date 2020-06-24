using BatailleNavaleApp.Enums;
using BatailleNavaleApp.Extensions;
using BatailleNavaleApp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BatailleNavaleApp.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public BoardGame PersonnalBoardGame { get; set; }
        public BoardGame EnnemyBoardGame { get; set; }
        public bool LostGame
        {
            get
            {
                return Ships.All(ship => ship.IsDestroyed);
            }
        }
        public List<Ship> Ships { get; set; }

        public Player(string name)
        {
            this.Name = name;
            this.PersonnalBoardGame = new BoardGame();
            this.EnnemyBoardGame = new BoardGame();
        }

        public void ShowGameBoard()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine(Name);
            Console.WriteLine("|--|--------------------|--|---------------------|");
            Console.WriteLine("|  |   Votre plateau :  |  |   Plateau ennemi :  |");
            Console.WriteLine("|--|--------------------|--|---------------------|");
            Console.WriteLine("|  |A B C D E F G H I J |  | A B C D E F G H I J |");
            Console.WriteLine("|--|--------------------|--|---------------------|");
            for (int row = 1; row <= PersonnalBoardGame.Length; row++)
            {
                if (row != 10)
                {
                    Console.Write("|" + row + " |");
                }
                else
                {
                    Console.Write("|" + row + "|");
                }
                for (int playerCol = 1; playerCol <= PersonnalBoardGame.Width; playerCol++)
                {
                    Console.Write(PersonnalBoardGame.Cells.At(row, playerCol).OccupantDescription + " ");
                }
                if (row != 10)
                {
                    Console.Write("|" + row + " | ");
                }
                else
                {
                    Console.Write("|" + row + "| ");
                }
                for (int enemyCol = 1; enemyCol <= EnnemyBoardGame.Width; enemyCol++)
                {
                    Console.Write(EnnemyBoardGame.Cells.At(row, enemyCol).OccupantDescription + " ");
                }
                Console.WriteLine("|");
                Console.WriteLine("|--|--------------------|--|---------------------| ");
            }
            Console.WriteLine(Environment.NewLine);
        }

        public BoardCoordinates Shot()
        {
            Console.Write(Environment.NewLine);
            bool shotFired = false;
            BoardCoordinates fireCoordinates;
            do
            {
                Console.WriteLine(Name + ", entrez vos coordonnées de tir");
                fireCoordinates = GetPlayerCoordinates();
                if (EnnemyBoardGame.Cells.At(fireCoordinates).IsAlreadyShot)
                {
                    Console.WriteLine("ERREUR : vous avez déja tiré ici !");
                }else
                {
                    shotFired = true;
                }
            } while (!shotFired);
            return fireCoordinates;
        }

        public ShipType ReactToShot(BoardCoordinates fireCoordinates)
        {
            var firedCell = PersonnalBoardGame.Cells.At(fireCoordinates);
            if (!firedCell.IsOccupied)
            {
                Console.WriteLine("|--|--------------------|--|---------------------| ");
                Console.WriteLine("                     Tir manqué !                 ");
                Console.WriteLine("|--|--------------------|--|---------------------| ");
                Console.WriteLine(Name + " n'a aucun bateau à ces coordonnées");
                return ShipType.MISSED;
            }
            Ship hittedShip = this.Ships.FirstOrDefault(ship => ship.OccupedCells.Contains(firedCell));
                Console.WriteLine("|--|--------------------|--|---------------------| ");
                Console.WriteLine("                       Touché !                  ");
                Console.WriteLine("|--|--------------------|--|---------------------| ");
            hittedShip.Damages++;
            if (hittedShip.IsDestroyed)
            {
                Console.WriteLine("|--|--------------------|--|---------------------| ");
                Console.WriteLine("                       Coulé !                  ");
                Console.WriteLine("|--|--------------------|--|---------------------| ");
            }
            return ShipType.HITTED;
        }

        public void ReactToShotResult(ShipType shotResult, BoardCoordinates fireCoordinates)
        {
            this.EnnemyBoardGame.Cells.At(fireCoordinates).CellOccupant = shotResult;
        }

        public BoardCoordinates GetPlayerCoordinates()
        {
            BoardCoordinates coordinates;
            do
            {
                Console.Write("Entrez les coordonnées : ");
                coordinates = BoardCoordinates.Parse(InputHandler.GetPlayerInput());
            } while (coordinates == null);
            return coordinates;
        }

        public void PlaceShips()
        {
            foreach (var playerShip in Ships)
            {
                Console.Write(Environment.NewLine);
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
                        Console.Write(Environment.NewLine);
                        Console.WriteLine("Quelles sont les coordonnées de l'avant du " + playerShip.Name + " ? (ex -> A5)");
                        startCoordinate = GetPlayerCoordinates();
                        if (PersonnalBoardGame.Cells.At(startCoordinate).IsOccupied)
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
                        Console.Write(Environment.NewLine);
                        Console.WriteLine("Quelles sont les coordonnées de l'arrière du " + playerShip.Name + " ? (ex -> C5)");
                        endCoordinate = GetPlayerCoordinates();
                        if (PersonnalBoardGame.Cells.At(endCoordinate).IsOccupied)
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
