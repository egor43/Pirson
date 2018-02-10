using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pirson
{
    class Program
    {
        // Метод считает длину интервала
        static double GetIntervalLength(int max_interval_count, int interval_count)
        {
            if (interval_count <= max_interval_count)
            {
                return (double)max_interval_count / interval_count;
            }
            throw new ArgumentException("Uncorrect argument");
        }

        // Метод проверяет, присутствует ли во всех интервалах определнной длины минимальное количество элементов 
        static bool AllIntervalsFill(int[] sequence, double interval_length, int min_elements_in_interval)
        {
            double left_border = 0; // Левая граница интервала
            double right_border = interval_length; // Правая граница интервала
            int current_element_count = 0; // Текущее количество элементов в интервале

            foreach (var element in sequence)
            {
                if(element >= left_border && element <= right_border) // Если элемент входит в текущий интервал
                {
                    current_element_count++; // Увеличиваем счетчик текущих элементов интервала
                }
                else
                {
                    if (current_element_count < min_elements_in_interval) // Если в интервале оказалось меньше элементов
                    {
                        return false;
                    }
                    else // Иначе переходим к следующему интервалу и сбрасываем счетчик
                    {
                        left_border += interval_length;
                        right_border += interval_length;
                        current_element_count = 0;

                        // Проверяем текущий элемент на принадлежность новому интервалу
                        if (element >= left_border && element <= right_border) // Если элементо входит в интервал
                        {
                            current_element_count++; // Уведичиваем счетчик текущих элементов интервала
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            
            return true;
        } 

        static void Main(string[] args)
        {
            const int N = 1000; // Количество элементов
            const int MIN_ELEMENTS_IN_INTERVAL = 5; // МИнимальное количество элементов, которые должны быть в каждом интервале

            Random rand = new Random();
            int[] numbers = new int[N]; // Массив элементов

            int max_intervals_count = 0; // Максимальное количество интервалов (равно общему времени)

            // Вычисляем время работы элемента относительно предыдущего и, попутно, считаем общее время (максимальное количество интервалов)
            for (int index = 0; index < numbers.Length; ++index)
            {
                max_intervals_count += rand.Next(24);
                numbers[index] = max_intervals_count;
                if (index < 10)
                {
                    Console.Write(numbers[index] + " ");
                }
                else if (index == 10)
                {
                    Console.Write("... ");
                }
            }

            Console.WriteLine();

            Console.WriteLine("Общее время: " + max_intervals_count);

            int current_intervals_count = max_intervals_count; // Задаем начальное количество интервалов

            for (;current_intervals_count > 1; --current_intervals_count)
            {
                double interval_length = GetIntervalLength(max_intervals_count, current_intervals_count); // Считаем длину одного интервала
                if (AllIntervalsFill(numbers, interval_length, MIN_ELEMENTS_IN_INTERVAL))
                {
                    break;
                }
            }

            Console.WriteLine("Максимальное количество интервалов: " + current_intervals_count);

            Console.ReadLine();
        }
    }
}
