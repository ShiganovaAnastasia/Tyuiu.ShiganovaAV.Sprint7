namespace Tyuiu.ShiganovaAV.Sprint7.Project.V7
{
    partial class FormMain_SAV
    {
        private System.ComponentModel.IContainer components = null;

        // Меню
        private System.Windows.Forms.MenuStrip menuStripMain_SAV;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen_SAV;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave_SAV;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit_SAV;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout_SAV;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp_SAV;

        // Панель инструментов
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

        // Статус бар
        private System.Windows.Forms.StatusStrip statusStripMain_SAV;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo_SAV;

        // Основной контейнер
        private System.Windows.Forms.SplitContainer splitContainerMain_SAV;

        // Левая панель - данные и управление
        private System.Windows.Forms.Panel panelLeft_SAV;
        private System.Windows.Forms.GroupBox groupBoxSearch_SAV;
        private System.Windows.Forms.TextBox textBoxSearch_SAV;
        private System.Windows.Forms.Button buttonSearch_SAV;
        private System.Windows.Forms.GroupBox groupBoxFilters_SAV;
        private System.Windows.Forms.ComboBox comboBoxFilterEntrance_SAV;
        private System.Windows.Forms.Label labelFilterEntrance_SAV;
        private System.Windows.Forms.ComboBox comboBoxFilterDebt_SAV;
        private System.Windows.Forms.Label labelFilterDebt_SAV;
        private System.Windows.Forms.ComboBox comboBoxSortBy_SAV;
        private System.Windows.Forms.Label labelSortBy_SAV;
        private System.Windows.Forms.CheckBox checkBoxAscending_SAV;
        private System.Windows.Forms.Button buttonApplyFilters_SAV;
        private System.Windows.Forms.DataGridView dataGridViewApartments_SAV;

        // Правая панель - статистика и графики
        private System.Windows.Forms.Panel panelRight_SAV;
        private System.Windows.Forms.GroupBox groupBoxStatistics_SAV;
        private System.Windows.Forms.Label labelTotalApartments_SAV;
        private System.Windows.Forms.Label labelTotalArea_SAV;
        private System.Windows.Forms.Label labelAvgArea_SAV;
        private System.Windows.Forms.Label labelDebtors_SAV;
        private System.Windows.Forms.Label labelTotalChildren_SAV;
        private System.Windows.Forms.Label labelAvgFamily_SAV;
        private System.Windows.Forms.Label labelTotalRooms_SAV;
        private System.Windows.Forms.GroupBox groupBoxChart_SAV;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistics_SAV;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain_SAV));
            this.menuStripMain_SAV = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpen_SAV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSave_SAV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit_SAV = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout_SAV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp_SAV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain_SAV = new System.Windows.Forms.ToolStrip();
            this.buttonLoadFile_SAV = new System.Windows.Forms.ToolStripButton();
            this.buttonSaveFile_SAV = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonAddApartment_SAV = new System.Windows.Forms.ToolStripButton();
            this.buttonEditApartment_SAV = new System.Windows.Forms.ToolStripButton();
            this.buttonDeleteApartment_SAV = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonExportStats_SAV = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonHelp_SAV = new System.Windows.Forms.ToolStripButton();
            this.buttonAbout_SAV = new System.Windows.Forms.ToolStripButton();
            this.statusStripMain_SAV = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo_SAV = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainerMain_SAV = new System.Windows.Forms.SplitContainer();
            this.panelLeft_SAV = new System.Windows.Forms.Panel();
            this.dataGridViewApartments_SAV = new System.Windows.Forms.DataGridView();
            this.panelRight_SAV = new System.Windows.Forms.Panel();
            this.groupBoxChart_SAV = new System.Windows.Forms.GroupBox();
            this.chartStatistics_SAV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBoxStatistics_SAV = new System.Windows.Forms.GroupBox();
            this.labelTotalRooms_SAV = new System.Windows.Forms.Label();
            this.labelAvgFamily_SAV = new System.Windows.Forms.Label();
            this.labelTotalChildren_SAV = new System.Windows.Forms.Label();
            this.labelDebtors_SAV = new System.Windows.Forms.Label();
            this.labelAvgArea_SAV = new System.Windows.Forms.Label();
            this.labelTotalArea_SAV = new System.Windows.Forms.Label();
            this.labelTotalApartments_SAV = new System.Windows.Forms.Label();
            this.groupBoxFilters_SAV = new System.Windows.Forms.GroupBox();
            this.buttonApplyFilters_SAV = new System.Windows.Forms.Button();
            this.checkBoxAscending_SAV = new System.Windows.Forms.CheckBox();
            this.comboBoxSortBy_SAV = new System.Windows.Forms.ComboBox();
            this.labelSortBy_SAV = new System.Windows.Forms.Label();
            this.comboBoxFilterDebt_SAV = new System.Windows.Forms.ComboBox();
            this.labelFilterDebt_SAV = new System.Windows.Forms.Label();
            this.comboBoxFilterEntrance_SAV = new System.Windows.Forms.ComboBox();
            this.labelFilterEntrance_SAV = new System.Windows.Forms.Label();
            this.groupBoxSearch_SAV = new System.Windows.Forms.GroupBox();
            this.buttonSearch_SAV = new System.Windows.Forms.Button();
            this.textBoxSearch_SAV = new System.Windows.Forms.TextBox();
            this.menuStripMain_SAV.SuspendLayout();
            this.toolStripMain_SAV.SuspendLayout();
            this.statusStripMain_SAV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain_SAV)).BeginInit();
            this.splitContainerMain_SAV.Panel1.SuspendLayout();
            this.splitContainerMain_SAV.Panel2.SuspendLayout();
            this.splitContainerMain_SAV.SuspendLayout();
            this.panelLeft_SAV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApartments_SAV)).BeginInit();
            this.panelRight_SAV.SuspendLayout();
            this.groupBoxChart_SAV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistics_SAV)).BeginInit();
            this.groupBoxStatistics_SAV.SuspendLayout();
            this.groupBoxFilters_SAV.SuspendLayout();
            this.groupBoxSearch_SAV.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain_SAV
            // 
            this.menuStripMain_SAV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain_SAV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStripMain_SAV.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain_SAV.Name = "menuStripMain_SAV";
            this.menuStripMain_SAV.Size = new System.Drawing.Size(1200, 28);
            this.menuStripMain_SAV.TabIndex = 0;
            this.menuStripMain_SAV.Text = "menuStripMain_SAV";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpen_SAV,
            this.toolStripMenuItemSave_SAV,
            this.toolStripMenuItemExit_SAV});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // toolStripMenuItemOpen_SAV
            // 
            this.toolStripMenuItemOpen_SAV.Name = "toolStripMenuItemOpen_SAV";
            this.toolStripMenuItemOpen_SAV.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItemOpen_SAV.Size = new System.Drawing.Size(181, 26);
            this.toolStripMenuItemOpen_SAV.Text = "Открыть";
            this.toolStripMenuItemOpen_SAV.Click += new System.EventHandler(this.buttonLoadFile_SAV_Click);
            // 
            // toolStripMenuItemSave_SAV
            // 
            this.toolStripMenuItemSave_SAV.Name = "toolStripMenuItemSave_SAV";
            this.toolStripMenuItemSave_SAV.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSave_SAV.Size = new System.Drawing.Size(181, 26);
            this.toolStripMenuItemSave_SAV.Text = "Сохранить";
            this.toolStripMenuItemSave_SAV.Click += new System.EventHandler(this.buttonSaveFile_SAV_Click);
            // 
            // toolStripMenuItemExit_SAV
            // 
            this.toolStripMenuItemExit_SAV.Name = "toolStripMenuItemExit_SAV";
            this.toolStripMenuItemExit_SAV.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.toolStripMenuItemExit_SAV.Size = new System.Drawing.Size(181, 26);
            this.toolStripMenuItemExit_SAV.Text = "Выход";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout_SAV,
            this.toolStripMenuItemHelp_SAV});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // toolStripMenuItemAbout_SAV
            // 
            this.toolStripMenuItemAbout_SAV.Name = "toolStripMenuItemAbout_SAV";
            this.toolStripMenuItemAbout_SAV.Size = new System.Drawing.Size(181, 26);
            this.toolStripMenuItemAbout_SAV.Text = "О программе";
            this.toolStripMenuItemAbout_SAV.Click += new System.EventHandler(this.buttonAbout_SAV_Click);
            // 
            // toolStripMenuItemHelp_SAV
            // 
            this.toolStripMenuItemHelp_SAV.Name = "toolStripMenuItemHelp_SAV";
            this.toolStripMenuItemHelp_SAV.Size = new System.Drawing.Size(181, 26);
            this.toolStripMenuItemHelp_SAV.Text = "Помощь";
            this.toolStripMenuItemHelp_SAV.Click += new System.EventHandler(this.buttonHelp_SAV_Click);
            // 
            // toolStripMain_SAV
            // 
            this.toolStripMain_SAV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain_SAV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonLoadFile_SAV,
            this.buttonSaveFile_SAV,
            this.toolStripSeparator1,
            this.buttonAddApartment_SAV,
            this.buttonEditApartment_SAV,
            this.buttonDeleteApartment_SAV,
            this.toolStripSeparator2,
            this.buttonExportStats_SAV,
            this.toolStripSeparator3,
            this.buttonHelp_SAV,
            this.buttonAbout_SAV});
            this.toolStripMain_SAV.Location = new System.Drawing.Point(0, 28);
            this.toolStripMain_SAV.Name = "toolStripMain_SAV";
            this.toolStripMain_SAV.Size = new System.Drawing.Size(1200, 27);
            this.toolStripMain_SAV.TabIndex = 1;
            this.toolStripMain_SAV.Text = "toolStripMain_SAV";
            // 
            // buttonLoadFile_SAV
            // 
            this.buttonLoadFile_SAV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonLoadFile_SAV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLoadFile_SAV.Name = "buttonLoadFile_SAV";
            this.buttonLoadFile_SAV.Size = new System.Drawing.Size(84, 24);
            this.buttonLoadFile_SAV.Text = "Загрузить";
            this.buttonLoadFile_SAV.Click += new System.EventHandler(this.buttonLoadFile_SAV_Click);
            // 
            // buttonSaveFile_SAV
            // 
            this.buttonSaveFile_SAV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonSaveFile_SAV.Enabled = false;
            this.buttonSaveFile_SAV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSaveFile_SAV.Name = "buttonSaveFile_SAV";
            this.buttonSaveFile_SAV.Size = new System.Drawing.Size(83, 24);
            this.buttonSaveFile_SAV.Text = "Сохранить";
            this.buttonSaveFile_SAV.Click += new System.EventHandler(this.buttonSaveFile_SAV_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // buttonAddApartment_SAV
            // 
            this.buttonAddApartment_SAV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonAddApartment_SAV.Enabled = false;
            this.buttonAddApartment_SAV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddApartment_SAV.Name = "buttonAddApartment_SAV";
            this.buttonAddApartment_SAV.Size = new System.Drawing.Size(81, 24);
            this.buttonAddApartment_SAV.Text = "Добавить";
            this.buttonAddApartment_SAV.Click += new System.EventHandler(this.buttonAddApartment_SAV_Click);
            // 
            // buttonEditApartment_SAV
            // 
            this.buttonEditApartment_SAV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonEditApartment_SAV.Enabled = false;
            this.buttonEditApartment_SAV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEditApartment_SAV.Name = "buttonEditApartment_SAV";
            this.buttonEditApartment_SAV.Size = new System.Drawing.Size(97, 24);
            this.buttonEditApartment_SAV.Text = "Изменить";
            this.buttonEditApartment_SAV.Click += new System.EventHandler(this.buttonEditApartment_SAV_Click);
            // 
            // buttonDeleteApartment_SAV
            // 
            this.buttonDeleteApartment_SAV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonDeleteApartment_SAV.Enabled = false;
            this.buttonDeleteApartment_SAV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDeleteApartment_SAV.Name = "buttonDeleteApartment_SAV";
            this.buttonDeleteApartment_SAV.Size = new System.Drawing.Size(65, 24);
            this.buttonDeleteApartment_SAV.Text = "Удалить";
            this.buttonDeleteApartment_SAV.Click += new System.EventHandler(this.buttonDeleteApartment_SAV_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // buttonExportStats_SAV
            // 
            this.buttonExportStats_SAV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonExportStats_SAV.Enabled = false;
            this.buttonExportStats_SAV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExportStats_SAV.Name = "buttonExportStats_SAV";
            this.buttonExportStats_SAV.Size = new System.Drawing.Size(124, 24);
            this.buttonExportStats_SAV.Text = "Экспорт статистики";
            this.buttonExportStats_SAV.Click += new System.EventHandler(this.buttonExportStats_SAV_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // buttonHelp_SAV
            // 
            this.buttonHelp_SAV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonHelp_SAV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonHelp_SAV.Name = "buttonHelp_SAV";
            this.buttonHelp_SAV.Size = new System.Drawing.Size(66, 24);
            this.buttonHelp_SAV.Text = "Справка";
            this.buttonHelp_SAV.Click += new System.EventHandler(this.buttonHelp_SAV_Click);
            // 
            // buttonAbout_SAV
            // 
            this.buttonAbout_SAV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonAbout_SAV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAbout_SAV.Name = "buttonAbout_SAV";
            this.buttonAbout_SAV.Size = new System.Drawing.Size(94, 24);
            this.buttonAbout_SAV.Text = "О программе";
            this.buttonAbout_SAV.Click += new System.EventHandler(this.buttonAbout_SAV_Click);
            // 
            // statusStripMain_SAV
            // 
            this.statusStripMain_SAV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain_SAV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo_SAV});
            this.statusStripMain_SAV.Location = new System.Drawing.Point(0, 673);
            this.statusStripMain_SAV.Name = "statusStripMain_SAV";
            this.statusStripMain_SAV.Size = new System.Drawing.Size(1200, 27);
            this.statusStripMain_SAV.TabIndex = 2;
            this.statusStripMain_SAV.Text = "statusStripMain_SAV";
            // 
            // toolStripStatusLabelInfo_SAV
            // 
            this.toolStripStatusLabelInfo_SAV.Name = "toolStripStatusLabelInfo_SAV";
            this.toolStripStatusLabelInfo_SAV.Size = new System.Drawing.Size(1185, 20);
            this.toolStripStatusLabelInfo_SAV.Spring = true;
            this.toolStripStatusLabelInfo_SAV.Text = "Готов к работе";
            this.toolStripStatusLabelInfo_SAV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainerMain_SAV
            // 
            this.splitContainerMain_SAV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain_SAV.Location = new System.Drawing.Point(0, 55);
            this.splitContainerMain_SAV.Name = "splitContainerMain_SAV";
            // 
            // splitContainerMain_SAV.Panel1
            // 
            this.splitContainerMain_SAV.Panel1.Controls.Add(this.panelLeft_SAV);
            // 
            // splitContainerMain_SAV.Panel2
            // 
            this.splitContainerMain_SAV.Panel2.Controls.Add(this.panelRight_SAV);
            this.splitContainerMain_SAV.Size = new System.Drawing.Size(1200, 618);
            this.splitContainerMain_SAV.SplitterDistance = 800;
            this.splitContainerMain_SAV.TabIndex = 3;
            // 
            // panelLeft_SAV
            // 
            this.panelLeft_SAV.Controls.Add(this.dataGridViewApartments_SAV);
            this.panelLeft_SAV.Controls.Add(this.groupBoxFilters_SAV);
            this.panelLeft_SAV.Controls.Add(this.groupBoxSearch_SAV);
            this.panelLeft_SAV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft_SAV.Location = new System.Drawing.Point(0, 0);
            this.panelLeft_SAV.Name = "panelLeft_SAV";
            this.panelLeft_SAV.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeft_SAV.Size = new System.Drawing.Size(800, 618);
            this.panelLeft_SAV.TabIndex = 0;
            // 
            // dataGridViewApartments_SAV
            // 
            this.dataGridViewApartments_SAV.AllowUserToAddRows = false;
            this.dataGridViewApartments_SAV.AllowUserToDeleteRows = false;
            this.dataGridViewApartments_SAV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewApartments_SAV.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewApartments_SAV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewApartments_SAV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewApartments_SAV.Location = new System.Drawing.Point(10, 178);
            this.dataGridViewApartments_SAV.MultiSelect = false;
            this.dataGridViewApartments_SAV.Name = "dataGridViewApartments_SAV";
            this.dataGridViewApartments_SAV.ReadOnly = true;
            this.dataGridViewApartments_SAV.RowHeadersWidth = 51;
            this.dataGridViewApartments_SAV.RowTemplate.Height = 24;
            this.dataGridViewApartments_SAV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewApartments_SAV.Size = new System.Drawing.Size(780, 430);
            this.dataGridViewApartments_SAV.TabIndex = 2;
            this.dataGridViewApartments_SAV.SelectionChanged += new System.EventHandler(this.dataGridViewApartments_SAV_SelectionChanged);
            // 
            // panelRight_SAV
            // 
            this.panelRight_SAV.Controls.Add(this.groupBoxChart_SAV);
            this.panelRight_SAV.Controls.Add(this.groupBoxStatistics_SAV);
            this.panelRight_SAV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight_SAV.Location = new System.Drawing.Point(0, 0);
            this.panelRight_SAV.Name = "panelRight_SAV";
            this.panelRight_SAV.Padding = new System.Windows.Forms.Padding(10);
            this.panelRight_SAV.Size = new System.Drawing.Size(396, 618);
            this.panelRight_SAV.TabIndex = 0;
            // 
            // groupBoxChart_SAV
            // 
            this.groupBoxChart_SAV.Controls.Add(this.chartStatistics_SAV);
            this.groupBoxChart_SAV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxChart_SAV.Location = new System.Drawing.Point(10, 232);
            this.groupBoxChart_SAV.Name = "groupBoxChart_SAV";
            this.groupBoxChart_SAV.Size = new System.Drawing.Size(376, 376);
            this.groupBoxChart_SAV.TabIndex = 1;
            this.groupBoxChart_SAV.TabStop = false;
            this.groupBoxChart_SAV.Text = "График распределения";
            // 
            // chartStatistics_SAV
            // 
            chartArea1.Name = "ChartArea1";
            this.chartStatistics_SAV.ChartAreas.Add(chartArea1);
            this.chartStatistics_SAV.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartStatistics_SAV.Legends.Add(legend1);
            this.chartStatistics_SAV.Location = new System.Drawing.Point(3, 18);
            this.chartStatistics_SAV.Name = "chartStatistics_SAV";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartStatistics_SAV.Series.Add(series1);
            this.chartStatistics_SAV.Size = new System.Drawing.Size(370, 355);
            this.chartStatistics_SAV.TabIndex = 0;
            this.chartStatistics_SAV.Text = "chartStatistics_SAV";
            // 
            // groupBoxStatistics_SAV
            // 
            this.groupBoxStatistics_SAV.Controls.Add(this.labelTotalRooms_SAV);
            this.groupBoxStatistics_SAV.Controls.Add(this.labelAvgFamily_SAV);
            this.groupBoxStatistics_SAV.Controls.Add(this.labelTotalChildren_SAV);
            this.groupBoxStatistics_SAV.Controls.Add(this.labelDebtors_SAV);
            this.groupBoxStatistics_SAV.Controls.Add(this.labelAvgArea_SAV);
            this.groupBoxStatistics_SAV.Controls.Add(this.labelTotalArea_SAV);
            this.groupBoxStatistics_SAV.Controls.Add(this.labelTotalApartments_SAV);
            this.groupBoxStatistics_SAV.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxStatistics_SAV.Location = new System.Drawing.Point(10, 10);
            this.groupBoxStatistics_SAV.Name = "groupBoxStatistics_SAV";
            this.groupBoxStatistics_SAV.Size = new System.Drawing.Size(376, 222);
            this.groupBoxStatistics_SAV.TabIndex = 0;
            this.groupBoxStatistics_SAV.TabStop = false;
            this.groupBoxStatistics_SAV.Text = "Статистика";
            // 
            // labelTotalApartments_SAV
            // 
            this.labelTotalApartments_SAV.AutoSize = true;
            this.labelTotalApartments_SAV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotalApartments_SAV.Location = new System.Drawing.Point(20, 30);
            this.labelTotalApartments_SAV.Name = "labelTotalApartments_SAV";
            this.labelTotalApartments_SAV.Size = new System.Drawing.Size(104, 20);
            this.labelTotalApartments_SAV.TabIndex = 0;
            this.labelTotalApartments_SAV.Text = "Квартир: 0";
            // 
            // labelTotalArea_SAV
            // 
            this.labelTotalArea_SAV.AutoSize = true;
            this.labelTotalArea_SAV.Location = new System.Drawing.Point(20, 60);
            this.labelTotalArea_SAV.Name = "labelTotalArea_SAV";
            this.labelTotalArea_SAV.Size = new System.Drawing.Size(154, 16);
            this.labelTotalArea_SAV.TabIndex = 1;
            this.labelTotalArea_SAV.Text = "Общая площадь: 0 м²";
            // 
            // labelAvgArea_SAV
            // 
            this.labelAvgArea_SAV.AutoSize = true;
            this.labelAvgArea_SAV.Location = new System.Drawing.Point(20, 86);
            this.labelAvgArea_SAV.Name = "labelAvgArea_SAV";
            this.labelAvgArea_SAV.Size = new System.Drawing.Size(152, 16);
            this.labelAvgArea_SAV.TabIndex = 2;
            this.labelAvgArea_SAV.Text = "Средняя площадь: 0 м²";
            // 
            // labelDebtors_SAV
            // 
            this.labelDebtors_SAV.AutoSize = true;
            this.labelDebtors_SAV.Location = new System.Drawing.Point(20, 112);
            this.labelDebtors_SAV.Name = "labelDebtors_SAV";
            this.labelDebtors_SAV.Size = new System.Drawing.Size(96, 16);
            this.labelDebtors_SAV.TabIndex = 3;
            this.labelDebtors_SAV.Text = "Должников: 0";
            // 
            // labelTotalChildren_SAV
            // 
            this.labelTotalChildren_SAV.AutoSize = true;
            this.labelTotalChildren_SAV.Location = new System.Drawing.Point(20, 138);
            this.labelTotalChildren_SAV.Name = "labelTotalChildren_SAV";
            this.labelTotalChildren_SAV.Size = new System.Drawing.Size(94, 16);
            this.labelTotalChildren_SAV.TabIndex = 4;
            this.labelTotalChildren_SAV.Text = "Всего детей: 0";
            // 
            // labelAvgFamily_SAV
            // 
            this.labelAvgFamily_SAV.AutoSize = true;
            this.labelAvgFamily_SAV.Location = new System.Drawing.Point(20, 164);
            this.labelAvgFamily_SAV.Name = "labelAvgFamily_SAV";
            this.labelAvgFamily_SAV.Size = new System.Drawing.Size(140, 16);
            this.labelAvgFamily_SAV.TabIndex = 5;
            this.labelAvgFamily_SAV.Text = "Ср. размер семьи: 0";
            // 
            // labelTotalRooms_SAV
            // 
            this.labelTotalRooms_SAV.AutoSize = true;
            this.labelTotalRooms_SAV.Location = new System.Drawing.Point(20, 190);
            this.labelTotalRooms_SAV.Name = "labelTotalRooms_SAV";
            this.labelTotalRooms_SAV.Size = new System.Drawing.Size(109, 16);
            this.labelTotalRooms_SAV.TabIndex = 6;
            this.labelTotalRooms_SAV.Text = "Всего комнат: 0";
            // 
            // groupBoxFilters_SAV
            // 
            this.groupBoxFilters_SAV.Controls.Add(this.buttonApplyFilters_SAV);
            this.groupBoxFilters_SAV.Controls.Add(this.checkBoxAscending_SAV);
            this.groupBoxFilters_SAV.Controls.Add(this.comboBoxSortBy_SAV);
            this.groupBoxFilters_SAV.Controls.Add(this.labelSortBy_SAV);
            this.groupBoxFilters_SAV.Controls.Add(this.comboBoxFilterDebt_SAV);
            this.groupBoxFilters_SAV.Controls.Add(this.labelFilterDebt_SAV);
            this.groupBoxFilters_SAV.Controls.Add(this.comboBoxFilterEntrance_SAV);
            this.labelFilterEntrance_SAV = new System.Windows.Forms.Label();
            this.groupBoxFilters_SAV.Controls.Add(this.labelFilterEntrance_SAV);
            this.groupBoxFilters_SAV.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFilters_SAV.Location = new System.Drawing.Point(10, 68);
            this.groupBoxFilters_SAV.Name = "groupBoxFilters_SAV";
            this.groupBoxFilters_SAV.Size = new System.Drawing.Size(780, 110);
            this.groupBoxFilters_SAV.TabIndex = 1;
            this.groupBoxFilters_SAV.TabStop = false;
            this.groupBoxFilters_SAV.Text = "Фильтры и сортировка";
            // 
            // buttonApplyFilters_SAV
            // 
            this.buttonApplyFilters_SAV.Enabled = false;
            this.buttonApplyFilters_SAV.Location = new System.Drawing.Point(650, 70);
            this.buttonApplyFilters_SAV.Name = "buttonApplyFilters_SAV";
            this.buttonApplyFilters_SAV.Size = new System.Drawing.Size(120, 30);
            this.buttonApplyFilters_SAV.TabIndex = 7;
            this.buttonApplyFilters_SAV.Text = "Применить";
            this.buttonApplyFilters_SAV.UseVisualStyleBackColor = true;
            this.buttonApplyFilters_SAV.Click += new System.EventHandler(this.buttonApplyFilters_SAV_Click);
            // 
            // checkBoxAscending_SAV
            // 
            this.checkBoxAscending_SAV.AutoSize = true;
            this.checkBoxAscending_SAV.Checked = true;
            this.checkBoxAscending_SAV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAscending_SAV.Location = new System.Drawing.Point(550, 75);
            this.checkBoxAscending_SAV.Name = "checkBoxAscending_SAV";
            this.checkBoxAscending_SAV.Size = new System.Drawing.Size(94, 20);
            this.checkBoxAscending_SAV.TabIndex = 6;
            this.checkBoxAscending_SAV.Text = "По возр.";
            this.checkBoxAscending_SAV.UseVisualStyleBackColor = true;
            // 
            // comboBoxSortBy_SAV
            // 
            this.comboBoxSortBy_SAV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSortBy_SAV.FormattingEnabled = true;
            this.comboBoxSortBy_SAV.Location = new System.Drawing.Point(400, 72);
            this.comboBoxSortBy_SAV.Name = "comboBoxSortBy_SAV";
            this.comboBoxSortBy_SAV.Size = new System.Drawing.Size(140, 24);
            this.comboBoxSortBy_SAV.TabIndex = 5;
            // 
            // labelSortBy_SAV
            // 
            this.labelSortBy_SAV.AutoSize = true;
            this.labelSortBy_SAV.Location = new System.Drawing.Point(397, 50);
            this.labelSortBy_SAV.Name = "labelSortBy_SAV";
            this.labelSortBy_SAV.Size = new System.Drawing.Size(81, 16);
            this.labelSortBy_SAV.TabIndex = 4;
            this.labelSortBy_SAV.Text = "Сортировка:";
            // 
            // comboBoxFilterDebt_SAV
            // 
            this.comboBoxFilterDebt_SAV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterDebt_SAV.FormattingEnabled = true;
            this.comboBoxFilterDebt_SAV.Location = new System.Drawing.Point(200, 72);
            this.comboBoxFilterDebt_SAV.Name = "comboBoxFilterDebt_SAV";
            this.comboBoxFilterDebt_SAV.Size = new System.Drawing.Size(140, 24);
            this.comboBoxFilterDebt_SAV.TabIndex = 3;
            // 
            // labelFilterDebt_SAV
            // 
            this.labelFilterDebt_SAV.AutoSize = true;
            this.labelFilterDebt_SAV.Location = new System.Drawing.Point(197, 50);
            this.labelFilterDebt_SAV.Name = "labelFilterDebt_SAV";
            this.labelFilterDebt_SAV.Size = new System.Drawing.Size(55, 16);
            this.labelFilterDebt_SAV.TabIndex = 2;
            this.labelFilterDebt_SAV.Text = "Долги:";
            // 
            // comboBoxFilterEntrance_SAV
            // 
            this.comboBoxFilterEntrance_SAV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterEntrance_SAV.FormattingEnabled = true;
            this.comboBoxFilterEntrance_SAV.Location = new System.Drawing.Point(20, 72);
            this.comboBoxFilterEntrance_SAV.Name = "comboBoxFilterEntrance_SAV";
            this.comboBoxFilterEntrance_SAV.Size = new System.Drawing.Size(140, 24);
            this.comboBoxFilterEntrance_SAV.TabIndex = 1;
            // 
            // labelFilterEntrance_SAV
            // 
            this.labelFilterEntrance_SAV.AutoSize = true;
            this.labelFilterEntrance_SAV.Location = new System.Drawing.Point(17, 50);
            this.labelFilterEntrance_SAV.Name = "labelFilterEntrance_SAV";
            this.labelFilterEntrance_SAV.Size = new System.Drawing.Size(73, 16);
            this.labelFilterEntrance_SAV.TabIndex = 0;
            this.labelFilterEntrance_SAV.Text = "Подъезд:";
            // 
            // groupBoxSearch_SAV
            // 
            this.groupBoxSearch_SAV.Controls.Add(this.buttonSearch_SAV);
            this.groupBoxSearch_SAV.Controls.Add(this.textBoxSearch_SAV);
            this.groupBoxSearch_SAV.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSearch_SAV.Location = new System.Drawing.Point(10, 10);
            this.groupBoxSearch_SAV.Name = "groupBoxSearch_SAV";
            this.groupBoxSearch_SAV.Size = new System.Drawing.Size(780, 58);
            this.groupBoxSearch_SAV.TabIndex = 0;
            this.groupBoxSearch_SAV.TabStop = false;
            this.groupBoxSearch_SAV.Text = "Поиск по фамилии";
            // 
            // buttonSearch_SAV
            // 
            this.buttonSearch_SAV.Enabled = false;
            this.buttonSearch_SAV.Location = new System.Drawing.Point(650, 20);
            this.buttonSearch_SAV.Name = "buttonSearch_SAV";
            this.buttonSearch_SAV.Size = new System.Drawing.Size(120, 30);
            this.buttonSearch_SAV.TabIndex = 1;
            this.buttonSearch_SAV.Text = "Найти";
            this.buttonSearch_SAV.UseVisualStyleBackColor = true;
            this.buttonSearch_SAV.Click += new System.EventHandler(this.buttonSearch_SAV_Click);
            // 
            // textBoxSearch_SAV
            // 
            this.textBoxSearch_SAV.Enabled = false;
            this.textBoxSearch_SAV.Location = new System.Drawing.Point(20, 25);
            this.textBoxSearch_SAV.Name = "textBoxSearch_SAV";
            this.textBoxSearch_SAV.Size = new System.Drawing.Size(620, 22);
            this.textBoxSearch_SAV.TabIndex = 0;
            this.textBoxSearch_SAV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_SAV_KeyPress);
            // 
            // FormMain_SAV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.splitContainerMain_SAV);
            this.Controls.Add(this.statusStripMain_SAV);
            this.Controls.Add(this.toolStripMain_SAV);
            this.Controls.Add(this.menuStripMain_SAV);
            this.MainMenuStrip = this.menuStripMain_SAV;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FormMain_SAV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система домоуправления | Шиганова А.В. | Вариант 7";
            this.menuStripMain_SAV.ResumeLayout(false);
            this.menuStripMain_SAV.PerformLayout();
            this.toolStripMain_SAV.ResumeLayout(false);
            this.toolStripMain_SAV.PerformLayout();
            this.statusStripMain_SAV.ResumeLayout(false);
            this.statusStripMain_SAV.PerformLayout();
            this.splitContainerMain_SAV.Panel1.ResumeLayout(false);
            this.splitContainerMain_SAV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain_SAV)).EndInit();
            this.splitContainerMain_SAV.ResumeLayout(false);
            this.panelLeft_SAV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewApartments_SAV)).EndInit();
            this.panelRight_SAV.ResumeLayout(false);
            this.groupBoxChart_SAV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistics_SAV)).EndInit();
            this.groupBoxStatistics_SAV.ResumeLayout(false);
            this.groupBoxStatistics_SAV.PerformLayout();
            this.groupBoxFilters_SAV.ResumeLayout(false);
            this.groupBoxFilters_SAV.PerformLayout();
            this.groupBoxSearch_SAV.ResumeLayout(false);
            this.groupBoxSearch_SAV.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}