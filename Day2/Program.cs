using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = File.ReadAllLines("input.txt");
            var inputList = inputFile.Select(x => x.Split(" ")).ToList();

            var part1Result = Part1(inputList);
            Console.WriteLine(part1Result);
            
            var part2Result = Part2(inputList);
            Console.WriteLine(part2Result);
        }

        private static int Part1(List<string[]> commands)
        {
            var x = 0; // x being horizontal
            var y = 0; // y being depth
            
            foreach (var command in commands)
            {
                var direction = command[0];
                var value = int.Parse(command[1]);

                switch (direction)
                {
                    case "forward":
                        x = x+value;
                        break;
                    case "up":
                        y = y-value;
                        break;
                    case "down":
                        y = y+value;
                        break;
                }
            }

            return x * y;
        }

        private static int Part2(List<string[]> commands)
        {
            var x = 0; // x being horizontal
            var y = 0; // y being depth
            var aim = 0;
            
            foreach (var command in commands)
            {
                var direction = command[0];
                var value = int.Parse(command[1]);

                switch (direction)
                {
                    case "forward":
                        x = x + value;
                        y = y + (aim * value);
                        break;
                    case "up":
                        aim = aim - value;
                        break;
                    case "down":
                        aim = aim + value;
                        break;
                }
            }

            return x * y;
        }
    }
}