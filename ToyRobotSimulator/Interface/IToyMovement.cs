using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.Interface
{
    public interface IToyMovement
    {
        #region Properties
        ToyDirection ToyDirection { get; set; }
        ToyPosition ToyPosition { get; set; }
        #endregion

        /// <summary>
        /// Place the toy in given position and direction
        /// </summary>
        /// <param name="position">ToyPosition</param>
        /// <param name="direction">ToyDirection</param>
        void Place(ToyPosition position, ToyDirection direction);


        /// <summary>
        /// Retrieve the toy's next position depending
        /// on the direction toy is facing
        /// </summary>
        /// <returns>ToyPosition</returns>
        ToyPosition RetrieveNextPosition();

        /// <summary>
        /// Rotates the direction of the toy 90 degrees to the left.
        /// </summary>
        void RotateLeft();

        /// <summary>
        /// Rotates the direction of the toy 90 degrees to the right.
        /// </summary>
        void RotateRight();
      

    }
}
