using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.CommandParser
{
    public class PlaceCommandParameter
    {
        public ToyPosition Position { get; set; }
        public ToyDirection Direction { get; set; }

        public PlaceCommandParameter(ToyPosition position, ToyDirection direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
