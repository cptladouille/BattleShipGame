using BatailleNavaleApp.Enums;
using BatailleNavaleApp.Extensions;
using System.ComponentModel;


namespace BatailleNavaleApp.Entities
{
    public class BoardCell : BaseEntity
    {
        public BoardCoordinates BoardCoordinates { get; set; }
        public ShipType CellOccupant { get; set; }
        public BoardCell()
        {
            this.CellOccupant = ShipType.NONE;
        }

        public string OccupantDescription
        {
            get
            {
                return CellOccupant.GetAttributeOfType<DescriptionAttribute>().Description;
            }
        }

        public bool IsOccupied
        {
            get
            {
                return CellOccupant == ShipType.AICRAFT_CARRIER
                    || CellOccupant == ShipType.COUNTER_TORPEDO
                    || CellOccupant == ShipType.CRUISER
                    || CellOccupant == ShipType.TORPEDO_BOAT;
            }
        }

        public bool IsAlreadyShot
        {
            get
            {
                return CellOccupant == ShipType.HITTED
                    || CellOccupant == ShipType.MISSED;
            }
        }


        public bool IsParallelWith(BoardCell cell)
        {
            return (cell.BoardCoordinates.x == this.BoardCoordinates.x
                || cell.BoardCoordinates.y == this.BoardCoordinates.y);
        }
    }
}
