using iMORPHr.JellyFishTank.Contract;
using iMORPHr.JellyFishTank.Contract.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace iMORPHr.JellyFishTank.Test
{
    [TestClass]
    public class CompassTest
    {
        [TestMethod]
        public void TurnLeft_FromEast()
        {
            ICompass c = new Compass(Orientation.East);
            c.Turn(TurnDirection.Left);

            Assert.AreEqual(Orientation.North, c.Direction);
        }

        [TestMethod]
        public void TurnRight_FromEast()
        {
            ICompass c = new Compass(Orientation.East);
            c.Turn(TurnDirection.Right);

            Assert.AreEqual(Orientation.South, c.Direction);
        }

        [TestMethod]
        public void TurnLeft_FromNorth()
        {
            ICompass c = new Compass(Orientation.North);
            c.Turn(TurnDirection.Left);

            Assert.AreEqual(Orientation.West, c.Direction);
        }

        [TestMethod]
        public void TurnRight_FromNorth()
        {
            ICompass c = new Compass(Orientation.North);
            c.Turn(TurnDirection.Right);

            Assert.AreEqual(Orientation.East, c.Direction);
        }

        [TestMethod]
        public void TurnLeft_FromWest()
        {
            ICompass c = new Compass(Orientation.West);
            c.Turn(TurnDirection.Left);

            Assert.AreEqual(Orientation.South, c.Direction);
        }

        [TestMethod]
        public void TurnRight_FromWest()
        {
            ICompass c = new Compass(Orientation.West);
            c.Turn(TurnDirection.Right);

            Assert.AreEqual(Orientation.North, c.Direction);
        }

        [TestMethod]
        public void TurnLeft_FromSouth()
        {
            ICompass c = new Compass(Orientation.South);
            c.Turn(TurnDirection.Left);

            Assert.AreEqual(Orientation.East, c.Direction);
        }

        [TestMethod]
        public void TurnRight_FromSouth()
        {
            ICompass c = new Compass(Orientation.South);
            c.Turn(TurnDirection.Right);

            Assert.AreEqual(Orientation.West, c.Direction);
        }
    }
}
