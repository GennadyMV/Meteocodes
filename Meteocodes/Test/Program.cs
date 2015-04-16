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
           // Parser.Parser.Razdel01(2015, 4, 09, "TTAA 09121 21432 99028 20120 23511 00224 15918 25016 92815 13934 26014 85458 15156 26513 70903 20556 28509 50532 35730 34012 40684 45924 00519 30869 61524 01028 25980 67923 01021 20116 64127 02512 15292 61927 05503 10547 56533 17012 88266 67523 01027 77999=");
           // return;

            string[] filePaths = Directory.GetFiles(@"\\192.168.72.123\obmen\Zyryanov\SpecialPoints\data\2015\04", "*_12.txt",
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
                        FileInfo fi = new FileInfo(name);

                        int day = Convert.ToInt32(fi.Name.Substring(9, 2));
                        int month = Convert.ToInt32(fi.Name.Substring(11, 2));
                        int year = Convert.ToInt32(fi.Name.Substring(13, 4));
                        
                        Parser.Parser.Razdel01(year, month, day, line);
                    }
                }

                file.Close();
            }



            Console.ReadKey();
        }
    }
}
