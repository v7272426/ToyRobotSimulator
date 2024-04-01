using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobSimulator.Interface
{
    // Define the interface for the repository
    public interface IToyRobot
    {
        void Place(int x, int y, string direction);
        void Move();
        void Left();
        void Right();
        string Report();
    }
}
