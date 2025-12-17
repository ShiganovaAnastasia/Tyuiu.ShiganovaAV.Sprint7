using System;
using System.Drawing;
using System.Windows.Forms;
using Tyuiu.ShiganovaAV.Sprint7.Project.V7.Lib;
using static Tyuiu.ShiganovaAV.Sprint7.Project.V7.Lib.DataService;

namespace Tyuiu.ShiganovaAV.Sprint7.Project.V7
{
    public partial class FormEditApartment_SAV : Form
    {
        private Apartment apartment_SAV;
        private bool isEditMode_SAV;

        public FormEditApartment_SAV()
        {
            InitializeComponent();
            apartment_SAV = new Apartment();
            isEditMode_SAV = false;
            SetupForm_SAV();
        }

        public FormEditApartment_SAV(Apartment apartment)
        {
            InitializeComponent();
            apartment_SAV = apartment;
            isEditMode_SAV = true;
            SetupForm_SAV();
            FillForm_SAV();
        }

        private void SetupForm_SAV()
        {
            this.Text = isEditMode_SAV ? "Редактирование квартиры" : "Добавление новой квартиры";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Настройка DateTimePicker
            dateTimePickerRegistration_SAV.Format = DateTimePickerFormat.Custom;
            dateTimePickerRegistration_SAV.CustomFormat = "dd.MM.yyyy";
            dateTimePickerRegistration_SAV.Value = DateTime.Now;

            // Настройка NumericUpDown
            numericUpDownEntrance_SAV.Minimum = 1;
            numericUpDownEntrance_SAV.Maximum = 20;

            numericUpDownApartment_SAV.Minimum = 1;
            numericUpDownApartment_SAV.Maximum = 999;

            numericUpDownTotalArea_SAV.DecimalPlaces = 1;
            numericUpDownTotalArea_SAV.Minimum = 20;
            numericUpDownTotalArea_SAV.Maximum = 500;
            numericUpDownTotalArea_SAV.Increment = 0.5m;

            numericUpDownLivingArea_SAV.DecimalPlaces = 1;
            numericUpDownLivingArea_SAV.Minimum = 10;
            numericUpDownLivingArea_SAV.Maximum = 300;
            numericUpDownLivingArea_SAV.Increment = 0.5m;

            numericUpDownRooms_SAV.Minimum = 1;
            numericUpDownRooms_SAV.Maximum = 10;

            numericUpDownFamily_SAV.Minimum = 1;
            numericUpDownFamily_SAV.Maximum = 20;

            numericUpDownChildren_SAV.Minimum = 0;
            numericUpDownChildren_SAV.Maximum = 10;

            // Подсказки
            toolTip_SAV.SetToolTip(textBoxSurname_SAV, "Введите фамилию квартиросъемщика");
            toolTip_SAV.SetToolTip(textBoxNotes_SAV, "Дополнительная информация о квартире");
            toolTip_SAV.SetToolTip(checkBoxDebt_SAV, "Отметьте, если есть задолженность по квартплате");
        }

        private void FillForm_SAV()
        {
            numericUpDownEntrance_SAV.Value = apartment_SAV.EntranceNumber;
            numericUpDownApartment_SAV.Value = apartment_SAV.ApartmentNumber;
            numericUpDownTotalArea_SAV.Value = (decimal)apartment_SAV.TotalArea;
            numericUpDownLivingArea_SAV.Value = (decimal)apartment_SAV.LivingArea;
            numericUpDownRooms_SAV.Value = apartment_SAV.RoomsCount;
            textBoxSurname_SAV.Text = apartment_SAV.TenantSurname;
            dateTimePickerRegistration_SAV.Value = apartment_SAV.RegistrationDate;
            numericUpDownFamily_SAV.Value = apartment_SAV.FamilyMembers;
            numericUpDownChildren_SAV.Value = apartment_SAV.ChildrenCount;
            checkBoxDebt_SAV.Checked = apartment_SAV.HasDebt;
            textBoxNotes_SAV.Text = apartment_SAV.Notes;
        }

        public Apartment GetApartment()
        {
            return apartment_SAV;
        }

