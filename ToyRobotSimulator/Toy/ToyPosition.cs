

namespace ToyRobotSimulator.Toy
{
    /// <summary>
    /// Class for Position of the Toy on Table/Board
    /// </summary>
    public class ToyPosition
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        public ToyPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion

        #region Properties
        public int X { get; set; }
        public int Y { get; set; }
        #endregion  

    }
}
