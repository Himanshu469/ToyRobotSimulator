using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator.Toy
{
    public class ToyMovement : IToyMovement
    {
        public ToyDirection ToyDirection { get; set; }
        public ToyPosition ToyPosition { get ; set; }

        /// <summary>
        /// Retrieve the toy's next position depending
        /// on the direction toy is facing
        /// </summary>
        /// <returns>ToyPosition</returns>
        public ToyPosition RetrieveNextPosition()
        {
            ToyPosition newPosition = new ToyPosition(ToyPosition.X, ToyPosition.Y);
            switch (ToyDirection)
            {
                case ToyDirection.North:
                    newPosition.Y += 1;
                    break;
                case ToyDirection.East:
                    newPosition.X += 1;
                    break;
                case ToyDirection.South:
                    newPosition.Y -= 1;
                    break;
                case ToyDirection.West:
                    newPosition.X -= 1;
                    break;
            }
            return newPosition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public void Place(ToyPosition position, ToyDirection direction)
        {
            ToyPosition = position;
            ToyDirection = direction;
        }

        /// <summary>
        /// 
        /// </summary>
        public void RotateLeft()
        {
            Rotate(-1);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RotateRight()
        {
            Rotate(1);
        }

        #region Private Fields
        /// <summary>
        /// Rotate 
        /// </summary>
        /// <param name="rotationNumber"></param>
        private void Rotate(int rotationNumber)
        {
            var directions = (ToyDirection[])Enum.GetValues(typeof(ToyDirection));
            ToyDirection newDirection;
            if ((ToyDirection + rotationNumber) < 0)
                newDirection = directions[directions.Length - 1];
            else
            {
                var index = ((int)(ToyDirection + rotationNumber)) % directions.Length;
                newDirection = directions[index];
            }
            ToyDirection = newDirection;
        }
        #endregion
    }
}
