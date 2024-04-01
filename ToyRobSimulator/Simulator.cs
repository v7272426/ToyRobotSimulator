using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToyRobSimulator.Interface;

namespace ToyRobSimulator
{
    // Define the simulator class using the repository
    public class Simulator
    {
        private static readonly Regex _placeCommand = new Regex(@"PLACE (\d+),(\d+),(\w+)");
        private readonly IToyRobot _repository;
        public Simulator(IToyRobot repository)
        {
            _repository = repository;
        }

        public void Execute(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return;
            try
            {
                if (command == "MOVE")
                {
                    _repository.Move();
                }
                if (command == "LEFT")
                {
                    _repository.Left();
                }
                if (command == "RIGHT")
                {
                    _repository.Right();
                }

                if (command == "REPORT")
                {
                    Console.WriteLine(_repository.Report());
                }

                var match = _placeCommand.Match(command);
                if (match.Success)
                {
                    var xIsValid = int.TryParse(match.Groups[1].Value, out var x);
                    var yIsValid = int.TryParse(match.Groups[2].Value, out var y);
                    var direction = match.Groups[3].Value;
                    if (xIsValid && yIsValid)
                    {
                        _repository.Place(x, y, direction);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
