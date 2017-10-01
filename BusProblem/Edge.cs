
namespace BusProblem
{
    /// <summary>
    /// Класс реализующий ребро графа, или маршрут между 2 остановками
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// Остановка от которой идет автобус
        /// </summary>
        public Vertex from;
        /// <summary>
        /// Остановка к которой идет автобус
        /// </summary>
        public Vertex to;
        /// <summary>
        /// Автобус
        /// </summary>
        public Bus bus;
        /// <summary>
        /// Время в пути
        /// </summary>
        public int time;
        /// <summary>
        /// Индикатор состояния маршрута (был ли он уже проверен)
        /// </summary>
        public bool isChecked;

        /// <summary>
        /// Конструктор класса с наполнением экземпляра
        /// </summary>
        /// <param name="fromStop">Начальная остановка</param>
        /// <param name="toStop">Конечная остановка</param>
        /// <param name="b">Автобус</param>
        /// <param name="timeRoute">Время в пути</param>
        public Edge(Vertex fromStop, Vertex toStop, Bus b, int timeRoute)
        {
            from = fromStop;
            to = toStop;
            bus = b;
            time = timeRoute;
        }
    }
}
