
using ToyRobotSimulator.Interface;

namespace ToyRobotSimulator.CommandHandler
{
    public class ReportCommandHandler : ICommandHandler
    {
        IToyMovement ToyMovement;
        public ReportCommandHandler(IToyMovement toyMovement)
        {
            ToyMovement = toyMovement;
        }
        public string ExecuteCommand()
        {
           return string.Format("Output: {0},{1},{2}", ToyMovement.ToyPosition.X,
                ToyMovement.ToyPosition.Y, ToyMovement.ToyDirection.ToString().ToUpper());
        }
    }
}
