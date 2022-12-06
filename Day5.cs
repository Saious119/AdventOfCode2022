using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day5
    {
        List<string> stack1 = new List<string>();
        List<string> stack2 = new List<string>();
        List<string> stack3 = new List<string>();
        List<string> stack4 = new List<string>();
        List<string> stack5 = new List<string>();
        List<string> stack6 = new List<string>();
        List<string> stack7 = new List<string>();
        List<string> stack8 = new List<string>();
        List<string> stack9 = new List<string>();
        int quantity;
        int from;
        int to;
        public void Part1()
        {
            initStacks();
            string[] input = File.ReadAllLines("input.txt");
            foreach(string line in input)
            {
                string[] parts = line.Split(' ');
                parseInstructions(parts);
                List<string> origin = GetStack(from);
                List<string> destination = GetStack(to);
                for(int i=0; i< quantity; i++)
                {
                    destination.Reverse();
                    destination.Add(origin.First());
                    destination.Reverse();
                    origin.Remove(origin.First());
                }
                syncStacks(origin, destination);
            }
            Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}", stack1.First(), stack2.First(), stack3.First(), stack4.First(), stack5.First(), stack6.First(), stack7.First(), stack8.First(), stack9.First());
        }
        public void initStacks()
        {
            //stack 1
            stack1.Add("Z");
            stack1.Add("V");
            stack1.Add("T");
            stack1.Add("B");
            stack1.Add("J");
            stack1.Add("G");
            stack1.Add("R");
            //stack 2
            stack2.Add("L");
            stack2.Add("V");
            stack2.Add("R");
            stack2.Add("J");
            //stack 3
            stack3.Add("F");
            stack3.Add("Q");
            stack3.Add("S");
            //stack 4
            stack4.Add("G");
            stack4.Add("Q");
            stack4.Add("V");
            stack4.Add("F");
            stack4.Add("L");
            stack4.Add("N");
            stack4.Add("H");
            stack4.Add("Z");
            //stack 5
            stack5.Add("W");
            stack5.Add("M");
            stack5.Add("S");
            stack5.Add("C");
            stack5.Add("J");
            stack5.Add("T");
            stack5.Add("Q");
            stack5.Add("R");
            //stack 6
            stack6.Add("F");
            stack6.Add("H");
            stack6.Add("C");
            stack6.Add("T");
            stack6.Add("W");
            stack6.Add("S");
            //stack 7
            stack7.Add("J");
            stack7.Add("N");
            stack7.Add("F");
            stack7.Add("V");
            stack7.Add("C");
            stack7.Add("Z");
            stack7.Add("D");
            //stack 8
            stack8.Add("Q");
            stack8.Add("F");
            stack8.Add("R");
            stack8.Add("W");
            stack8.Add("D");
            stack8.Add("Z");
            stack8.Add("G");
            stack8.Add("L");
            //stack 9
            stack9.Add("P");
            stack9.Add("V");
            stack9.Add("W");
            stack9.Add("B");
            stack9.Add("J");
        }
        public void parseInstructions(string[] parts)
        {
            quantity = Int32.Parse(parts[1]);
            from = Int32.Parse(parts[3]);
            to = Int32.Parse(parts[5]);
        }
        public List<string> GetStack(int index)
        {
            if(index == 1) { return stack1; }
            if(index == 2) { return stack2; }
            if(index == 3) { return stack3; }
            if(index == 4) { return stack4; }
            if(index == 5) { return stack5; }
            if(index == 6) { return stack6; }
            if(index == 7) { return stack7; }
            if(index == 8) { return stack8; }
            if(index == 9) { return stack9; }
            return stack1; //should never reach here
        }
        public void syncStacks(List<string> origin, List<string> destination)
        {
            if(from == 1) { stack1 = origin; }
            if(from == 2) { stack2 = origin; }
            if(from == 3) { stack3 = origin; }
            if(from == 4) { stack4 = origin; }
            if(from == 5) { stack5 = origin; }
            if(from == 6) { stack6 = origin; }
            if(from == 7) { stack7 = origin; }
            if(from == 8) { stack8 = origin; }
            if(from == 9) { stack9 = origin; }
            if(to == 1) { stack1 = destination; }
            if(to == 2) { stack2 = destination; }
            if(to == 3) { stack3 = destination; }
            if(to == 4) { stack4 = destination; }
            if(to == 5) { stack5 = destination; }
            if(to == 6) { stack6 = destination; }
            if(to == 7) { stack7 = destination; }
            if(to == 8) { stack8 = destination; }
            if(to == 9) { stack9 = destination; }
        }
        public void Part2()
        {
            initStacks();
            string[] input = File.ReadAllLines("input.txt");
            foreach (string line in input)
            {
                string[] parts = line.Split(' ');
                parseInstructions(parts);
                List<string> origin = GetStack(from);
                List<string> destination = GetStack(to);
                List<string> TempStack = new List<string>();
                for (int i = 0; i < quantity; i++)
                {
                    TempStack.Add(origin.First());
                    origin.Remove(origin.First());
                }
                TempStack.Reverse();
                int counter = TempStack.Count();
                for (int i = 0; i < counter; i++)
                {
                    destination.Reverse();
                    destination.Add(TempStack.First());
                    destination.Reverse();
                    TempStack.Remove(TempStack.First());
                }
                syncStacks(origin, destination);
            }
            Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}", stack1.First(), stack2.First(), stack3.First(), stack4.First(), stack5.First(), stack6.First(), stack7.First(), stack8.First(), stack9.First());

        }
    }
}
