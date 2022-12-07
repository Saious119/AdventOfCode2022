using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day6
    {
        public int markerCounter = 14;
        public void Part1() //and 2
        {
            string[] input = File.ReadAllLines("input.txt");
            List<char> buffer = new List<char>();
            List<char> seen = new List<char>();
            int counter = 0;
            foreach(char c in input[0])
            {
                counter++;
                buffer.Add(c);
                if(buffer.Count() > markerCounter)
                {
                    buffer.RemoveAt(0);
                }
                foreach(char L in buffer)
                {
                    if(seen.Contains(L) == false)
                    {
                        seen.Add(L);
                        if(seen.Count() == markerCounter)
                        {
                            Console.WriteLine("Counter = {0}", counter);
                            return;
                        }
                    }
                }
                seen.Clear();
            }
            Console.WriteLine("None found"); // shouldn't get here
        }
    }
}