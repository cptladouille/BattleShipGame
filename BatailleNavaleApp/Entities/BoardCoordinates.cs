using System;
using System.Collections.Generic;
using System.Text;

namespace BatailleNavaleApp.Entities
{
    public class BoardCoordinates
    {
        public static readonly List<string> columnNames = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        public int x { get; set; }
        public int y { get; set; } 
        public bool AsSameCoordinates(BoardCoordinates bc)
        {
            return this.x == bc.x && this.y == bc.y;
        }

        public BoardCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public string Coordinates
        {
            get 
            {
                return string.Concat(columnNames[x-1], y);
            }
        }

        public static BoardCoordinates Parse(string input) {
            
            if(input.Length == 2)
            {
                var letter = input.Substring(0, 1).ToUpper();
                if(columnNames.Contains(letter))
                {
                    int rowNumber;
                    if (int.TryParse(input.Substring(1,1), out rowNumber))
                    {
                        if(rowNumber >= 1 && rowNumber <= 10)
                        {
                            return new BoardCoordinates(columnNames.IndexOf(letter)+1, rowNumber);
                        }
                        Console.WriteLine("Veuillez entrer un numéro de ligne comprise entre 1 et 10");
                    }
                    Console.WriteLine("Veuillez entrer un numéro de ligne correct");
                    return null;
                }
                Console.WriteLine("Veuillez entrer une lettre de colonne comrpise entre A et J.");
                return null;
            }
            Console.WriteLine("Coordonées incorrectes, entrez sous la forme : ");
            Console.WriteLine("[LETTRE_COLONNE]+[NUMERO_LIGNE] - > ex : E5");
            return null;
        }

    }
}
