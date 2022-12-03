using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day3
    {
        public void Part1()
        {
            int sum = 0;
            string[] input = File.ReadAllLines("input.txt");
            foreach(string line in input)
            {
                string firstComp = line.Substring(0, line.Length / 2);
                string secondComp = line.Substring(line.Length / 2);
                foreach(char compType in firstComp)
                {
                    if (secondComp.Contains(compType))
                    {
                        sum += CalcPriority(compType);
                        break;
                    }
                }
            }
            Console.WriteLine(sum);
        }
        public void Part2()
        {
            int sum = 0;
            string[] input = File.ReadAllLines("input.txt");
            for(int i = 0; i < input.Length; i += 3)
            {
                foreach(char compType in input[i])
                {
                    if (input[i+1].Contains(compType) && input[i + 2].Contains(compType))
                    {
                        sum += CalcPriority(compType);
                        break;
                    }
                }
            }
            Console.WriteLine(sum);
        }
        private int CalcPriority(char compType)
        {
            if(compType > 'Z')
            {
                return compType - 96;
            }
            if(compType < 'a')
            {
                return compType - 38;
            }
            return 0;
        }
    }
}
