using NUnit.Framework;
using ToyRobSimulator;
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

            // Move forward Action
            simulator.Execute("MOVE");

            // Assert to check equal in North
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

            // Left rotate Action
            simulator.Execute("LEFT");

            // Assert to check equal in West
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

            // Right rotate Action
            simulator.Execute("RIGHT");

            // Assert to check equal in East
            Assert.That(robot.Report(),Is.EqualTo("1,1,EAST"));


        }

        [Fact]
        public void Execute_ReportCommand_ReturnsPositionAndDirection()
        {
            // Arrange
            ToyRobot robot = new ToyRobot();
            RobotCommand toyRobot = new RobotCommand(robot);
            Simulator simulator = new Simulator(toyRobot);
            simulator.Execute("PLACE 2,3,WEST");

            // Report Action
            simulator.Execute("REPORT");

            // Assert to check equal in West
            Assert.That(robot.Report(),Is.EqualTo("2,3,WEST"));
        }

        [Fact]
        public void Execute_PlaceCommand_OutsideBounds_DoesNotChangePosition()
        {
            // Arrange
            ToyRobot robot = new ToyRobot();
            RobotCommand toyRobot = new RobotCommand(robot);
            Simulator simulator = new Simulator(toyRobot);

            // Action
            simulator.Execute("PLACE 6,6,NORTH");

            // Assert check is null when reported
            Assert.That(robot.Report(),Is.Null);
        }

        [Fact]
        public void ToyRobot_Move_UpdatesPosition()
        {
            // Arrange
            var robot = new ToyRobot();
            robot.Place(1, 1, Direction.North);

            // Action Move direction
            robot.Move();

            // Assert equals to report
            Assert.That(robot.Report(),Is.EqualTo("1,2,NORTH"));
        }

        [Fact]
        public void ToyRobot_Left_UpdatesDirection()
        {
            // Arrange
            var robot = new ToyRobot();
            robot.Place(1, 1, Direction.North);

            // Action Left direction
            robot.Left();

            // Assert equal to West direction
            Assert.That(robot.Report(), Is.EqualTo("1,1,WEST"));
        }

        [Fact]
        public void ToyRobot_Right_UpdatesDirection()
        {
            // Arrange
            var robot = new ToyRobot();
            robot.Place(1, 1, Direction.North);

            // Action right direction
            robot.Right();

            // Assert equal to East direction
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
            // Action & Assert
            Assert.That(Direction.IsValid(Direction.North), Is.True);
            Assert.That(Direction.IsValid(Direction.East), Is.True);
            Assert.That(Direction.IsValid(Direction.South), Is.True);
            Assert.That(Direction.IsValid(Direction.West), Is.True);
        }

        [Fact]
        public void Direction_IsValid_ReturnsFalseForInvalidDirection()
        {
            // Action invalid direction & Assert
            Assert.That(Direction.IsValid("INVALID_DIRECTION"),Is.False);
        }

        [Fact]
        public void Direction_RotateLeft_ReturnsCorrectDirection()
        {
            // Action direction & Assert left rotate
            Assert.That(Direction.RotateLeft(Direction.North), Is.EqualTo(Direction.West));
            Assert.That(Direction.RotateLeft(Direction.West), Is.EqualTo(Direction.South));
            Assert.That(Direction.RotateLeft(Direction.South), Is.EqualTo(Direction.East));
            Assert.That(Direction.RotateLeft(Direction.East), Is.EqualTo(Direction.North));

        }

        [Fact]
        public void Direction_RotateRight_ReturnsCorrectDirection()
        {
            // Action direction & Assert right rotate
            Assert.That(Direction.RotateRight(Direction.North), Is.EqualTo(Direction.East));
            Assert.That(Direction.RotateRight(Direction.East), Is.EqualTo(Direction.South));
            Assert.That(Direction.RotateRight(Direction.South), Is.EqualTo(Direction.West));
            Assert.That(Direction.RotateRight(Direction.West), Is.EqualTo(Direction.North));
        }
    }
}
