using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BatailleNavaleApp.Entities
{
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
