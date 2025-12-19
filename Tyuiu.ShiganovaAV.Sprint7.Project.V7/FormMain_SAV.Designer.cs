using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tyuiu.ShiganovaAV.Sprint7.Project.V7.Lib;

namespace Tyuiu.ShiganovaAV.Sprint7.Project.V7
{
    public partial class FormMain_SAV : Form
    {
        private DataService dataService_SAV;
        private List<DataService.Apartment> apartments_SAV;
        private string currentFilePath_SAV;

        public FormMain_SAV()
        {
            InitializeComponent();
            InitializeApplication_SAV();
        }

        private void InitializeApplication_SAV()
        {
            dataService_SAV = new DataService();
            apartments_SAV = new List<DataService.Apartment>();
            currentFilePath_SAV = string.Empty;

            SetupDataGridView_SAV();
            SetupChart_SAV();
            SetupComboBoxes_SAV();
            UpdateStatusBar_SAV("Готов к работе. Загрузите файл или добавьте новую квартиру.");

            // Включаем основные кнопки
            EnableControls_SAV(true);
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
            chartStatistics_SAV.Legends.Clear();

            // Основная область для гистограммы
            ChartArea mainArea = new ChartArea("MainArea");
            mainArea.AxisX.Title = "Подъезды";
            mainArea.AxisY.Title = "Количество квартир";
            mainArea.AxisX.Interval = 1;
            mainArea.AxisY.Interval = 1;
            mainArea.AxisX.LabelStyle.Font = new Font("Arial", 10);
            mainArea.AxisY.LabelStyle.Font = new Font("Arial", 10);
            mainArea.AxisX.TitleFont = new Font("Arial", 11, FontStyle.Bold);
            mainArea.AxisY.TitleFont = new Font("Arial", 11, FontStyle.Bold);

            chartStatistics_SAV.ChartAreas.Add(mainArea);
        }

        private void SetupComboBoxes_SAV()
        {
            comboBoxFilterEntrance_SAV.Items.Clear();
            comboBoxFilterEntrance_SAV.Items.Add("Все подъезды");
            for (int i = 1; i <= 10; i++)
                comboBoxFilterEntrance_SAV.Items.Add($"Подъезд {i}");
            comboBoxFilterEntrance_SAV.SelectedIndex = 0;

            comboBoxFilterDebt_SAV.Items.Clear();
            comboBoxFilterDebt_SAV.Items.AddRange(new string[] { "Все", "С долгом", "Без долга" });
            comboBoxFilterDebt_SAV.SelectedIndex = 0;

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

        private void EnableControls_SAV(bool enabled)
        {
            buttonSaveFile_SAV.Enabled = enabled && apartments_SAV.Count > 0;
            buttonAddApartment_SAV.Enabled = true; // Всегда доступно
            buttonEditApartment_SAV.Enabled = enabled && dataGridViewApartments_SAV.SelectedRows.Count > 0;
            buttonDeleteApartment_SAV.Enabled = enabled && dataGridViewApartments_SAV.SelectedRows.Count > 0;
            buttonExportStats_SAV.Enabled = enabled && apartments_SAV.Count > 0;
            buttonApplyFilters_SAV.Enabled = enabled && apartments_SAV.Count > 0;
            textBoxSearch_SAV.Enabled = enabled && apartments_SAV.Count > 0;
            buttonSearch_SAV.Enabled = enabled && apartments_SAV.Count > 0;
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

                UpdateStatusBar_SAV($"Загружено {apartments_SAV.Count} записей из файла: {Path.GetFileName(filePath)}");
                EnableControls_SAV(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatusBar_SAV("Ошибка загрузки файла");
            }
        }

        private void DisplayApartments_SAV(List<DataService.Apartment> apartments)
        {
            dataGridViewApartments_SAV.Rows.Clear();
            dataGridViewApartments_SAV.Columns.Clear();

            string[] columns = {
                "Подъезд", "Квартира", "Общ. пл., м²", "Жил. пл., м²",
                "Комнаты", "Фамилия", "Дата прописки", "Членов семьи",
                "Детей", "Долг", "Примечание"
            };

            foreach (string col in columns)
            {
                dataGridViewApartments_SAV.Columns.Add(col, col);
            }

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

            // Обновляем состояние кнопок после отображения данных
            EnableControls_SAV(true);
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
            chartStatistics_SAV.Titles.Clear();
            chartStatistics_SAV.ChartAreas.Clear();
            chartStatistics_SAV.Legends.Clear();

            if (apartments_SAV.Count == 0) return;

            // Создаем новую область для графика
            ChartArea chartArea = new ChartArea("ChartArea1");
            chartArea.AxisX.Title = "Подъезды";
            chartArea.AxisY.Title = "Количество квартир";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisY.Interval = 1;
            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 10);
            chartArea.AxisY.LabelStyle.Font = new Font("Arial", 10);
            chartArea.AxisX.TitleFont = new Font("Arial", 11, FontStyle.Bold);
            chartArea.AxisY.TitleFont = new Font("Arial", 11, FontStyle.Bold);
            chartStatistics_SAV.ChartAreas.Add(chartArea);

            // Получаем данные для графика
            var byEntrance = apartments_SAV
                .GroupBy(a => a.EntranceNumber)
                .Select(g => new { Entrance = g.Key, Count = g.Count() })
                .OrderBy(x => x.Entrance)
                .ToList();

            // Создаем серию для графика
            Series series = new Series("Квартиры по подъездам");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.SteelBlue;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "0";
            series.Font = new Font("Arial", 10, FontStyle.Bold);
            series["PointWidth"] = "0.6";

            // Добавляем точки данных
            foreach (var item in byEntrance)
            {
                int pointIndex = series.Points.AddXY($"Подъезд {item.Entrance}", item.Count);
                series.Points[pointIndex].Color = Color.SteelBlue;
                series.Points[pointIndex].Label = item.Count.ToString();
                series.Points[pointIndex].LabelForeColor = Color.White;
            }

            chartStatistics_SAV.Series.Add(series);

            // Добавляем заголовок
            chartStatistics_SAV.Titles.Add($"Распределение квартир по подъездам (всего: {apartments_SAV.Count})");
            chartStatistics_SAV.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);

