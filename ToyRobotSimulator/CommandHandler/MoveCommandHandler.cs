using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator.CommandHandler
{
    public class MoveCommandHandler : ICommandHandler
    {
        private IValidateBoardPosition boardPosition;
        private IToyMovement toyMovement;

        public MoveCommandHandler(IToyMovement toyMovement, IValidateBoardPosition boardPosition)
        {
            this.toyMovement = toyMovement;
            this.boardPosition = boardPosition;
        }

        public string ExecuteCommand()
        {
            var newPosition = toyMovement.RetrieveNextPosition();
            if (boardPosition.IsValidPosition(newPosition))
                toyMovement.ToyPosition = newPosition;

            return string.Empty;
        }
    }
}
