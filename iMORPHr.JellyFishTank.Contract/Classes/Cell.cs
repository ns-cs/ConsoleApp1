using iMORPHr.JellyFishTank.Contract.Interfaces;
using System.Collections.Generic;

namespace iMORPHr.JellyFishTank.Contract
{
    /// <summary>
    /// The basic structure that defines a cell.  
    /// </summary>
    public class Cell: ICell
    {
        #region Properties
        private ICoordinates position;
        public ICoordinates Position { get => position; }
        
        bool isScented = false;
        public bool IsScented { get => isScented; set => isScented = value; }
        
        private Tank container;
        public Tank Container { get => container; }
        
        private List<JellyFish> jellyFishes = new List<JellyFish>();
        public List<JellyFish> JellyFishes { get => jellyFishes; set => jellyFishes = value; }
        #endregion

        #region Constructor
        /// <summary>
        /// Create a cell by specifying x and y coordinates.
        /// </summary>
        /// <param name="x">X coordinate of the cell</param>
        /// <param name="y">Y coordinate of the cell</param>
        public Cell(int x, int y, Tank container)
        {
            this.position = new Coordinates(x, y);
            this.container = container;
        }
        #endregion
    }
}
