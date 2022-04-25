#region Microsoft Directive(s)
#endregion

#region CustomDirective(s)
using ToyRobotSimulator.Toy;
#endregion

namespace ToyRobotSimulator.Interface
{
    /// <summary>
    /// this interface has a boolean method that returns
    /// true or false if the position of the robot is within the Table/Board
    /// </summary>
    public interface IValidateBoardPosition
    {
        /// <summary>
        /// Validate The Borad Position
        /// </summary>
        /// <param name="position">ToyPosition</param>
        /// <returns>true/false</returns>
        bool IsValidPosition(ToyPosition position);
    }
}
