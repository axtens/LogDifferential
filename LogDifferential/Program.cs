using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace LogDifferential
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("LogDifferential logfile");
                Environment.Exit(1);
            }

            CultureInfo provider = CultureInfo.InvariantCulture;
            var logLines = File.ReadAllLines(args[0]);
            for (var i = 0; i < logLines.Length - 1; i++)
            {
                var first = logLines[i];
                var second = logLines[i + 1];
                var firstParts = first.Split(new char[] { '\t' }, 2);
                var secondParts = second.Split(new char[] { '\t' }, 2);
                //var firstTime = Convert.ToDateTime(firstParts[0]);
                //var secondTime = Convert.ToDateTime(secondParts[0]);
                var firstTime = DateTime.ParseExact(firstParts[0],"o",null);
                var secondTime = DateTime.ParseExact(secondParts[0], "o", null);

                var timeDiff = secondTime.Subtract(firstTime);
                Console.WriteLine($"{timeDiff}\t{firstParts[1]}");
            }
        }
    }
}
