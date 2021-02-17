using iMORPHr.JellyFishTank.Contract.Interfaces;

namespace iMORPHr.JellyFishTank.Contract
{
    public class Coordinates: ICoordinates
    {
        private int x;
        /// <summary>
        /// Defines X coordinate of the cell with 0 based index.
        /// </summary>
        public int X { get => x; set => x = value; }

        private int y;
        /// <summary>
        /// Defines Y coordinate of the cell with 0 based index.
        /// </summary>
        public int Y { get => y; set => y = value; }

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }        
    }
}
