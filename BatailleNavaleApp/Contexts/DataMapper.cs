using BatailleNavaleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BatailleNavaleApp.Contexts
{
    public class DataMapper
    {
        private readonly BattleShipGameContext battleShipGameContext = new BattleShipGameContext();

        public DataMapper()
        {
            battleShipGameContext.Database.Migrate();

        }
        /// <summary>
        /// Enregistre une partie avec tout ses objets référents
        /// </summary>
        /// <param name="toSave">Partie a sauvgarder</param>
        public void SaveGame(BattleShipGame toSave)
        {
            try
            {
                using var context = new BattleShipGameContext();
                context.Database.EnsureCreated();
                context.BattleShipGames.Add(toSave);
                context.SaveChanges();
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Partie sauvgardée avec succès !");
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de sauvegarder la partie");
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateGame(BattleShipGame toUpdate)
        {
            try
            {
                using var context = new BattleShipGameContext();
                context.Database.EnsureCreated();
                context.Update(toUpdate);
                context.SaveChanges();
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Partie sauvgardée avec succès !");
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de sauvegarder la partie");
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Charge toutes les parties sauvgardées avec leurs joueurs
        /// </summary>
        /// <returns>une List<BattleShipGame> contenant tout les BattleShipGame existants</returns>
        public IList<BattleShipGame> GetSavedGamesWithPlayers()
        {
            try
            {
                using var context = new BattleShipGameContext();
                context.Database.EnsureCreated();
                var res = context.BattleShipGames
                    .Include(bsg => bsg.Player1)
                    .Include(bsg => bsg.Player2)
                    .ToList();
                if (res.Count == 0)
                {
                    Console.WriteLine("Aucune partie n'a été trouvé ");
                }
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de récupérer les parties sauvgardées");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Supprime les données
        /// </summary>
        /// <returns>une List<BattleShipGame> contenant tout les BattleShipGame existants</returns>
        public bool DeleteGame(BattleShipGame toDelete)
        {
            try
            {
                using var context = new BattleShipGameContext();
                context.Database.EnsureCreated();
                context.Remove(toDelete);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de supprimer la partie");
                Console.WriteLine(e.Message);
                return false;
            }
        }



        /// <summary>
        /// Charge une partie spécifique grace a son Id
        /// </summary>
        /// <param name="battleShipGameGuid">Id de la partie à trouver</param>
        /// <returns>BattleShipGame existant possédant l'Id</returns>
        public BattleShipGame LoadGame(Guid battleShipGameGuid)
        {
            try
            {
                using var context = new BattleShipGameContext();
                context.Database.EnsureCreated();
                var res = context.BattleShipGames
                    .Include(bsg => bsg.Player1)
                    .Include(bsg => bsg.Player2)
                .FirstOrDefault(bsg => bsg.Id == battleShipGameGuid);
                res.Player1 = FetchPlayerDatas(res.Player1);
                res.Player2 = FetchPlayerDatas(res.Player2);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de charger la partie");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Récupère les données associées aaun joueur donné
        /// </summary>
        /// <param name="player">Joueur a hydrater</param>
        /// <returns>Player hydraté</returns>
        public Player FetchPlayerDatas(Player player)
        {
            try
            {
                using var context = new BattleShipGameContext();
                context.Database.EnsureCreated();
                var foundedPlayer = context.Players
                    .Include(p => p.Ships)
                    .Include(p => p.PersonnalBoardGame)
                        .ThenInclude(ebg => ebg.Cells)
                            .ThenInclude(cell => cell.BoardCoordinates)
                    .Include(p => p.EnnemyBoardGame)
                        .ThenInclude(ebg => ebg.Cells)
                            .ThenInclude(cell => cell.BoardCoordinates)
                    .FirstOrDefault(p => p.Id == player.Id);
                return foundedPlayer;
            }
            catch (Exception e)
            {
                Console.WriteLine("Impossible de charger le joueur " + player.Name);
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

