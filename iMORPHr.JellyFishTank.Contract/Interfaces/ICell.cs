using System;
using System.Collections.Generic;
using System.Text;

namespace iMORPHr.JellyFishTank.Contract.Interfaces
{
    public interface ICell
    {
        ICoordinates Position
        {
            get;
        }

        bool IsScented
        {
            get;
            set;
        }

        Tank Container
        {
            get;
        }

        List<JellyFish> JellyFishes
        {
            get;
        }
    }
}
