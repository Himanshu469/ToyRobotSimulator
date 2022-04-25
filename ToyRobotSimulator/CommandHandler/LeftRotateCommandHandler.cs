

using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator.CommandHandler
{
    public class LeftRotateCommandHandler : ICommandHandler
    {
        private IToyMovement toyMovement;

        public LeftRotateCommandHandler(IToyMovement toyMovement)
        {
            this.toyMovement = toyMovement;
        }
        public string ExecuteCommand()
        {
            toyMovement.RotateLeft();
            return string.Empty;
        }
    }
}
