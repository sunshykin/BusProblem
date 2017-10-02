using System;
using System.Collections.Generic;
using System.Linq;

namespace BusProblem
{
    /// <summary>
    /// Класс расширений
    /// </summary>
    public static class Extentions
    {
        /// <summary>
        /// Получение стоимости проезда по маршруту с учетом следующей станции
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Текущий маршрут (список ребер)</param>
        /// <param name="end">Следующая станция</param>
        /// <param name="bus">Автобус</param>
        /// <returns>Стоимость в рублях</returns>
        public static int GetCost<T>(this List<T> list, T end, Bus[] bus)
            where T : Edge
        {
            List<T> full = new List<T>();
            full.AddRange(list);
            full.Add(end);
            int sum = full[0].bus.cost;
            for (int i = 1; i < full.Count; i++)
                if (full[i].bus != full[i-1].bus)
                    sum += full[i].bus.cost;
            return sum;
        }

        /// <summary>
        /// Получение следующей проверяемой вершины (остановки)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Список вершин</param>
        /// <param name="edges">Список ребер</param>
        /// <returns>Возвращает ссылку на следующую вершину</returns>
        public static Vertex GetNextVertex<T>(this List<T> list, List<Edge> edges, bool byTime)
            where T : Vertex
        {
            list = list.Where(x => !x.isChecked && (byTime ? x.timeOfStop != 0 : x.costOfStop != 0)).ToList();

            int min = Int32.MaxValue;
            Vertex result = new Vertex();
            foreach (var v in list)
            {
                //Проверяем вершину по минимальному весу
                int weight = byTime ? v.timeOfStop : v.costOfStop;
                if (weight < min)
                {
                    min = weight;
                    result = v;
                }
            }
            return result;
        }
    }
}
