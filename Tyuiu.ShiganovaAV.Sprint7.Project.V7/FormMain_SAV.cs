namespace Tyuiu.ShiganovaAV.Sprint7.Project.V7
{
    partial class FormMain_SAV
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            menuStripMain_SAV = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemOpen_SAV = new ToolStripMenuItem();
            toolStripMenuItemSave_SAV = new ToolStripMenuItem();
            toolStripMenuItemExit_SAV = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemAbout_SAV = new ToolStripMenuItem();
            toolStripMenuItemHelp_SAV = new ToolStripMenuItem();
            toolStripMain_SAV = new ToolStrip();
            buttonLoadFile_SAV = new ToolStripButton();
            buttonSaveFile_SAV = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            buttonAddApartment_SAV = new ToolStripButton();
            buttonEditApartment_SAV = new ToolStripButton();
            buttonDeleteApartment_SAV = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            buttonExportStats_SAV = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            buttonHelp_SAV = new ToolStripButton();
            buttonAbout_SAV = new ToolStripButton();
            statusStripMain_SAV = new StatusStrip();
            toolStripStatusLabelInfo_SAV = new ToolStripStatusLabel();
            splitContainerMain_SAV = new SplitContainer();
            panelLeft_SAV = new Panel();
            dataGridViewApartments_SAV = new DataGridView();
            groupBoxFilters_SAV = new GroupBox();
            buttonApplyFilters_SAV = new Button();
            checkBoxAscending_SAV = new CheckBox();
            comboBoxSortBy_SAV = new ComboBox();
            labelSortBy_SAV = new Label();
            comboBoxFilterDebt_SAV = new ComboBox();
            labelFilterDebt_SAV = new Label();
            comboBoxFilterEntrance_SAV = new ComboBox();
            labelFilterEntrance_SAV = new Label();
            groupBoxSearch_SAV = new GroupBox();
            buttonSearch_SAV = new Button();
            textBoxSearch_SAV = new TextBox();
            panelRight_SAV = new Panel();
            groupBoxChart_SAV = new GroupBox();
            chartStatistics_SAV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBoxStatistics_SAV = new GroupBox();
            labelTotalRooms_SAV = new Label();
            labelAvgFamily_SAV = new Label();
            labelTotalChildren_SAV = new Label();
            labelDebtors_SAV = new Label();
            labelAvgArea_SAV = new Label();
            labelTotalArea_SAV = new Label();
            labelTotalApartments_SAV = new Label();
            menuStripMain_SAV.SuspendLayout();
            toolStripMain_SAV.SuspendLayout();
            statusStripMain_SAV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain_SAV).BeginInit();
            splitContainerMain_SAV.Panel1.SuspendLayout();
            splitContainerMain_SAV.Panel2.SuspendLayout();
            splitContainerMain_SAV.SuspendLayout();
            panelLeft_SAV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewApartments_SAV).BeginInit();
            groupBoxFilters_SAV.SuspendLayout();
            groupBoxSearch_SAV.SuspendLayout();
            panelRight_SAV.SuspendLayout();
            groupBoxChart_SAV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartStatistics_SAV).BeginInit();
            groupBoxStatistics_SAV.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripMain_SAV
            // 
            menuStripMain_SAV.ImageScalingSize = new Size(20, 20);
            menuStripMain_SAV.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, справкаToolStripMenuItem });
            menuStripMain_SAV.Location = new Point(0, 0);
            menuStripMain_SAV.Name = "menuStripMain_SAV";
            menuStripMain_SAV.Size = new Size(1200, 28);
            menuStripMain_SAV.TabIndex = 0;
            menuStripMain_SAV.Text = "menuStripMain_SAV";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemOpen_SAV, toolStripMenuItemSave_SAV, toolStripMenuItemExit_SAV });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // toolStripMenuItemOpen_SAV
            // 
            toolStripMenuItemOpen_SAV.Name = "toolStripMenuItemOpen_SAV";
            toolStripMenuItemOpen_SAV.ShortcutKeys = Keys.Control | Keys.O;
            toolStripMenuItemOpen_SAV.Size = new Size(216, 26);
            toolStripMenuItemOpen_SAV.Text = "Открыть";
            toolStripMenuItemOpen_SAV.Click += toolStripMenuItemOpen_SAV_Click;
            // 
            // toolStripMenuItemSave_SAV
            // 
            toolStripMenuItemSave_SAV.Name = "toolStripMenuItemSave_SAV";
            toolStripMenuItemSave_SAV.ShortcutKeys = Keys.Control | Keys.S;
            toolStripMenuItemSave_SAV.Size = new Size(216, 26);
            toolStripMenuItemSave_SAV.Text = "Сохранить";
            toolStripMenuItemSave_SAV.Click += toolStripMenuItemSave_SAV_Click;
            // 
            // toolStripMenuItemExit_SAV
            // 
            toolStripMenuItemExit_SAV.Name = "toolStripMenuItemExit_SAV";
            toolStripMenuItemExit_SAV.ShortcutKeys = Keys.Alt | Keys.F4;
            toolStripMenuItemExit_SAV.Size = new Size(216, 26);
            toolStripMenuItemExit_SAV.Text = "Выход";
            toolStripMenuItemExit_SAV.Click += toolStripMenuItemExit_SAV_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemAbout_SAV, toolStripMenuItemHelp_SAV });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(81, 24);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // toolStripMenuItemAbout_SAV
            // 
            toolStripMenuItemAbout_SAV.Name = "toolStripMenuItemAbout_SAV";
            toolStripMenuItemAbout_SAV.Size = new Size(187, 26);
            toolStripMenuItemAbout_SAV.Text = "О программе";
            toolStripMenuItemAbout_SAV.Click += buttonAbout_SAV_Click;
            // 
            // toolStripMenuItemHelp_SAV
            // 
            toolStripMenuItemHelp_SAV.Name = "toolStripMenuItemHelp_SAV";
            toolStripMenuItemHelp_SAV.Size = new Size(187, 26);
            toolStripMenuItemHelp_SAV.Text = "Помощь";
            toolStripMenuItemHelp_SAV.Click += buttonHelp_SAV_Click;
            // 
            // toolStripMain_SAV
            // 
            toolStripMain_SAV.ImageScalingSize = new Size(20, 20);
            toolStripMain_SAV.Items.AddRange(new ToolStripItem[] { buttonLoadFile_SAV, buttonSaveFile_SAV, toolStripSeparator1, buttonAddApartment_SAV, buttonEditApartment_SAV, buttonDeleteApartment_SAV, toolStripSeparator2, buttonExportStats_SAV, toolStripSeparator3, buttonHelp_SAV, buttonAbout_SAV });
            toolStripMain_SAV.Location = new Point(0, 28);
            toolStripMain_SAV.Name = "toolStripMain_SAV";
            toolStripMain_SAV.Size = new Size(1200, 27);
            toolStripMain_SAV.TabIndex = 1;
            toolStripMain_SAV.Text = "toolStripMain_SAV";
            // 
            // buttonLoadFile_SAV
            // 
            buttonLoadFile_SAV.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonLoadFile_SAV.ImageTransparentColor = Color.Magenta;
            buttonLoadFile_SAV.Name = "buttonLoadFile_SAV";
            buttonLoadFile_SAV.Size = new Size(81, 24);
            buttonLoadFile_SAV.Text = "Загрузить";
            buttonLoadFile_SAV.Click += buttonLoadFile_SAV_Click;
            // 
            // buttonSaveFile_SAV
            // 
            buttonSaveFile_SAV.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonSaveFile_SAV.Enabled = false;
            buttonSaveFile_SAV.ImageTransparentColor = Color.Magenta;
            buttonSaveFile_SAV.Name = "buttonSaveFile_SAV";
            buttonSaveFile_SAV.Size = new Size(87, 24);
            buttonSaveFile_SAV.Text = "Сохранить";
            buttonSaveFile_SAV.Click += buttonSaveFile_SAV_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // buttonAddApartment_SAV
            // 
            buttonAddApartment_SAV.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonAddApartment_SAV.Enabled = false;
            buttonAddApartment_SAV.ImageTransparentColor = Color.Magenta;
            buttonAddApartment_SAV.Name = "buttonAddApartment_SAV";
            buttonAddApartment_SAV.Size = new Size(80, 24);
            buttonAddApartment_SAV.Text = "Добавить";
            buttonAddApartment_SAV.Click += buttonAddApartment_SAV_Click;
            // 
            // buttonEditApartment_SAV
            // 
            buttonEditApartment_SAV.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonEditApartment_SAV.Enabled = false;
            buttonEditApartment_SAV.ImageTransparentColor = Color.Magenta;
            buttonEditApartment_SAV.Name = "buttonEditApartment_SAV";
            buttonEditApartment_SAV.Size = new Size(82, 24);
            buttonEditApartment_SAV.Text = "Изменить";
            buttonEditApartment_SAV.Click += buttonEditApartment_SAV_Click;
            // 
            // buttonDeleteApartment_SAV
            // 
            buttonDeleteApartment_SAV.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonDeleteApartment_SAV.Enabled = false;
            buttonDeleteApartment_SAV.ImageTransparentColor = Color.Magenta;
            buttonDeleteApartment_SAV.Name = "buttonDeleteApartment_SAV";
            buttonDeleteApartment_SAV.Size = new Size(69, 24);
            buttonDeleteApartment_SAV.Text = "Удалить";
            buttonDeleteApartment_SAV.Click += buttonDeleteApartment_SAV_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 27);
            // 
            // buttonExportStats_SAV
            // 
            buttonExportStats_SAV.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonExportStats_SAV.Enabled = false;
            buttonExportStats_SAV.ImageTransparentColor = Color.Magenta;
            buttonExportStats_SAV.Name = "buttonExportStats_SAV";
            buttonExportStats_SAV.Size = new Size(147, 24);
            buttonExportStats_SAV.Text = "Экспорт статистики";
            buttonExportStats_SAV.Click += buttonExportStats_SAV_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 27);
            // 
            // buttonHelp_SAV
            // 
            buttonHelp_SAV.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonHelp_SAV.ImageTransparentColor = Color.Magenta;
            buttonHelp_SAV.Name = "buttonHelp_SAV";
            buttonHelp_SAV.Size = new Size(71, 24);
            buttonHelp_SAV.Text = "Справка";
            buttonHelp_SAV.Click += buttonHelp_SAV_Click;
            // 
            // buttonAbout_SAV
            // 
            buttonAbout_SAV.DisplayStyle = ToolStripItemDisplayStyle.Text;
            buttonAbout_SAV.ImageTransparentColor = Color.Magenta;
            buttonAbout_SAV.Name = "buttonAbout_SAV";
            buttonAbout_SAV.Size = new Size(108, 24);
            buttonAbout_SAV.Text = "О программе";
            buttonAbout_SAV.Click += buttonAbout_SAV_Click;
            // 
            // statusStripMain_SAV
            // 
            statusStripMain_SAV.ImageScalingSize = new Size(20, 20);
            statusStripMain_SAV.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelInfo_SAV });
            statusStripMain_SAV.Location = new Point(0, 849);
            statusStripMain_SAV.Name = "statusStripMain_SAV";
            statusStripMain_SAV.Size = new Size(1200, 26);
            statusStripMain_SAV.TabIndex = 2;
            statusStripMain_SAV.Text = "statusStripMain_SAV";
            // 
            // toolStripStatusLabelInfo_SAV
            // 
            toolStripStatusLabelInfo_SAV.Name = "toolStripStatusLabelInfo_SAV";
            toolStripStatusLabelInfo_SAV.Size = new Size(1185, 20);
            toolStripStatusLabelInfo_SAV.Spring = true;
            toolStripStatusLabelInfo_SAV.Text = "Готов к работе";
            toolStripStatusLabelInfo_SAV.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // splitContainerMain_SAV
            // 
            splitContainerMain_SAV.Dock = DockStyle.Fill;
            splitContainerMain_SAV.Location = new Point(0, 55);
            splitContainerMain_SAV.Margin = new Padding(3, 4, 3, 4);
            splitContainerMain_SAV.Name = "splitContainerMain_SAV";
            // 
            // splitContainerMain_SAV.Panel1
            // 
            splitContainerMain_SAV.Panel1.Controls.Add(panelLeft_SAV);
            // 
            // splitContainerMain_SAV.Panel2
            // 
            splitContainerMain_SAV.Panel2.Controls.Add(panelRight_SAV);
            splitContainerMain_SAV.Size = new Size(1200, 794);
            splitContainerMain_SAV.SplitterDistance = 800;
            splitContainerMain_SAV.TabIndex = 3;
            // 
            // panelLeft_SAV
            // 
            panelLeft_SAV.Controls.Add(dataGridViewApartments_SAV);
            panelLeft_SAV.Controls.Add(groupBoxFilters_SAV);
            panelLeft_SAV.Controls.Add(groupBoxSearch_SAV);
            panelLeft_SAV.Dock = DockStyle.Fill;
            panelLeft_SAV.Location = new Point(0, 0);
            panelLeft_SAV.Margin = new Padding(3, 4, 3, 4);
            panelLeft_SAV.Name = "panelLeft_SAV";
            panelLeft_SAV.Padding = new Padding(10, 12, 10, 12);
            panelLeft_SAV.Size = new Size(800, 794);
            panelLeft_SAV.TabIndex = 0;
            // 
            // dataGridViewApartments_SAV
            // 
            dataGridViewApartments_SAV.AllowUserToAddRows = false;
            dataGridViewApartments_SAV.AllowUserToDeleteRows = false;
            dataGridViewApartments_SAV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewApartments_SAV.BackgroundColor = Color.White;
            dataGridViewApartments_SAV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewApartments_SAV.Dock = DockStyle.Fill;
            dataGridViewApartments_SAV.Location = new Point(10, 222);
            dataGridViewApartments_SAV.Margin = new Padding(3, 4, 3, 4);
            dataGridViewApartments_SAV.MultiSelect = false;
            dataGridViewApartments_SAV.Name = "dataGridViewApartments_SAV";
            dataGridViewApartments_SAV.ReadOnly = true;
            dataGridViewApartments_SAV.RowHeadersWidth = 51;
            dataGridViewApartments_SAV.RowTemplate.Height = 24;
            dataGridViewApartments_SAV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewApartments_SAV.Size = new Size(780, 560);
            dataGridViewApartments_SAV.TabIndex = 2;
            dataGridViewApartments_SAV.SelectionChanged += dataGridViewApartments_SAV_SelectionChanged;
            // 
            // groupBoxFilters_SAV
            // 
            groupBoxFilters_SAV.Controls.Add(buttonApplyFilters_SAV);
            groupBoxFilters_SAV.Controls.Add(checkBoxAscending_SAV);
            groupBoxFilters_SAV.Controls.Add(comboBoxSortBy_SAV);
            groupBoxFilters_SAV.Controls.Add(labelSortBy_SAV);
            groupBoxFilters_SAV.Controls.Add(comboBoxFilterDebt_SAV);
            groupBoxFilters_SAV.Controls.Add(labelFilterDebt_SAV);
            groupBoxFilters_SAV.Controls.Add(comboBoxFilterEntrance_SAV);
            groupBoxFilters_SAV.Controls.Add(labelFilterEntrance_SAV);
            groupBoxFilters_SAV.Dock = DockStyle.Top;
            groupBoxFilters_SAV.Location = new Point(10, 84);
            groupBoxFilters_SAV.Margin = new Padding(3, 4, 3, 4);
            groupBoxFilters_SAV.Name = "groupBoxFilters_SAV";
            groupBoxFilters_SAV.Padding = new Padding(3, 4, 3, 4);
            groupBoxFilters_SAV.Size = new Size(780, 138);
            groupBoxFilters_SAV.TabIndex = 1;
            groupBoxFilters_SAV.TabStop = false;
            groupBoxFilters_SAV.Text = "Фильтры и сортировка";
            // 
            // buttonApplyFilters_SAV
            // 
            buttonApplyFilters_SAV.Enabled = false;
            buttonApplyFilters_SAV.Location = new Point(650, 88);
            buttonApplyFilters_SAV.Margin = new Padding(3, 4, 3, 4);
            buttonApplyFilters_SAV.Name = "buttonApplyFilters_SAV";
            buttonApplyFilters_SAV.Size = new Size(120, 38);
            buttonApplyFilters_SAV.TabIndex = 7;
            buttonApplyFilters_SAV.Text = "Применить";
            buttonApplyFilters_SAV.UseVisualStyleBackColor = true;
            buttonApplyFilters_SAV.Click += buttonApplyFilters_SAV_Click;
            // 
            // checkBoxAscending_SAV
            // 
            checkBoxAscending_SAV.AutoSize = true;
            checkBoxAscending_SAV.Checked = true;
            checkBoxAscending_SAV.CheckState = CheckState.Checked;
            checkBoxAscending_SAV.Location = new Point(550, 94);
            checkBoxAscending_SAV.Margin = new Padding(3, 4, 3, 4);
            checkBoxAscending_SAV.Name = "checkBoxAscending_SAV";
            checkBoxAscending_SAV.Size = new Size(91, 24);
            checkBoxAscending_SAV.TabIndex = 6;
            checkBoxAscending_SAV.Text = "По возр.";
            checkBoxAscending_SAV.UseVisualStyleBackColor = true;
            // 
            // comboBoxSortBy_SAV
            // 
            comboBoxSortBy_SAV.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSortBy_SAV.FormattingEnabled = true;
            comboBoxSortBy_SAV.Location = new Point(400, 90);
            comboBoxSortBy_SAV.Margin = new Padding(3, 4, 3, 4);
            comboBoxSortBy_SAV.Name = "comboBoxSortBy_SAV";
            comboBoxSortBy_SAV.Size = new Size(140, 28);
            comboBoxSortBy_SAV.TabIndex = 5;
            // 
            // labelSortBy_SAV
            // 
            labelSortBy_SAV.AutoSize = true;
            labelSortBy_SAV.Location = new Point(397, 62);
            labelSortBy_SAV.Name = "labelSortBy_SAV";
            labelSortBy_SAV.Size = new Size(95, 20);
            labelSortBy_SAV.TabIndex = 4;
            labelSortBy_SAV.Text = "Сортировка:";
            // 
            // comboBoxFilterDebt_SAV
            // 
            comboBoxFilterDebt_SAV.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilterDebt_SAV.FormattingEnabled = true;
            comboBoxFilterDebt_SAV.Location = new Point(200, 90);
            comboBoxFilterDebt_SAV.Margin = new Padding(3, 4, 3, 4);
            comboBoxFilterDebt_SAV.Name = "comboBoxFilterDebt_SAV";
            comboBoxFilterDebt_SAV.Size = new Size(140, 28);
            comboBoxFilterDebt_SAV.TabIndex = 3;
            // 
            // labelFilterDebt_SAV
            // 
            labelFilterDebt_SAV.AutoSize = true;
            labelFilterDebt_SAV.Location = new Point(197, 62);
            labelFilterDebt_SAV.Name = "labelFilterDebt_SAV";
            labelFilterDebt_SAV.Size = new Size(54, 20);
            labelFilterDebt_SAV.TabIndex = 2;
            labelFilterDebt_SAV.Text = "Долги:";
            // 
            // comboBoxFilterEntrance_SAV
            // 
            comboBoxFilterEntrance_SAV.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFilterEntrance_SAV.FormattingEnabled = true;
            comboBoxFilterEntrance_SAV.Location = new Point(20, 90);
            comboBoxFilterEntrance_SAV.Margin = new Padding(3, 4, 3, 4);
            comboBoxFilterEntrance_SAV.Name = "comboBoxFilterEntrance_SAV";
            comboBoxFilterEntrance_SAV.Size = new Size(140, 28);
            comboBoxFilterEntrance_SAV.TabIndex = 1;
            // 
            // labelFilterEntrance_SAV
            // 
            labelFilterEntrance_SAV.AutoSize = true;
            labelFilterEntrance_SAV.Location = new Point(17, 62);
            labelFilterEntrance_SAV.Name = "labelFilterEntrance_SAV";
            labelFilterEntrance_SAV.Size = new Size(72, 20);
            labelFilterEntrance_SAV.TabIndex = 0;
            labelFilterEntrance_SAV.Text = "Подъезд:";
            // 
            // groupBoxSearch_SAV
            // 
            groupBoxSearch_SAV.Controls.Add(buttonSearch_SAV);
            groupBoxSearch_SAV.Controls.Add(textBoxSearch_SAV);
            groupBoxSearch_SAV.Dock = DockStyle.Top;
            groupBoxSearch_SAV.Location = new Point(10, 12);
            groupBoxSearch_SAV.Margin = new Padding(3, 4, 3, 4);
            groupBoxSearch_SAV.Name = "groupBoxSearch_SAV";
            groupBoxSearch_SAV.Padding = new Padding(3, 4, 3, 4);
            groupBoxSearch_SAV.Size = new Size(780, 72);
            groupBoxSearch_SAV.TabIndex = 0;
            groupBoxSearch_SAV.TabStop = false;
            groupBoxSearch_SAV.Text = "Поиск по фамилии";
            // 
            // buttonSearch_SAV
            // 
            buttonSearch_SAV.Enabled = false;
            buttonSearch_SAV.Location = new Point(650, 25);
            buttonSearch_SAV.Margin = new Padding(3, 4, 3, 4);
            buttonSearch_SAV.Name = "buttonSearch_SAV";
            buttonSearch_SAV.Size = new Size(120, 38);
            buttonSearch_SAV.TabIndex = 1;
            buttonSearch_SAV.Text = "Найти";
            buttonSearch_SAV.UseVisualStyleBackColor = true;
            buttonSearch_SAV.Click += buttonSearch_SAV_Click;
            // 
            // textBoxSearch_SAV
            // 
            textBoxSearch_SAV.Enabled = false;
            textBoxSearch_SAV.Location = new Point(20, 31);
            textBoxSearch_SAV.Margin = new Padding(3, 4, 3, 4);
            textBoxSearch_SAV.Name = "textBoxSearch_SAV";
            textBoxSearch_SAV.Size = new Size(620, 27);
            textBoxSearch_SAV.TabIndex = 0;
            textBoxSearch_SAV.KeyPress += textBoxSearch_SAV_KeyPress;
            // 
            // panelRight_SAV
            // 
            panelRight_SAV.Controls.Add(groupBoxChart_SAV);
            panelRight_SAV.Controls.Add(groupBoxStatistics_SAV);
            panelRight_SAV.Dock = DockStyle.Fill;
            panelRight_SAV.Location = new Point(0, 0);
            panelRight_SAV.Margin = new Padding(3, 4, 3, 4);
            panelRight_SAV.Name = "panelRight_SAV";
            panelRight_SAV.Padding = new Padding(10, 12, 10, 12);
            panelRight_SAV.Size = new Size(396, 794);
            panelRight_SAV.TabIndex = 0;
            // 
            // groupBoxChart_SAV
            // 
            groupBoxChart_SAV.Controls.Add(chartStatistics_SAV);
            groupBoxChart_SAV.Dock = DockStyle.Fill;
            groupBoxChart_SAV.Location = new Point(10, 290);
            groupBoxChart_SAV.Margin = new Padding(3, 4, 3, 4);
            groupBoxChart_SAV.Name = "groupBoxChart_SAV";
            groupBoxChart_SAV.Padding = new Padding(3, 4, 3, 4);
            groupBoxChart_SAV.Size = new Size(376, 492);
            groupBoxChart_SAV.TabIndex = 1;
            groupBoxChart_SAV.TabStop = false;
            groupBoxChart_SAV.Text = "График распределения";
            // 
            // chartStatistics_SAV
            // 
            chartArea1.Name = "ChartArea1";
            chartStatistics_SAV.ChartAreas.Add(chartArea1);
            chartStatistics_SAV.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartStatistics_SAV.Legends.Add(legend1);
            chartStatistics_SAV.Location = new Point(3, 24);
            chartStatistics_SAV.Margin = new Padding(3, 4, 3, 4);
            chartStatistics_SAV.Name = "chartStatistics_SAV";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartStatistics_SAV.Series.Add(series1);
            chartStatistics_SAV.Size = new Size(370, 464);
            chartStatistics_SAV.TabIndex = 0;
            chartStatistics_SAV.Text = "chartStatistics_SAV";
            // 
            // groupBoxStatistics_SAV
            // 
            groupBoxStatistics_SAV.Controls.Add(labelTotalRooms_SAV);
            groupBoxStatistics_SAV.Controls.Add(labelAvgFamily_SAV);
            groupBoxStatistics_SAV.Controls.Add(labelTotalChildren_SAV);
            groupBoxStatistics_SAV.Controls.Add(labelDebtors_SAV);
            groupBoxStatistics_SAV.Controls.Add(labelAvgArea_SAV);
            groupBoxStatistics_SAV.Controls.Add(labelTotalArea_SAV);
            groupBoxStatistics_SAV.Controls.Add(labelTotalApartments_SAV);
            groupBoxStatistics_SAV.Dock = DockStyle.Top;
            groupBoxStatistics_SAV.Location = new Point(10, 12);
            groupBoxStatistics_SAV.Margin = new Padding(3, 4, 3, 4);
            groupBoxStatistics_SAV.Name = "groupBoxStatistics_SAV";
            groupBoxStatistics_SAV.Padding = new Padding(3, 4, 3, 4);
            groupBoxStatistics_SAV.Size = new Size(376, 278);
            groupBoxStatistics_SAV.TabIndex = 0;
            groupBoxStatistics_SAV.TabStop = false;
            groupBoxStatistics_SAV.Text = "Статистика";
            // 
            // labelTotalRooms_SAV
            // 
            labelTotalRooms_SAV.AutoSize = true;
            labelTotalRooms_SAV.Location = new Point(20, 238);
            labelTotalRooms_SAV.Name = "labelTotalRooms_SAV";
            labelTotalRooms_SAV.Size = new Size(117, 20);
            labelTotalRooms_SAV.TabIndex = 6;
            labelTotalRooms_SAV.Text = "Всего комнат: 0";
            // 
            // labelAvgFamily_SAV
            // 
            labelAvgFamily_SAV.AutoSize = true;
            labelAvgFamily_SAV.Location = new Point(20, 205);
            labelAvgFamily_SAV.Name = "labelAvgFamily_SAV";
            labelAvgFamily_SAV.Size = new Size(148, 20);
            labelAvgFamily_SAV.TabIndex = 5;
            labelAvgFamily_SAV.Text = "Ср. размер семьи: 0";
            // 
            // labelTotalChildren_SAV
            // 
            labelTotalChildren_SAV.AutoSize = true;
            labelTotalChildren_SAV.Location = new Point(20, 172);
            labelTotalChildren_SAV.Name = "labelTotalChildren_SAV";
            labelTotalChildren_SAV.Size = new Size(106, 20);
            labelTotalChildren_SAV.TabIndex = 4;
            labelTotalChildren_SAV.Text = "Всего детей: 0";
            // 
            // labelDebtors_SAV
            // 
            labelDebtors_SAV.AutoSize = true;
            labelDebtors_SAV.Location = new Point(20, 140);
            labelDebtors_SAV.Name = "labelDebtors_SAV";
            labelDebtors_SAV.Size = new Size(104, 20);
            labelDebtors_SAV.TabIndex = 3;
            labelDebtors_SAV.Text = "Должников: 0";
            // 
            // labelAvgArea_SAV
            // 
            labelAvgArea_SAV.AutoSize = true;
            labelAvgArea_SAV.Location = new Point(20, 108);
            labelAvgArea_SAV.Name = "labelAvgArea_SAV";
            labelAvgArea_SAV.Size = new Size(170, 20);
            labelAvgArea_SAV.TabIndex = 2;
            labelAvgArea_SAV.Text = "Средняя площадь: 0 м²";
            // 
            // labelTotalArea_SAV
            // 
            labelTotalArea_SAV.AutoSize = true;
            labelTotalArea_SAV.Location = new Point(20, 75);
            labelTotalArea_SAV.Name = "labelTotalArea_SAV";
            labelTotalArea_SAV.Size = new Size(159, 20);
            labelTotalArea_SAV.TabIndex = 1;
            labelTotalArea_SAV.Text = "Общая площадь: 0 м²";
            // 
            // labelTotalApartments_SAV
            // 
            labelTotalApartments_SAV.AutoSize = true;
            labelTotalApartments_SAV.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            labelTotalApartments_SAV.Location = new Point(20, 38);
            labelTotalApartments_SAV.Name = "labelTotalApartments_SAV";
            labelTotalApartments_SAV.Size = new Size(109, 20);
            labelTotalApartments_SAV.TabIndex = 0;
            labelTotalApartments_SAV.Text = "Квартир: 0";
            // 
            // FormMain_SAV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 875);
            Controls.Add(splitContainerMain_SAV);
            Controls.Add(statusStripMain_SAV);
            Controls.Add(toolStripMain_SAV);
            Controls.Add(menuStripMain_SAV);
            MainMenuStrip = menuStripMain_SAV;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1000, 738);
            Name = "FormMain_SAV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Система домоуправления | Шиганова А.В. | Вариант 7";
            Load += FormMain_SAV_Load;
            menuStripMain_SAV.ResumeLayout(false);
            menuStripMain_SAV.PerformLayout();
            toolStripMain_SAV.ResumeLayout(false);
            toolStripMain_SAV.PerformLayout();
            statusStripMain_SAV.ResumeLayout(false);
            statusStripMain_SAV.PerformLayout();
            splitContainerMain_SAV.Panel1.ResumeLayout(false);
            splitContainerMain_SAV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain_SAV).EndInit();
            splitContainerMain_SAV.ResumeLayout(false);
            panelLeft_SAV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewApartments_SAV).EndInit();
            groupBoxFilters_SAV.ResumeLayout(false);
            groupBoxFilters_SAV.PerformLayout();
            groupBoxSearch_SAV.ResumeLayout(false);
            groupBoxSearch_SAV.PerformLayout();
            panelRight_SAV.ResumeLayout(false);
            groupBoxChart_SAV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartStatistics_SAV).EndInit();
            groupBoxStatistics_SAV.ResumeLayout(false);
            groupBoxStatistics_SAV.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain_SAV;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen_SAV;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave_SAV;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit_SAV;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout_SAV;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp_SAV;
        private System.Windows.Forms.ToolStrip toolStripMain_SAV;
        private System.Windows.Forms.ToolStripButton buttonLoadFile_SAV;
        private System.Windows.Forms.ToolStripButton buttonSaveFile_SAV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonAddApartment_SAV;
        private System.Windows.Forms.ToolStripButton buttonEditApartment_SAV;
        private System.Windows.Forms.ToolStripButton buttonDeleteApartment_SAV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buttonExportStats_SAV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton buttonHelp_SAV;
        private System.Windows.Forms.ToolStripButton buttonAbout_SAV;
        private System.Windows.Forms.StatusStrip statusStripMain_SAV;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo_SAV;
        private System.Windows.Forms.SplitContainer splitContainerMain_SAV;
        private System.Windows.Forms.Panel panelLeft_SAV;
        private System.Windows.Forms.DataGridView dataGridViewApartments_SAV;
        private System.Windows.Forms.GroupBox groupBoxFilters_SAV;
        private System.Windows.Forms.Button buttonApplyFilters_SAV;
        private System.Windows.Forms.CheckBox checkBoxAscending_SAV;
        private System.Windows.Forms.ComboBox comboBoxSortBy_SAV;
        private System.Windows.Forms.Label labelSortBy_SAV;
        private System.Windows.Forms.ComboBox comboBoxFilterDebt_SAV;
        private System.Windows.Forms.Label labelFilterDebt_SAV;
        private System.Windows.Forms.ComboBox comboBoxFilterEntrance_SAV;
        private System.Windows.Forms.Label labelFilterEntrance_SAV;
        private System.Windows.Forms.GroupBox groupBoxSearch_SAV;
        private System.Windows.Forms.Button buttonSearch_SAV;
        private System.Windows.Forms.TextBox textBoxSearch_SAV;
        private System.Windows.Forms.Panel panelRight_SAV;
        private System.Windows.Forms.GroupBox groupBoxChart_SAV;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistics_SAV;
        private System.Windows.Forms.GroupBox groupBoxStatistics_SAV;
        private System.Windows.Forms.Label labelTotalRooms_SAV;
        private System.Windows.Forms.Label labelAvgFamily_SAV;
        private System.Windows.Forms.Label labelTotalChildren_SAV;
        private System.Windows.Forms.Label labelDebtors_SAV;
        private System.Windows.Forms.Label labelAvgArea_SAV;
        private System.Windows.Forms.Label labelTotalArea_SAV;
        private System.Windows.Forms.Label labelTotalApartments_SAV;

        private void FormMain_SAV_Load(object sender, EventArgs e)
        {

        }
    }
}