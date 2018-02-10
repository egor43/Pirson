using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pirson
{
    class Pirson
    {
        private int? element_count = null; // Количество элементов
        private int? min_count_element_in_interval = null; // Минимальное количество элементов, которые должны быть в каждом интервале
        private int? max_intervals_count = null; // Максимальное количество интервалов
        private int all_work_time = 0; // Общее время работы

        private List<int> numbers = new List<int>(); // Список элементов

        // Метод считает длину интервала
        private double GetIntervalLength(int max_interval_count, int interval_count)
        {
            if (interval_count <= max_interval_count)
            {
                return (double)max_interval_count / interval_count;
            }
            throw new ArgumentException("Uncorrect argument");
        }

        // Метод проверяет, присутствует ли во всех интервалах определнной длины минимальное количество элементов 
        private bool AllIntervalsFill(int[] sequence, double interval_length, int min_elements_in_interval)
        {
            double left_border = 0; // Левая граница интервала
            double right_border = interval_length; // Правая граница интервала
            int current_element_count = 0; // Текущее количество элементов в интервале

            foreach (var element in sequence)
            {
                if (element >= left_border && element <= right_border) // Если элемент входит в текущий интервал
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

            if (current_element_count < min_elements_in_interval) // Если в последнем интервале оказалось меньше элементов
            {
                return false;
            }

            return true;
        }

        public Pirson(int element_count, int min_count_element_in_interval, int max_random_interval)
        {
            this.element_count = element_count;
            this.min_count_element_in_interval = min_count_element_in_interval;

            Random rand = new Random();

            // Вычисляем время работы элемента относительно предыдущего и, попутно, считаем общее время (максимальное количество интервалов)
            for (int index = 0; index < element_count; ++index)
            {
                all_work_time += rand.Next(max_random_interval);
                numbers.Add((int)all_work_time);
            }
        }

        // Возвращает максимальное количество интервалов в которых не меньше чем min_count_element_in_interval элементов
        public int GetMaxCountIntervals()
        {
            // Проверим, корректны ли внутренние параметы
            if (element_count.HasValue && min_count_element_in_interval.HasValue)
            {
                // Если значение уже считали - отдаем его
                if(max_intervals_count.HasValue)
                {
                    return (int)max_intervals_count;
                }

                // Подсчет максимального количеств интервалов
                for (int current_intervals_count = (int)all_work_time; current_intervals_count > 1; --current_intervals_count)
                {
                    double interval_length = GetIntervalLength((int)all_work_time, current_intervals_count); // Считаем длину одного интервала
                    if (AllIntervalsFill(numbers.ToArray(), interval_length, (int)min_count_element_in_interval))
                    {
                        max_intervals_count = current_intervals_count;
                        break;
                    }
                }
                return (int)max_intervals_count;
            }
            else
            {
                throw new InvalidOperationException("Access to an uninitialized variable");
            }      
        }      

        // Геттер для количества элементов
        public int ElementCount
        {
            get
            {
                if (element_count.HasValue)
                {
                    return (int)element_count;
                }
                throw new InvalidOperationException("Access to an uninitialized variable");
            }
        }

        // Геттер для максимального количества интервалов
        public int MaxIntervalsCount
        {
            get
            {
                return GetMaxCountIntervals();
            }
        }

        // Геттер для минимального количества элементов, которые должны быть в каждом интервале
        public int MinCountElementInInterval
        {
            get
            {
                if (min_count_element_in_interval.HasValue)
                {
                    return (int)min_count_element_in_interval;
                }
                throw new InvalidOperationException("Access to an uninitialized variable");
            }
        }

        // Геттер для общего времени элеметнов
        public int AllWorkTime
        {
            get
            {
                return all_work_time;
            }
        }
    }
}