        private void buttonSave_SAV_Click(object sender, EventArgs e)
        {
            if (ValidateForm_SAV())
            {
                SaveData_SAV();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SaveData_SAV()
        {
            apartment_SAV.EntranceNumber = (int)numericUpDownEntrance_SAV.Value;
            apartment_SAV.ApartmentNumber = (int)numericUpDownApartment_SAV.Value;
            apartment_SAV.TotalArea = (double)numericUpDownTotalArea_SAV.Value;
            apartment_SAV.LivingArea = (double)numericUpDownLivingArea_SAV.Value;
            apartment_SAV.RoomsCount = (int)numericUpDownRooms_SAV.Value;
            apartment_SAV.TenantSurname = textBoxSurname_SAV.Text.Trim();
            apartment_SAV.RegistrationDate = dateTimePickerRegistration_SAV.Value;
            apartment_SAV.FamilyMembers = (int)numericUpDownFamily_SAV.Value;
            apartment_SAV.ChildrenCount = (int)numericUpDownChildren_SAV.Value;
            apartment_SAV.HasDebt = checkBoxDebt_SAV.Checked;
            apartment_SAV.Notes = textBoxNotes_SAV.Text.Trim();
        }

        private bool ValidateForm_SAV()
        {
            // Проверка фамилии
            if (string.IsNullOrWhiteSpace(textBoxSurname_SAV.Text))
            {
                MessageBox.Show("Введите фамилию квартиросъемщика",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSurname_SAV.Focus();
                return false;
            }

            // Проверка площади
            if ((double)numericUpDownLivingArea_SAV.Value > (double)numericUpDownTotalArea_SAV.Value)
            {
                MessageBox.Show("Жилая площадь не может быть больше общей",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownLivingArea_SAV.Focus();
                return false;
            }

            // Проверка количества детей
            if ((int)numericUpDownChildren_SAV.Value > (int)numericUpDownFamily_SAV.Value)
            {
                MessageBox.Show("Количество детей не может превышать количество членов семьи",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownChildren_SAV.Focus();
                return false;
            }

            // Проверка даты (не может быть в будущем)
            if (dateTimePickerRegistration_SAV.Value > DateTime.Now)
            {
                MessageBox.Show("Дата прописки не может быть в будущем",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerRegistration_SAV.Focus();
                return false;
            }

            // Проверка даты (не слишком старая - например, не раньше 1900 года)
            if (dateTimePickerRegistration_SAV.Value.Year < 1900)
            {
                MessageBox.Show("Укажите корректную дату прописки",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerRegistration_SAV.Focus();
                return false;
            }

            return true;
        }

        private void buttonCancel_SAV_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBoxSurname_SAV_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только буквы, пробел, дефис и управляющие символы
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ' &&
                e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void numericUpDownTotalArea_SAV_ValueChanged(object sender, EventArgs e)
        {
            // Автоматическая проверка жилой площади
            if ((double)numericUpDownLivingArea_SAV.Value > (double)numericUpDownTotalArea_SAV.Value)
            {
                numericUpDownLivingArea_SAV.Value = numericUpDownTotalArea_SAV.Value;
            }
        }

        private void numericUpDownFamily_SAV_ValueChanged(object sender, EventArgs e)
        {
            // Автоматическая проверка количества детей
            if ((int)numericUpDownChildren_SAV.Value > (int)numericUpDownFamily_SAV.Value)
            {
                numericUpDownChildren_SAV.Value = numericUpDownFamily_SAV.Value;
            }
        }

        private void buttonClear_SAV_Click(object sender, EventArgs e)
        {
            ClearForm_SAV();
        }

        private void ClearForm_SAV()
        {
            if (!isEditMode_SAV)
            {
                numericUpDownEntrance_SAV.Value = 1;
                numericUpDownApartment_SAV.Value = 1;
                numericUpDownTotalArea_SAV.Value = 50;
                numericUpDownLivingArea_SAV.Value = 35;
                numericUpDownRooms_SAV.Value = 2;
                textBoxSurname_SAV.Clear();
                dateTimePickerRegistration_SAV.Value = DateTime.Now;
                numericUpDownFamily_SAV.Value = 2;
                numericUpDownChildren_SAV.Value = 0;
                checkBoxDebt_SAV.Checked = false;
                textBoxNotes_SAV.Clear();
                textBoxSurname_SAV.Focus();
            }
        }

        private void FormEditApartment_SAV_Load(object sender, EventArgs e)
        {
            if (!isEditMode_SAV)
            {
                ClearForm_SAV();
            }
        }
    }
}