using iMORPHr.JellyFishTank.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleToAttribute("iMORPHr.JellyFishTank.Test")]
namespace iMORPHr.JellyFishTank.Contract
{
    class Compass: ICompass
    {

        #region Private Variables
        private int directionAngle;
        #endregion

        #region Properties
        private Orientation direction;
        
        public Orientation Direction
        {
            get
            {
                return direction;
            }
            private set
            {
                direction = value;
                SetDirectionAngle();
            }

        }
        #endregion

        #region Constructor
        public Compass(Orientation initialDirection)
        {
            Direction = initialDirection;
        }
        #endregion

        #region Private Methods
        private void SetDirectionAngle()
        {
            switch (direction)
            {
                case Orientation.West:
                    directionAngle = 0;
                    break;
                case Orientation.North:
                    directionAngle = 90;
                    break;
                case Orientation.East:
                    directionAngle = 180;
                    break;
                case Orientation.South:
                    directionAngle = 270;
                    break;
            }
        }

        private void SetDirection()
        {
            switch (directionAngle)
            {
                case 0:
                    direction = Orientation.West;
                    break;
                case 90:
                    direction = Orientation.North;
                    break;
                case 180:
                    direction = Orientation.East;
                    break;
                case 270:
                    direction = Orientation.South;
                    break;
            }
        }

        private void TurnLeft()
        {
            if (directionAngle > 0)
                directionAngle -= 90;
            else
                directionAngle = 270;

            SetDirection();
        }

        private void TurnRight()
        {
            if (directionAngle < 270)
                directionAngle += 90;
            else
                directionAngle = 0;

            SetDirection();
        }
        #endregion

        #region Public Methods
        public void Turn(TurnDirection turnDirection)
        {
            switch (turnDirection)
            {
                case TurnDirection.Left:
                    TurnLeft();
                    break;
                case TurnDirection.Right:
                    TurnRight();
                    break;
            }

        }
        #endregion        
    }
}
