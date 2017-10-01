using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BusProblem
{
    public partial class MainForm : Form
    {
        private StopMap map;

        public MainForm()
        {
            InitializeComponent();
        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePathBox.Text = fileDialog.SafeFileName;
                LoadFile(fileDialog.FileName);
            }
        }

        /// <summary>
        /// Загрузка информации и файла
        /// </summary>
        /// <param name="path">Путь до файла</param>
        private void LoadFile(string path)
        {
            StreamReader stream = new StreamReader(path);
            int busCount = Convert.ToInt32(stream.ReadLine()),
                stopCount = Convert.ToInt32(stream.ReadLine());
            string[] timeArray = stream.ReadLine().Split(' '),
                costArray = stream.ReadLine().Split(' '),
                routeArray = stream.ReadToEnd().Split('\n');
            Bus[] busArray = new Bus[busCount];
            for (int i = 0; i < busCount; i++)
            {
                busArray[i] = new Bus();
                busArray[i].Fill(timeArray[i], costArray[i], routeArray[i].Trim('\r'));
            }
            stream.Close();
            map = new StopMap(busArray, stopCount);
            InitializeSelect(stopCount);
        }

        /// <summary>
        /// Инициализация элементов для выбора пользователя
        /// </summary>
        /// <param name="stopCount">Количество остановок</param>
        private void InitializeSelect(int stopCount)
        {
            startStopLabel.Visible = true;
            startStopCombo.Visible = true;
            endStopLabel.Visible = true;
            endStopCombo.Visible = true;
            timeLabel.Visible = true;
            timePicker.Visible = true;
            searchButton.Visible = true;

            startStopCombo.Items.Clear();
            string[] arr = Enumerable.Range(1, stopCount).Select(x => x.ToString()).ToArray();
            startStopCombo.Items.AddRange(arr);
            endStopCombo.Items.AddRange(arr);

            timePicker.Value = new DateTime(2017, 01, 01) + map.GetLowestUpTime();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timePicker.CustomFormat = "HH:mm";
            timePicker.Format = DateTimePickerFormat.Custom;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if ((string) startStopCombo.SelectedItem == (string) endStopCombo.SelectedItem)
            {
                MessageBox.Show("Начальный и конечный пункты не могут совпадать", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            if ((string) startStopCombo.SelectedItem == "" || (string) endStopCombo.SelectedItem == "")
            {
                MessageBox.Show("Выберите пункт отправления и прибытия", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            fastestListBox.Items.Clear();
            cheapestListBox.Items.Clear();
            //Добавляем строку состояния о прибытии пассажира
            fastestListBox.Items.Add(
                $"[{timePicker.Value.TimeOfDay:hh\\:mm}] Прибытие на начальную остановку");
            var fastestRoute = map.FindRoute(Convert.ToInt32(timePicker.Value.TimeOfDay.TotalMinutes),
                Convert.ToInt32(startStopCombo.SelectedItem), 
                Convert.ToInt32(endStopCombo.SelectedItem), true);
            AnalyzeRoute(fastestRoute, true);
            map.Clean();
            var cheapestRoute = map.FindRoute(Convert.ToInt32(timePicker.Value.TimeOfDay.TotalMinutes),
                Convert.ToInt32(startStopCombo.SelectedItem),
                Convert.ToInt32(endStopCombo.SelectedItem), false);
            AnalyzeRoute(cheapestRoute, false);
            map.Clean();

            routeControl.Visible = true;
        }

        /// <summary>
        /// Анализ маршрутного листа и вывод его для пользователя
        /// </summary>
        /// <param name="route">Маршрутный лист</param>
        /// <param name="byTime">Индикатор состояния</param>
        private void AnalyzeRoute(List<Edge> route, bool byTime)
        {
            ListBox list;
            //Если нужен быстрый маршрут
            if (byTime)
                list = fastestListBox;
            else
                list = cheapestListBox;
            //Проверяем, удалось ли построть маршрут
            if (route.Count == 0)
            {
                list.Items.Clear();
                list.Items.Add("Не удалось построить маршрут, выберите другое время");
            }
            for (int i = 0; i < route.Count; i++)
            {
                //Если нужен быстрый маршрут
                if (byTime)
                {
                    list.Items.Add(
                        String.Format("[{0:hh\\:mm}] Отправление автобуса №{1} от остановки №{2}.",
                            TimeSpan.FromMinutes(route[i].to.timeOfStop), map.NumOfBus(route[i].bus),
                            route[i].from.num));
                    list.Items.Add(String.Format("[{0:hh\\:mm}] Прибытие на остановку №{1}.",
                        TimeSpan.FromMinutes(route[i].to.timeOfStop), route[i].to.num));
                    if (i != route.Count - 1 && route[i].bus != route[i + 1].bus)
                    {
                        list.Items.Add(String.Format("Пересадка на автобус №{0}.",
                            map.NumOfBus(route[i + 1].bus)));
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        list.Items.Add(
                            String.Format("Посадка на автобус №{0} (стоимость поездки {1} руб).",
                            map.NumOfBus(route[i].bus), route[i].bus.cost));
                    }
                    list.Items.Add(
                        String.Format("Отправление автобуса №{0} от остановки №{1}.",
                        map.NumOfBus(route[i].bus), route[i].from.num));
                    list.Items.Add(String.Format("Прибытие на остановку №{0}.", route[i].to.num));
                    if (i != route.Count - 1 && route[i].bus != route[i + 1].bus)
                    {
                        list.Items.Add(
                            String.Format("Пересадка на автобус №{0} (стоимость поездки {1} руб).",
                            map.NumOfBus(route[i + 1].bus), route[i + 1].bus.cost));
                    }
                }
            }
            list.Items.Add("Конечная остановка.");
        }
    }
}
