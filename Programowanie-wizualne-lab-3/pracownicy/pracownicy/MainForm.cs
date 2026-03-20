using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pracownicy
{
    public partial class MainForm : Form
    {
        private BindingList<Employee> employees = new BindingList<Employee>();
        private int nextId = 1;

        public MainForm()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                ReadOnly = true
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "Imię"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Nazwisko"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Age",
                HeaderText = "Wiek"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Position",
                HeaderText = "Stanowisko"
            });

            dataGridView1.DataSource = employees;

            buttonAdd.Click += ButtonAdd_Click;
            buttonDelete.Click += ButtonDelete_Click;
            buttonSave.Click += ButtonSave_Click;
            buttonLoad.Click += ButtonLoad_Click;
        }

        private void ButtonAdd_Click(object? sender, EventArgs e)
        {
            using var f = new AddEmployeeForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                var emp = f.Employee;
                emp.Id = nextId++;
                employees.Add(emp);
            }
        }

        private void ButtonDelete_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var emp = dataGridView1.CurrentRow.DataBoundItem as Employee;
                if (emp != null)
                {
                    employees.Remove(emp);
                }
            }
        }

        private void ButtonSave_Click(object? sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog { Filter = "CSV files (*.csv)|*.csv", FileName = "employees.csv" };
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                SaveToCsv(sfd.FileName);
            }
        }

        private void SaveToCsv(string path)
        {
            var lines = new List<string>();
            lines.Add("Id;FirstName;LastName;Age;Position");
            foreach (var emp in employees)
            {
                lines.Add($"{emp.Id};{Escape(emp.FirstName)};{Escape(emp.LastName)};{emp.Age};{Escape(emp.Position)}");
            }
            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        private string Escape(string s)
        {
            if (s.Contains(';') || s.Contains('"'))
            {
                return '"' + s.Replace("\"", "\"\"") + '"';
            }
            return s;
        }

        private void ButtonLoad_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "CSV files (*.csv)|*.csv" };
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                LoadFromCsv(ofd.FileName);
            }
        }

        private void LoadFromCsv(string path)
        {
            var lines = File.ReadAllLines(path, Encoding.UTF8);
            employees.Clear();
            nextId = 1;
            for (int i = 1; i < lines.Length; i++)
            {
                var parts = SplitCsvLine(lines[i]);
                if (parts.Length < 5) continue;
                if (!int.TryParse(parts[0], out var id)) id = nextId++;
                var emp = new Employee
                {
                    Id = id,
                    FirstName = parts[1],
                    LastName = parts[2],
                    Age = int.TryParse(parts[3], out var a) ? a : 0,
                    Position = parts[4]
                };
                employees.Add(emp);
                if (emp.Id >= nextId) nextId = emp.Id + 1;
            }
        }

        private string[] SplitCsvLine(string line)
        {
            var result = new List<string>();
            var cur = new StringBuilder();
            bool inQuotes = false;
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (inQuotes)
                {
                    if (c == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            cur.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else cur.Append(c);
                }
                else
                {
                    if (c == '"') { inQuotes = true; }
                    else if (c == ';') { result.Add(cur.ToString()); cur.Clear(); }
                    else cur.Append(c);
                }
            }
            result.Add(cur.ToString());
            return result.ToArray();
        }
    }
}
