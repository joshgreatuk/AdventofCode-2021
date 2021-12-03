using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text;

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

        static public int BinaryToDenary(string input)
        {
            int factor = 1;
            int answer = 0;

            int[] inputArray = new int[input.Length];
            for (int i=0; i < input.Length; i++)
            {
                inputArray[i] = Int32.Parse(input[i].ToString());
            }

            for (int i=1; i < input.Length+1; i++)
            {
                answer += inputArray[input.Length-i] * factor;
                factor *= 2;
            }

            return answer;
        }

        static public int Part1(string[] input)
        {
            int[] bitCount = new int[input[0].Length];

            for (int i=0; i < input[0].Length; i++)
            {
                for (int j=0; j < input.Count(); j++)
                {
                    if (input[j][i] == '1')
                    {
                        bitCount[i] += 1;
                    }
                }
            }

            string mostCommon = "";

            for (int i=0; i < bitCount.Count(); i++)
            {
                if (bitCount[i] >= input.Count()/2)
                {
                    mostCommon += "1";
                }
                else
                {
                    mostCommon += "0";
                }
            }

            string leastCommon = "";

            for (int i=0; i < mostCommon.Length; i++)
            {
                if (mostCommon[i] == '1')
                {
                    leastCommon += "0";
                }
                else
                {
                    leastCommon += "1";
                }
            }

            return BinaryToDenary(mostCommon) * BinaryToDenary(leastCommon);
        }

        //There must be a more efficient way to do this
        static public int Part2(string[] input)
        {
            string[] oxygenSortArray = input;
            int currentBit = 0;
            int chosenBit = 0;
            while (oxygenSortArray.Count() > 2)
            {
                int bitCount = 0;
                for (int i=0; i < oxygenSortArray.Count(); i++)
                {
                    if (oxygenSortArray[i][currentBit] == '1')
                    {
                        bitCount += 1;
                    }
                }
                if (bitCount >= oxygenSortArray.Count()/2)
                {
                    chosenBit = 1;
                }
                else
                {
                    chosenBit = 0;
                }

                string[] tempSortArray;
                if (chosenBit == 1)
                {
                    tempSortArray = new string[bitCount];
                }
                else
                {
                    tempSortArray = new string[oxygenSortArray.Count()-bitCount];
                }
                int currentIndex = 0;
                for (int i=0; i < oxygenSortArray.Count(); i++)
                {
                    if (oxygenSortArray[i][currentBit].ToString() == chosenBit.ToString())
                    {
                        tempSortArray[currentIndex] = oxygenSortArray[i];
                        currentIndex += 1;
                    }
                }
                oxygenSortArray = tempSortArray;
                currentBit += 1;
            }
            
            return 0;
        }
    }
}