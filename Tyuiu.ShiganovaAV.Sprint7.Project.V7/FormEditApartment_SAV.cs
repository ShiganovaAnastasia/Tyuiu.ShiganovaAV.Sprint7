namespace Tyuiu.ShiganovaAV.Sprint7.Project.V7
{
    partial class FormEditApartment_SAV
    {
        private System.ComponentModel.IContainer components = null;

        // Основные элементы
        private System.Windows.Forms.Label labelTitle_SAV;
        private System.Windows.Forms.GroupBox groupBoxMain_SAV;
        private System.Windows.Forms.Panel panelButtons_SAV;
        private System.Windows.Forms.Button buttonSave_SAV;
        private System.Windows.Forms.Button buttonCancel_SAV;
        private System.Windows.Forms.Button buttonClear_SAV;
        private System.Windows.Forms.ToolTip toolTip_SAV;

        // Поля ввода
        private System.Windows.Forms.Label labelEntrance_SAV;
        private System.Windows.Forms.Label labelApartment_SAV;
        private System.Windows.Forms.Label labelTotalArea_SAV;
        private System.Windows.Forms.Label labelLivingArea_SAV;
        private System.Windows.Forms.Label labelRooms_SAV;
        private System.Windows.Forms.Label labelSurname_SAV;
        private System.Windows.Forms.Label labelRegistrationDate_SAV;
        private System.Windows.Forms.Label labelFamily_SAV;
        private System.Windows.Forms.Label labelChildren_SAV;
        private System.Windows.Forms.Label labelDebt_SAV;
        private System.Windows.Forms.Label labelNotes_SAV;

        private System.Windows.Forms.NumericUpDown numericUpDownEntrance_SAV;
        private System.Windows.Forms.NumericUpDown numericUpDownApartment_SAV;
        private System.Windows.Forms.NumericUpDown numericUpDownTotalArea_SAV;
        private System.Windows.Forms.NumericUpDown numericUpDownLivingArea_SAV;
        private System.Windows.Forms.NumericUpDown numericUpDownRooms_SAV;
        private System.Windows.Forms.TextBox textBoxSurname_SAV;
        private System.Windows.Forms.DateTimePicker dateTimePickerRegistration_SAV;
        private System.Windows.Forms.NumericUpDown numericUpDownFamily_SAV;
        private System.Windows.Forms.NumericUpDown numericUpDownChildren_SAV;
        private System.Windows.Forms.CheckBox checkBoxDebt_SAV;
        private System.Windows.Forms.TextBox textBoxNotes_SAV;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditApartment_SAV));
            this.labelTitle_SAV = new System.Windows.Forms.Label();
            this.groupBoxMain_SAV = new System.Windows.Forms.GroupBox();
            this.textBoxNotes_SAV = new System.Windows.Forms.TextBox();
            this.labelNotes_SAV = new System.Windows.Forms.Label();
            this.checkBoxDebt_SAV = new System.Windows.Forms.CheckBox();
            this.labelDebt_SAV = new System.Windows.Forms.Label();
            this.numericUpDownChildren_SAV = new System.Windows.Forms.NumericUpDown();
            this.labelChildren_SAV = new System.Windows.Forms.Label();
            this.numericUpDownFamily_SAV = new System.Windows.Forms.NumericUpDown();
            this.labelFamily_SAV = new System.Windows.Forms.Label();
            this.dateTimePickerRegistration_SAV = new System.Windows.Forms.DateTimePicker();
            this.labelRegistrationDate_SAV = new System.Windows.Forms.Label();
            this.textBoxSurname_SAV = new System.Windows.Forms.TextBox();
            this.labelSurname_SAV = new System.Windows.Forms.Label();
            this.numericUpDownRooms_SAV = new System.Windows.Forms.NumericUpDown();
            this.labelRooms_SAV = new System.Windows.Forms.Label();
            this.numericUpDownLivingArea_SAV = new System.Windows.Forms.NumericUpDown();
            this.labelLivingArea_SAV = new System.Windows.Forms.Label();
            this.numericUpDownTotalArea_SAV = new System.Windows.Forms.NumericUpDown();
            this.labelTotalArea_SAV = new System.Windows.Forms.Label();
            this.numericUpDownApartment_SAV = new System.Windows.Forms.NumericUpDown();
            this.labelApartment_SAV = new System.Windows.Forms.Label();
            this.numericUpDownEntrance_SAV = new System.Windows.Forms.NumericUpDown();
            this.labelEntrance_SAV = new System.Windows.Forms.Label();
            this.panelButtons_SAV = new System.Windows.Forms.Panel();
            this.buttonClear_SAV = new System.Windows.Forms.Button();
            this.buttonCancel_SAV = new System.Windows.Forms.Button();
            this.buttonSave_SAV = new System.Windows.Forms.Button();
            this.toolTip_SAV = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxMain_SAV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChildren_SAV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFamily_SAV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRooms_SAV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLivingArea_SAV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalArea_SAV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownApartment_SAV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEntrance_SAV)).BeginInit();
            this.panelButtons_SAV.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle_SAV
            // 
            this.labelTitle_SAV.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle_SAV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle_SAV.Location = new System.Drawing.Point(0, 0);
            this.labelTitle_SAV.Name = "labelTitle_SAV";
            this.labelTitle_SAV.Size = new System.Drawing.Size(550, 40);
            this.labelTitle_SAV.TabIndex = 0;
            this.labelTitle_SAV.Text = "Добавление новой квартиры";
            this.labelTitle_SAV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxMain_SAV
            // 
            this.groupBoxMain_SAV.Controls.Add(this.textBoxNotes_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.labelNotes_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.checkBoxDebt_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.labelDebt_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.numericUpDownChildren_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.labelChildren_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.numericUpDownFamily_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.labelFamily_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.dateTimePickerRegistration_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.labelRegistrationDate_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.textBoxSurname_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.labelSurname_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.numericUpDownRooms_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.labelRooms_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.numericUpDownLivingArea_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.labelLivingArea_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.numericUpDownTotalArea_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.labelTotalArea_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.numericUpDownApartment_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.labelApartment_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.numericUpDownEntrance_SAV);
            this.groupBoxMain_SAV.Controls.Add(this.labelEntrance_SAV);
            this.groupBoxMain_SAV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMain_SAV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxMain_SAV.Location = new System.Drawing.Point(0, 40);
            this.groupBoxMain_SAV.Name = "groupBoxMain_SAV";
            this.groupBoxMain_SAV.Size = new System.Drawing.Size(550, 360);
            this.groupBoxMain_SAV.TabIndex = 1;
            this.groupBoxMain_SAV.TabStop = false;
            this.groupBoxMain_SAV.Text = "Данные квартиры";
            // 
            // textBoxNotes_SAV
            // 
            this.textBoxNotes_SAV.Location = new System.Drawing.Point(20, 290);
            this.textBoxNotes_SAV.Multiline = true;
            this.textBoxNotes_SAV.Name = "textBoxNotes_SAV";
            this.textBoxNotes_SAV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNotes_SAV.Size = new System.Drawing.Size(510, 60);
            this.textBoxNotes_SAV.TabIndex = 10;
            // 
            // labelNotes_SAV
            // 
            this.labelNotes_SAV.AutoSize = true;
            this.labelNotes_SAV.Location = new System.Drawing.Point(17, 270);
            this.labelNotes_SAV.Name = "labelNotes_SAV";
            this.labelNotes_SAV.Size = new System.Drawing.Size(80, 18);
            this.labelNotes_SAV.TabIndex = 19;
            this.labelNotes_SAV.Text = "Примечание:";
            // 
            // checkBoxDebt_SAV
            // 
            this.checkBoxDebt_SAV.AutoSize = true;
            this.checkBoxDebt_SAV.Location = new System.Drawing.Point(450, 220);
            this.checkBoxDebt_SAV.Name = "checkBoxDebt_SAV";
            this.checkBoxDebt_SAV.Size = new System.Drawing.Size(18, 17);
            this.checkBoxDebt_SAV.TabIndex = 9;
            this.checkBoxDebt_SAV.UseVisualStyleBackColor = true;
            // 
            // labelDebt_SAV
            // 
            this.labelDebt_SAV.AutoSize = true;
            this.labelDebt_SAV.Location = new System.Drawing.Point(447, 200);
            this.labelDebt_SAV.Name = "labelDebt_SAV";
            this.labelDebt_SAV.Size = new System.Drawing.Size(80, 18);
            this.labelDebt_SAV.TabIndex = 17;
            this.labelDebt_SAV.Text = "Задолженность:";
            // 
            // numericUpDownChildren_SAV
            // 
            this.numericUpDownChildren_SAV.Location = new System.Drawing.Point(300, 220);
            this.numericUpDownChildren_SAV.Name = "numericUpDownChildren_SAV";
            this.numericUpDownChildren_SAV.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownChildren_SAV.TabIndex = 8;
            // 
            // labelChildren_SAV
            // 
            this.labelChildren_SAV.AutoSize = true;
            this.labelChildren_SAV.Location = new System.Drawing.Point(297, 200);
            this.labelChildren_SAV.Name = "labelChildren_SAV";
            this.labelChildren_SAV.Size = new System.Drawing.Size(56, 18);
            this.labelChildren_SAV.TabIndex = 15;
            this.labelChildren_SAV.Text = "Детей:";
            // 
            // numericUpDownFamily_SAV
            // 
            this.numericUpDownFamily_SAV.Location = new System.Drawing.Point(150, 220);
            this.numericUpDownFamily_SAV.Name = "numericUpDownFamily_SAV";
            this.numericUpDownFamily_SAV.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownFamily_SAV.TabIndex = 7;
            this.numericUpDownFamily_SAV.ValueChanged += new System.EventHandler(this.numericUpDownFamily_SAV_ValueChanged);
            // 
            // labelFamily_SAV
            // 
            this.labelFamily_SAV.AutoSize = true;
            this.labelFamily_SAV.Location = new System.Drawing.Point(147, 200);
            this.labelFamily_SAV.Name = "labelFamily_SAV";
            this.labelFamily_SAV.Size = new System.Drawing.Size(113, 18);
            this.labelFamily_SAV.TabIndex = 13;
            this.labelFamily_SAV.Text = "Членов семьи:";
            // 
            // dateTimePickerRegistration_SAV
            // 
            this.dateTimePickerRegistration_SAV.Location = new System.Drawing.Point(300, 160);
            this.dateTimePickerRegistration_SAV.Name = "dateTimePickerRegistration_SAV";
            this.dateTimePickerRegistration_SAV.Size = new System.Drawing.Size(230, 24);
            this.dateTimePickerRegistration_SAV.TabIndex = 6;
            // 
            // labelRegistrationDate_SAV
            // 
            this.labelRegistrationDate_SAV.AutoSize = true;
            this.labelRegistrationDate_SAV.Location = new System.Drawing.Point(297, 140);
            this.labelRegistrationDate_SAV.Name = "labelRegistrationDate_SAV";
            this.labelRegistrationDate_SAV.Size = new System.Drawing.Size(110, 18);
            this.labelRegistrationDate_SAV.TabIndex = 11;
            this.labelRegistrationDate_SAV.Text = "Дата прописки:";
            // 
            // textBoxSurname_SAV
            // 
            this.textBoxSurname_SAV.Location = new System.Drawing.Point(20, 160);
            this.textBoxSurname_SAV.Name = "textBoxSurname_SAV";
            this.textBoxSurname_SAV.Size = new System.Drawing.Size(250, 24);
            this.textBoxSurname_SAV.TabIndex = 5;
            this.textBoxSurname_SAV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSurname_SAV_KeyPress);
            // 
            // labelSurname_SAV
            // 
            this.labelSurname_SAV.AutoSize = true;
            this.labelSurname_SAV.Location = new System.Drawing.Point(17, 140);
            this.labelSurname_SAV.Name = "labelSurname_SAV";
            this.labelSurname_SAV.Size = new System.Drawing.Size(78, 18);
            this.labelSurname_SAV.TabIndex = 9;
            this.labelSurname_SAV.Text = "Фамилия:";
            // 
            // numericUpDownRooms_SAV
            // 
            this.numericUpDownRooms_SAV.Location = new System.Drawing.Point(450, 100);
            this.numericUpDownRooms_SAV.Name = "numericUpDownRooms_SAV";
            this.numericUpDownRooms_SAV.Size = new System.Drawing.Size(80, 24);
            this.numericUpDownRooms_SAV.TabIndex = 4;
            // 
            // labelRooms_SAV
            // 
            this.labelRooms_SAV.AutoSize = true;
            this.labelRooms_SAV.Location = new System.Drawing.Point(447, 80);
            this.labelRooms_SAV.Name = "labelRooms_SAV";
            this.labelRooms_SAV.Size = new System.Drawing.Size(72, 18);
            this.labelRooms_SAV.TabIndex = 7;
            this.labelRooms_SAV.Text = "Комнат:";
            // 
            // numericUpDownLivingArea_SAV
            // 
            this.numericUpDownLivingArea_SAV.DecimalPlaces = 1;
            this.numericUpDownLivingArea_SAV.Location = new System.Drawing.Point(300, 100);
            this.numericUpDownLivingArea_SAV.Name = "numericUpDownLivingArea_SAV";
            this.numericUpDownLivingArea_SAV.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownLivingArea_SAV.TabIndex = 3;
            // 
            // labelLivingArea_SAV
            // 
            this.labelLivingArea_SAV.AutoSize = true;
            this.labelLivingArea_SAV.Location = new System.Drawing.Point(297, 80);
            this.labelLivingArea_SAV.Name = "labelLivingArea_SAV";
            this.labelLivingArea_SAV.Size = new System.Drawing.Size(108, 18);
            this.labelLivingArea_SAV.TabIndex = 5;
            this.labelLivingArea_SAV.Text = "Жилая площадь:";
            // 
            // numericUpDownTotalArea_SAV
            // 
            this.numericUpDownTotalArea_SAV.DecimalPlaces = 1;
            this.numericUpDownTotalArea_SAV.Location = new System.Drawing.Point(150, 100);
            this.numericUpDownTotalArea_SAV.Name = "numericUpDownTotalArea_SAV";
            this.numericUpDownTotalArea_SAV.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownTotalArea_SAV.TabIndex = 2;
            this.numericUpDownTotalArea_SAV.ValueChanged += new System.EventHandler(this.numericUpDownTotalArea_SAV_ValueChanged);
            // 
            // labelTotalArea_SAV
            // 
            this.labelTotalArea_SAV.AutoSize = true;
            this.labelTotalArea_SAV.Location = new System.Drawing.Point(147, 80);
            this.labelTotalArea_SAV.Name = "labelTotalArea_SAV";
            this.labelTotalArea_SAV.Size = new System.Drawing.Size(112, 18);
            this.labelTotalArea_SAV.TabIndex = 3;
            this.labelTotalArea_SAV.Text = "Общая площадь:";
            // 
            // numericUpDownApartment_SAV
            // 
            this.numericUpDownApartment_SAV.Location = new System.Drawing.Point(300, 40);
            this.numericUpDownApartment_SAV.Name = "numericUpDownApartment_SAV";
            this.numericUpDownApartment_SAV.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownApartment_SAV.TabIndex = 1;
            // 
            // labelApartment_SAV
            // 
            this.labelApartment_SAV.AutoSize = true;
            this.labelApartment_SAV.Location = new System.Drawing.Point(297, 20);
            this.labelApartment_SAV.Name = "labelApartment_SAV";
            this.labelApartment_SAV.Size = new System.Drawing.Size(92, 18);
            this.labelApartment_SAV.TabIndex = 1;
            this.labelApartment_SAV.Text = "№ Квартиры:";
            // 
            // numericUpDownEntrance_SAV
            // 
            this.numericUpDownEntrance_SAV.Location = new System.Drawing.Point(150, 40);
            this.numericUpDownEntrance_SAV.Name = "numericUpDownEntrance_SAV";
            this.numericUpDownEntrance_SAV.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownEntrance_SAV.TabIndex = 0;
            // 
            // labelEntrance_SAV
            // 
            this.labelEntrance_SAV.AutoSize = true;
            this.labelEntrance_SAV.Location = new System.Drawing.Point(147, 20);
            this.labelEntrance_SAV.Name = "labelEntrance_SAV";
            this.labelEntrance_SAV.Size = new System.Drawing.Size(78, 18);
            this.labelEntrance_SAV.TabIndex = 0;
            this.labelEntrance_SAV.Text = "Подъезд:";
            // 
            // panelButtons_SAV
            // 
            this.panelButtons_SAV.Controls.Add(this.buttonClear_SAV);
            this.panelButtons_SAV.Controls.Add(this.buttonCancel_SAV);
            this.panelButtons_SAV.Controls.Add(this.buttonSave_SAV);
            this.panelButtons_SAV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons_SAV.Location = new System.Drawing.Point(0, 400);
            this.panelButtons_SAV.Name = "panelButtons_SAV";
            this.panelButtons_SAV.Padding = new System.Windows.Forms.Padding(20);
            this.panelButtons_SAV.Size = new System.Drawing.Size(550, 100);
            this.panelButtons_SAV.TabIndex = 2;
            // 
            // buttonClear_SAV
            // 
            this.buttonClear_SAV.Location = new System.Drawing.Point(210, 20);
            this.buttonClear_SAV.Name = "buttonClear_SAV";
            this.buttonClear_SAV.Size = new System.Drawing.Size(120, 40);
            this.buttonClear_SAV.TabIndex = 11;
            this.buttonClear_SAV.Text = "Очистить";
            this.buttonClear_SAV.UseVisualStyleBackColor = true;
            this.buttonClear_SAV.Click += new System.EventHandler(this.buttonClear_SAV_Click);
            // 
            // buttonCancel_SAV
            // 
            this.buttonCancel_SAV.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel_SAV.Location = new System.Drawing.Point(350, 20);
            this.buttonCancel_SAV.Name = "buttonCancel_SAV";
            this.buttonCancel_SAV.Size = new System.Drawing.Size(120, 40);
            this.buttonCancel_SAV.TabIndex = 12;
            this.buttonCancel_SAV.Text = "Отмена";
            this.buttonCancel_SAV.UseVisualStyleBackColor = true;
            this.buttonCancel_SAV.Click += new System.EventHandler(this.buttonCancel_SAV_Click);
            // 
            // buttonSave_SAV
            // 
            this.buttonSave_SAV.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonSave_SAV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave_SAV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave_SAV.ForeColor = System.Drawing.Color.White;
            this.buttonSave_SAV.Location = new System.Drawing.Point(70, 20);
            this.buttonSave_SAV.Name = "buttonSave_SAV";
            this.buttonSave_SAV.Size = new System.Drawing.Size(120, 40);
            this.buttonSave_SAV.TabIndex = 10;
            this.buttonSave_SAV.Text = "Сохранить";
            this.buttonSave_SAV.UseVisualStyleBackColor = false;
            this.buttonSave_SAV.Click += new System.EventHandler(this.buttonSave_SAV_Click);
            // 
            // FormEditApartment_SAV
            // 
            this.AcceptButton = this.buttonSave_SAV;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel_SAV;
            this.ClientSize = new System.Drawing.Size(550, 500);
            this.Controls.Add(this.groupBoxMain_SAV);
            this.Controls.Add(this.labelTitle_SAV);
            this.Controls.Add(this.panelButtons_SAV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditApartment_SAV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование квартиры";
            this.Load += new System.EventHandler(this.FormEditApartment_SAV_Load);
            this.groupBoxMain_SAV.ResumeLayout(false);
            this.groupBoxMain_SAV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChildren_SAV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFamily_SAV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRooms_SAV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLivingArea_SAV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalArea_SAV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownApartment_SAV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEntrance_SAV)).EndInit();
            this.panelButtons_SAV.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}