using System;
using System.Collections.Generic;

namespace BatailleNavaleApp.Entities
{
    public class BoardCoordinates : BaseEntity
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
        public BoardCoordinates()
        {
        }

        public string Coordinates
        {
            get
            {
                return string.Concat(columnNames[x - 1], y);
            }
        }

        public static BoardCoordinates Parse(string input)
        {

            if (input.Length >= 2 && input.Length <= 3)
            {
                var letter = input.Substring(0, 1).ToUpper();
                if (columnNames.Contains(letter))
                {
                    bool parseSuccess = false;
                    int rowNumber = 0;
                    if (input.Length == 2)
                    {
                        parseSuccess = int.TryParse(input.Substring(1, 1), out rowNumber);
                    }
                    else if (input.Length == 3)
                    {
                        parseSuccess = int.TryParse(input.Substring(1, 2), out rowNumber);
                    }
                    if (parseSuccess)
                    {
                        if (rowNumber >= 1 && rowNumber <= 10)
                        {
                            return new BoardCoordinates(columnNames.IndexOf(letter) + 1, rowNumber);
                        }
                        Console.WriteLine("Veuillez entrer un numéro de ligne comprise entre 1 et 10");
                    }
                    Console.WriteLine("Veuillez entrer un numéro de ligne correct");
                    return null;
                }
                Console.WriteLine("Veuillez entrer une lettre de colonne comrpise entre A et J.");
                return null;
            }
            Console.WriteLine("Coordonnées incorrectes, entrez sous la forme : ");
            Console.WriteLine("[LETTRE_LIGNE]+[NUMERO_LIGNE] - > ex : E5");
            return null;
        }

    }
}
