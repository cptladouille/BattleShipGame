using System.ComponentModel;

namespace BatailleNavaleApp.Enums{
    public enum ShipType
    {
        [Description("O")]
        NONE,
        [Description("A")]
        AICRAFT_CARRIER,
        [Description("C")]
        CRUISER,
        [Description("T")]
        TORPEDO_BOAT,
        [Description("S")]
        COUNTER_TORPEDO,
        [Description("X")]
        HITTED,
        [Description("M")]
        MISSED

    }
}
