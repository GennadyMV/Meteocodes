using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codes.Models;
using System.IO;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] filePaths = Directory.GetFiles(@"\\192.168.72.123\obmen\Zyryanov\SpecialPoints\data\2015\04", "*07042015_12.txt",
                                         SearchOption.AllDirectories);
            int count = 0;
            foreach (var name in filePaths)
            {
                System.IO.StreamReader file = new System.IO.StreamReader(name);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Substring(0, 4) == "TTAA")
                    {
                        count++; 
                    }
                }

                file.Close();
            }

            int i = 0;
            foreach (var name in filePaths)
            {
                System.IO.StreamReader file = new System.IO.StreamReader(name);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Substring(0, 4) == "TTAA")
                    {
                        i++;
                        Console.WriteLine("{0} из {1}", i, count);
                        Parser.Parser.Razdel01(line);
                    }
                }

                file.Close();
            }


            //Parser.Parser.Razdel01(rawData);


            


            Console.ReadKey();
        }
    }
}
