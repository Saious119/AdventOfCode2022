using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day4
    {
        public void Part1()
        {
            int numOverlap = 0;
            string[] input = File.ReadAllLines("input.txt");
            foreach(string line in input)
            {
                string[] assignments = line.Split(',');
                int bottonRange1 = Int32.Parse(assignments[0].Split('-')[0]);
                int topRange1 = Int32.Parse(assignments[0].Split('-')[1]);
                int bottonRange2 = Int32.Parse(assignments[1].Split('-')[0]);
                int topRange2 = Int32.Parse(assignments[1].Split('-')[1]);
                if(bottonRange1 <= bottonRange2 && topRange1 >= topRange2) { numOverlap++; } // 1 encompasses 2
                else if (bottonRange2 <= bottonRange1 && topRange2 >= topRange1) { numOverlap++; } // 2 encompasses 1
            }
            Console.WriteLine("Overlaps = {0}", numOverlap);
        }
        public void Part2()
        {
            int numOverlap = 0;
            string[] input = File.ReadAllLines("input.txt");
            foreach (string line in input)
            {
                string[] assignments = line.Split(',');
                int bottonRange1 = Int32.Parse(assignments[0].Split('-')[0]);
                int topRange1 = Int32.Parse(assignments[0].Split('-')[1]);
                int bottonRange2 = Int32.Parse(assignments[1].Split('-')[0]);
                int topRange2 = Int32.Parse(assignments[1].Split('-')[1]);
                if (bottonRange1 <= bottonRange2 && topRange1 >= topRange2) { numOverlap++; } // 1 encompasses 2
                else if (bottonRange2 <= bottonRange1 && topRange2 >= topRange1) { numOverlap++; } // 2 encompasses 1
                else if(bottonRange1 <= bottonRange2 && topRange1 >= bottonRange2) { numOverlap++; } //partial overlap on the bottom
                else if(bottonRange1 <= topRange2 && topRange1 >= topRange2) { numOverlap++; } //partial overlap on the top
            }
            Console.WriteLine("Overlaps = {0}", numOverlap);
        }
    }
}
