using BatailleNavaleApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BatailleNavaleApp.Handlers
{
    public static class InputHandler
    {
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
    }
}
