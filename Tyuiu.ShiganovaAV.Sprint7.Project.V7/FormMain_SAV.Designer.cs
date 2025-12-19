using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tyuiu.ShiganovaAV.Sprint7.Project.V7.Lib;
using static Tyuiu.ShiganovaAV.Sprint7.Project.V7.Lib.DataService;

namespace Tyuiu.ShiganovaAV.Sprint7.Project.V7
{
    public partial class FormMain_SAV : Form
    {
        private DataService dataService_SAV;
        private List<Apartment> apartments_SAV;
        private string currentFilePath_SAV;

        public FormMain_SAV()
        {
            InitializeComponent();
            InitializeApplication_SAV();
        }

        private void InitializeApplication_SAV()
        {
            dataService_SAV = new DataService();
            apartments_SAV = new List<Apartment>();
            currentFilePath_SAV = string.Empty;

            // Настройка интерфейса
            SetupDataGridView_SAV();
            SetupChart_SAV();
            SetupComboBoxes_SAV();
            UpdateStatusBar_SAV("Готов к работе");
        }

        private void SetupDataGridView_SAV()
        {
            dataGridViewApartments_SAV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewApartments_SAV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewApartments_SAV.AllowUserToAddRows = false;
            dataGridViewApartments_SAV.ReadOnly = true;
            dataGridViewApartments_SAV.RowHeadersVisible = false;
        }

        private void SetupChart_SAV()
        {
            chartStatistics_SAV.Titles.Clear();
            chartStatistics_SAV.Series.Clear();
            chartStatistics_SAV.ChartAreas.Clear();

            // Основная область для гистограммы
            ChartArea mainArea = new ChartArea("MainArea");
            mainArea.AxisX.Title = "Подъезды";
            mainArea.AxisY.Title = "Количество квартир";
            chartStatistics_SAV.ChartAreas.Add(mainArea);
        }

        private void SetupComboBoxes_SAV()
        {
            // Фильтр по подъездам
            comboBoxFilterEntrance_SAV.Items.Clear();
            comboBoxFilterEntrance_SAV.Items.Add("Все подъезды");
            for (int i = 1; i <= 10; i++)
                comboBoxFilterEntrance_SAV.Items.Add($"Подъезд {i}");
            comboBoxFilterEntrance_SAV.SelectedIndex = 0;

            // Фильтр по долгам
            comboBoxFilterDebt_SAV.Items.Clear();
            comboBoxFilterDebt_SAV.Items.AddRange(new string[] { "Все", "С долгом", "Без долга" });
            comboBoxFilterDebt_SAV.SelectedIndex = 0;

            // Сортировка
            comboBoxSortBy_SAV.Items.Clear();
            comboBoxSortBy_SAV.Items.AddRange(new string[] {
                "Номер квартиры",
                "Общая площадь",
                "Количество комнат",
                "Дата прописки"
            });
            comboBoxSortBy_SAV.SelectedIndex = 0;
        }

        private void UpdateStatusBar_SAV(string message)
        {
            toolStripStatusLabelInfo_SAV.Text = message;
        }

