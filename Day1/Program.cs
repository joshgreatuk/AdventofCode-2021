using System;
using System.IO;
using System.Linq;

namespace AdventofCode_2021
{
    class Program
    {
        static string fileInput = "SweepReport.txt";

        static void Main(string[] args)
        {
            //Here is where base code goes for loading input files and calling functions
            Console.WriteLine("AOC2021 - Day 1 - Sonar Sweep");

            int[] input = File.ReadAllLines(fileInput).Select(int.Parse).ToArray();
            if (input.Length <= 2) { Console.WriteLine("Data source too short"); return; }
            Console.WriteLine("Part 1 solution is: " + Part1(input).ToString());
            if (input.Length <= 6) { Console.WriteLine("Data source too short"); return; }
            Console.WriteLine("Part 2 solution is: " + Part2(input).ToString());

            Console.WriteLine("Finished!");
        }

        static int Part1(int[] input)
        {
            int increases = 0;
            int previous = input[0];

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > previous)
                {
                    increases += 1;
                }
                previous = input[i];
            }
            return increases;
        }

        static int Part2(int[] input)
        {
            int increases = 0;
            int[] measurement = {input[0], input[1], input[2]};
            int previous = measurement.Sum();
            int lastIndex = 0;
            
            for (int i = 3; i < input.Length; i++)
            {
                if (lastIndex == 3) 
                { 
                    lastIndex = 0; 
                }

                previous = measurement.Sum();
                measurement[lastIndex] = input[i];
                lastIndex += 1;

                if (measurement.Sum() > previous)
                {
                    increases += 1;
                }
            }
            return increases;
        }
    }
}
