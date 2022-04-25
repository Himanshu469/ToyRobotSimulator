using System;
using ToyRobotSimulator.CommandParser;
using ToyRobotSimulator.Interface;
using ToyRobotSimulator.TableTop;
using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
        
            const string guidelines =
@"       **** TOY ROBOT SIMULATOR ****

1: Place the toy on a 5 x 5 grid using the following command:

PLACE X,Y,F (Where X and Y are integers and F 
must be either NORTH, SOUTH, EAST or WEST)
    
2: When the toy is placed, use the following commands.

LEFT   – turns the toy 90 degrees left.
RIGHT  – turns the toy 90 degrees right.
MOVE   – Moves the toy 1 unit forward in the direction it is currently facing
REPORT – will announce X,Y and F of the robot.
STOP -   To Exit from the Toy Simulator ";

            Console.WriteLine(guidelines);
            IValidateBoardPosition boardPosition = new ToyBoard(5, 5);
            ICommandParser inputParser = new CommandParser.CommandParser();
            IToyMovement toyMovement = new ToyMovement();
            
            ToySimulator simulator = new ToySimulator(toyMovement, boardPosition, inputParser);
            
            bool exitLoop = false;
            
            do
            {
                string inputCommand = Console.ReadLine();
                if (inputCommand == null)
                { continue; }
                if (inputCommand.Equals("STOP"))
                {
                    exitLoop = true;
                }
                else
                {
                    try
                    {

                        var output = simulator.ProcessCommand(inputCommand.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }

            } while (!exitLoop);
        }
    }
}
