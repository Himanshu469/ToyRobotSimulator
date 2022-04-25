using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.CommandParser
{
    public class CommandParser : ICommandParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Command ParseCommand(string[] input)
        {
            Command command;
            if (!Enum.TryParse(input[0], true, out command))
                throw new ArgumentException("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT");
            return command;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PlaceCommandParameter ParseCommandParameter(string[] input)
        {
            var thisPlaceCommandParameter = new PlaceCommandParameterParser();
            return thisPlaceCommandParameter.ParseParameters(input);
        }
    }
}
