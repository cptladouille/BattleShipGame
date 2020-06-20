using System;
using System.Collections.Generic;
using System.Text;

namespace BatailleNavaleApp.Interfaces
{
    public interface IPlayer
    {
        void PlayTurn();
        void Fire(int x, int y);
        
        
    }
}
