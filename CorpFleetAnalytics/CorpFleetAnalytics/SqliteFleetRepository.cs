using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace CorpFleetAnalytics
{
    public class SqliteFleetRepository : IRepository<Vehicle>
    {
        private readonly string _dbFile = "corp_fleet.db";
        private readonly string _connectionString;
        public SqliteFleetRepository()
        {
            _connectionString = $"Data Source={_dbFile};Version=3;";
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            if (!File.Exists(_dbFile))
            {
                SQLiteConnection.CreateFile(_dbFile);
            }
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string schemaSql = @"
                    CREATE TABLE IF NOT EXISTS Categories (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        CategoryName TEXT NOT NULL,
                        TaxRate REAL NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS Vehicles (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Model TEXT NOT NULL,
                        BasePrice REAL NOT NULL,
                        Power INTEGER NOT NULL,
                        CategoryId INTEGER NOT NULL,
                        VehicleType TEXT NOT NULL,
                        ExtraParam REAL NOT NULL,
                        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
                    );
                    CREATE TABLE IF NOT EXISTS MaintenanceLogs (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        VehicleId INTEGER NOT NULL,
                        ServiceName TEXT NOT NULL,
                        Cost REAL NOT NULL,
                        LogDate TEXT NOT NULL,
                        Channel TEXT NOT NULL,
                        FOREIGN KEY (VehicleId) REFERENCES Vehicles(Id)
                    );";
                using (var cmd = new SQLiteCommand(schemaSql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                using (var countCmd = new SQLiteCommand("SELECT COUNT(*) FROM Categories;", conn))
                {
                    long count = (long)countCmd.ExecuteScalar();
                    if (count == 0)
                    {
                        SeedInitialData(conn);
                    }
                }
            }
        }
        private void SeedInitialData(SQLiteConnection conn)
        {
            string seedSql = @"
                INSERT INTO Categories (Id, CategoryName, TaxRate) VALUES
                (1, 'Магистральные Тягачи', 0.08),
                (2, 'Коммерческие Автобусы', 0.05),
                (3, 'Спецтехника и Фургоны', 0.06),
                (4, 'Корпоративный Бизнес-Класс', 0.04);
                INSERT INTO Vehicles (Id, Model, BasePrice, Power, CategoryId, VehicleType, ExtraParam) VALUES
                (1, 'KAMAZ-54901 Neo', 7800000, 450, 1, 'Cargo', 20.0),
                (2, 'Volvo FH16 Globetrotter', 12500000, 540, 1, 'Cargo', 25.0),
                (3, 'MAN TGX 18.480', 10900000, 480, 1, 'Cargo', 22.0),
                (4, 'GAZelle NEXT Cargo', 3200000, 150, 3, 'Cargo', 3.5),
                (5, 'Scania R500 Heavy', 11800000, 500, 1, 'Cargo', 24.0),
                (6, 'Mercedes-Benz Sprinter Tourer', 5600000, 190, 2, 'Passenger', 19.0),
                (7, 'LiAZ-5292 CityBus', 9400000, 300, 2, 'Passenger', 45.0),
                (8, 'Toyota Camry Executive', 4100000, 249, 4, 'Passenger', 5.0),
                (9, 'Ford Transit Van', 3950000, 170, 3, 'Cargo', 4.2),
                (10, 'Yutong ZK6122H9 Coach', 11200000, 375, 2, 'Passenger', 53.0);
                INSERT INTO MaintenanceLogs (VehicleId, ServiceName, Cost, LogDate, Channel) VALUES
                (1, 'Замена масла и фильтров ДВС', 45000, '2025-01-12', 'Online'),
                (1, 'Компьютерная диагностика тормозной системы', 28000, '2025-02-05', 'Offline'),
                (2, 'Замена масла и фильтров ДВС', 62000, '2025-01-18', 'Offline'),
                (2, 'Калибровка тахографа и ГЛОНАСС', 19000, '2025-02-11', 'Online'),
                (3, 'Регулировка топливной аппаратуры', 85000, '2025-01-22', 'Offline'),
                (4, 'Шиномонтаж и балансировка колес', 16000, '2025-02-01', 'Online'),
                (5, 'Компьютерная диагностика тормозной системы', 35000, '2025-02-15', 'Online'),
                (6, 'Обслуживание климат-контроля салона', 32000, '2025-02-18', 'Online'),
                (7, 'Замена пневмобаллонов подвески', 110000, '2025-02-20', 'Offline'),
                (8, 'Шиномонтаж и балансировка колес', 21000, '2025-02-22', 'Offline'),
                (9, 'Проверка электрооборудования', 14500, '2025-02-25', 'Online'),
                (10, 'Капитальная ревизия КПП', 145000, '2025-02-27', 'Offline');";
            using (var cmd = new SQLiteCommand(seedSql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        private DataTable ExecuteDataTable(string sql, params SQLiteParameter[] parameters)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }
        public List<CategoryEntity> GetCategories()
        {
            var dt = ExecuteDataTable("SELECT Id, CategoryName, TaxRate FROM Categories;");
            return dt.AsEnumerable()
                .Select(row => new CategoryEntity
                {
                    Id = Convert.ToInt32(row["Id"]),
                    CategoryName = Convert.ToString(row["CategoryName"]),
                    TaxRate = Convert.ToDouble(row["TaxRate"])
                })
                .ToList();
        }
        public List<MaintenanceLog> GetMaintenanceLogs()
        {
            var dt = ExecuteDataTable("SELECT Id, VehicleId, ServiceName, Cost, LogDate, Channel FROM MaintenanceLogs;");
            return dt.AsEnumerable()
                .Select(row => new MaintenanceLog
                {
                    Id = Convert.ToInt32(row["Id"]),
                    VehicleId = Convert.ToInt32(row["VehicleId"]),
                    ServiceName = Convert.ToString(row["ServiceName"]),
                    Cost = Convert.ToDouble(row["Cost"]),
                    LogDate = Convert.ToString(row["LogDate"]),
                    Channel = Convert.ToString(row["Channel"])
                })
                .ToList();
        }
        public List<Vehicle> GetAll()
        {
            string sql = @"
                SELECT v.Id, v.Model, v.BasePrice, v.Power, v.CategoryId, v.VehicleType, v.ExtraParam,
                       IFNULL(c.TaxRate, 0.05) AS TaxRate
                FROM Vehicles v
                LEFT JOIN Categories c ON v.CategoryId = c.Id;";
            var dt = ExecuteDataTable(sql);
            return dt.AsEnumerable()
                .Select<DataRow, Vehicle>(row =>
                {
                    int id = Convert.ToInt32(row["Id"]);
                    string model = Convert.ToString(row["Model"]);
                    double price = Convert.ToDouble(row["BasePrice"]);
                    int power = Convert.ToInt32(row["Power"]);
                    int catId = Convert.ToInt32(row["CategoryId"]);
                    string vType = Convert.ToString(row["VehicleType"]);
                    double extra = Convert.ToDouble(row["ExtraParam"]);
                    double rate = Convert.ToDouble(row["TaxRate"]);
                    return string.Equals(vType, "Cargo", StringComparison.OrdinalIgnoreCase)
                        ? new CargoVehicle(id, model, power, price, extra, catId, rate)
                        : new PassengerVehicle(id, model, power, price, (int)Math.Max(1, extra), catId, rate);
                })
                .ToList();
        }
        public Vehicle GetById(int id)
        {
            return GetAll().FirstOrDefault(v => v.Id == id);
        }
        public void Add(Vehicle item)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                string sql = @"
                    INSERT INTO Vehicles (Model, BasePrice, Power, CategoryId, VehicleType, ExtraParam)
                    VALUES (@model, @price, @power, @catId, @type, @extra);";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@model", item.Model);
                    cmd.Parameters.AddWithValue("@price", item.BasePrice);
                    cmd.Parameters.AddWithValue("@power", item.Power);
                    cmd.Parameters.AddWithValue("@catId", item.CategoryId);
                    if (item is CargoVehicle cargo)
                    {
                        cmd.Parameters.AddWithValue("@type", "Cargo");
                        cmd.Parameters.AddWithValue("@extra", cargo.MaxLoadTon);
                    }
                    else if (item is PassengerVehicle pass)
                    {
                        cmd.Parameters.AddWithValue("@type", "Passenger");
                        cmd.Parameters.AddWithValue("@extra", pass.PassengerSeats);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@type", "Cargo");
                        cmd.Parameters.AddWithValue("@extra", 10.0);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public bool Delete(int id)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("DELETE FROM Vehicles WHERE Id = @id;", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}