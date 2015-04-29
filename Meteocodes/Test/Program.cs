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
            //Parser.Parser.Razdel01(2015, 4, 09, "TTAA 13001 24688 99925 18756 00000 00150 ///// ///// 92737 ///// ///// 85367 16757 23001 70803 22957 12005 50519 38357 05003 40669 48557 48957 13005 30853 591// ///// 25967 57957 ///// 20109 54559 09505 15293 52761 09005 88303 589// ///// 77999=");
            //return;

            string[] filePaths = Directory.GetFiles(@"\\192.168.72.123\obmen\Zyryanov\SpecialPoints\data\2015\04", "*.txt",
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

                        try
                        {
                            Parser.Parser.Razdel01(year, month, day, line);
                        }
                        catch (Exception ex)
                        {
                            Codes.Models.Error err = new Codes.Models.Error();
                            err.Raw = line;
                            err.Description = ex.Message;
                            err.Save();
                            
                        }
                    }
                }

                file.Close();
            }



            Console.ReadKey();
        }
    }
}
