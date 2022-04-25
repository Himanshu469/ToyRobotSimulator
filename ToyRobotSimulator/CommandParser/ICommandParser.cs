
using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.CommandParser
{
    public interface ICommandParser
    {
        /// <summary>
        /// Retrieve the command from input
        /// </summary>
        /// <param name="rawInput"></param>
        /// <returns></returns>
        Command ParseCommand(string[] input);

        /// <summary>
        /// Retrieve the Place Command Parameter from input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>PlaceCommandParameter</returns>
        PlaceCommandParameter ParseCommandParameter(string[] input);
    }
}
