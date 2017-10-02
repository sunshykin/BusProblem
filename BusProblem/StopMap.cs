using System;
using System.Collections.Generic;
using System.Linq;

namespace BusProblem
{
    /// <summary>
    /// Класс реализующий карту всех остановок и маршрутов
    /// </summary>
    public class StopMap
    {
        /// <summary>
        /// Массив автобусов
        /// </summary>
        private Bus[] busses;
        /// <summary>
        /// Список вершин/остановок
        /// </summary>
        private List<Vertex> stops;
        /// <summary>
        /// Список ребер/маршрутов
        /// </summary>
        private List<Edge> routes;
        /// <summary>
        /// Начальная остановка
        /// </summary>
        private Vertex startVertex;
        /// <summary>
        /// Конечная остановка
        /// </summary>
        private Vertex endVertex;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="arr">Массив автобусов</param>
        /// <param name="stopCount">Количество остановок</param>
        public StopMap(Bus[] arr, int stopCount)
        {
            busses = arr;
            stops = new List<Vertex>();
            routes = new List<Edge>();
            for (int i = 1; i <= stopCount; i++)
                stops.Add(new Vertex(i));
            FillRoutes();
        }

        /// <summary>
        /// Наполнение маршрутов
        /// </summary>
        private void FillRoutes()
        {
            foreach (var b in busses)
            {
                for (int i = 0; i < b.stop.Length; i++)
                {
                    if (i != b.stop.Length - 1)
                        routes.Add(new Edge(stops.Find(x => x.num == b.stop[i]),
                            stops.Find(x => x.num == b.stop[i+1]), b, b.travel[i]));
                    else
                        routes.Add(new Edge(stops.Find(x => x.num == b.stop[i]),
                            stops.Find(x => x.num == b.stop[0]), b, b.travel[i]));
                }
            }
        }

        /// <summary>
        /// Поиск маршрута
        /// </summary>
        /// <param name="startTime">Время, когда пассажир подходит к остановке</param>
        /// <param name="startPoint">Начальная остановка</param>
        /// <param name="endPoint">Конечная остановка</param>
        /// <param name="byTime">Индикатор режима поиска (дешевый или быстрый)</param>
        /// <returns></returns>
        public List<Edge> FindRoute(int startTime, int startPoint, int endPoint, bool byTime)
        {
            startVertex = stops.Find(x => x.num == startPoint);
            startVertex.timeOfStop = startTime;
            endVertex = stops.Find(x => x.num == endPoint);
            //Текуща проверяемая вершина
            Vertex curVertex = startVertex;
            //пока мы не дошли до конечной вершины
            while (curVertex != endVertex)
            {
                //ребра, в которых текущая остановка начальная
                var curRoutes = routes.Where(x => x.from == curVertex).ToList();
                foreach (var r in curRoutes)
                {
                    r.isChecked = true;
                    int newTime = r.bus.TimeOfStop(r.from.timeOfStop + r.time, r.to.num);
                    //Если во время пути часы покажут за полночь (и все автобусы перестанут ездить)
                    if (newTime > 1440 || newTime < startTime)
                        continue;
                    if (byTime) //если расчет по времени
                    {
                        //Если в вершине 0 (еще не было маршрутов к ней) или время меньше
                        if (r.to.timeOfStop == 0 || newTime < r.to.timeOfStop)
                        {
                            //Заменяем путь, если он был, на более быстрый
                            r.to.minRoute.Clear();
                            r.to.timeOfStop = newTime;
                            if (r.from.minRoute.Count > 0)
                                r.to.minRoute.AddRange(r.from.minRoute);
                            r.to.minRoute.Add(r);
                        }
                    }
                    else    //если рассчет по стоимости
                    {
                        int newCost = r.from.minRoute.GetCost(r, busses);
                        //Если в вершине 0 (еще не было маршрутов к ней) или цена меньше
                        if (r.to.costOfStop == 0 || newCost < r.to.costOfStop)
                        {
                            //Заменяем путь, если он был, на более дешевый
                            r.to.minRoute.Clear();
                            r.to.timeOfStop = newTime;
                            r.to.costOfStop = newCost;
                            if (r.from.minRoute.Count > 0)
                                r.to.minRoute.AddRange(r.from.minRoute);
                            r.to.minRoute.Add(r);
                        }
                    }
                }
                //Прошли все пути вершины и пометили ее
                curVertex.isChecked = true;
                //Подбираем следующую вершину для проверки
                curVertex = stops.GetNextVertex(routes, byTime);
            }
            return endVertex.minRoute;
        }

        /// <summary>
        /// Нахождение наименьшего времени отправления автобусов
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetLowestUpTime()
        {
            int min = busses.Min(x => x.startTime);
            return TimeSpan.FromMinutes(min);
        }

        /// <summary>
        /// Очистка экземпляра класса для проведения другого поиска
        /// </summary>
        public void Clean()
        {
            foreach (var v in stops)
            {
                v.costOfStop = 0;
                v.timeOfStop = 0;
                v.minRoute.Clear();
                v.isChecked = false;
            }
            foreach (var e in routes)
            {
                e.isChecked = false;
            }
        }

        /// <summary>
        /// Нахождение номера автобуса
        /// </summary>
        /// <param name="b">Автобус</param>
        /// <returns>Номер автобуса</returns>
        public int NumOfBus(Bus b)
        {
            int i = 0;
            for (i = 0; i < busses.Length; i++)
            {
                if (busses[i] == b)
                    break;
            }
            return i + 1;
        }
    }
}
