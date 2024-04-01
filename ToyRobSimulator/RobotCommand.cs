using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobSimulator.Interface;

namespace ToyRobSimulator
{
    // Implement the repository
    public class RobotCommand : IToyRobot
    {
        private readonly ToyRobot _toyRobot;

        public RobotCommand(ToyRobot toyRobot)
        {
            _toyRobot = toyRobot;
        }

        public void Place(int x, int y, string direction)
        {
            _toyRobot.Place(x, y, direction);
        }

        public void Move()
        {
            _toyRobot.Move();
        }

        public void Left()
        {
            _toyRobot.Left();
        }

        public void Right()
        {
            _toyRobot.Right();
        }

        public string Report()
        {
            return _toyRobot.Report();
        }
    }
}
