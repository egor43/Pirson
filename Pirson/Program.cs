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
            try
            {
                Pirson pirson_obj = new Pirson(100, 0, 24);
                Console.WriteLine("Количество элементов: " + pirson_obj.ElementCount);
                Console.WriteLine("Минимальное количество элементов, которые должны быть в каждом интервале: " + pirson_obj.MinCountElementInInterval);
                Console.WriteLine("Общее время работы: " + pirson_obj.AllWorkTime);
                Console.WriteLine("Максимальное количество интервалов: " + pirson_obj.MaxIntervalsCount);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
