using BatailleNavaleApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BatailleNavaleApp.Handlers
{
    public static class InputHandler
    {
        public static readonly List<string> Orientations = new List<string>() { "haut", "bas", "gauche", "droite" };
        public static string GetPlayerInput()
        {
                string input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Saisie incorrecte, vous devez saisir quelque chose");
                input = Console.ReadLine();
            }
            input = input.Replace(" ", "");
            return input;
        }
        public static int GetOrientation()
        {
            string input;
            do
            {
                Console.WriteLine("Saisissez l'orientation du bateau (haut/bas/gauche/droite) : ");
                input = GetPlayerInput();
            }
            while (!Orientations.Contains(input.ToLower()));
            return Orientations.IndexOf(input);
        }
    }
}
