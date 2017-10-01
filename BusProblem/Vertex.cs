using System;
using System.Collections.Generic;

namespace BusProblem
{
    /// <summary>
    /// Класс реализующий вершину графа, или остановку
    /// </summary>
    public class Vertex //вершина
    {
        /// <summary>
        /// Номер остановки
        /// </summary>
        public int num;
        /// <summary>
        /// Время, когда на остановке останавливается автобус текущего маршрута
        /// </summary>
        public int timeOfStop;
        /// <summary>
        /// Стоимость проезда до текущей остановки
        /// </summary>
        public int costOfStop;
        /// <summary>
        /// Индикатор состояния вершины (была ли она уже проверена)
        /// </summary>
        public bool isChecked;
        /// <summary>
        /// Список ребер (текущий маршрут до остановки)
        /// </summary>
        public List<Edge> minRoute;

        public Vertex()
        {

        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="n">Номер остановки</param>
        public Vertex(int n)
        {
            num = n;
            timeOfStop = 0;
            isChecked = false;
            minRoute = new List<Edge>();
        }
    }
}
