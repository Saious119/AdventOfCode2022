using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day2
    {
        private static int score = 0;
        public void Part1()
        {
            string[] input = File.ReadAllLines("input.txt");
            foreach(string line in input)
            {
                string[] choice = line.Split(' ');
                score += choice[1].ToCharArray()[0] - 87;
                if (((choice[1].ToCharArray()[0] - 23) - (choice[0].ToCharArray()[0]-0)) == 1 || ((choice[1].ToCharArray()[0] - 23) - (choice[0].ToCharArray()[0] - 0)) == -2) { score += 6; } //win
                if (((choice[1].ToCharArray()[0] - 23) - (choice[0].ToCharArray()[0]-0)) == 0) { score += 3; } //tie
            }
            Console.WriteLine("Score = {0}", score);
        }
        public void Part2()
        {
            string[] input = File.ReadAllLines("input.txt");
            int TotalScore = 0;
            foreach (string line in input)
            {
                int yourScore = 0;
                string[] choice = line.Split(' ');
                int theirMove = choice[0].ToCharArray()[0] - 64;
                if (choice[1] == "X") //lose 
                {
                    yourScore = theirMove - 1;
                    if(yourScore < 1) { yourScore = 3; }
                }
                else if(choice[1] == "Y")
                {
                    yourScore = theirMove;
                    yourScore += 3; //draw

                }
                else if (choice[1] == "Z")
                {
                    yourScore = theirMove + 1;
                    if(yourScore > 3) { yourScore = 1; }
                    yourScore += 6; //win
                }
                TotalScore += yourScore;
            }
            Console.WriteLine("Score = {0}", TotalScore);
        }
    }
}
