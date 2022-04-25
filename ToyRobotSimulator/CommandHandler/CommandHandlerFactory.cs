#region Microsoft Directives
using System;
#endregion

#region CustomDirectives
using ToyRobotSimulator.CommandParser;
using ToyRobotSimulator.Interface;
using ToyRobotSimulator.Toy;
#endregion

namespace ToyRobotSimulator.CommandHandler
{
    public class CommandHandlerFactory : InputCommandHandler
    {
        #region Private Fields
        private readonly IToyMovement toyMovement;
        private readonly IValidateBoardPosition boardPosition;
        private readonly ICommandParser commandParser;
        private readonly string[] input;
        #endregion

        #region Constructor
        /// <summary>
        /// CommandHandlerFactory 
        /// </summary>
        /// <param name="toyMovement"></param>
        /// <param name="boardPosition"></param>
        /// <param name="commandParser"></param>
        public CommandHandlerFactory(IToyMovement toyMovement, IValidateBoardPosition boardPosition,
           ICommandParser commandParser, string[] input)
        {
            this.toyMovement = toyMovement;
            this.boardPosition = boardPosition;
            this.commandParser = commandParser;
            this.input = input;
        }
        #endregion

        #region Public Method's
        /// <summary>
        /// Retrieve HandlerInstance
        /// </summary>
        /// <param name="commandType">commandType</param>
        /// <returns>ICommandHandler instance</returns>
        public override ICommandHandler RetrieveHandlerInstance(Command commandType)
        {
            ICommandHandler commandHandler;
            switch (commandType)
            {
                case Command.Place:
                    commandHandler = new PlaceCommandHandler(toyMovement, boardPosition, commandParser, input);
                    break;
                case Command.Move:
                    commandHandler = new MoveCommandHandler(toyMovement, boardPosition);
                    break;
                case Command.Right:
                    commandHandler = new RightRotateCommandHandler(toyMovement);
                    break;
                case Command.Left:
                    commandHandler = new LeftRotateCommandHandler(toyMovement);
                    break;
                case Command.Report:
                    commandHandler = new ReportCommandHandler(toyMovement);
                    break;
                default:
                    throw new ArgumentException("Invalid Command : " + commandType);
            }
            return commandHandler;
        }
        #endregion

    }
}
