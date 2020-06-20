using BatailleNavaleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BatailleNavaleApp.Extensions
{
    public static class CustomExtensions
    {
        public static BoardCell At(this List<BoardCell> boardCells,int x, int y)
        {
            return boardCells.FirstOrDefault(boardCoordinates => boardCoordinates.BoardCoordinates.x == x && boardCoordinates.BoardCoordinates.y == y); 
        }

        public static BoardCell At(this List<BoardCell> boardCells, BoardCoordinates bc)
        {
            return boardCells.FirstOrDefault(boardCoordinates => boardCoordinates.BoardCoordinates.AsSameCoordinates(bc));
        }

        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}
