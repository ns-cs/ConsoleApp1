using iMORPHr.JellyFishTank.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace iMORPHr.JellyFishTank.Contract
{
    internal class Transporter:ITransporter
    {
        #region Private Variables
        IJellyFish rider;
        #endregion

        #region Properties
        ICompass directionProvider;
               
        public ICompass DirectionProvider { get => directionProvider; }

        #endregion

        #region Constructor
        public Transporter(Orientation initialDirection, IJellyFish rider)
        {
            directionProvider = new Compass(initialDirection);
            this.rider = rider;
        }
        #endregion

        #region Private Methods
        private void MoveForward()
        {
            switch (DirectionProvider.Direction)
            {
                case Orientation.East:
                    MoveRight();
                    break;
                case Orientation.West:
                    MoveLeft();
                    break;
                case Orientation.North:
                    MoveUp();
                    break;
                case Orientation.South:
                    MoveDown();
                    break;
            }
        }

        private void MoveDown()
        {
            if (this.rider.CurrentCell.Position.Y > 0)                
            {
                (this.rider as JellyFish).MoveToCell(new Coordinates(this.rider.CurrentCell.Position.X, this.rider.CurrentCell.Position.Y - 1));
            }
            else
            {
                (this.rider as JellyFish).SignalInabilityToMoveOutOfBounds();
            }
        }

        private void MoveUp()
        {
            if (this.rider.CurrentCell.Position.Y < this.rider.CurrentCell.Container.TopRight.Y)
            {
                (this.rider as JellyFish).MoveToCell(new Coordinates(this.rider.CurrentCell.Position.X, this.rider.CurrentCell.Position.Y + 1));
            }
            else
            {
                (this.rider as JellyFish).SignalInabilityToMoveOutOfBounds();
            }
        }

        private void MoveRight()
        {
            if (this.rider.CurrentCell.Position.X < this.rider.CurrentCell.Container.TopRight.X)
                (this.rider as JellyFish).MoveToCell(new Coordinates(this.rider.CurrentCell.Position.X + 1, this.rider.CurrentCell.Position.Y));
            else
            {
                (this.rider as JellyFish).SignalInabilityToMoveOutOfBounds();
            }
        }

        private void MoveLeft()
        {
            if (this.rider.CurrentCell.Position.X > 0)
                (this.rider as JellyFish).MoveToCell(new Coordinates(this.rider.CurrentCell.Position.X - 1, this.rider.CurrentCell.Position.Y));
            else
            {
                (this.rider as JellyFish).SignalInabilityToMoveOutOfBounds();
            }
        }
        #endregion

        #region Public Methods
        public void ProcessInstruction(char instruction)
        {
            switch (instruction)
            {
                case 'L':
                    DirectionProvider.Turn(TurnDirection.Left);
                    break;
                case 'R':
                    DirectionProvider.Turn(TurnDirection.Right);
                    break;
                case 'F':
                    MoveForward();
                    break;
            }
        }
        #endregion
    }
}
