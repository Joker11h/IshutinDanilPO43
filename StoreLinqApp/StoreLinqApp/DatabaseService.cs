using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
namespace StoreLinqApp
{
    public static class DatabaseService
    {
        private const string ConnectionString = "Data Source=store.db";
        public static void InitializeDatabase()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            string createTablesQuery = "CREATE TABLE IF NOT EXISTS OnlineOrders(Id INTEGER PRIMARY KEY AUTOINCREMENT,CustomerName TEXT NOT NULL,ProductName TEXT NOT NULL,Category TEXT NOT NULL,Price REAL NOT NULL,Quantity INTEGER NOT NULL);CREATE TABLE IF NOT EXISTS StoreOrders(Id INTEGER PRIMARY KEY AUTOINCREMENT,CustomerName TEXT NOT NULL,ProductName TEXT NOT NULL,Category TEXT NOT NULL,Price REAL NOT NULL,Quantity INTEGER NOT NULL);";
            using (var cmd = new SqliteCommand(createTablesQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }
            using var checkCmd = new SqliteCommand("SELECT COUNT(*) FROM OnlineOrders;", connection);
            long count = (long)(checkCmd.ExecuteScalar() ?? 0);
            if (count == 0)
            {
                string seedQuery = "INSERT INTO OnlineOrders(CustomerName,ProductName,Category,Price,Quantity)VALUES('Иван Петров','Ноутбук ASUS','Электроника',65000,1),('Анна Смирнова','Мышь Logitech','Периферия',1500,2),('Олег Волков','Коврик для мыши','Аксессуары',450,1),('Мария Козлова','Подписка Яндекс Плюс','Цифровые товары',299,3),('Дмитрий Соколов','Механическая клавиатура','Периферия',4500,1),('Елена Новикова','USB-хаб Baseus','Аксессуары',1200,1);INSERT INTO StoreOrders(CustomerName,ProductName,Category,Price,Quantity)VALUES('Сергей Морозов','Ноутбук ASUS','Электроника',65000,1),('Ольга Павлова','Мышь Logitech','Периферия',1500,1),('Алексей Лебедев','Монитор Samsung','Электроника',18000,1),('Наталья Орлова','Кабель HDMI','Аксессуары',600,2),('Виктор Киселев','Офисное кресло','Мебель',12500,1);";
                using var seedCmd = new SqliteCommand(seedQuery, connection);
                seedCmd.ExecuteNonQuery();
            }
        }
        public static List<OrderItem> GetOrders(string tableName)
        {
            var list = new List<OrderItem>();
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            string query = $"SELECT Id,CustomerName,ProductName,Category,Price,Quantity FROM {tableName};";
            using var cmd = new SqliteCommand(query, connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new OrderItem(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), Convert.ToDecimal(reader.GetDouble(4)), reader.GetInt32(5)));
            }
            return list;
        }
    }
}