using System;
using System.Windows.Forms;

namespace pracownicy
{
    public partial class AddEmployeeForm : Form
    {
        public Employee Employee { get; private set; } = new Employee();

        public AddEmployeeForm()
        {
            InitializeComponent();
            comboBoxPosition.Items.AddRange(new[] { "Programista", "Tester", "Menedżer" });
            buttonOk.Click += ButtonOk_Click;
            buttonCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private void ButtonOk_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) || string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                MessageBox.Show(this, "Imię i nazwisko są wymagane", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxAge.Text, out var age))
            {
                MessageBox.Show(this, "Wiek musi być liczbą", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Employee.FirstName = textBoxFirstName.Text.Trim();
            Employee.LastName = textBoxLastName.Text.Trim();
            Employee.Age = age;
            Employee.Position = comboBoxPosition.SelectedItem?.ToString() ?? string.Empty;

            this.DialogResult = DialogResult.OK;
        }
    }
}
