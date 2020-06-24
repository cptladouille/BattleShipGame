using BatailleNavaleApp.Enums;
using BatailleNavaleApp.Extensions;
using System;
using System.Collections.Generic;

namespace BatailleNavaleApp.Entities
{
    public class BoardGame : BaseEntity {
        public int Width = 10;
        public int Length = 10;
        public List<BoardCell> Cells { get; set; }

        public void InitBoardGame()
        {
            this.Cells = new List<BoardCell>();
            for (int column = 1; column <= Width; column++)
            {
                for (int rows = 1; rows <= Length; rows++)
                {
                    Cells.Add(new BoardCell() { BoardCoordinates = new BoardCoordinates(column, rows)});
                }
            }

        }

        public List<BoardCell> GetCellsBetween(BoardCell startCell, BoardCell endCell)
        {
            if (startCell.IsParallelWith(endCell))
            {
                List<BoardCell> cells = new List<BoardCell>() {};
                if (startCell.BoardCoordinates.x == endCell.BoardCoordinates.x)//If columns are the same
                {
                    if (startCell.BoardCoordinates.y < endCell.BoardCoordinates.y) //ex: A1 -> C1
                    {
                        for (int i = startCell.BoardCoordinates.y; i <= endCell.BoardCoordinates.y; i++)
                        {
                            cells.Add(Cells.At(startCell.BoardCoordinates.x, i));
                        }
                    }else //ex: C1 -> A1
                    {
                        for (int i = startCell.BoardCoordinates.y; i >= endCell.BoardCoordinates.y; i--)
                        {
                            cells.Add(Cells.At(startCell.BoardCoordinates.x, i));
                        }
                    }
                }else//rows are the same
                {
                    if (startCell.BoardCoordinates.x < endCell.BoardCoordinates.x) //ex: A1 -> A3
                    {
                        for (int i = startCell.BoardCoordinates.x; i <= endCell.BoardCoordinates.x; i++)
                        {
                            cells.Add(Cells.At(i,startCell.BoardCoordinates.y));
                        }
                    }else //ex: A3 -> A1
                    {
                        for (int i = startCell.BoardCoordinates.x; i >= endCell.BoardCoordinates.x; i--)
                        {
                            cells.Add(Cells.At(i,startCell.BoardCoordinates.y));
                        }
                    }
                }
                return cells;
            }                
            Console.WriteLine("Erreur : les coordonnées ne sont pas parallèles");
            return null;
        }

        public bool PlaceShipAtCoordinates(Ship ship, BoardCoordinates startCoordinates, BoardCoordinates endCoordinates)
        {
            var cellsBetweenCoordinates = GetCellsBetween(Cells.At(startCoordinates), Cells.At(endCoordinates));
            if (cellsBetweenCoordinates != null)
            {
                if (ship.Size == cellsBetweenCoordinates.Count)
                {
                    List<BoardCell> affectedCells = new List<BoardCell>();
                   foreach(var cell in cellsBetweenCoordinates)
                    {
                        if(!cell.IsOccupied)
                        {
                            cell.CellOccupant = ship.ShipType;
                            affectedCells.Add(cell);
                        }
                        else
                        {
                            Console.WriteLine("Un autre bateau est déja sur la cellule " + cell.BoardCoordinates.Coordinates);
                            foreach(var affectedCell in affectedCells)//rollback on affected cells
                            {
                                affectedCell.CellOccupant = ShipType.NONE;
                            }
                            return false;
                        }
                    }
                   if(affectedCells.Count == ship.Size)
                    {
                        ship.OccupedCells = affectedCells;
                        return true;
                    }
                } else if (ship.Size > cellsBetweenCoordinates.Count)
                {
                    Console.WriteLine("Les coordonnées entrées sont trop courtes");
                }else
                {
                    Console.WriteLine("Les coordonnées entrées sont trop longues");
                }
            }
            return false;
        }


    }
}
