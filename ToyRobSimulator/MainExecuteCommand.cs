using System;
using System.IO;
using System.Linq;
using ToyRobSimulator;

namespace ToyRoboSimulator
{
    public class MainExecuteCommand
    {
        static void Main(string[] args)
        {
            // Automatically executes when application is started.

            //var toyRobot = new ToyRobot();
            //Simulator obj = new Simulator();
            // Create an instance of ToyRobot
            ToyRobot Robot = new ToyRobot();

            // Create an instance of ToyRobotRepository and pass the ToyRobot instance to it
            RobotCommand toyRobot = new RobotCommand(Robot);
            // Create an instance of Simulator and pass the ToyRobotRepository instance to it
            Simulator simulator = new Simulator(toyRobot);

            string binFolderPath = AppDomain.CurrentDomain.BaseDirectory;
            string textFilePath = Path.Combine(binFolderPath, "commands.txt");

            if (binFolderPath == null || binFolderPath.Length == 0)
            {
                Console.WriteLine("Please specify a .txt filepath.");
                return;
            }
            if (File.Exists(textFilePath) && (Path.GetExtension(textFilePath) == ".txt"))
            {
                string[] commands = File.ReadAllLines(textFilePath);
                foreach (var command in commands)
                {
                    //Executes the commands
                    simulator.Execute(command);

                }
                Console.ReadLine();

            }
        }
    }
}