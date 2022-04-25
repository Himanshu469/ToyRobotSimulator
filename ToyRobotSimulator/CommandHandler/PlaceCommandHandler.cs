using ToyRobotSimulator.CommandParser;
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator.CommandHandler
{
    public class PlaceCommandHandler : ICommandHandler
    {
        private IToyMovement toyMovement;
        private IValidateBoardPosition boardPosition;
        private ICommandParser commandParser;
        private string[] input;

        public PlaceCommandHandler(IToyMovement toyMovement, IValidateBoardPosition boardPosition,
           ICommandParser commandParser, string[] input)
        {
            this.toyMovement = toyMovement;
            this.commandParser = commandParser;
            this.boardPosition = boardPosition;
            this.input = input;
        }
        public string ExecuteCommand()
        {
            var placeCommandParameter = commandParser.ParseCommandParameter(input);
            if (boardPosition.IsValidPosition(placeCommandParameter.Position))
                toyMovement.Place(placeCommandParameter.Position, placeCommandParameter.Direction);

            return string.Empty;
        }
    }
}
