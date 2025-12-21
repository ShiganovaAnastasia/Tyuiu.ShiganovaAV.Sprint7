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
        private DataService ds = new DataService();
        private List<Apartment> list = new List<Apartment>();
        private List<Apartment> filteredList = new List<Apartment>();
        private string currentFile = "";

        private class EditApartmentForm_SAV : Form
        {
            private Apartment apartment;
            private bool isEditMode;

            private TableLayoutPanel tableLayoutPanelMain_SAV;
            private Panel panelButtons_SAV;
            private Button buttonSave_SAV;
            private Button buttonCancel_SAV;

            private Label labelEntrance_SAV;
            private Label labelNumber_SAV;
            private Label labelTotalArea_SAV;
            private Label labelLivingArea_SAV;
            private Label labelRooms_SAV;
            private Label labelSurname_SAV;
            private Label labelRegDate_SAV;
            private Label labelFamily_SAV;
            private Label labelChildren_SAV;
            private Label labelDebt_SAV;
            private Label labelNotes_SAV;

            private NumericUpDown numericUpDownEntrance_SAV;
            private NumericUpDown numericUpDownNumber_SAV;
            private NumericUpDown numericUpDownTotalArea_SAV;
            private NumericUpDown numericUpDownLivingArea_SAV;
            private NumericUpDown numericUpDownRooms_SAV;
            private TextBox textBoxSurname_SAV;
            private DateTimePicker dateTimePickerRegDate_SAV;
            private NumericUpDown numericUpDownFamily_SAV;
            private NumericUpDown numericUpDownChildren_SAV;
            private CheckBox checkBoxDebt_SAV;
            private TextBox textBoxNotes_SAV;

            public Apartment EditedApartment => apartment;

            public EditApartmentForm_SAV()
            {
                apartment = new Apartment();
                isEditMode = false;
                InitializeComponents();
                SetupForm();
            }

            public EditApartmentForm_SAV(Apartment apartmentToEdit)
            {
                apartment = apartmentToEdit ?? throw new ArgumentNullException(nameof(apartmentToEdit));
                isEditMode = true;
                InitializeComponents();
                SetupForm();
                LoadApartmentData();
            }

            private void InitializeComponents()
            {
                this.ClientSize = new Size(500, 550);
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Padding = new Padding(10);

                tableLayoutPanelMain_SAV = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 2,
                    RowCount = 12,
                    Padding = new Padding(5),
                    Margin = new Padding(10)
                };

                tableLayoutPanelMain_SAV.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
                tableLayoutPanelMain_SAV.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

                int row = 0;

                labelEntrance_SAV = new Label
                {
                    Text = "Подъезд:",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                numericUpDownEntrance_SAV = new NumericUpDown
                {
                    Minimum = 1,
                    Maximum = 20,
                    Value = 1,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                tableLayoutPanelMain_SAV.Controls.Add(labelEntrance_SAV, 0, row);
                tableLayoutPanelMain_SAV.Controls.Add(numericUpDownEntrance_SAV, 1, row++);

                labelNumber_SAV = new Label
                {
                    Text = "Номер квартиры:",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                numericUpDownNumber_SAV = new NumericUpDown
                {
                    Minimum = 1,
                    Maximum = 999,
                    Value = 1,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                tableLayoutPanelMain_SAV.Controls.Add(labelNumber_SAV, 0, row);
                tableLayoutPanelMain_SAV.Controls.Add(numericUpDownNumber_SAV, 1, row++);

                labelTotalArea_SAV = new Label
                {
                    Text = "Общая площадь (м²):",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                numericUpDownTotalArea_SAV = new NumericUpDown
                {
                    DecimalPlaces = 1,
                    Minimum = 20,
                    Maximum = 500,
                    Increment = 0.5m,
                    Value = 50,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                tableLayoutPanelMain_SAV.Controls.Add(labelTotalArea_SAV, 0, row);
                tableLayoutPanelMain_SAV.Controls.Add(numericUpDownTotalArea_SAV, 1, row++);
                labelLivingArea_SAV = new Label
                {
                    Text = "Жилая площадь (м²):",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                numericUpDownLivingArea_SAV = new NumericUpDown
                {
                    DecimalPlaces = 1,
                    Minimum = 10,
                    Maximum = 300,
                    Increment = 0.5m,
                    Value = 35,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                tableLayoutPanelMain_SAV.Controls.Add(labelLivingArea_SAV, 0, row);
                tableLayoutPanelMain_SAV.Controls.Add(numericUpDownLivingArea_SAV, 1, row++);
                labelRooms_SAV = new Label
                {
                    Text = "Количество комнат:",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                numericUpDownRooms_SAV = new NumericUpDown
                {
                    Minimum = 1,
                    Maximum = 10,
                    Value = 2,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                tableLayoutPanelMain_SAV.Controls.Add(labelRooms_SAV, 0, row);
                tableLayoutPanelMain_SAV.Controls.Add(numericUpDownRooms_SAV, 1, row++);
                labelSurname_SAV = new Label
                {
                    Text = "Фамилия:",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                textBoxSurname_SAV = new TextBox
                {
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                tableLayoutPanelMain_SAV.Controls.Add(labelSurname_SAV, 0, row);
                tableLayoutPanelMain_SAV.Controls.Add(textBoxSurname_SAV, 1, row++);
                labelRegDate_SAV = new Label
                {
                    Text = "Дата прописки:",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                dateTimePickerRegDate_SAV = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Short,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                tableLayoutPanelMain_SAV.Controls.Add(labelRegDate_SAV, 0, row);
                tableLayoutPanelMain_SAV.Controls.Add(dateTimePickerRegDate_SAV, 1, row++);
                labelFamily_SAV = new Label
                {
                    Text = "Членов семьи:",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                numericUpDownFamily_SAV = new NumericUpDown
                {
                    Minimum = 1,
                    Maximum = 20,
                    Value = 2,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                tableLayoutPanelMain_SAV.Controls.Add(labelFamily_SAV, 0, row);
                tableLayoutPanelMain_SAV.Controls.Add(numericUpDownFamily_SAV, 1, row++);
                labelChildren_SAV = new Label
                {
                    Text = "Детей:",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                numericUpDownChildren_SAV = new NumericUpDown
                {
                    Minimum = 0,
                    Maximum = 10,
                    Value = 0,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                tableLayoutPanelMain_SAV.Controls.Add(labelChildren_SAV, 0, row);
                tableLayoutPanelMain_SAV.Controls.Add(numericUpDownChildren_SAV, 1, row++);
                labelDebt_SAV = new Label
                {
                    Text = "Задолженность:",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                checkBoxDebt_SAV = new CheckBox
                {
                    Text = "Есть задолженность",
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                tableLayoutPanelMain_SAV.Controls.Add(labelDebt_SAV, 0, row);
                tableLayoutPanelMain_SAV.Controls.Add(checkBoxDebt_SAV, 1, row++);
                labelNotes_SAV = new Label
                {
                    Text = "Примечание:",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5)
                };
                textBoxNotes_SAV = new TextBox
                {
                    Multiline = true,
                    Height = 80,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(5),
                    ScrollBars = ScrollBars.Vertical
                };
                tableLayoutPanelMain_SAV.Controls.Add(labelNotes_SAV, 0, row);
                tableLayoutPanelMain_SAV.Controls.Add(textBoxNotes_SAV, 1, row);

                this.Controls.Add(tableLayoutPanelMain_SAV);
                panelButtons_SAV = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Height = 70,
                    Padding = new Padding(20, 10, 20, 10)
                };

                buttonSave_SAV = new Button
                {
                    Text = "Сохранить",
                    Size = new Size(120, 40),
                    Location = new Point(150, 10),
                    BackColor = Color.DodgerBlue,
                    ForeColor = Color.White,
                    Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold)
                };
                buttonSave_SAV.Click += ButtonSave_SAV_Click;

                buttonCancel_SAV = new Button
                {
                    Text = "Отмена",
                    Size = new Size(120, 40),
                    Location = new Point(280, 10)
                };
                buttonCancel_SAV.Click += ButtonCancel_SAV_Click;

                panelButtons_SAV.Controls.Add(buttonSave_SAV);
                panelButtons_SAV.Controls.Add(buttonCancel_SAV);
                this.Controls.Add(panelButtons_SAV);
            }

            private void SetupForm()
            {
                this.Text = isEditMode ? "Редактирование квартиры" : "Добавление новой квартиры";
                dateTimePickerRegDate_SAV.Value = DateTime.Now;
            }

            private void LoadApartmentData()
            {
                numericUpDownEntrance_SAV.Value = apartment.Entrance;
                numericUpDownNumber_SAV.Value = apartment.Number;
                numericUpDownTotalArea_SAV.Value = (decimal)apartment.TotalArea;
                numericUpDownLivingArea_SAV.Value = (decimal)apartment.LivingArea;
                numericUpDownRooms_SAV.Value = apartment.Rooms;
                textBoxSurname_SAV.Text = apartment.Surname;
                dateTimePickerRegDate_SAV.Value = apartment.RegDate == DateTime.MinValue ? DateTime.Now : apartment.RegDate;
                numericUpDownFamily_SAV.Value = apartment.Family;
                numericUpDownChildren_SAV.Value = apartment.Children;
                checkBoxDebt_SAV.Checked = apartment.Debt;
                textBoxNotes_SAV.Text = apartment.Notes;
            }

            private void ButtonSave_SAV_Click(object sender, EventArgs e)
            {
                if (ValidateForm())
                {
                    SaveData();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

            private void ButtonCancel_SAV_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            private bool ValidateForm()
            {
                if (string.IsNullOrWhiteSpace(textBoxSurname_SAV.Text))
                {
                    MessageBox.Show("Введите фамилию квартиросъемщика", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxSurname_SAV.Focus();
                    return false;
                }

                if ((double)numericUpDownLivingArea_SAV.Value > (double)numericUpDownTotalArea_SAV.Value)
                {
                    MessageBox.Show("Жилая площадь не может быть больше общей", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numericUpDownLivingArea_SAV.Focus();
                    return false;
                }

                if ((int)numericUpDownChildren_SAV.Value > (int)numericUpDownFamily_SAV.Value)
                {
                    MessageBox.Show("Количество детей не может превышать количество членов семьи", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numericUpDownChildren_SAV.Focus();
                    return false;
                }

                return true;
            }

            private void SaveData()
            {
                apartment.Entrance = (int)numericUpDownEntrance_SAV.Value;
                apartment.Number = (int)numericUpDownNumber_SAV.Value;
                apartment.TotalArea = (double)numericUpDownTotalArea_SAV.Value;
                apartment.LivingArea = (double)numericUpDownLivingArea_SAV.Value;
                apartment.Rooms = (int)numericUpDownRooms_SAV.Value;
                apartment.Surname = textBoxSurname_SAV.Text.Trim();
                apartment.RegDate = dateTimePickerRegDate_SAV.Value;
                apartment.Family = (int)numericUpDownFamily_SAV.Value;
                apartment.Children = (int)numericUpDownChildren_SAV.Value;
                apartment.Debt = checkBoxDebt_SAV.Checked;
                apartment.Notes = textBoxNotes_SAV.Text.Trim();
            }
        }
        public FormMain_SAV()
        {
            InitializeComponent();

            SetupDataGridView();
            SetupComboBoxes();
            InitializeToolTips();
            UpdateButtons();
            UpdateChart();
            tabControlMain.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            dataGridViewApartments_SAV.Columns.Clear();
            string[] columns = { "Подъезд", "Квартира", "Общая пл.", "Жилая пл.", "Комнаты",
                                "Фамилия", "Семья", "Дети", "Дата прописки", "Долг", "Примечание" };

            foreach (string column in columns)
            {
                dataGridViewApartments_SAV.Columns.Add(column, column);
            }
            dataGridViewApartments_SAV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewApartments_SAV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewApartments_SAV.ReadOnly = true;
            dataGridViewApartments_SAV.AllowUserToAddRows = false;
            dataGridViewApartments_SAV.AllowUserToDeleteRows = false;
            dataGridViewApartments_SAV.RowHeadersVisible = false;
        }

        private void SetupComboBoxes()
        {
            comboBoxFilterEntrance_SAV.Items.Clear();
            comboBoxFilterEntrance_SAV.Items.Add("Все подъезды");
            for (int i = 1; i <= 20; i++)
                comboBoxFilterEntrance_SAV.Items.Add($"Подъезд {i}");
            comboBoxFilterEntrance_SAV.SelectedIndex = 0;

            comboBoxFilterDebt_SAV.Items.Clear();
            comboBoxFilterDebt_SAV.Items.AddRange(new[] { "Все", "С долгом", "Без долга" });
            comboBoxFilterDebt_SAV.SelectedIndex = 0;

            comboBoxSortBy_SAV.Items.Clear();
            comboBoxSortBy_SAV.Items.AddRange(new[] { "Номер квартиры", "Общая площадь", "Комнаты", "Дата прописки", "Количество жильцов" });
            comboBoxSortBy_SAV.SelectedIndex = 0;
        }

        private void InitializeToolTips()
        {
            toolTip_SAV.SetToolTip(buttonLoadFile_SAV, "Загрузить данные из файла (Ctrl+O)");
            toolTip_SAV.SetToolTip(buttonSaveFile_SAV, "Сохранить данные в файл (Ctrl+S)");
            toolTip_SAV.SetToolTip(buttonAddApartment_SAV, "Добавить новую квартиру (Ctrl+N)");
            toolTip_SAV.SetToolTip(buttonEditApartment_SAV, "Редактировать выбранную квартиру (Ctrl+E)");
            toolTip_SAV.SetToolTip(buttonDeleteApartment_SAV, "Удалить выбранную квартиру (Delete)");
            toolTip_SAV.SetToolTip(buttonSearch_SAV, "Поиск по фамилии (Enter)");
            toolTip_SAV.SetToolTip(buttonApplyFilters_SAV, "Применить фильтры и сортировку");
            toolTip_SAV.SetToolTip(buttonClearFilters_SAV, "Сбросить все фильтры");
            toolTip_SAV.SetToolTip(buttonExportStats_SAV, "Экспорт статистики в файл");
            toolTip_SAV.SetToolTip(textBoxSearch_SAV, "Введите фамилию для поиска");
            toolTip_SAV.SetToolTip(comboBoxFilterEntrance_SAV, "Фильтр по номеру подъезда");
            toolTip_SAV.SetToolTip(comboBoxFilterDebt_SAV, "Фильтр по наличию долга");
            toolTip_SAV.SetToolTip(comboBoxSortBy_SAV, "Выберите поле для сортировки");
            toolTip_SAV.SetToolTip(checkBoxAscending_SAV, "Сортировка по возрастанию");
        }

        private void ShowData(List<Apartment> data)
        {
            dataGridViewApartments_SAV.Rows.Clear();

            if (data == null || data.Count == 0)
            {
                toolStripStatusLabelInfo_SAV.Text = "Нет данных для отображения";
                UpdateButtons();
                return;
            }
            foreach (var a in data)
            {
                try
                {
                    dataGridViewApartments_SAV.Rows.Add(
                        a.Entrance.ToString(),
                        a.Number.ToString(),
                        a.TotalArea.ToString("F1"),
                        a.LivingArea.ToString("F1"),
                        a.Rooms.ToString(),
                        a.Surname ?? "",
                        a.Family.ToString(),
                        a.Children.ToString(),
                        a.RegDate.ToString("dd.MM.yyyy"),
                        a.Debt ? "Да" : "Нет",
                        a.Notes ?? ""
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка добавления строки: {ex.Message}");
                }
            }

            toolStripStatusLabelInfo_SAV.Text = $"Отображено записей: {data.Count}";
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            bool hasData = list.Any();
            bool hasSelection = dataGridViewApartments_SAV.SelectedRows.Count > 0;

            buttonSaveFile_SAV.Enabled = hasData;
            buttonEditApartment_SAV.Enabled = hasSelection;
            buttonDeleteApartment_SAV.Enabled = hasSelection;
            buttonExportStats_SAV.Enabled = hasData;
            buttonApplyFilters_SAV.Enabled = hasData;
            buttonClearFilters_SAV.Enabled = hasData;
            textBoxSearch_SAV.Enabled = hasData;
            buttonSearch_SAV.Enabled = hasData;
            comboBoxFilterEntrance_SAV.Enabled = hasData;
            comboBoxFilterDebt_SAV.Enabled = hasData;
            comboBoxSortBy_SAV.Enabled = hasData;
            checkBoxAscending_SAV.Enabled = hasData;
            addApartmentToolStripMenuItem_SAV.Enabled = true;
            editApartmentToolStripMenuItem_SAV.Enabled = hasSelection;
            deleteApartmentToolStripMenuItem_SAV.Enabled = hasSelection;
            saveToolStripMenuItem_SAV.Enabled = hasData;
            openToolStripMenuItem_SAV.Enabled = true;
        }

        private void UpdateStats()
        {
            if (!list.Any())
            {
                labelTotalApartments_SAV.Text = "Квартир: 0";
                labelTotalArea_SAV.Text = "Общая площадь: 0 м²";
                labelAvgArea_SAV.Text = "Средняя пл.: 0 м²";
                labelDebtors_SAV.Text = "Должники: 0";
                labelTotalChildren_SAV.Text = "Дети: 0";
                labelAvgFamily_SAV.Text = "Средняя семья: 0";
                labelTotalRooms_SAV.Text = "Комнаты: 0";
                return;
            }

            try
            {
                var stats = ds.GetStats(list);
                labelTotalApartments_SAV.Text = $"Квартир: {stats["Квартир"]}";
                labelTotalArea_SAV.Text = $"Общая площадь: {stats["ОбщаяПлощадь"]:F1} м²";
                labelAvgArea_SAV.Text = $"Средняя пл.: {stats["СрПлощадь"]:F1} м²";
                labelDebtors_SAV.Text = $"Должники: {stats["Должники"]}";
                labelTotalChildren_SAV.Text = $"Дети: {stats["Дети"]}";
                labelAvgFamily_SAV.Text = $"Средняя семья: {stats["СрСемья"]:F1}";
                labelTotalRooms_SAV.Text = $"Комнаты: {stats["Комнаты"]}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обновления статистики: {ex.Message}");
            }
        }

        private void UpdateChart()
        {
            chartStatistics_SAV.Series.Clear();
            chartStatistics_SAV.Titles.Clear();
            chartStatistics_SAV.ChartAreas.Clear();

            if (!list.Any())
            {
                chartStatistics_SAV.Titles.Add("Нет данных для отображения");
                return;
            }

            try
            {
                var chartArea = new ChartArea("Main");
                chartArea.AxisX.Title = "Подъезд";
                chartArea.AxisY.Title = "Количество квартир";
                chartArea.AxisX.Interval = 1;
                chartStatistics_SAV.ChartAreas.Add(chartArea);
                chartStatistics_SAV.Titles.Add("Распределение квартир по подъездам");
                var groups = list
                    .GroupBy(a => a.Entrance)
                    .Select(g => new { Подъезд = g.Key, Квартир = g.Count() })
                    .OrderBy(x => x.Подъезд)
                    .ToList();
                var series = new Series("Квартиры")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.SteelBlue,
                    XValueType = ChartValueType.String,
                    IsValueShownAsLabel = true
                };
                foreach (var group in groups)
                {
                    series.Points.AddXY($"Подъезд {group.Подъезд}", group.Квартир);
                }

                chartStatistics_SAV.Series.Add(series);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обновления графика: {ex.Message}");
            }
        }

        private void TestDataGridView()
        {
            dataGridViewApartments_SAV.Rows.Clear();
            dataGridViewApartments_SAV.Rows.Add("1", "101", "50.5", "35.0", "2", "Иванов", "3", "1", "01.01.2020", "Нет", "Тестовая запись");
            dataGridViewApartments_SAV.Rows.Add("1", "102", "65.0", "45.0", "3", "Петров", "4", "2", "15.03.2021", "Да", "Долг");
            dataGridViewApartments_SAV.Rows.Add("2", "201", "40.0", "28.0", "1", "Сидоров", "2", "0", "10.05.2019", "Нет", "");
            UpdateTestStats();
        }

        private void UpdateTestStats()
        {
            labelTotalApartments_SAV.Text = "Квартир: 3";
            labelTotalArea_SAV.Text = "Общая площадь: 155.5 м²";
            labelAvgArea_SAV.Text = "Средняя пл.: 51.8 м²";
            labelDebtors_SAV.Text = "Должники: 1";
            labelTotalChildren_SAV.Text = "Дети: 3";
            labelAvgFamily_SAV.Text = "Средняя семья: 3.0";
            labelTotalRooms_SAV.Text = "Комнаты: 6";
        }

        private void buttonLoadFile_SAV_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
                dialog.Title = "Загрузить данные";
                dialog.CheckFileExists = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        list = ds.Load(dialog.FileName);
                        filteredList = new List<Apartment>(list);
                        currentFile = dialog.FileName;

                        if (list.Count == 0)
                        {
                            MessageBox.Show("Файл не содержит данных или имеет неправильный формат", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        ShowData(list);
                        UpdateStats();
                        UpdateChart();
                        tabControlMain.SelectedTab = tabPageData;

                        toolStripStatusLabelInfo_SAV.Text = $"Файл загружен: {Path.GetFileName(currentFile)}";
                        MessageBox.Show($"Загружено {list.Count} записей", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show($"Файл не найден:\n{ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show($"Ошибка формата данных в файле:\n{ex.Message}\n\nУбедитесь, что файл имеет правильный формат:\nПодъезд;Квартира;ОбщаяПлощадь;ЖилаяПлощадь;Комнаты;Фамилия;ДатаПрописки;ЧленовСемьи;Детей;Задолженность;Примечание",
                            "Ошибка формата",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки файла:\n{ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonSaveFile_SAV_Click(object sender, EventArgs e)
        {
            if (!list.Any())
            {
                MessageBox.Show("Нет данных для сохранения", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(currentFile))
            {
                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "CSV файлы (*.csv)|*.csv";
                    dialog.Title = "Сохранить данные";
                    dialog.DefaultExt = "csv";

                    if (dialog.ShowDialog() != DialogResult.OK) return;
                    currentFile = dialog.FileName;
                }
            }

            try
            {
                ds.Save(currentFile, list);
                MessageBox.Show($"Данные сохранены в файл:\n{currentFile}", "Успешно",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripStatusLabelInfo_SAV.Text = $"Файл сохранен: {Path.GetFileName(currentFile)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddApartment_SAV_Click(object sender, EventArgs e)
        {
            using (var form = new EditApartmentForm_SAV())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var newApartment = form.EditedApartment;
                    if (list.Any(a => a.Entrance == newApartment.Entrance && a.Number == newApartment.Number))
                    {
                        MessageBox.Show("Квартира с таким номером уже существует в этом подъезде", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    list.Add(newApartment);
                    filteredList = new List<Apartment>(list);

                    ShowData(list);
                    UpdateStats();
                    UpdateChart();
                    tabControlMain.SelectedTab = tabPageData;

                    MessageBox.Show("Квартира успешно добавлена", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonEditApartment_SAV_Click(object sender, EventArgs e)
        {
            if (dataGridViewApartments_SAV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите квартиру для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = dataGridViewApartments_SAV.SelectedRows[0].Index;
            if (selectedIndex < 0 || selectedIndex >= filteredList.Count) return;

            var apartmentToEdit = filteredList[selectedIndex];
            var apartmentCopy = new Apartment
            {
                Entrance = apartmentToEdit.Entrance,
                Number = apartmentToEdit.Number,
                TotalArea = apartmentToEdit.TotalArea,
                LivingArea = apartmentToEdit.LivingArea,
                Rooms = apartmentToEdit.Rooms,
                Surname = apartmentToEdit.Surname,
                RegDate = apartmentToEdit.RegDate,
                Family = apartmentToEdit.Family,
                Children = apartmentToEdit.Children,
                Debt = apartmentToEdit.Debt,
                Notes = apartmentToEdit.Notes
            };

            using (var form = new EditApartmentForm_SAV(apartmentCopy))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var editedApartment = form.EditedApartment;
                    var originalIndex = list.FindIndex(a =>
                        a.Entrance == apartmentToEdit.Entrance &&
                        a.Number == apartmentToEdit.Number);

                    if (originalIndex >= 0)
                    {
                        list[originalIndex] = editedApartment;
                        if (selectedIndex < filteredList.Count)
                        {
                            filteredList[selectedIndex] = editedApartment;
                        }

                        ShowData(filteredList);
                        UpdateStats();
                        UpdateChart();
                        tabControlMain.SelectedTab = tabPageData;

                        MessageBox.Show("Изменения сохранены", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void buttonDeleteApartment_SAV_Click(object sender, EventArgs e)
        {
            if (dataGridViewApartments_SAV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите квартиру для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = dataGridViewApartments_SAV.SelectedRows[0].Index;
            if (selectedIndex < 0 || selectedIndex >= filteredList.Count) return;

            var apartmentToDelete = filteredList[selectedIndex];

            var result = MessageBox.Show(
                $"Удалить квартиру №{apartmentToDelete.Number} в подъезде {apartmentToDelete.Entrance}?\n" +
                $"Жилец: {apartmentToDelete.Surname} ({apartmentToDelete.Family} чел.)",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                list.RemoveAll(a =>
                    a.Entrance == apartmentToDelete.Entrance &&
                    a.Number == apartmentToDelete.Number);

                filteredList.RemoveAt(selectedIndex);

                ShowData(filteredList);
                UpdateStats();
                UpdateChart();
                tabControlMain.SelectedTab = tabPageData;

                MessageBox.Show("Квартира удалена", "Успешно",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSearch_SAV_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch_SAV.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                filteredList = new List<Apartment>(list);
                ShowData(filteredList);
                toolStripStatusLabelInfo_SAV.Text = "Поиск отменен";
                return;
            }

            var results = ds.Search(list, searchText);
            filteredList = results;
            ShowData(filteredList);
            tabControlMain.SelectedTab = tabPageData;

            toolStripStatusLabelInfo_SAV.Text = $"Найдено записей: {results.Count}";
        }

        private void buttonApplyFilters_SAV_Click(object sender, EventArgs e)
        {
            if (!list.Any()) return;

            filteredList = new List<Apartment>(list);

            if (comboBoxFilterEntrance_SAV.SelectedIndex > 0)
            {
                int entranceNumber = comboBoxFilterEntrance_SAV.SelectedIndex;
                filteredList = ds.FilterEntrance(filteredList, entranceNumber);
            }

            if (comboBoxFilterDebt_SAV.SelectedIndex == 1)
            {
                filteredList = ds.FilterDebt(filteredList, true);
            }
            else if (comboBoxFilterDebt_SAV.SelectedIndex == 2)
            {
                filteredList = ds.FilterDebt(filteredList, false);
            }

            bool asc = checkBoxAscending_SAV.Checked;
            string sortBy = comboBoxSortBy_SAV.SelectedItem.ToString();

            switch (sortBy)
            {
                case "Номер квартиры":
                    filteredList = ds.SortByNumber(filteredList, asc);
                    break;
                case "Общая площадь":
                    filteredList = ds.SortByArea(filteredList, asc);
                    break;
                case "Комнаты":
                    filteredList = ds.SortByRooms(filteredList, asc);
                    break;
                case "Дата прописки":
                    filteredList = ds.SortByDate(filteredList, asc);
                    break;
                case "Количество жильцов":
                    filteredList = asc ?
                        filteredList.OrderBy(a => a.Family).ToList() :
                        filteredList.OrderByDescending(a => a.Family).ToList();
                    break;
            }

            ShowData(filteredList);
            tabControlMain.SelectedTab = tabPageData;

            toolStripStatusLabelInfo_SAV.Text = $"Отфильтровано записей: {filteredList.Count}";
        }

        private void buttonClearFilters_SAV_Click(object sender, EventArgs e)
        {
            comboBoxFilterEntrance_SAV.SelectedIndex = 0;
            comboBoxFilterDebt_SAV.SelectedIndex = 0;
            comboBoxSortBy_SAV.SelectedIndex = 0;
            checkBoxAscending_SAV.Checked = true;
            textBoxSearch_SAV.Clear();

            filteredList = new List<Apartment>(list);
            ShowData(filteredList);
            tabControlMain.SelectedTab = tabPageData;

            toolStripStatusLabelInfo_SAV.Text = "Фильтры сброшены";

            if (list.Any())
            {
                UpdateStats();
                UpdateChart();
            }
        }

        private void buttonExportStats_SAV_Click(object sender, EventArgs e)
        {
            if (!list.Any())
            {
                MessageBox.Show("Нет данных для экспорта", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                dialog.Title = "Экспорт статистики";
                dialog.DefaultExt = "txt";
                dialog.FileName = $"Статистика_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportStatistics(dialog.FileName);
                        MessageBox.Show($"Статистика экспортирована в файл:\n{dialog.FileName}", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка экспорта:\n{ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportStatistics(string filePath)
        {
            var stats = ds.GetStats(list);
            var entranceStats = ds.GetEntranceStats(list);

            using (var writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine("СТАТИСТИКА ДОМОУПРАВЛЕНИЯ");
                writer.WriteLine($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}");
                writer.WriteLine(new string('=', 50));
                writer.WriteLine();
                writer.WriteLine("ОБЩАЯ СТАТИСТИКА:");
                writer.WriteLine($"Всего квартир: {stats["Квартир"]}");
                writer.WriteLine($"Общая площадь: {stats["ОбщаяПлощадь"]:F1} м²");
                writer.WriteLine($"Средняя площадь: {stats["СрПлощадь"]:F1} м²");
                writer.WriteLine($"Макс. площадь: {stats["МаксПлощадь"]:F1} м²");
                writer.WriteLine($"Мин. площадь: {stats["МинПлощадь"]:F1} м²");
                writer.WriteLine($"Всего жильцов: {stats["Жильцы"]}");
                writer.WriteLine($"Средний размер семьи: {stats["СрСемья"]:F1}");
                writer.WriteLine($"Всего детей: {stats["Дети"]}");
                writer.WriteLine($"Всего комнат: {stats["Комнаты"]}");
                writer.WriteLine($"Квартир с долгом: {stats["Должники"]}");
                writer.WriteLine();
                writer.WriteLine("СТАТИСТИКА ПО ПОДЪЕЗДАМ:");
                writer.WriteLine(new string('-', 50));

                foreach (var entrance in entranceStats.OrderBy(e => e.Key))
                {
                    writer.WriteLine($"Подъезд {entrance.Key}:");
                    writer.WriteLine($"  Квартир: {entrance.Value.Apartments}");
                    writer.WriteLine($"  Общая площадь: {entrance.Value.TotalArea:F1} м²");
                    writer.WriteLine($"  Жилая площадь: {entrance.Value.LivingArea:F1} м²");
                    writer.WriteLine($"  Жильцов: {entrance.Value.Residents}");
                    writer.WriteLine($"  Детей: {entrance.Value.Children}");
                    writer.WriteLine($"  Комнат: {entrance.Value.Rooms}");
                    writer.WriteLine($"  Должников: {entrance.Value.Debtors}");
                    writer.WriteLine();
                }

                writer.WriteLine("ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ:");
                writer.WriteLine(new string('-', 50));
                writer.WriteLine($"Файл данных: {currentFile}");
                writer.WriteLine($"Последнее обновление: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
            }
        }

        private void dataGridViewApartments_SAV_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void textBoxSearch_SAV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonSearch_SAV_Click(sender, e);
                e.Handled = true;
            }
        }

        private void ExitToolStripMenuItem_SAV_Click(object sender, EventArgs e)
        {
            if (list.Any())
            {
                var result = MessageBox.Show("Сохранить изменения перед выходом?", "Подтверждение",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    buttonSaveFile_SAV_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            Application.Exit();
        }

        private void AboutToolStripMenuItem_SAV_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Домоуправление \n\n" +
                "Разработчик: Шиганова А.В.\n" +
                "Приложение для учета квартир в жилом доме\n" +
                "© 2025 Все права защищены",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void GuideToolStripMenuItem_SAV_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Краткое руководство пользователя:\n\n" +
                "1. Загрузите данные из CSV файла (Файл → Открыть)\n" +
                "2. Для добавления квартиры нажмите кнопку '+' или Ctrl+N\n" +
                "3. Для редактирования выделите строку и нажмите кнопку карандаша или Ctrl+E\n" +
                "4. Для удаления выделите строку и нажмите кнопку корзины или Delete\n" +
                "5. Используйте фильтры и поиск для быстрого поиска данных\n" +
                "6. Статистика и графики обновляются автоматически\n" +
                "7. Для сохранения данных нажмите кнопку дискеты или Ctrl+S\n" +
                "8. Экспорт статистики доступен через соответствующую кнопку",
                "Руководство пользователя",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void FormMain_SAV_Load(object sender, EventArgs e)
        {
        }
    }
}