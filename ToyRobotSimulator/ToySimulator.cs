
using System;
using ToyRobotSimulator.CommandHandler;
using ToyRobotSimulator.CommandParser;
using ToyRobotSimulator.Interface;
using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator
{
    public class ToySimulator
    {
        private IToyMovement toyMovement;
        private IValidateBoardPosition boardPosition;
        private ICommandParser commandParser;

        public ToySimulator(IToyMovement toyMovement, IValidateBoardPosition boardPosition,
           ICommandParser commandParser)
        {
            this.toyMovement = toyMovement;
            this.boardPosition = boardPosition;
            this.commandParser = commandParser;
            
        }

        /// <summary>
        /// This method will process the input command
        /// and will return Robot Position on table if
        /// command is REPORT otherwise will return empty String
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        public string ProcessCommand(string[] input)
        {
            var command = commandParser.ParseCommand(input);
            if (command != Command.Place && toyMovement.ToyPosition == null) return string.Empty;

            InputCommandHandler inputCommandHandler = 
                new CommandHandlerFactory(toyMovement,boardPosition,commandParser, input);
            
            ICommandHandler commandHandler =inputCommandHandler.RetrieveHandlerInstance(command);
             return commandHandler.ExecuteCommand();
        }

        
    }
}
