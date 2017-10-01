using System;
using System.Linq;

namespace BusProblem
{
    /// <summary>
    /// Класс реализующий автобус
    /// </summary>
    public class Bus
    {
        /// <summary>
        /// Время выхода на маршрут
        /// </summary>
        public int startTime;
        /// <summary>
        /// Стоимость проезда
        /// </summary>
        public int cost;
        /// <summary>
        /// Массив остановок в порядке проезда
        /// </summary>
        public int[] stop;
        /// <summary>
        /// Массив времени в пути между остановками
        /// </summary>
        public int[] travel;

        public Bus()
        {
        }

        /// <summary>
        /// Наполнение экземпляра класса данными
        /// </summary>
        /// <param name="start">Строка формата hh:mm с временем выхода на маршрут</param>
        /// <param name="cost">СТоимость проезда</param>
        /// <param name="route">Маршрут в виде строки из исходных данных</param>
        public void Fill(string start, string cost, string route)
        {
            startTime = (int) TimeSpan.Parse(start).TotalMinutes;
            this.cost = Convert.ToInt32(cost);
            string[] routeInfo = route.Split(' ');
            int stopCount = Convert.ToInt32(routeInfo[0]);
            stop = routeInfo.Skip(1).Take(stopCount).Select(x => Convert.ToInt32(x)).ToArray();
            travel = routeInfo.Skip(1 + stopCount).Take(stopCount).Select(x => Convert.ToInt32(x)).ToArray();
        }

        /// <summary>
        /// Вычисление времени, когда автобус будет на остановке
        /// </summary>
        /// <param name="userTime">Начальное время, когда пассажир приходит на остановку</param>
        /// <param name="stopNum">Номер автобусной остановки</param>
        /// <returns>Время в виде количества минут от начала дня</returns>
        public int TimeOfStop(int userTime, int stopNum)
        {
            int time = startTime;
            for (int i = 0; i < stop.Length; i++)
            {
                if (stop[i] == stopNum)
                    break;
                time += travel[i];
            }
            while (time < userTime)
                time += travel.Sum();
            return time;
        }

    }
}
