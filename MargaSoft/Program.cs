using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MargaSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello please provide a number of test:");
            int arrayCount;
            if(!Int32.TryParse(Console.ReadLine(), out arrayCount))
            {
                Console.WriteLine("First argument must be integer");
                Environment.Exit(1);
            }
            if (arrayCount > 100 ||  arrayCount == 0)
            {
                Console.WriteLine("First argument must be in range 1-100");
                Environment.Exit(1);
            }
            Regex regex = new Regex("^[a-z]{1,100}$");
            List<string> res = new List<string>();
            int index=0;
            for (int i = 0; i < arrayCount; i++)
            {
                Console.WriteLine("Please describe string " + (i + 1));
                string str = Console.ReadLine();
                if (regex.Matches(str).Count == 0)
                {
                    Console.WriteLine("Rock must be a-z from 1-100");
                    Environment.Exit(1);
                }
                Console.WriteLine("Please provide index of char " + (i + 1));
                if (!Int32.TryParse(Console.ReadLine(), out index))
                {
                    Console.WriteLine("Index must be integer");
                    Environment.Exit(1);
                }
                while (str.Length != 0)
                {
                    for(int y=0;y< str.Length; y++)
                    {
                        res.Add(str.Substring(0, str.Length - y));
                    }
                    str = str.Substring(1,str.Length-1);
                }
                res.Sort();
                Console.WriteLine(string.Join("", res).Substring(index - 1, 1));
                res.Clear();
            }
            Console.ReadLine();
        }
    }
}
