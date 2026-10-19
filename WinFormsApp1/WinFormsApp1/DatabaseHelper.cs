using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace ConsoleApp3
{
    public record Employee(int Id, string FullName, string Department, string Position, decimal Salary, DateTime HireDate);

    public static class DatabaseHelper
    {
        private const string ConnectionString = "Data Source=company.db";

        public static void InitializeDatabase()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Employees (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FullName TEXT NOT NULL,
                    Department TEXT NOT NULL,
                    Position TEXT NOT NULL,
                    Salary REAL NOT NULL,
                    HireDate TEXT NOT NULL
                );
            ";
            command.ExecuteNonQuery();

            command.CommandText = "SELECT COUNT(*) FROM Employees;";
            long count = (long)command.ExecuteScalar()!;

            if (count == 0)
            {
                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = @"
                    INSERT INTO Employees (FullName, Department, Position, Salary, HireDate) VALUES
                    ('Иванов Иван Иванович', 'IT', 'Разработчик', 150000, '2022-03-15'),
                    ('Петров Петр Петрович', 'IT', 'Тестировщик', 120000, '2023-01-10'),
                    ('Сидорова Анна Сергеевна', 'Маркетинг', 'Менеджер', 95000, '2021-07-20'),
                    ('Смирнов Алексей Павлович', 'Бухгалтерия', 'Бухгалтер', 110000, '2020-11-05'),
                    ('Кузнецова Елена Викторовна', 'Продажи', 'Специалист', 90000, '2023-05-12'),
                    ('Васильев Дмитрий Олегович', 'IT', 'Архитектор', 250000, '2019-02-18'),
                    ('Морозова Ольга Николаевна', 'Маркетинг', 'Аналитик', 130000, '2022-09-01'),
                    ('Федоров Игорь Сергеевич', 'Продажи', 'Руководитель', 180000, '2018-06-30');
                ";
                insertCommand.ExecuteNonQuery();
            }
        }

        public static List<Employee> LoadEmployees()
        {
            var employees = new List<Employee>();
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, FullName, Department, Position, Salary, HireDate FROM Employees;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(new Employee(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    Convert.ToDecimal(reader.GetDouble(4)),
                    DateTime.Parse(reader.GetString(5))
                ));
            }

            return employees;
        }
    }
}