using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator;
using ToyRobotSimulator.CommandParser;
using ToyRobotSimulator.Interface;
using ToyRobotSimulator.TableTop;
using ToyRobotSimulator.Toy;

namespace TestToyRobotSimulator
{
    [TestClass]
    public class TestToySimulator
    {
        #region TestInitialization/Cleanup
        [TestInitialize]
        public void TestInitialization()
        {
            boardPosition = new ToyBoard(5, 5);
            commandParser = new CommandParser();
            toyMovement = new ToyMovement();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            boardPosition = null;
            commandParser = null;
            toyMovement = null;
        }
        #endregion

        #region TestMethod
        /// <summary>
        /// Test a valid place command
        /// </summary>
        [TestMethod]
        public void TestValidToySimulatorPlaceCommand()
        {
            //arrange
            var simulator = new ToySimulator(toyMovement, boardPosition, commandParser);

            //act 
            simulator.ProcessCommand("PLACE 2,4,WEST".Split(' '));

            // assert
            Assert.AreEqual(2, toyMovement.ToyPosition.X);
            Assert.AreEqual(4, toyMovement.ToyPosition.Y);
            Assert.AreEqual(ToyDirection.West, toyMovement.ToyDirection);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [TestMethod]
        public void TestInvalidToySimulatorPlaceCommand()
        {
            //arrange
            var simulator = new ToySimulator(toyMovement, boardPosition, commandParser);

            // act
            simulator.ProcessCommand("PLACE 9,7,EAST".Split(' '));

            // assert
            Assert.IsNull(toyMovement.ToyPosition);
        }

        /// <summary>
        /// Test a valid move command
        /// </summary>
        [TestMethod]
        public void TestValidToySimulatorMoveCommand()
        {

            //arrange
            var simulator = new ToySimulator(toyMovement, boardPosition, commandParser);
            // act
            simulator.ProcessCommand("PLACE 3,2,SOUTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            string result = simulator.ProcessCommand("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 3,1,SOUTH", result);
        }

        /// <summary>
        /// Test a invalid move command
        /// </summary>
        [TestMethod]
        public void TestInValidToySimulatorMoveCommand()
        {

            //arrange
            var simulator = new ToySimulator(toyMovement, boardPosition, commandParser);
            // act
            simulator.ProcessCommand("PLACE 2,2,NORTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            string result = simulator.ProcessCommand("REPORT".Split(' '));
            // assert
            Assert.AreEqual("Output: 2,4,NORTH", result);

            // if the toy goes out of the board then that command will be ignored
            simulator.ProcessCommand("MOVE".Split(' '));

            result = simulator.ProcessCommand("REPORT".Split(' '));
            // assert
            Assert.AreEqual("Output: 2,4,NORTH", result);
        }

        [TestMethod]
        public void TestValidToySimulatorLeftCommand()
        {
            //arrange
            var simulator = new ToySimulator(toyMovement, boardPosition, commandParser);
            // act
            simulator.ProcessCommand("PLACE 2,2,NORTH".Split(' '));
            simulator.ProcessCommand("LEFT".Split(' '));
            string result = simulator.ProcessCommand("REPORT".Split(' '));
            // assert
            Assert.AreEqual("Output: 2,2,WEST", result);
        }
        #endregion

        #region Private Field(s)
        private IToyMovement toyMovement;
        private IValidateBoardPosition boardPosition;
        private ICommandParser commandParser;
        #endregion  
    }
}
