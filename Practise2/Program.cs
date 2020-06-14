using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Practise2
{
    class Program
    {
        static void Main(string[] args)
        {
            MatchCollection input;
            string output = "YES";

            string line = Console.ReadLine();

            if (Char.IsDigit(line[0]))
            {
                output = "NO";
                Console.WriteLine(output);
                return;
            }

            input = Regex.Matches(line, @"[A-Z][a-z]*[0-9]*");

            Match num = Regex.Match(input[0].ToString(), @"[0-9]+");

            if (num.ToString() != "" &&
                (num.ToString()[0] == '0' || (num.ToString().Length == 1 && num.ToString() == "1")))
            {
                output = "NO";
                Console.WriteLine(output);
                return;
            }

            for (int i = 0; i < input.Count - 1; i++)
            {
                num = Regex.Match(input[i].ToString(), @"[0-9]+");

                if (num.ToString() != "" &&
                    (num.ToString()[0] == '0' || (num.ToString().Length == 1 && num.ToString() == "1")))
                {
                    output = "NO";
                    break;
                }

                if (Regex.Match(input[i].ToString(), @"[A-Z][a-z]*").ToString() ==
                    Regex.Match(input[i + 1].ToString(), @"[A-Z][a-z]*").ToString())
                {
                    output = "NO";
                    break;
                }
            }

            Console.WriteLine(output);
        }
    }
}