            // Настраиваем легенду
            Legend legend = new Legend();
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            chartStatistics_SAV.Legends.Add(legend);

            // Обновляем график
            chartStatistics_SAV.Invalidate();
        }

        private void buttonSaveFile_SAV_Click(object sender, EventArgs e)
        {
            if (apartments_SAV.Count == 0)
            {
                MessageBox.Show("Нет данных для сохранения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
                UpdateStatusBar_SAV($"Данные сохранены в файл: {Path.GetFileName(currentFilePath_SAV)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddApartment_SAV_Click(object sender, EventArgs e)
        {
            try
            {
                using (var editForm = new FormEditApartment_SAV())
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        apartments_SAV.Add(editForm.GetApartment());
                        DisplayApartments_SAV(apartments_SAV);
                        UpdateStatistics_SAV();
                        UpdateChart_SAV();
                        UpdateStatusBar_SAV("Новая квартира добавлена");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении квартиры: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                try
                {
                    using (var editForm = new FormEditApartment_SAV(apartments_SAV[index]))
                    {
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            apartments_SAV[index] = editForm.GetApartment();
                            DisplayApartments_SAV(apartments_SAV);
                            UpdateStatistics_SAV();
                            UpdateChart_SAV();
                            UpdateStatusBar_SAV("Данные квартиры обновлены");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при редактировании: {ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (apartments_SAV.Count == 0)
            {
                MessageBox.Show("Нет данных для поиска", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
            if (apartments_SAV.Count == 0)
            {
                MessageBox.Show("Нет данных для фильтрации", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<DataService.Apartment> filtered = apartments_SAV;

            // Фильтр по подъезду
            if (comboBoxFilterEntrance_SAV.SelectedIndex > 0)
            {
                int entrance = comboBoxFilterEntrance_SAV.SelectedIndex;
                filtered = dataService_SAV.FilterByEntrance(filtered, entrance);
            }

            // Фильтр по долгу
            if (comboBoxFilterDebt_SAV.SelectedIndex == 1)
            {
                filtered = dataService_SAV.FilterByDebt(filtered, true);
            }
            else if (comboBoxFilterDebt_SAV.SelectedIndex == 2)
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

                using (StreamWriter writer = new StreamWriter(filePath))
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
                UpdateStatusBar_SAV($"Статистика экспортирована в файл: {Path.GetFileName(filePath)}");
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
            buttonEditApartment_SAV.Enabled = hasSelection && apartments_SAV.Count > 0;
            buttonDeleteApartment_SAV.Enabled = hasSelection && apartments_SAV.Count > 0;
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

    // Класс формы редактирования
    public class FormEditApartment_SAV : Form
    {
        private DataService.Apartment apartment;
        private bool isEditMode;

        // Элементы управления
        private Label labelTitle;
        private GroupBox groupBoxMain;
        private TextBox textBoxNotes;
        private Label labelNotes;
        private CheckBox checkBoxDebt;
        private Label labelDebt;
        private NumericUpDown numericUpDownChildren;
        private Label labelChildren;
        private NumericUpDown numericUpDownFamily;
        private Label labelFamily;
        private DateTimePicker dateTimePickerRegistration;
        private Label labelRegistrationDate;
        private TextBox textBoxSurname;
        private Label labelSurname;
        private NumericUpDown numericUpDownRooms;
        private Label labelRooms;
        private NumericUpDown numericUpDownLivingArea;
        private Label labelLivingArea;
        private NumericUpDown numericUpDownTotalArea;
        private Label labelTotalArea;
        private NumericUpDown numericUpDownApartmentNum;
        private Label labelApartment;
        private NumericUpDown numericUpDownEntrance;
        private Label labelEntrance;
        private Panel panelButtons;
        private Button buttonSave;
        private Button buttonCancel;

        public FormEditApartment_SAV()
        {
            InitializeControls();
            apartment = new DataService.Apartment();
            isEditMode = false;
            SetupForm();
        }

        public FormEditApartment_SAV(DataService.Apartment apartmentToEdit)
        {
            InitializeControls();
            apartment = apartmentToEdit;
            isEditMode = true;
            SetupForm();
            FillForm();
        }

        private void InitializeControls()
        {
            // Настройка формы
            this.Text = "Добавление квартиры";
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Padding = new Padding(10);

            // Заголовок
            labelTitle = new Label();
            labelTitle.Text = "Добавление новой квартиры";
            labelTitle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            labelTitle.Dock = DockStyle.Top;
            labelTitle.Height = 30;
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(labelTitle);

            // Группа для полей ввода
            groupBoxMain = new GroupBox();
            groupBoxMain.Text = "Данные квартиры";
            groupBoxMain.Dock = DockStyle.Fill;
            groupBoxMain.Padding = new Padding(15);
            this.Controls.Add(groupBoxMain);

            // Создаем и добавляем элементы управления
            InitializeFormControls();
        }

        private void InitializeFormControls()
        {
            int yPos = 30;
            int labelWidth = 150;
            int controlWidth = 250;
            int spacing = 35;

            // Подъезд
            labelEntrance = new Label();
            labelEntrance.Text = "Подъезд:";
            labelEntrance.Location = new Point(20, yPos);
            labelEntrance.Size = new Size(labelWidth, 25);
            groupBoxMain.Controls.Add(labelEntrance);

            numericUpDownEntrance = new NumericUpDown();
            numericUpDownEntrance.Location = new Point(180, yPos);
            numericUpDownEntrance.Size = new Size(controlWidth, 25);
            numericUpDownEntrance.Minimum = 1;
            numericUpDownEntrance.Maximum = 20;
            numericUpDownEntrance.Value = 1;
            groupBoxMain.Controls.Add(numericUpDownEntrance);

            yPos += spacing;

            // Номер квартиры
            labelApartment = new Label();
            labelApartment.Text = "Номер квартиры:";
            labelApartment.Location = new Point(20, yPos);
            labelApartment.Size = new Size(labelWidth, 25);
            groupBoxMain.Controls.Add(labelApartment);

            numericUpDownApartmentNum = new NumericUpDown();
            numericUpDownApartmentNum.Location = new Point(180, yPos);
            numericUpDownApartmentNum.Size = new Size(controlWidth, 25);
            numericUpDownApartmentNum.Minimum = 1;
            numericUpDownApartmentNum.Maximum = 999;
            numericUpDownApartmentNum.Value = 1;
            groupBoxMain.Controls.Add(numericUpDownApartmentNum);

            yPos += spacing;

            // Общая площадь
            labelTotalArea = new Label();
            labelTotalArea.Text = "Общая площадь (м²):";
            labelTotalArea.Location = new Point(20, yPos);
            labelTotalArea.Size = new Size(labelWidth, 25);
            groupBoxMain.Controls.Add(labelTotalArea);

            numericUpDownTotalArea = new NumericUpDown();
            numericUpDownTotalArea.Location = new Point(180, yPos);
            numericUpDownTotalArea.Size = new Size(controlWidth, 25);
            numericUpDownTotalArea.DecimalPlaces = 1;
            numericUpDownTotalArea.Minimum = 20;
            numericUpDownTotalArea.Maximum = 500;
            numericUpDownTotalArea.Increment = 0.5m;
            numericUpDownTotalArea.Value = 50;
            groupBoxMain.Controls.Add(numericUpDownTotalArea);

            yPos += spacing;

            // Жилая площадь
            labelLivingArea = new Label();
            labelLivingArea.Text = "Жилая площадь (м²):";
            labelLivingArea.Location = new Point(20, yPos);
            labelLivingArea.Size = new Size(labelWidth, 25);
            groupBoxMain.Controls.Add(labelLivingArea);

            numericUpDownLivingArea = new NumericUpDown();
            numericUpDownLivingArea.Location = new Point(180, yPos);
            numericUpDownLivingArea.Size = new Size(controlWidth, 25);
            numericUpDownLivingArea.DecimalPlaces = 1;
            numericUpDownLivingArea.Minimum = 10;
            numericUpDownLivingArea.Maximum = 300;
            numericUpDownLivingArea.Increment = 0.5m;
            numericUpDownLivingArea.Value = 35;
            groupBoxMain.Controls.Add(numericUpDownLivingArea);

            yPos += spacing;

            // Комнаты
            labelRooms = new Label();
            labelRooms.Text = "Количество комнат:";
            labelRooms.Location = new Point(20, yPos);
            labelRooms.Size = new Size(labelWidth, 25);
            groupBoxMain.Controls.Add(labelRooms);

            numericUpDownRooms = new NumericUpDown();
            numericUpDownRooms.Location = new Point(180, yPos);
            numericUpDownRooms.Size = new Size(controlWidth, 25);
            numericUpDownRooms.Minimum = 1;
            numericUpDownRooms.Maximum = 10;
            numericUpDownRooms.Value = 2;
            groupBoxMain.Controls.Add(numericUpDownRooms);

            yPos += spacing;

            // Фамилия
            labelSurname = new Label();
            labelSurname.Text = "Фамилия:";
            labelSurname.Location = new Point(20, yPos);
            labelSurname.Size = new Size(labelWidth, 25);
            groupBoxMain.Controls.Add(labelSurname);

            textBoxSurname = new TextBox();
            textBoxSurname.Location = new Point(180, yPos);
            textBoxSurname.Size = new Size(controlWidth, 25);
            groupBoxMain.Controls.Add(textBoxSurname);

            yPos += spacing;

            // Дата прописки
            labelRegistrationDate = new Label();
            labelRegistrationDate.Text = "Дата прописки:";
            labelRegistrationDate.Location = new Point(20, yPos);
            labelRegistrationDate.Size = new Size(labelWidth, 25);
            groupBoxMain.Controls.Add(labelRegistrationDate);

            dateTimePickerRegistration = new DateTimePicker();
            dateTimePickerRegistration.Location = new Point(180, yPos);
            dateTimePickerRegistration.Size = new Size(controlWidth, 25);
            dateTimePickerRegistration.Format = DateTimePickerFormat.Short;
            groupBoxMain.Controls.Add(dateTimePickerRegistration);

            yPos += spacing;

            // Членов семьи
            labelFamily = new Label();
            labelFamily.Text = "Членов семьи:";
            labelFamily.Location = new Point(20, yPos);
            labelFamily.Size = new Size(labelWidth, 25);
            groupBoxMain.Controls.Add(labelFamily);

            numericUpDownFamily = new NumericUpDown();
            numericUpDownFamily.Location = new Point(180, yPos);
            numericUpDownFamily.Size = new Size(controlWidth, 25);
            numericUpDownFamily.Minimum = 1;
            numericUpDownFamily.Maximum = 20;
            numericUpDownFamily.Value = 2;
            groupBoxMain.Controls.Add(numericUpDownFamily);

            yPos += spacing;

            // Детей
            labelChildren = new Label();
            labelChildren.Text = "Детей:";
            labelChildren.Location = new Point(20, yPos);
            labelChildren.Size = new Size(labelWidth, 25);
            groupBoxMain.Controls.Add(labelChildren);

            numericUpDownChildren = new NumericUpDown();
            numericUpDownChildren.Location = new Point(180, yPos);
            numericUpDownChildren.Size = new Size(controlWidth, 25);
            numericUpDownChildren.Minimum = 0;
            numericUpDownChildren.Maximum = 10;
            numericUpDownChildren.Value = 0;
            groupBoxMain.Controls.Add(numericUpDownChildren);

            yPos += spacing;

            // Долг
            labelDebt = new Label();
            labelDebt.Text = "Задолженность:";
            labelDebt.Location = new Point(20, yPos);
            labelDebt.Size = new Size(labelWidth, 25);
            groupBoxMain.Controls.Add(labelDebt);

            checkBoxDebt = new CheckBox();
            checkBoxDebt.Location = new Point(180, yPos);
            checkBoxDebt.Size = new Size(150, 25);
            checkBoxDebt.Text = "Есть задолженность";
            groupBoxMain.Controls.Add(checkBoxDebt);

            yPos += spacing;

            // Примечание
            labelNotes = new Label();
            labelNotes.Text = "Примечание:";
            labelNotes.Location = new Point(20, yPos);
            labelNotes.Size = new Size(labelWidth, 25);
            groupBoxMain.Controls.Add(labelNotes);

            textBoxNotes = new TextBox();
            textBoxNotes.Location = new Point(180, yPos);
            textBoxNotes.Size = new Size(controlWidth, 60);
            textBoxNotes.Multiline = true;
            textBoxNotes.ScrollBars = ScrollBars.Vertical;
            groupBoxMain.Controls.Add(textBoxNotes);

            // Панель кнопок
            panelButtons = new Panel();
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Height = 60;
            panelButtons.Padding = new Padding(20);

            buttonSave = new Button();
            buttonSave.Text = "Сохранить";
            buttonSave.Location = new Point(120, 10);
            buttonSave.Size = new Size(120, 40);
            buttonSave.BackColor = Color.DodgerBlue;
            buttonSave.ForeColor = Color.White;
            buttonSave.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            buttonSave.Click += ButtonSave_Click;

            buttonCancel = new Button();
            buttonCancel.Text = "Отмена";
            buttonCancel.Location = new Point(260, 10);
            buttonCancel.Size = new Size(120, 40);
            buttonCancel.Click += ButtonCancel_Click;

            panelButtons.Controls.Add(buttonSave);
            panelButtons.Controls.Add(buttonCancel);
            this.Controls.Add(panelButtons);
        }

        private void SetupForm()
        {
            this.Text = isEditMode ? "Редактирование квартиры" : "Добавление новой квартиры";
            labelTitle.Text = isEditMode ? "Редактирование квартиры" : "Добавление новой квартиры";
            dateTimePickerRegistration.Value = DateTime.Now;
        }

        private void FillForm()
        {
            numericUpDownEntrance.Value = apartment.EntranceNumber;
            numericUpDownApartmentNum.Value = apartment.ApartmentNumber;
            numericUpDownTotalArea.Value = (decimal)apartment.TotalArea;
            numericUpDownLivingArea.Value = (decimal)apartment.LivingArea;
            numericUpDownRooms.Value = apartment.RoomsCount;
            textBoxSurname.Text = apartment.TenantSurname;
            dateTimePickerRegistration.Value = apartment.RegistrationDate;
            numericUpDownFamily.Value = apartment.FamilyMembers;
            numericUpDownChildren.Value = apartment.ChildrenCount;
            checkBoxDebt.Checked = apartment.HasDebt;
            textBoxNotes.Text = apartment.Notes;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveData();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxSurname.Text))
            {
                MessageBox.Show("Введите фамилию квартиросъемщика", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSurname.Focus();
                return false;
            }

            if ((double)numericUpDownLivingArea.Value > (double)numericUpDownTotalArea.Value)
            {
                MessageBox.Show("Жилая площадь не может быть больше общей", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownLivingArea.Focus();
                return false;
            }

            if ((int)numericUpDownChildren.Value > (int)numericUpDownFamily.Value)
            {
                MessageBox.Show("Количество детей не может превышать количество членов семьи", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownChildren.Focus();
                return false;
            }

            return true;
        }

        private void SaveData()
        {
            apartment.EntranceNumber = (int)numericUpDownEntrance.Value;
            apartment.ApartmentNumber = (int)numericUpDownApartmentNum.Value;
            apartment.TotalArea = (double)numericUpDownTotalArea.Value;
            apartment.LivingArea = (double)numericUpDownLivingArea.Value;
            apartment.RoomsCount = (int)numericUpDownRooms.Value;
            apartment.TenantSurname = textBoxSurname.Text.Trim();
            apartment.RegistrationDate = dateTimePickerRegistration.Value;
            apartment.FamilyMembers = (int)numericUpDownFamily.Value;
            apartment.ChildrenCount = (int)numericUpDownChildren.Value;
            apartment.HasDebt = checkBoxDebt.Checked;
            apartment.Notes = textBoxNotes.Text.Trim();
        }

        public DataService.Apartment GetApartment()
        {
            return apartment;
        }
    }
}