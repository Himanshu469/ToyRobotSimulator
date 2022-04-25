

using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator.CommandHandler
{
    public class RightRotateCommandHandler : ICommandHandler
    {
        public RightRotateCommandHandler(IToyMovement toyMovement)
        {
            this.toyMovement = toyMovement;
        }

        private IToyMovement toyMovement;

        public string ExecuteCommand()
        {
            toyMovement.RotateRight();
            return string.Empty;
        }
    }
}
