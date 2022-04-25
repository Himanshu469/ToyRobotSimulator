using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.CommandHandler
{
    /// <summary>
    /// InputCommandHandler
    /// </summary>
    public abstract class InputCommandHandler
    {
        public abstract ICommandHandler RetrieveHandlerInstance(Command commandType);
    }
}
