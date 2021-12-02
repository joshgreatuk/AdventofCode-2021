using System;
using System.IO;
using System.Diagnostics;

namespace Day2
{
    class Program
    {
        static string fileInput = "SubCode.txt";

        static void Main(string[] args)
        {
            //Here is where base code goes for loading input files and calling functions
            Console.WriteLine("AOC2021 - Day 2 - Dive!");

            Stopwatch timer = new Stopwatch();
            timer.Start();

            string[] inputRaw = File.ReadAllLines(fileInput);
            if (inputRaw.Length%2 != 0) { Console.WriteLine("Data source not even"); return; }
            int arrayLen = inputRaw.Length;

            string[,] input = new string[arrayLen, 2];
            for (int i = 0; i < arrayLen; i++)
            {
                string[] arrayContent = inputRaw[i].Split(' ');
                for (int j = 0; j < 2; j++)
                {
                    input[i,j] = arrayContent[j];
                }
            }
            
            Console.WriteLine("File parsed in '" + timer.ElapsedMilliseconds.ToString() + "' milliseconds");
            timer.Restart();

            if (input.Length <= 1) { Console.WriteLine("Data source too short"); return; }
            int solution = Part1(input);
            Console.WriteLine("Got part 1 solution as '" + solution.ToString() + "' in '" + timer.ElapsedMilliseconds.ToString() + "' milliseconds");
            timer.Restart();

            if (input.Length <= 1) { Console.WriteLine("Data source too short"); return; }
            solution = Part2(input);
            Console.WriteLine("Got part 2 solution as '" + solution.ToString() + "' in '" + timer.ElapsedMilliseconds.ToString() + "' milliseconds");
            timer.Stop();

            Console.WriteLine("Finished!");
        }

        static int Part1 (string[,] input)
        {
            int horizontalPos = 0;
            int depth = 0;

            for (int i = 0; i < input.Length/2; i++)
            {
                switch (input[i,0])
                {
                    case "forward":
                        horizontalPos += Int32.Parse(input[i,1]);
                        break;
                    case "up":
                        depth -= Int32.Parse(input[i,1]);
                        break;
                    case "down":
                        depth += Int32.Parse(input[i,1]);
                        break;
                }
            }

            return horizontalPos * depth;
        }

        static int Part2 (string[,] input)
        {
            int horizontalPos = 0;
            int depth = 0;
            int aim = 0;

            for (int i = 0; i < input.Length/2; i++)
            {
                switch (input[i, 0])
                {
                    case "forward":
                        horizontalPos += Int32.Parse(input[i, 1]);
                        depth += aim * Int32.Parse(input[i, 1]);
                        break;
                    case "up":
                        aim -= Int32.Parse(input[i, 1]);
                        break;
                    case "down":
                        aim += Int32.Parse(input[i, 1]);
                        break;
                }   
            }

            return horizontalPos * depth;
        }
    }
}
