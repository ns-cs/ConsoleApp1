﻿using iMORPHr.JellyFishTank.Contract.Interfaces;
using System;

namespace iMORPHr.JellyFishTank.Contract
{
    public class Tank:ITank
    {
        #region Properties
        private ICoordinates topRight;
        public ICoordinates TopRight { get => topRight; }
        
        private ICell[,] grid;
        public ICell[,] Grid { get => grid; }

        #endregion
        /// <summary>
        /// Constructor of the Grid class, which takes top and right as parameters to define the limits of the Grid.
        /// </summary>
        /// <param name="top">Top coordinate of the Grid with 0 based index</param>
        /// <param name="right">Right coordinate of the Grid with 0 based index</param>
        public Tank(int top, int right)
        {
            if(top < 1 || top > 60)
            {
                throw new ArgumentOutOfRangeException("top", "top should be greater than 0 and not more than 60");
            }

            if(right < 1 || right > 60)
            {
                throw new ArgumentOutOfRangeException("right", "right should be greater than 0 and not more than 60");
            }

            this.topRight = new Coordinates(right, top);
            
            grid = new Cell[right + 1, top + 1];

            for (int i = 0; i <= right; i++)
            {
                for (int j = 0; j <= top; j++)
                {
                    grid[i, j] = new Cell(i, j, this);
                }
            }
        }
        
        public IJellyFish AddJellyFish(ICoordinates initalPosition, Orientation direction)
        {            
            return new JellyFish(grid[initalPosition.X, initalPosition.Y], direction);
        }
    }
}
