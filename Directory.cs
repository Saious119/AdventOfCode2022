using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Directory
    {
        public string name { get; set; }
        public List<Directory> dirs = new List<Directory>();
        public List<KeyValuePair<string, int>> files = new List<KeyValuePair<string, int>> (); //string is file name, int is size of file
        public Directory(string name)
        {
            this.name = name;
        }
        public void Sync(string name, List<Directory> dirs, List<KeyValuePair<string, int>> files)
        {
            this.name = name;
            this.dirs = dirs;
            this.files = files;
        }
        public int DirSize()
        {
            int sum = 0;
            foreach(KeyValuePair<string, int> file in files)
            {
                sum += file.Value;
            }
            return sum;
        }
    }
}
