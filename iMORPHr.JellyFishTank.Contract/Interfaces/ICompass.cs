using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleToAttribute("iMORPHr.JellyFishTank.Test")]
namespace iMORPHr.JellyFishTank.Contract.Interfaces
{
    interface ICompass
    {
        Orientation Direction
        {
            get;
        }

        void Turn(TurnDirection turnDirection);
    }
}
