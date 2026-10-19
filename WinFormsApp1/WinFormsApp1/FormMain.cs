using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormMain : Form
    {
        private List<ConsoleApp3.Employee> allEmployees = new();

        private GroupBox grpFilters = new();
        private ComboBox cmbDepartment = new();
        private TextBox txtSearchName = new();
        private NumericUpDown numMinSalary = new();
        private NumericUpDown numMaxSalary = new();

        private GroupBox grpSort = new();
        private ComboBox cmbSortCriterion = new();
        private RadioButton rdbAsc = new();
        private RadioButton rdbDesc = new();

        private Button btnApply = new();
        private Button btnReset = new();

        private DataGridView dgvEmployees = new();
        private Label lblStatus = new();

        public FormMain()
        {
            InitializeComponentCustom();
            LoadData();
        }

        private void InitializeComponentCustom()
        {
            this.Text = "Фильтрация и сортировка сотрудников";
            this.Width = 900;
            this.Height = 650;
            this.StartPosition = FormStartPosition.CenterScreen;

            grpFilters.Text = "Фильтры";
            grpFilters.Location = new Point(12, 12);
            grpFilters.Size = new Size(860, 100);

            var lblDept = new Label { Text = "Отдел:", Location = new Point(15, 30), AutoSize = true };
            cmbDepartment.Location = new Point(70, 27);
            cmbDepartment.Size = new Size(150, 25);
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;

            var lblSearch = new Label { Text = "ФИО:", Location = new Point(240, 30), AutoSize = true };
            txtSearchName.Location = new Point(280, 27);
            txtSearchName.Size = new Size(180, 25);

            var lblMin = new Label { Text = "Мин. оклад:", Location = new Point(480, 30), AutoSize = true };
            numMinSalary.Location = new Point(560, 27);
            numMinSalary.Size = new Size(100, 25);
            numMinSalary.Maximum = 1000000;
            numMinSalary.Value = 0;

            var lblMax = new Label { Text = "Макс. оклад:", Location = new Point(680, 30), AutoSize = true };
            numMaxSalary.Location = new Point(760, 27);
            numMaxSalary.Size = new Size(100, 25);
            numMaxSalary.Maximum = 1000000;
            numMaxSalary.Value = 500000;

            grpFilters.Controls.Add(lblDept);
            grpFilters.Controls.Add(cmbDepartment);
            grpFilters.Controls.Add(lblSearch);
            grpFilters.Controls.Add(txtSearchName);
            grpFilters.Controls.Add(lblMin);
            grpFilters.Controls.Add(numMinSalary);
            grpFilters.Controls.Add(lblMax);
            grpFilters.Controls.Add(numMaxSalary);

            grpSort.Text = "Сортировка";
            grpSort.Location = new Point(12, 120);
            grpSort.Size = new Size(860, 70);

            var lblCriterion = new Label { Text = "Критерий:", Location = new Point(15, 30), AutoSize = true };
            cmbSortCriterion.Location = new Point(80, 27);
            cmbSortCriterion.Size = new Size(200, 25);
            cmbSortCriterion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSortCriterion.Items.AddRange(new object[] { "ФИО", "Оклад", "Отдел + Оклад", "Должность + Дата приема" });
            cmbSortCriterion.SelectedIndex = 0;

            rdbAsc.Text = "По возрастанию";
            rdbAsc.Location = new Point(300, 29);
            rdbAsc.AutoSize = true;
            rdbAsc.Checked = true;

            rdbDesc.Text = "По убыванию";
            rdbDesc.Location = new Point(430, 29);
            rdbDesc.AutoSize = true;

            btnApply.Text = "Применить";
            btnApply.Location = new Point(600, 25);
            btnApply.Size = new Size(110, 30);
            btnApply.Click += BtnApply_Click;

            btnReset.Text = "Сбросить";
            btnReset.Location = new Point(720, 25);
            btnReset.Size = new Size(110, 30);
            btnReset.Click += BtnReset_Click;

            grpSort.Controls.Add(lblCriterion);
            grpSort.Controls.Add(cmbSortCriterion);
            grpSort.Controls.Add(rdbAsc);
            grpSort.Controls.Add(rdbDesc);
            grpSort.Controls.Add(btnApply);
            grpSort.Controls.Add(btnReset);

            dgvEmployees.Location = new Point(12, 200);
            dgvEmployees.Size = new Size(860, 350);
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.ReadOnly = true;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            lblStatus.Location = new Point(12, 560);
            lblStatus.Size = new Size(860, 25);

            this.Controls.Add(grpFilters);
            this.Controls.Add(grpSort);
            this.Controls.Add(dgvEmployees);
            this.Controls.Add(lblStatus);
        }

        private void LoadData()
        {
            DatabaseHelper.InitializeDatabase();
            allEmployees = DatabaseHelper.LoadEmployees();

            cmbDepartment.Items.Clear();
            cmbDepartment.Items.Add("Все отделы");
            var departments = allEmployees.Select(e => e.Department).Distinct().ToArray();
            cmbDepartment.Items.AddRange(departments);
            cmbDepartment.SelectedIndex = 0;

            ApplyFilterAndSort();
        }

        private void BtnApply_Click(object? sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void BtnReset_Click(object? sender, EventArgs e)
        {
            cmbDepartment.SelectedIndex = 0;
            txtSearchName.Text = string.Empty;
            numMinSalary.Value = 0;
            numMaxSalary.Value = 500000;
            cmbSortCriterion.SelectedIndex = 0;
            rdbAsc.Checked = true;

            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            string selectedDept = cmbDepartment.SelectedItem?.ToString() ?? "Все отделы";
            string searchText = txtSearchName.Text.Trim();
            decimal minSalary = numMinSalary.Value;
            decimal maxSalary = numMaxSalary.Value;
            bool isAscending = rdbAsc.Checked;

            IEnumerable<ConsoleApp3.Employee> filtered = allEmployees.Where(e =>
                (selectedDept == "Все отделы" || e.Department == selectedDept) &&
                (e.Salary >= minSalary && e.Salary <= maxSalary) &&
                (string.IsNullOrEmpty(searchText) || e.FullName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            );

            IOrderedEnumerable<ConsoleApp3.Employee> query = cmbSortCriterion.SelectedIndex switch
            {
                0 => isAscending ? filtered.OrderBy(e => e.FullName) : filtered.OrderByDescending(e => e.FullName),
                1 => isAscending ? filtered.OrderBy(e => e.Salary) : filtered.OrderByDescending(e => e.Salary),
                2 => isAscending ? filtered.OrderBy(e => e.Department).ThenBy(e => e.Salary) : filtered.OrderBy(e => e.Department).ThenByDescending(e => e.Salary),
                3 => isAscending ? filtered.OrderBy(e => e.Position).ThenBy(e => e.HireDate) : filtered.OrderByDescending(e => e.Position).ThenByDescending(e => e.HireDate),
                _ => isAscending ? filtered.OrderBy(e => e.Id) : filtered.OrderByDescending(e => e.Id)
            };

            var resultList = query.ToList();
            dgvEmployees.DataSource = resultList;

            int count = resultList.Count;
            decimal totalSalary = resultList.Sum(e => e.Salary);
            lblStatus.Text = $"Найдено сотрудников: {count} | Общий фонд з/п: {totalSalary:N2} руб.";
        }
    }
}