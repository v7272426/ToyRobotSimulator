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
