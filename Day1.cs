using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day1
    {
        public void run()
        {
            string[] input = File.ReadAllLines("input.txt");
            List<int> list = new List<int>();
            int num = 0;
            foreach(string line in input)
            {
                if(line != "")
                {
                    num += Int32.Parse(line);
                }
                if(line == "")
                {
                    list.Add(num);
                    num = 0;
                }
            }
            int max1 = list.Max();
            list.Remove(max1);
            int max2 = list.Max();
            list.Remove(max2);
            int max3 = list.Max();
            int total = max1 + max2 + max3;
            Console.WriteLine(total.ToString());
        }
    }
}
