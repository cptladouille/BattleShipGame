using BatailleNavaleApp.Enums;
using BatailleNavaleApp.Extensions;
using BatailleNavaleApp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public Player()
        {
            Ships = new List<Ship>();
            ResetGameBoards();
        }


        public Player(string name)
        {

            Ships = new List<Ship>();
            this.Name = name;
            ResetGameBoards();
        }
        public bool IsShipPlacementOk()
        {
            string input;
            do
            {
                Console.Write(Name + " êtes vous satisfait de votre placement ? y/n : ");
                input = InputHandler.GetPlayerInput();
            } while (input != "y" && input != "n");
            return input == "y";

        }

        public void ResetGameBoards()
        {
            PersonnalBoardGame = new BoardGame();
            PersonnalBoardGame.InitBoardGame();
            EnnemyBoardGame = new BoardGame();
            EnnemyBoardGame.InitBoardGame();
        }

        public void SetupPlayer()
        {
            foreach (var playerShip in Ships)
            {
                bool isShipPlaced;
                do
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine(Name + " placez votre " + playerShip.Name);
                    Console.WriteLine(playerShip.GetSizeToShow());
                    BoardCoordinates bc1, bc2;
                    do
                    {
                        Console.WriteLine("Quelles sont les coordonnées de l'avant du " + playerShip.Name + " ? (ex -> A5)");
                        bc1 = BoardCoordinates.Parse(InputHandler.GetPlayerInput());
                    } while (bc1 == null);
                    Console.Write(Environment.NewLine);
                    do
                    {
                        Console.WriteLine("Quelles sont les coordonnées de l'arrière du " + playerShip.Name + " ? (ex -> C5)");
                        bc2 = BoardCoordinates.Parse(InputHandler.GetPlayerInput());
                    } while (bc2 == null); 
                    isShipPlaced = PlaceShip(playerShip, bc1, bc2);
                }
                while (!isShipPlaced);
            }
            Console.WriteLine(BuildGameBoard());
        }


        public string BuildGameBoard()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Environment.NewLine);
            sb.AppendLine(Name);
            sb.AppendLine("|--|--------------------|--|---------------------|");
            sb.AppendLine("|  |   Votre plateau :  |  |   Plateau ennemi :  |");
            sb.AppendLine("|--|--------------------|--|---------------------|");
            sb.AppendLine("|  |A B C D E F G H I J |  | A B C D E F G H I J |");
            sb.AppendLine("|--|--------------------|--|---------------------|");
            for (int row = 1; row <= PersonnalBoardGame.Length; row++)
            {
                if (row != 10)
                {
                    sb.Append("|" + row + " |");
                }
                else
                {
                    sb.Append("|" + row + "|");
                }
                for (int playerCol = 1; playerCol <= PersonnalBoardGame.Width; playerCol++)
                {
                    sb.Append(PersonnalBoardGame.Cells.At(playerCol, row).OccupantDescription + " ");
                }
                if (row != 10)
                {
                    sb.Append("|" + row + " | ");
                }
                else
                {
                    sb.Append("|" + row + "| ");
                }
                for (int enemyCol = 1; enemyCol <= EnnemyBoardGame.Width; enemyCol++)
                {
                    sb.Append(EnnemyBoardGame.Cells.At(enemyCol, row).OccupantDescription + " ");
                }
                sb.AppendLine("|");
                sb.AppendLine("|--|--------------------|--|---------------------| ");
            }
           sb.AppendLine(Environment.NewLine);
            return sb.ToString();
        }

        public BoardCoordinates CheckFireCoordinates(BoardCoordinates fireCoordinates)
        {
            if (EnnemyBoardGame.Cells.At(fireCoordinates).IsAlreadyShot)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("ERREUR : vous avez déja tiré ici !");
                return null;
            }
            Console.WriteLine(Environment.NewLine);
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
            Console.WriteLine(Environment.NewLine);
            return ShipType.HITTED;
        }

        public void UpdateBoardWithShotResult(ShipType shotResult, BoardCoordinates fireCoordinates)
        {
            this.EnnemyBoardGame.Cells.At(fireCoordinates).CellOccupant = shotResult;
        }

        public bool PlaceShip(Ship playerShip, BoardCoordinates startCoordinate, BoardCoordinates endCoordinate)
        {
            Console.Write(Environment.NewLine);
            if (!PersonnalBoardGame.Cells.At(startCoordinate).IsOccupied)
            {
                if (!PersonnalBoardGame.Cells.At(endCoordinate).IsOccupied)
                {
                    return PersonnalBoardGame.PlaceShipAtCoordinates(playerShip, startCoordinate, endCoordinate);
                }
                else
                {
                    Console.WriteLine("ERREUR : La cellule " + startCoordinate.Coordinates + " est déja occupée");
                }
            }
            else
            {
                Console.WriteLine("ERREUR : La cellule " + endCoordinate.Coordinates + " est déja occupée");
            }
            return false;
        }
    }
}
