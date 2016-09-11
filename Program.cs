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
            var content = File.ReadAllBytes(path);
            foreach (var x in content)
                if (x == 0)
                    return true;
            return false;
        }

        static void Main(string[] args)
        {
            foreach(var path in args)
            {
                if(isBinary(path))
                {
                    Console.WriteLine("{0}: binary file", path);
                    continue;
                }
                var lines = File.ReadAllLines(path, Encoding.UTF8);
                var changed = false;
                for(int i=0;i<lines.Length;i++)
                {
                    var s = lines[i].TrimEnd(null);
                    if(s!=lines[i])
                    {
                        lines[i] = s;
                        changed = true;
                    }
                }
                if(changed)
                {
                    Console.WriteLine(path);
                    File.WriteAllLines(path, lines, Encoding.UTF8);
                }
            }
        }
    }
}
