using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var logFile = File.ReadAllLines("input.txt");
            var logList = logFile.Select(int.Parse).ToList();

            var part1Result = Part1(logList);
            Console.WriteLine($"Part 1 result: {part1Result}");

            var part2Result = Part2(logList);
            Console.WriteLine($"Part 2 result (sliding window): {part2Result}");
        }

        private static int Part1(List<int> input)
        {
            var increaseValues = input
                .Select((value, index) => new {value, index})
                .Where(x => x.index > 0 && x.value > input[x.index - 1]);

           return increaseValues.Count();
        }

        private static int Part2(List<int> input)
        {
            var trackingWindow = -1;
            var increaseValues = input
                .Select((value, index) => new {value, index})
                .Where(x =>
                {
                    if (x.index >= input.Count() - 2) return false;

                    var slidingWindowValue = x.value + input[x.index + 1] + input[x.index + 2];

                    if (x.index == 0) trackingWindow = slidingWindowValue;
                    
                    var res = slidingWindowValue > trackingWindow;
                    trackingWindow = slidingWindowValue;
                    return res;
                });

            return increaseValues.Count();
        }
    }
}