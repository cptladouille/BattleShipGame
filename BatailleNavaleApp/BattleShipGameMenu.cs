using BatailleNavaleApp.Contexts;
using BatailleNavaleApp.Entities;
using BatailleNavaleApp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatailleNavaleApp
{
    public class BattleShipGameMenu
    {
        public static void ShowMainMenu()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("BIENVENUE DANS UN JEU DE BATAILLE NAVALE QUELCONQUE");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("--------------- Auteur : Mouttet Rémy -------------");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("----------------- MENU PRINCIPAL ------------------");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("---------------- enter : Nouvelle partie ----------");
            Console.WriteLine("-------------------- C : Charger une partie -------");
            Console.WriteLine("---------------- echap : Quitter ------------------");
            Console.WriteLine("---------------------------------------------------");
        }
        public static void ShowPauseMenu()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("------------------- JEU EN PAUSE ------------------");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("------------------ MENU DE PAUSE ------------------");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("--------------- entrer : Continuer ----------------");
            Console.WriteLine("-------------------- S : Sauvegarder --------------");
            Console.WriteLine("---------------- echap : Quitter ------------------");
            Console.WriteLine("---------------------------------------------------");
        }
    }
}
