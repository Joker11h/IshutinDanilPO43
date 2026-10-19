using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
namespace LinqSqliteWinForms
{
    public partial class FormMain : Form
    {
        private const string ConnectionString = "Data Source=company.db";
        private List<Employee> employees = new List<Employee>();
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            InitializeDatabase();
            LoadEmployeesFromDatabase();
            InitializeControls();
            ApplyFilterAndSort();
        }
        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Employees (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                FullName TEXT NOT NULL,
                Department TEXT NOT NULL,
                Position TEXT NOT NULL,
                Salary REAL NOT NULL,
                HireDate TEXT NOT NULL
            );";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT COUNT(*) FROM Employees;";
            long count = (long)(cmd.ExecuteScalar() ?? 0L);
            if (count == 0)
            {
                cmd.CommandText = @"INSERT INTO Employees (FullName, Department, Position, Salary, HireDate) VALUES
                ('Иванов Иван Иванович', 'IT', 'Разработчик C#', 150000, '2022-03-15'),
                ('Петрова Анна Сергеевна', 'Бухгалтерия', 'Главный бухгалтер', 130000, '2020-07-01'),
                ('Сидоров Алексей Дмитриевич', 'IT', 'Системный администратор', 95000, '2023-01-10'),
                ('Смирнова Елена Викторовна', 'Маркетинг', 'Маркетолог-аналитик', 110000, '2021-11-20'),
                ('Кузнецов Дмитрий Олегович', 'Продажи', 'Менеджер по продажам', 85000, '2023-05-12'),
                ('Морозова Ольга Николаевна', 'IT', 'Разработчик C#', 165000, '2021-02-18'),
                ('Волков Сергей Александрович', 'Продажи', 'Руководитель отдела продаж', 145000, '2019-09-01'),
                ('Новикова Мария Андреевна', 'Бухгалтерия', 'Бухгалтер-расчетчик', 80000, '2024-02-01'),
                ('Федоров Павел Игоревич', 'Маркетинг', 'SMM-специалист', 75000, '2023-08-25'),
                ('Соколова Татьяна Юрьевна', 'Продажи', 'Менеджер по продажам', 90000, '2022-06-14');";
                cmd.ExecuteNonQuery();
            }
        }
        private void LoadEmployeesFromDatabase()
        {
            employees.Clear();
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, FullName, Department, Position, Salary, HireDate FROM Employees;";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string fullName = reader.GetString(1);
                string department = reader.GetString(2);
                string position = reader.GetString(3);
                decimal salary = Convert.ToDecimal(reader.GetDouble(4));
                DateTime hireDate = DateTime.ParseExact(reader.GetString(5), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                employees.Add(new Employee(id, fullName, department, position, salary, hireDate));
            }
        }
        private void InitializeControls()
        {
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.AddRange(new object[] { "Все отделы", "IT", "Маркетинг", "Бухгалтерия", "Продажи" });
            cmbDepartment.SelectedIndex = 0;
            cmbSortCriterion.Items.Clear();
            cmbSortCriterion.Items.AddRange(new object[] { "ФИО", "Оклад", "Отдел + Оклад (по убыванию)", "Должность + Дата приема" });
            cmbSortCriterion.SelectedIndex = 0;
            numMinSalary.Value = 0;
            numMaxSalary.Value = 500000;
            txtSearchName.Text = string.Empty;
            rdbAsc.Checked = true;
        }
        private void ApplyFilterAndSort()
        {
            string selectedDept = cmbDepartment.SelectedItem?.ToString() ?? "Все отделы";
            string searchText = txtSearchName.Text.Trim();
            decimal minSalary = Math.Min(numMinSalary.Value, numMaxSalary.Value);
            decimal maxSalary = Math.Max(numMinSalary.Value, numMaxSalary.Value);
            IEnumerable<Employee> query = employees
                .Where(e => selectedDept == "Все отделы" || e.Department == selectedDept)
                .Where(e => e.Salary >= minSalary && e.Salary <= maxSalary)
                .Where(e => string.IsNullOrEmpty(searchText) || e.FullName.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            string sortCriterion = cmbSortCriterion.SelectedItem?.ToString() ?? "ФИО";
            bool ascending = rdbAsc.Checked;
            query = sortCriterion switch
            {
                "ФИО" => ascending
                    ? query.OrderBy(e => e.FullName)
                    : query.OrderByDescending(e => e.FullName),
                "Оклад" => ascending
                    ? query.OrderBy(e => e.Salary)
                    : query.OrderByDescending(e => e.Salary),
                "Отдел + Оклад (по убыванию)" => ascending
                    ? query.OrderBy(e => e.Department).ThenByDescending(e => e.Salary)
                    : query.OrderByDescending(e => e.Department).ThenByDescending(e => e.Salary),
                "Должность + Дата приема" => ascending
                    ? query.OrderBy(e => e.Position).ThenBy(e => e.HireDate)
                    : query.OrderByDescending(e => e.Position).ThenByDescending(e => e.HireDate),
                _ => query.OrderBy(e => e.Id)
            };
            List<Employee> resultList = query.ToList();
            dgvEmployees.DataSource = resultList;
            ConfigureGridColumns();
            int totalCount = resultList.Count;
            decimal totalSalary = resultList.Sum(e => e.Salary);
            lblStatus.Text = $"Найдено сотрудников: {totalCount} | Общий фонд оплаты труда: {totalSalary:N2} тг";
        }
        private void ConfigureGridColumns()
        {
            if (dgvEmployees.Columns["Id"] != null) dgvEmployees.Columns["Id"].HeaderText = "ID";
            if (dgvEmployees.Columns["FullName"] != null) dgvEmployees.Columns["FullName"].HeaderText = "ФИО";
            if (dgvEmployees.Columns["Department"] != null) dgvEmployees.Columns["Department"].HeaderText = "Отдел";
            if (dgvEmployees.Columns["Position"] != null) dgvEmployees.Columns["Position"].HeaderText = "Должность";
            if (dgvEmployees.Columns["Salary"] != null)
            {
                dgvEmployees.Columns["Salary"].HeaderText = "Оклад (тг)";
                dgvEmployees.Columns["Salary"].DefaultCellStyle.Format = "N2";
            }
            if (dgvEmployees.Columns["HireDate"] != null)
            {
                dgvEmployees.Columns["HireDate"].HeaderText = "Дата приема";
                dgvEmployees.Columns["HireDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }
        }
        private void BtnApply_Click(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            InitializeControls();
            ApplyFilterAndSort();
        }
    }
}