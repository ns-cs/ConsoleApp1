using System;
using System.Collections.Generic;
using System.Text;

namespace iMORPHr.JellyFishTank.Contract.Interfaces
{
    public interface ITank
    {
        ICoordinates TopRight
        {
            get;
        }

        ICell[,] Grid
        {
            get;
        }
    }
}
