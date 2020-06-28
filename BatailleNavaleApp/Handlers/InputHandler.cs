using BatailleNavaleApp.Enums;
using System;
using System.Collections.Generic;

namespace BatailleNavaleApp.Handlers
{
    public static class InputHandler
    {
        private static readonly List<ConsoleKey> PauseKeys = new List<ConsoleKey>() { ConsoleKey.Enter, ConsoleKey.S, ConsoleKey.Escape };
        private static readonly List<ConsoleKey> MainMenuKeys = new List<ConsoleKey>() { ConsoleKey.Enter, ConsoleKey.C, ConsoleKey.Escape,ConsoleKey.D };
        public static string GetPlayerInput()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Saisie incorrecte, Veuillez recommencer : ");
                input = Console.ReadLine();
            }
            input = input.Replace(" ", "");
            return input;
        }

        public static int GetLoadGameInput()
        {
            int inputNumber;
            do {
                var input = GetPlayerInput();
                int.TryParse(input, out inputNumber);
            }
            while (inputNumber == -1);
            return inputNumber;
        }

        public static ConsoleKey GetMenuInput(MenuType menu)
        {
            ConsoleKey input;
            List<ConsoleKey> possibleInputs;
            if (menu == MenuType.MAIN)
            {
                possibleInputs = MainMenuKeys;
            }
            else
            {
                possibleInputs = PauseKeys;
            }
            do
            {
                Console.WriteLine("Sélectionnez une option selon les touches affichées");
                input = Console.ReadKey().Key;
            }
            while (!possibleInputs.Contains(input));
            return input;
        }

    }
}
