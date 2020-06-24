using BatailleNavaleApp.Contexts;
using BatailleNavaleApp.Entities;
using BatailleNavaleApp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatailleNavaleApp
{
    class GameLoop
    {
        public BattleShipGame bsg;

        public void InitGame()
        {
            BattleShipGame battleShipGame = null;
            do
            {
                ShowMainMenu();
                var input = InputHandler.GetPlayerInput();
                Console.WriteLine(Environment.NewLine);
                if (input == "1")
                {
                    battleShipGame = new BattleShipGame();
                    battleShipGame.SetupGame();
                }
                else if (input == "2")
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
        public void PlayGame()
        {
            Console.WriteLine("Pressez echap pour mettre le jeu en pause");
            while (!bsg.Player1.LostGame && !bsg.Player1.LostGame)
            {

                bsg.PlayRound();
                // FIN DU TOUR PROPOSER STOP GAME POUR AFFICHER MENU
                if (Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    PauseGame()                                }
            }
            if (bsg.Player1.LostGame)
            {
                Console.WriteLine(bsg.Player2.Name + " a gagné la partie, BRAVO !");
            }
            else if (bsg.Player2.LostGame)

            {
                Console.WriteLine(bsg.Player1.Name + " a gagné la partie, BRAVO !");
            }
        }

        public void PauseGame()
        {
            ShowPauseMenu();
            var input = InputHandler.GetPlayerInput();
            if (input == "1")
            {
                PlayGame();
            }
            else
            {
                DataMapper.SaveGame(bsg);
                Console.WriteLine("appuyez sur une touche pour quitter");
                Console.ReadKey();
                Environment.Exit(0);
            }



            public BattleShipGame GetGame()
            {
                BattleShipGame loadedGame = null;
                var savedGames = DataMapper.GetSavedGames();
                if (savedGames.Count > 0)
                {
                    Console.WriteLine("Des parties sauvgardées ont étés trouvées :");
                    foreach (var game in savedGames)
                    {
                        Console.WriteLine("Partie " + savedGames.IndexOf(game));
                    }
                    Console.WriteLine("Saisissez le numéro de la partie à charger ou appuyez sur 0 pour en lancer une nouvelle");
                    var input = InputHandler.GetPlayerInput();
                    int.TryParse(input, out int gameNumber);
                    ////////////////////////Vérif supplémentaires
                    if (gameNumber <= savedGames.Count() && gameNumber >= 1)
                    {
                        loadedGame = DataMapper.LoadGame(savedGames[gameNumber].Id);
                    }
                }
                Console.WriteLine(Environment.NewLine);
                return loadedGame;
            }
        }

    }
}
