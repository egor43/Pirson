using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pirson;

namespace Pirson
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Максимальное количество интервалов: " + new Pirson(100,5).GetMaxCountIntervals());

            Console.ReadLine();
        }
    }
}
