using BatailleNavaleApp.Contexts;
using BatailleNavaleApp.Entities;
using BatailleNavaleApp.Enums;
using BatailleNavaleApp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatailleNavaleApp
{
    public class GameLoop
    {
        public BattleShipGame bsg;
        public bool IsGamePaused;
        public DataMapper dataMapper;

        public GameLoop()
        {
            dataMapper = new DataMapper();
        }
        public void InitGame()
        {
            BattleShipGame battleShipGame = null;
            do
            {
                BattleShipGameMenu.ShowMainMenu();
                var input = InputHandler.GetMenuInput(MenuType.MAIN);
                Console.WriteLine(Environment.NewLine);
                if (input == ConsoleKey.Enter)
                {
                    battleShipGame = new BattleShipGame();
                    battleShipGame.SetupGame();
                }
                else if (input == ConsoleKey.C)
                {
                    battleShipGame = GetGame();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            while (battleShipGame == null);
            bsg = battleShipGame;
            PlayGame();
        }

        /// <summary>
        /// Joue au jeu jusqu'à la fin ou la mise en pause
        /// </summary>
        public void PlayGame()
        {
            while (!bsg.Player1.LostGame && !bsg.Player2.LostGame && !IsGamePaused)
            {
                bsg.PlayRound();
                Console.WriteLine("Pressez echap pour mettre le jeu en pause, ou n'importe quelle autre touche pour passer au tour suivant");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    IsGamePaused = true;
                }
            }
            if (bsg.Player1.LostGame)
            {
                Console.WriteLine(bsg.Player2.Name + " a gagné la partie, BRAVO !");
            }
            else if (bsg.Player2.LostGame)

            {
                Console.WriteLine(bsg.Player1.Name + " a gagné la partie, BRAVO !");
            }
            PauseGame();
        }
        /// <summary>
        /// Mets en pause le jeu
        /// </summary>
        public void PauseGame()
        {
            BattleShipGameMenu.ShowPauseMenu();
            var input = InputHandler.GetMenuInput(MenuType.PAUSE);
            if (input == ConsoleKey.Enter)
            {
                PlayGame();
            }
            else if (input == ConsoleKey.S)
            {
                dataMapper.SaveGame(bsg);
            }
            else
            {
                Environment.Exit(0);
            }
            Console.WriteLine(Environment.NewLine);
        }

        /// <summary>
        /// Affiche les parties sauvgardées et charge celle selectionnée
        /// </summary>
        /// <returns></returns>
        public BattleShipGame GetGame()
        {
            BattleShipGame loadedGame = null;
            var savedGames = dataMapper.GetSavedGamesWithPlayers();
            if (savedGames != null && savedGames.Count > 0)
            {
                Console.WriteLine("Des parties sauvgardées ont étés trouvées :");
                foreach (var game in savedGames)
                {
                    Console.WriteLine("Partie " + (savedGames.IndexOf(game) + 1)+ " "+game.Player1.Name +" vs "+game.Player2.Name);
                }
                Console.WriteLine("Saisissez le numéro de la partie à charger ou 0 pour en lancer une nouvelle");
                var gameNumber = InputHandler.GetLoadGameInput();
                if (gameNumber <= savedGames.Count() && gameNumber >= 1)
                {
                    loadedGame = dataMapper.LoadGame(savedGames[gameNumber-1].Id);
                }
            }
            Console.WriteLine(Environment.NewLine);
            return loadedGame;
        }
    }
}

