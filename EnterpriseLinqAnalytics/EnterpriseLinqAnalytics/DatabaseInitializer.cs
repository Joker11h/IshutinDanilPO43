using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace EnterpriseLinqAnalytics
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString = "Data Source=enterprise.db";
        public void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            var createTablesCmd = connection.CreateCommand();
            createTablesCmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Categories (
                    Id INTEGER PRIMARY KEY,
                    Name TEXT NOT NULL,
                    DiscountRate REAL NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Products (
                    Id INTEGER PRIMARY KEY,
                    Name TEXT NOT NULL,
                    CategoryId INTEGER NOT NULL,
                    Price REAL NOT NULL,
                    Stock INTEGER NOT NULL,
                    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
                );
                CREATE TABLE IF NOT EXISTS Sales (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProductId INTEGER NOT NULL,
                    CustomerName TEXT NOT NULL,
                    Quantity INTEGER NOT NULL,
                    SaleDate TEXT NOT NULL,
                    Channel TEXT NOT NULL,
                    FOREIGN KEY (ProductId) REFERENCES Products(Id)
                );
            ";
            createTablesCmd.ExecuteNonQuery();
            var checkCmd = connection.CreateCommand();
            checkCmd.CommandText = "SELECT COUNT(*) FROM Categories;";
            long count = (long)(checkCmd.ExecuteScalar() ?? 0L);
            if (count > 0) return;
            using var transaction = connection.BeginTransaction();
            var seedCmd = connection.CreateCommand();
            seedCmd.Transaction = transaction;
            seedCmd.CommandText = @"
                INSERT INTO Categories (Id, Name, DiscountRate) VALUES
                (1, 'Электроника', 0.10),
                (2, 'Бытовая техника', 0.05),
                (3, 'Офисная мебель', 0.15),
                (4, 'Сетевое оборудование', 0.08);
                INSERT INTO Products (Id, Name, CategoryId, Price, Stock) VALUES
                (1, 'Ноутбук ProBook 15', 1, 85000, 12),
                (2, 'Монитор UltraWide 29', 1, 32000, 20),
                (3, 'Смартфон Galaxy S24', 1, 74000, 15),
                (4, 'Кофемашина Barista', 2, 45000, 8),
                (5, 'Робот-пылесос CleanBot', 2, 28000, 14),
                (6, 'Микроволновая печь SmartWave', 2, 14000, 25),
                (7, 'Кресло эргономичное ErgoMax', 3, 22000, 18),
                (8, 'Стол с электроприводом LiftDesk', 3, 39000, 9),
                (9, 'Маршрутизатор Wi-Fi 6 AX3000', 4, 9500, 30),
                (10, 'Коммутатор Гигабитный 16-Port', 4, 12500, 11);
                INSERT INTO Sales (ProductId, CustomerName, Quantity, SaleDate, Channel) VALUES
                (1, 'Иванов И.И.', 1, '2026-09-01', 'Online'),
                (1, 'Петров П.С.', 2, '2026-09-02', 'Online'),
                (2, 'Сидорова А.В.', 1, '2026-09-03', 'Online'),
                (2, 'Козлов Д.Н.', 3, '2026-09-04', 'Online'),
                (3, 'Смирнов К.Е.', 1, '2026-09-05', 'Online'),
                (3, 'Морозова О.П.', 1, '2026-09-06', 'Retail'),
                (4, 'Волков А.А.', 1, '2026-09-07', 'Online'),
                (4, 'Лебедева М.С.', 2, '2026-09-08', 'Retail'),
                (5, 'Соколов И.В.', 1, '2026-09-09', 'Online'),
                (5, 'Новикова Е.Д.', 2, '2026-09-10', 'Retail'),
                (6, 'Федоров Н.М.', 1, '2026-09-11', 'Retail'),
                (6, 'Орлова Т.Г.', 3, '2026-09-12', 'Retail'),
                (7, 'Алексеев В.Б.', 2, '2026-09-13', 'Online'),
                (7, 'Макарова Ю.А.', 4, '2026-09-14', 'Retail'),
                (8, 'Захаров Р.К.', 1, '2026-09-15', 'Retail'),
                (8, 'Павлова С.Л.', 2, '2026-09-16', 'Retail'),
                (9, 'Семенов Г.О.', 3, '2026-09-17', 'Online'),
                (9, 'Голубева Н.И.', 5, '2026-09-18', 'Retail'),
                (3, 'Виноградов Е.Р.', 2, '2026-09-19', 'Online'),
                (4, 'Богданова Л.Ф.', 1, '2026-09-20', 'Online');
            ";
            seedCmd.ExecuteNonQuery();
            transaction.Commit();
        }
        public List<Category> LoadCategories()
        {
            var list = new List<Category>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Name, DiscountRate FROM Categories;";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Category(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetDouble(2)));
            }
            return list;
        }

        public List<Product> LoadProducts()
        {
            var list = new List<Product>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Name, CategoryId, Price, Stock FROM Products;";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Product(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetDouble(3),
                    reader.GetInt32(4)));
            }
            return list;
        }
        public List<Sale> LoadSales()
        {
            var list = new List<Sale>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, ProductId, CustomerName, Quantity, SaleDate, Channel FROM Sales;";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Sale(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    reader.GetString(2),
                    reader.GetInt32(3),
                    reader.GetString(4),
                    reader.GetString(5)));
            }
            return list;
        }
        public Sale InsertSale(int productId, string customerName, int quantity, string saleDate, string channel)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Sales (ProductId, CustomerName, Quantity, SaleDate, Channel)
                VALUES ($pId, $cName, $qty, $sDate, $chan);
                SELECT last_insert_rowid();
            ";
            cmd.Parameters.AddWithValue("$pId", productId);
            cmd.Parameters.AddWithValue("$cName", customerName);
            cmd.Parameters.AddWithValue("$qty", quantity);
            cmd.Parameters.AddWithValue("$sDate", saleDate);
            cmd.Parameters.AddWithValue("$chan", channel);
            long newId = (long)(cmd.ExecuteScalar() ?? 0L);
            return new Sale((int)newId, productId, customerName, quantity, saleDate, channel);
        }
    }
}