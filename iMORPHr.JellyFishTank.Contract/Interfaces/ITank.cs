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
