using BatailleNavaleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatailleNavaleApp.Contexts
{
    public static class DataMapper
    {
        private static readonly BattleShipGameContext battleShipGameContext = new BattleShipGameContext();

        public static void SaveGame(BattleShipGame battleShipGame)
        {
            try
            {
                using var context = battleShipGameContext;
                context.BattleShipGames.Add(battleShipGame);
                context.SaveChanges();
                Console.WriteLine("Partie sauvgardée avec succès !");
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de sauvgarder la partie");
                Console.WriteLine(e.Message);
            }
        }

        public static IList<BattleShipGame> GetSavedGames()
        {
            try
            {
                using var context = battleShipGameContext;
                return context.BattleShipGames.ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine("Impossible de trouver les parties sauvgardées");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static BattleShipGame LoadGame(Guid battleShipGameGuid)
        {
            try
            {
                using var context = battleShipGameContext;
                return context.BattleShipGames
                     .Include(bsg => bsg.Player1)
                         .ThenInclude(p1 => p1.EnnemyBoardGame)
                             .ThenInclude(ebg => ebg.Cells)
                                 .ThenInclude(cell => cell.BoardCoordinates)
                     .Include(bsg => bsg.Player1)
                         .ThenInclude(p1 => p1.PersonnalBoardGame)
                             .ThenInclude(ebg => ebg.Cells)
                                 .ThenInclude(cell => cell.BoardCoordinates)
                     .Include(bsg => bsg.Player1)
                         .ThenInclude(p1 => p1.Ships)
                             .ThenInclude(ship => ship.OccupedCells)
                                 .ThenInclude(cell => cell.BoardCoordinates)
                     .Include(bsg => bsg.Player2)
                         .ThenInclude(p2 => p2.EnnemyBoardGame)
                             .ThenInclude(ebg => ebg.Cells)
                                 .ThenInclude(cell => cell.BoardCoordinates)
                     .Include(bsg => bsg.Player2)
                         .ThenInclude(p2 => p2.PersonnalBoardGame)
                             .ThenInclude(ebg => ebg.Cells)
                                 .ThenInclude(cell => cell.BoardCoordinates)
                     .Include(bsg => bsg.Player2)
                         .ThenInclude(p2 => p2.Ships)
                             .ThenInclude(ship => ship.OccupedCells)
                                 .ThenInclude(cell => cell.BoardCoordinates)
                     .FirstOrDefault(bsg => bsg.Id == battleShipGameGuid);
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de charger la partie");
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
