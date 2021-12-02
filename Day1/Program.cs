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

            var increaseValues = logList
                .Select((value, index) => new {value, index})
                .Where(x => x.index > 0 && x.value > logList[x.index - 1]);

            var result = increaseValues.Count();

            Console.WriteLine(result);
        }
    }
}