        private void buttonLoadFile_SAV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
                openFileDialog.Title = "Выберите файл с данными квартир";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadDataFromFile_SAV(openFileDialog.FileName);
                }
            }
        }

        private void LoadDataFromFile_SAV(string filePath)
        {
            try
            {
                apartments_SAV = dataService_SAV.LoadFromFile(filePath);
                currentFilePath_SAV = filePath;

                DisplayApartments_SAV(apartments_SAV);
                UpdateStatistics_SAV();
                UpdateChart_SAV();

                UpdateStatusBar_SAV($"Загружено {apartments_SAV.Count} записей из файла: {System.IO.Path.GetFileName(filePath)}");
                EnableControls_SAV(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatusBar_SAV("Ошибка загрузки файла");
            }
        }

        private void DisplayApartments_SAV(List<Apartment> apartments)
        {
            dataGridViewApartments_SAV.Rows.Clear();
            dataGridViewApartments_SAV.Columns.Clear();

            // Создаем колонки
            string[] columns = { "Подъезд", "Квартира", "Общ. пл., м²", "Жил. пл., м²",
                           "Комнаты", "Фамилия", "Дата прописки", "Членов семьи",
                           "Детей", "Долг", "Примечание" };

            foreach (string col in columns)
            {
                dataGridViewApartments_SAV.Columns.Add(col, col);
            }

            // Заполняем данными
            foreach (var apt in apartments)
            {
                dataGridViewApartments_SAV.Rows.Add(
                    apt.EntranceNumber,
                    apt.ApartmentNumber,
                    apt.TotalArea.ToString("F1"),
                    apt.LivingArea.ToString("F1"),
                    apt.RoomsCount,
                    apt.TenantSurname,
                    apt.RegistrationDate.ToString("dd.MM.yyyy"),
                    apt.FamilyMembers,
                    apt.ChildrenCount,
                    apt.HasDebt ? "Да" : "Нет",
                    apt.Notes
                );
            }

            // Настраиваем ширину колонок
            dataGridViewApartments_SAV.Columns["Примечание"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void UpdateStatistics_SAV()
        {
            if (apartments_SAV.Count == 0)
            {
                ClearStatistics_SAV();
                return;
            }

            var stats = dataService_SAV.GetStatistics(apartments_SAV);

            labelTotalApartments_SAV.Text = $"Квартир: {stats["КоличествоКвартир"]}";
            labelTotalArea_SAV.Text = $"Общая площадь: {stats["ОбщаяПлощадьВсех"]:F1} м²";
            labelAvgArea_SAV.Text = $"Средняя площадь: {stats["СредняяПлощадь"]:F1} м²";
            labelDebtors_SAV.Text = $"Должников: {stats["КоличествоДолжников"]}";
            labelTotalChildren_SAV.Text = $"Всего детей: {stats["ВсегоДетей"]}";
            labelAvgFamily_SAV.Text = $"Ср. размер семьи: {stats["СреднийРазмерСемьи"]:F1}";
            labelTotalRooms_SAV.Text = $"Всего комнат: {stats["КоличествоКомнатВсего"]}";
        }

        private void ClearStatistics_SAV()
        {
            labelTotalApartments_SAV.Text = "Квартир: 0";
            labelTotalArea_SAV.Text = "Общая площадь: 0 м²";
            labelAvgArea_SAV.Text = "Средняя площадь: 0 м²";
            labelDebtors_SAV.Text = "Должников: 0";
            labelTotalChildren_SAV.Text = "Всего детей: 0";
            labelAvgFamily_SAV.Text = "Ср. размер семьи: 0";
            labelTotalRooms_SAV.Text = "Всего комнат: 0";
        }

        private void UpdateChart_SAV()
        {
            chartStatistics_SAV.Series.Clear();

            if (apartments_SAV.Count == 0) return;

            // Гистограмма распределения по подъездам
            var byEntrance = apartments_SAV
                .GroupBy(a => a.EntranceNumber)
                .Select(g => new { Entrance = g.Key, Count = g.Count() })
                .OrderBy(x => x.Entrance)
                .ToList();

            Series series = new Series("Квартиры по подъездам");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.SteelBlue;

            foreach (var item in byEntrance)
            {
                DataPoint point = new DataPoint();
                point.SetValueXY($"Подъезд {item.Entrance}", item.Count);
                point.Label = item.Count.ToString();
                series.Points.Add(point);
            }

            chartStatistics_SAV.Series.Add(series);
            chartStatistics_SAV.Titles.Clear();
            chartStatistics_SAV.Titles.Add($"Распределение квартир по подъездам (всего: {apartments_SAV.Count})");
        }

        private void EnableControls_SAV(bool enabled)
        {
            buttonSaveFile_SAV.Enabled = enabled;
            buttonAddApartment_SAV.Enabled = enabled;
            buttonEditApartment_SAV.Enabled = enabled;
            buttonDeleteApartment_SAV.Enabled = enabled;
            buttonExportStats_SAV.Enabled = enabled;
            buttonApplyFilters_SAV.Enabled = enabled;
            textBoxSearch_SAV.Enabled = enabled;
            buttonSearch_SAV.Enabled = enabled;
        }

        private void buttonSaveFile_SAV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath_SAV))
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV файлы (*.csv)|*.csv";
                    saveDialog.Title = "Сохранить данные";
                    saveDialog.DefaultExt = "csv";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath_SAV = saveDialog.FileName;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            try
            {
                dataService_SAV.SaveToFile(currentFilePath_SAV, apartments_SAV);
                MessageBox.Show("Данные успешно сохранены!",
                    "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatusBar_SAV($"Данные сохранены в файл: {System.IO.Path.GetFileName(currentFilePath_SAV)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddApartment_SAV_Click(object sender, EventArgs e)
        {
            FormEditApartment_SAV form = new FormEditApartment_SAV();
            if (form.ShowDialog() == DialogResult.OK)
            {
                apartments_SAV.Add(form.GetApartment());
                DisplayApartments_SAV(apartments_SAV);
                UpdateStatistics_SAV();
                UpdateChart_SAV();
                UpdateStatusBar_SAV("Новая квартира добавлена");
            }
        }

        private void buttonEditApartment_SAV_Click(object sender, EventArgs e)
        {
            if (dataGridViewApartments_SAV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите квартиру для редактирования",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int index = dataGridViewApartments_SAV.SelectedRows[0].Index;
            if (index < apartments_SAV.Count)
            {
                FormEditApartment_SAV form = new FormEditApartment_SAV(apartments_SAV[index]);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    apartments_SAV[index] = form.GetApartment();
                    DisplayApartments_SAV(apartments_SAV);
                    UpdateStatistics_SAV();
                    UpdateChart_SAV();
                    UpdateStatusBar_SAV("Данные квартиры обновлены");
                }
            }
        }

        private void buttonDeleteApartment_SAV_Click(object sender, EventArgs e)
        {
            if (dataGridViewApartments_SAV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите квартиру для удаления",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную квартиру?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int index = dataGridViewApartments_SAV.SelectedRows[0].Index;
                if (index < apartments_SAV.Count)
                {
                    apartments_SAV.RemoveAt(index);
                    DisplayApartments_SAV(apartments_SAV);
                    UpdateStatistics_SAV();
                    UpdateChart_SAV();
                    UpdateStatusBar_SAV("Квартира удалена");
                }
            }
        }

        private void buttonSearch_SAV_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch_SAV.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                DisplayApartments_SAV(apartments_SAV);
                UpdateStatusBar_SAV("Показаны все записи");
                return;
            }

            var results = dataService_SAV.SearchBySurname(apartments_SAV, searchText);
            DisplayApartments_SAV(results);
            UpdateStatusBar_SAV($"Найдено {results.Count} записей по запросу: '{searchText}'");
        }

        private void buttonApplyFilters_SAV_Click(object sender, EventArgs e)
        {
            List<Apartment> filtered = apartments_SAV;

            // Фильтр по подъезду
            if (comboBoxFilterEntrance_SAV.SelectedIndex > 0)
            {
                int entrance = comboBoxFilterEntrance_SAV.SelectedIndex; // 1 -> Подъезд 1
                filtered = dataService_SAV.FilterByEntrance(filtered, entrance);
            }

            // Фильтр по долгу
            if (comboBoxFilterDebt_SAV.SelectedIndex == 1) // С долгом
            {
                filtered = dataService_SAV.FilterByDebt(filtered, true);
            }
            else if (comboBoxFilterDebt_SAV.SelectedIndex == 2) // Без долга
            {
                filtered = dataService_SAV.FilterByDebt(filtered, false);
            }

            // Сортировка
            bool ascending = checkBoxAscending_SAV.Checked;
            switch (comboBoxSortBy_SAV.SelectedItem.ToString())
            {
                case "Номер квартиры":
                    filtered = dataService_SAV.SortByApartmentNumber(filtered, ascending);
                    break;
                case "Общая площадь":
                    filtered = ascending ?
                        filtered.OrderBy(a => a.TotalArea).ToList() :
                        filtered.OrderByDescending(a => a.TotalArea).ToList();
                    break;
                case "Количество комнат":
                    filtered = ascending ?
                        filtered.OrderBy(a => a.RoomsCount).ToList() :
                        filtered.OrderByDescending(a => a.RoomsCount).ToList();
                    break;
                case "Дата прописки":
                    filtered = ascending ?
                        filtered.OrderBy(a => a.RegistrationDate).ToList() :
                        filtered.OrderByDescending(a => a.RegistrationDate).ToList();
                    break;
            }

            DisplayApartments_SAV(filtered);
            UpdateStatusBar_SAV($"Отображено {filtered.Count} записей после фильтрации");
        }

        private void buttonExportStats_SAV_Click(object sender, EventArgs e)
        {
            if (apartments_SAV.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                saveDialog.Title = "Экспорт статистики";
                saveDialog.DefaultExt = "txt";
                saveDialog.FileName = $"Статистика_домоуправления_{DateTime.Now:ddMMyyyy}.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportStatisticsToFile_SAV(saveDialog.FileName);
                }
            }
        }

        private void ExportStatisticsToFile_SAV(string filePath)
        {
            try
            {
                var stats = dataService_SAV.GetStatistics(apartments_SAV);

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
                {
                    writer.WriteLine("СТАТИСТИКА ДОМОУПРАВЛЕНИЯ");
                    writer.WriteLine("==========================");
                    writer.WriteLine($"Отчет создан: {DateTime.Now:dd.MM.yyyy HH:mm}");
                    writer.WriteLine($"Всего записей: {apartments_SAV.Count}");
                    writer.WriteLine();

                    writer.WriteLine("ОСНОВНЫЕ ПОКАЗАТЕЛИ:");
                    writer.WriteLine($"Количество квартир: {stats["КоличествоКвартир"]}");
                    writer.WriteLine($"Общая площадь всех квартир: {stats["ОбщаяПлощадьВсех"]:F1} м²");
                    writer.WriteLine($"Средняя площадь квартиры: {stats["СредняяПлощадь"]:F1} м²");
                    writer.WriteLine($"Самая большая квартира: {stats["МаксПлощадь"]} м²");
                    writer.WriteLine($"Самая маленькая квартира: {stats["МинПлощадь"]} м²");
                    writer.WriteLine();

                    writer.WriteLine("ДЕМОГРАФИЧЕСКИЕ ДАННЫЕ:");
                    writer.WriteLine($"Количество должников: {stats["КоличествоДолжников"]}");
                    writer.WriteLine($"Всего детей в доме: {stats["ВсегоДетей"]}");
                    writer.WriteLine($"Всего членов семей: {stats["ВсегоЧленовСемьи"]}");
                    writer.WriteLine($"Средний размер семьи: {stats["СреднийРазмерСемьи"]:F1} чел.");
                    writer.WriteLine($"Всего комнат в доме: {stats["КоличествоКомнатВсего"]}");
                    writer.WriteLine();

                    writer.WriteLine("РАСПРЕДЕЛЕНИЕ ПО ПОДЪЕЗДАМ:");
                    var byEntrance = apartments_SAV
                        .GroupBy(a => a.EntranceNumber)
                        .OrderBy(g => g.Key);

                    foreach (var group in byEntrance)
                    {
                        writer.WriteLine($"  Подъезд {group.Key}: {group.Count()} квартир");
                    }
                }

                MessageBox.Show("Статистика успешно экспортирована!",
                    "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatusBar_SAV($"Статистика экспортирована в файл: {System.IO.Path.GetFileName(filePath)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHelp_SAV_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "СИСТЕМА ДОМОУПРАВЛЕНИЯ - Руководство пользователя\n\n" +
                "Основные функции:\n" +
                "1. Загрузка данных из CSV файла\n" +
                "2. Добавление/редактирование/удаление квартир\n" +
                "3. Поиск по фамилии квартиросъемщика\n" +
                "4. Фильтрация и сортировка данных\n" +
                "5. Просмотр статистики и графиков\n" +
                "6. Экспорт статистики в текстовый файл\n\n" +
                "Формат CSV файла:\n" +
                "Подъезд;Квартира;ОбщаяПлощадь;ЖилаяПлощадь;Комнаты;" +
                "Фамилия;ДатаПрописки;ЧленовСемьи;Детей;Задолженность;Примечание\n\n" +
                "Пример строки:\n" +
                "1;25;65.5;45.0;3;Иванов;15.03.2010;4;2;False;",
                "Справка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void buttonAbout_SAV_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "СИСТЕМА ДОМОУПРАВЛЕНИЯ\n" +
                "Версия 1.0\n\n" +
                "Разработчик: Шиганова Анастасия Владимировна\n" +
                "Вариант: 7\n" +
                "Предметная область: Домоуправление\n\n" +
                "© 2024 Все права защищены",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void textBoxSearch_SAV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonSearch_SAV_Click(sender, e);
                e.Handled = true;
            }
        }

        private void dataGridViewApartments_SAV_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dataGridViewApartments_SAV.SelectedRows.Count > 0;
            buttonEditApartment_SAV.Enabled = hasSelection;
            buttonDeleteApartment_SAV.Enabled = hasSelection;
        }

        private void toolStripMenuItemOpen_SAV_Click(object sender, EventArgs e)
        {
            buttonLoadFile_SAV_Click(sender, e);
        }

        private void toolStripMenuItemSave_SAV_Click(object sender, EventArgs e)
        {
            buttonSaveFile_SAV_Click(sender, e);
        }

        private void toolStripMenuItemExit_SAV_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}