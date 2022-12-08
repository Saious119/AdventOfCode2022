using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2022.Directory;

namespace AdventOfCode2022
{
    internal class Day7 //incomplete 
    {
        List<Directory> directories = new List<Directory>();
        Directory currDir;
        string loc = "";
        public void Part1()
        {
            int totalSum = 0;
            string[] input = File.ReadAllLines("input.txt");
            int lineNum = 1;
            InitRoot();
            foreach(string inp in input) //build tree
            {
                try
                {
                    if (inp.Contains("$"))
                    {
                        Console.WriteLine("cmd detected");
                        HandleCommand(inp);
                    }
                    else if (inp.Contains("dir"))
                    {
                        Console.WriteLine("dir cmd");
                        string[] cmd = inp.Split(" ");
                        string newDirName = loc;

                        directories.Add(new Directory(loc));
                        currDir.dirs.Add(new Directory(loc));
                        SyncDir();
                    }
                    else
                    {
                        string[] fileDetails = inp.Split(" ");
                        currDir.files.Add(new KeyValuePair<string, int>(fileDetails[1], Int32.Parse(fileDetails[0])));
                        SyncDir();
                    }
                    lineNum++;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception on line {0}, with error:\n{1}", lineNum, e.ToString());
                    return;
                }
            }
            SyncDir();
            Console.WriteLine("Summing...");
            foreach(Directory dir in directories)
            {
                Console.WriteLine("Summing dir {0}...", dir.name);
                int subdirSize = 0;
                foreach(Directory sd in dir.dirs)
                {
                    subdirSize += directories.Where(x => x.name == sd.name).First().DirSize();
                }
                if (dir.DirSize()+subdirSize <= 100000)
                {
                    totalSum += dir.DirSize()+subdirSize;
                }
                Console.WriteLine("Dir {0}, size = {1}", dir.name, dir.DirSize());
            }
            Console.WriteLine("Size = {0}", totalSum);
        }
        public void HandleCommand(string input)
        {
            if (input.Contains("cd"))
            {
                SyncDir();
                string[] cmd = input.Split(" ");
                if (input.Contains(".."))
                {
                    foreach(Directory d in directories)
                    {
                        if(d.dirs.Where(x => x.name == currDir.name) != null)
                        {
                            currDir = d;
                            Console.WriteLine("currDir = {0}", currDir.name);
                            return;
                        }
                    }
                    loc.Reverse();
                    for(int i = 0; i< loc.Length;)
                    {
                        if (loc[i] != '/')
                        {
                            loc = loc[(i + 1)..loc.Length];
                        }
                        else
                        {
                            break;
                        }
                    }
                    loc.Reverse();
                }
                if (directories.FindAll(n => n.name == cmd[2]).Count() > 0)
                {
                    SyncDir();
                    currDir = directories.Where(x => x.name == cmd[2]).First();
                    loc = cmd[2];
                }
                else
                {
                    loc += "/" + cmd[2];
                    directories.Add(new Directory(loc));
                    currDir.dirs.Add(new Directory(loc));
                    SyncDir();
                    currDir = directories.Where(x => x.name == cmd[2]).First();
                }
                Console.WriteLine("currDir = {0}", currDir.name);
            }
            if (input.Contains("ls"))
            {
                return; //nothing needs to be done, just fluff
            }
        }
        public void SyncDir() //sets the dir in dir list with curr dir values based on currDir name
        {
            directories.Find(x => x.name == currDir.name).Sync(currDir.name, currDir.dirs, currDir.files);

        }
        public void InitRoot()
        {
            currDir = new Directory("/");
            directories.Add(currDir);
        }
        public string GetPath(string newDirName)
        {
            if (newDirName == "/") { return newDirName; }
            newDirName = GetPath(directories.Where(x => x.name == currDir.name).First().name) + "/" + newDirName;
            return newDirName += "/";
        }
    }
}
