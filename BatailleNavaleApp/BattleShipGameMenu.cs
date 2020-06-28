using System;
using System.Text;

namespace BatailleNavaleApp
{
    public class BattleShipGameMenu
    {
        public static string GetMainMenu()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Environment.NewLine);
            sb.AppendLine("---------------------------------------------------");
            sb.AppendLine("BIENVENUE DANS UN JEU DE BATAILLE NAVALE QUELCONQUE");
            sb.AppendLine("---------------------------------------------------");
            sb.AppendLine("--------------- Auteur : Mouttet Rémy -------------");
            sb.AppendLine("---------------------------------------------------");
            sb.AppendLine("----------------- MENU PRINCIPAL ------------------");
            sb.AppendLine("---------------------------------------------------");
            sb.AppendLine("---------------- enter : Nouvelle partie ----------");
            sb.AppendLine("-------------------- C : Charger une partie -------");
            sb.AppendLine("-------------------- D : Supprimer une partie -----");
            sb.AppendLine("---------------- echap : Quitter ------------------");
            sb.AppendLine("---------------------------------------------------");
            return sb.ToString();
        }
        public static string  GetPauseMenu()
        {
            var sb = new StringBuilder();
            sb.AppendLine("---------------------------------------------------");
            sb.AppendLine("------------------- JEU EN PAUSE ------------------");
            sb.AppendLine("---------------------------------------------------");
            sb.AppendLine("------------------ MENU DE PAUSE ------------------");
            sb.AppendLine("---------------------------------------------------");
            sb.AppendLine("--------------- entrer : Continuer ----------------");
            sb.AppendLine("-------------------- S : Sauvegarder --------------");
            sb.AppendLine("---------------- echap : Quitter ------------------");
            sb.AppendLine("---------------------------------------------------");
            return sb.ToString();
        }
    }
}
