using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ToyRobSimulator;
using ToyRobSimulator.Interface;
using Assert = NUnit.Framework.Assert;

namespace ToyRoboSimulator.Tests
{
    
    public class CommandTests
    {
        [Fact]
        public void Execute_MoveCommand_UpdatesPosition()
        {
            // Arrange
            ToyRobot robot = new ToyRobot();
            RobotCommand toyRobot = new RobotCommand(robot);
            Simulator simulator = new Simulator(toyRobot);
            simulator.Execute("PLACE 1,1,NORTH");

            // Act
            simulator.Execute("MOVE");

            // Assert
            Assert.That(robot.Report(), Is.EqualTo("1,2,NORTH"));
        }

        [Fact]
        public void Execute_LeftCommand_UpdatesDirection()
        {
            // Arrange
            ToyRobot robot = new ToyRobot();
            RobotCommand toyRobot = new RobotCommand(robot);
            Simulator simulator = new Simulator(toyRobot);
            simulator.Execute("PLACE 1,1,NORTH");

            // Act
            simulator.Execute("LEFT");

            // Assert
            Assert.That(robot.Report(), Is.EqualTo("1,1,WEST"));
        }

        [Fact]
        public void Execute_RightCommand_UpdatesDirection()
        {
            // Arrange
            ToyRobot robot = new ToyRobot();
            RobotCommand toyRobot = new RobotCommand(robot);
            Simulator simulator = new Simulator(toyRobot);
            simulator.Execute("PLACE 1,1,NORTH");

            // Act
            simulator.Execute("RIGHT");

            // Assert
            Assert.That(robot.Report(), Is.EqualTo("1,1,EAST"));


        }

        [Fact]
        public void Execute_ReportCommand_ReturnsPositionAndDirection()
        {
            // Arrange
            ToyRobot robot = new ToyRobot();
            RobotCommand toyRobot = new RobotCommand(robot);
            Simulator simulator = new Simulator(toyRobot);
            simulator.Execute("PLACE 2,3,WEST");

            // Act
            simulator.Execute("REPORT");

            // Assert
            Assert.That(robot.Report(), Is.EqualTo("2,3,WEST"));
        }

        [Fact]
        public void Execute_PlaceCommand_OutsideBounds_DoesNotChangePosition()
        {
            // Arrange
            ToyRobot robot = new ToyRobot();
            RobotCommand toyRobot = new RobotCommand(robot);
            Simulator simulator = new Simulator(toyRobot);

            // Act
            simulator.Execute("PLACE 6,6,NORTH");

            // Assert
            Assert.That(robot.Report(),Is.Null);
        }

        [Fact]
        public void ToyRobot_Move_UpdatesPosition()
        {
            // Arrange
            var robot = new ToyRobot();
            robot.Place(1, 1, Direction.North);

            // Act
            robot.Move();

            // Assert
            Assert.That(robot.Report(), Is.EqualTo("1,2,NORTH"));
        }

        [Fact]
        public void ToyRobot_Left_UpdatesDirection()
        {
            // Arrange
            var robot = new ToyRobot();
            robot.Place(1, 1, Direction.North);

            // Act
            robot.Left();

            // Assert
            Assert.That(robot.Report(), Is.EqualTo("1,1,WEST"));
        }

        [Fact]
        public void ToyRobot_Right_UpdatesDirection()
        {
            // Arrange
            var robot = new ToyRobot();
            robot.Place(1, 1, Direction.North);

            // Act
            robot.Right();

            // Assert
            Assert.That(robot.Report(), Is.EqualTo("1,1,EAST"));
        }

        [Fact]
        public void ToyRobot_Report_ReturnsPositionAndDirection()
        {
            // Arrange
            var robot = new ToyRobot();
            robot.Place(2, 3, Direction.West);

            // Act
            var report = robot.Report();

            // Assert
            Assert.That(report, Is.EqualTo("2,3,WEST"));
        }

        [Fact]
        public void ToyRobot_Place_OutsideBounds_DoesNotChangePosition()
        {
            // Arrange
            var robot = new ToyRobot();

            // Act
            robot.Place(6, 6, Direction.North);

            // Assert
            Assert.That(robot.Report(),Is.Null);
        }

        [Fact]
        public void Direction_IsValid_ReturnsTrueForValidDirection()
        {
            // Act & Assert
            Assert.That(Direction.IsValid(Direction.North), Is.True);
            Assert.That(Direction.IsValid(Direction.East), Is.True);
            Assert.That(Direction.IsValid(Direction.South), Is.True);
            Assert.That(Direction.IsValid(Direction.West), Is.True);
        }

        [Fact]
        public void Direction_IsValid_ReturnsFalseForInvalidDirection()
        {
            // Act & Assert
            Assert.That(Direction.IsValid("INVALID_DIRECTION"),Is.False);
        }

        [Fact]
        public void Direction_RotateLeft_ReturnsCorrectDirection()
        {
            // Act & Assert
            Assert.That(Direction.RotateLeft(Direction.North), Is.EqualTo(Direction.West));
            Assert.That(Direction.RotateLeft(Direction.West), Is.EqualTo(Direction.South));
            Assert.That(Direction.RotateLeft(Direction.South), Is.EqualTo(Direction.East));
            Assert.That(Direction.RotateLeft(Direction.East), Is.EqualTo(Direction.North));

        }

        [Fact]
        public void Direction_RotateRight_ReturnsCorrectDirection()
        {
            // Act & Assert
            Assert.That(Direction.RotateLeft(Direction.North), Is.EqualTo(Direction.West));
            Assert.That(Direction.RotateLeft(Direction.West), Is.EqualTo(Direction.South));
            Assert.That(Direction.RotateLeft(Direction.South), Is.EqualTo(Direction.East));
            Assert.That(Direction.RotateLeft(Direction.East), Is.EqualTo(Direction.North));
        }
    }
}
