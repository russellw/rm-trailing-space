using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rm_trailing_space
{
    class Program
    {
        static bool isBinary(string path)
        {
            var bytes = File.ReadAllBytes(path);
            foreach (var b in bytes)
                if (b == 0)
                    return true;
            return false;
        }

        static void Main(string[] args)
        {
            foreach (var path in args)
            {
                if (isBinary(path))
                {
                    Console.WriteLine("{0}: binary file", path);
                    continue;
                }
                var contents = File.ReadAllLines(path);
                var changed = false;
                for (int i = 0; i < contents.Length; i++)
                {
                    var s = contents[i].TrimEnd(null);
                    if (s != contents[i])
                    {
                        contents[i] = s;
                        changed = true;
                    }
                }
                if (changed)
                {
                    Console.WriteLine(path);
                    File.WriteAllLines(path, contents);
                }
            }
        }
    }
}
