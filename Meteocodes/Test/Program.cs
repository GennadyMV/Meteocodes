using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codes.Models;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            string rawData = "TTAA 01001 23078 99009 17519 11008 00126 17112 12510 92714 13304 19511 85356 15711 22010 70802 22116 27010 50522 31522 31521 40676 42524 32028 30865 56530 32542 25978 64335 32543 20113 68538 32538 15286 67136 32536 10528 71739 32538 88214 68337 32542 77278 33047=";

            


            Parser.Parser.Razdel01(rawData);


            


            Console.ReadKey();
        }
    }
}
