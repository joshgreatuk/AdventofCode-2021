using System;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace AdventofCode_2021
{
    class Program
    {
        static string fileInput = "DiagnosticTest.txt";

        static void Main(string[] args)
        {
            //Here is where base code goes for loading input files and calling functions
            Console.WriteLine("AOC2021 - Day 3 - Binary Diagnostic");

            Stopwatch timer = new Stopwatch();
            timer.Start();

            string[] input = File.ReadAllLines(fileInput);
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

        public int BinaryToDenary(string input)
        {
            int factor = 1;
            int answer = 0;

            for (int i=0; i < input.Length; i++)
            {
                answer += Int32.Parse(input[-i]) * factor;
                factor *= 2;
            }

            return answer;
        }

        public int Part1(string[] input)
        {
            int[] bitCount = new int[input[0].Length];

            for (int i=0; i < input[0].Length; i++)
            {
                for (int j=0; j < input.Count(); j++)
                {
                    if (input[j][i] == 1)
                    {
                        bitCount[i] += 1;
                    }
                }
            }

            string mostCommon = "00000";

            for (int i=0; i < bitCount.Count(); i++)
            {
                if (bitCount[i] >= input.Count()/2)
                {
                    mostCommon[i] = "1";
                }
                else
                {
                    mostCommon[i] = "0";
                }
            }

            string leastCommon = "00000";

            for (int i=0; i < mostCommon.Length; i++)
            {
                if (mostCommon[i] == "1")
                {
                    leastCommon[i] = "0";
                }
                else
                {
                    leastCommon[i] = "1";
                }
            }

            return BinaryToDenary(mostCommon) * BinaryToDenary(leastCommon);
        }

        public int Part2(string[] input)
        {
            return 0;
        }
    }
}