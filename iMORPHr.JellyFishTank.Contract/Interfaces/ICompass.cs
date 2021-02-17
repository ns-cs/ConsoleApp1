using System.Runtime.CompilerServices;
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
