using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.CommandParser
{
   public class PlaceCommandParameterParser
    {
        private const int ParameterCount = 3;

        // Number of raw input items expected from user.
        private const int CommandInputCount = 2;

        // Checks the toy's initial position and the direction it is going to be facing.
        public PlaceCommandParameter ParseParameters(string[] input)
        {
            ToyDirection direction;

            // Checks that Place command is followed by valid command parameters (X,Y and F toy's face direction).
            if (input.Length != CommandInputCount)
                throw new ArgumentException("Please ensure that the PLACE command is having format: PLACE X,Y,F");

            // Checks that three command parameters are provided for the PLACE command.   
            var commandParams = input[1].Split(',');
            if (commandParams.Length != ParameterCount)
                throw new ArgumentException("Please ensure that the PLACE command is using format: PLACE X,Y,F");

            // Checks the direction which the toy is going to be facing.
            if (!Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");

            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
            ToyPosition position = new ToyPosition(x, y);

            return new PlaceCommandParameter(position, direction);
        }
    }
}
