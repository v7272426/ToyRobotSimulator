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
            // Create an instance of ToyRobot

            ToyRobot Robot = new ToyRobot();
            RobotCommand toyRobot = new RobotCommand(Robot);
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