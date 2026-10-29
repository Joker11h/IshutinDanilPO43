using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CorpFleetAnalytics
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T item);
        bool Delete(int id);
    }
    public interface IStorable
    {
        string FilePath { get; set; }
        string Save();
    }
    public interface IExportable
    {
        string GetExportInfo();
    }
    public class TechPassport : ICloneable
    {
        public string SerialNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public List<string> InspectionNotes { get; set; }
        public TechPassport(string serialNumber, DateTime issueDate, IEnumerable<string> notes)
        {
            SerialNumber = serialNumber;
            IssueDate = issueDate;
            InspectionNotes = notes?.ToList() ?? new List<string>();
        }
        public object Clone()
        {
            return new TechPassport(
                new string(SerialNumber.ToCharArray()),
                IssueDate,
                InspectionNotes.Select(n => new string(n.ToCharArray())).ToList()
            );
        }
    }
    public abstract class Vehicle : IStorable, IExportable, IComparable<Vehicle>, IComparable, ICloneable
    {
        public int Id { get; private set; }
        public string Model { get; private set; }
        public int Power { get; private set; }
        public double BasePrice { get; private set; }
        public int CategoryId { get; private set; }
        public double TaxRate { get; private set; }
        public TechPassport Passport { get; protected set; }
        public string FilePath { get; set; } = "fleet_storage.txt";
        protected Vehicle(int id, string model, int power, double price, int categoryId = 1, double taxRate = 0.05)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Модель ТС не может быть пустой.", nameof(model));
            if (power <= 0)
                throw new ArgumentOutOfRangeException(nameof(power), "Мощность должна быть больше нуля.");
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Базовая стоимость не может быть отрицательной.");
            Id = id;
            Model = model.Trim();
            Power = power;
            BasePrice = price;
            CategoryId = categoryId;
            TaxRate = taxRate;
            Passport = new TechPassport($"PTS-{id:D4}-{power}", DateTime.Today, new[] { "Первичный учет пройден" });
        }
        public virtual double CalculateTax()
        {
            return Math.Round(BasePrice * TaxRate + (Power * 12.5), 2);
        }
        public virtual string Save()
        {
            string record = $"{DateTime.Now:s} | SAVED: {ToString()} | PTS: {Passport.SerialNumber}{Environment.NewLine}";
            File.AppendAllText(FilePath, record);
            return $"Запись сохранена в {FilePath}";
        }
        public virtual string GetExportInfo()
        {
            return $"[EXPORT-BASE] ID={Id}; Model={Model}; Price={BasePrice:N2}; Tax={CalculateTax():N2}";
        }
        public int CompareTo(Vehicle other)
        {
            if (other is null) return 1;
            return BasePrice.CompareTo(other.BasePrice);
        }
        public int CompareTo(object obj)
        {
            if (obj is null) return 1;
            if (obj is Vehicle otherVehicle) return CompareTo(otherVehicle);
            throw new ArgumentException("Объект не является транспортным средством.");
        }
        public abstract object Clone();
        public override string ToString()
        {
            return $"[{GetType().Name}] #{Id}: {Model} ({Power} л.с.) | Цена: {BasePrice:N0} руб. | Налог: {CalculateTax():N0} руб. | ПТС: {Passport.SerialNumber} (Заметок: {Passport.InspectionNotes.Count})";
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is Vehicle other)
            {
                return string.Equals(Model, other.Model, StringComparison.OrdinalIgnoreCase)
                       && Power == other.Power;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int h1 = Model?.ToUpperInvariant().GetHashCode() ?? 0;
            int h2 = Power.GetHashCode();
            return (h1 * 397) ^ h2;
        }
    }
    public class CargoVehicle : Vehicle, IExportable
    {
        public double MaxLoadTon { get; private set; }
        public CargoVehicle(int id, string model, int power, double price, double maxLoadTon, int categoryId = 1, double taxRate = 0.08)
            : base(id, model, power, price, categoryId, taxRate)
        {
            if (maxLoadTon <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxLoadTon), "Грузоподъемность должна быть положительной.");
            MaxLoadTon = maxLoadTon;
        }
        public override double CalculateTax()
        {
            return Math.Round(base.CalculateTax() + (MaxLoadTon * 850.0), 2);
        }
        string IExportable.GetExportInfo()
        {
            return $"[EXPLICIT CARGO EXPORT] Модель: {Model} | Мощность: {Power} л.с. | Тоннаж: {MaxLoadTon} т | Налог: {CalculateTax():N2} руб. | ПТС: {Passport.SerialNumber}";
        }
        public override object Clone()
        {
            var copy = new CargoVehicle(Id + 1000, $"{Model} (Клон)", Power, BasePrice, MaxLoadTon, CategoryId, TaxRate)
            {
                FilePath = new string(FilePath.ToCharArray()),
                Passport = (TechPassport)Passport.Clone()
            };
            return copy;
        }
        public override string ToString()
        {
            return $"{base.ToString()} | Грузоподъемность: {MaxLoadTon} т";
        }
    }

    public class PassengerVehicle : Vehicle
    {
        public int PassengerSeats { get; private set; }
        public PassengerVehicle(int id, string model, int power, double price, int seats, int categoryId = 2, double taxRate = 0.04)
            : base(id, model, power, price, categoryId, taxRate)
        {
            if (seats <= 0)
                throw new ArgumentOutOfRangeException(nameof(seats), "Число мест должно быть больше нуля.");
            PassengerSeats = seats;
        }
        public override double CalculateTax()
        {
            return Math.Round(base.CalculateTax() + (PassengerSeats * 150.0), 2);
        }
        public override string GetExportInfo()
        {
            return $"[PASSENGER EXPORT] Модель: {Model} | Мест: {PassengerSeats} | Цена: {BasePrice:N2} руб. | Налог: {CalculateTax():N2} руб.";
        }
        public override object Clone()
        {
            var copy = new PassengerVehicle(Id + 1000, $"{Model} (Клон)", Power, BasePrice, PassengerSeats, CategoryId, TaxRate)
            {
                FilePath = new string(FilePath.ToCharArray()),
                Passport = (TechPassport)Passport.Clone()
            };
            return copy;
        }
        public override string ToString()
        {
            return $"{base.ToString()} | Пассажиромест: {PassengerSeats}";
        }
    }
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public double TaxRate { get; set; }
    }
    public class MaintenanceLog : IEquatable<MaintenanceLog>
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string ServiceName { get; set; }
        public double Cost { get; set; }
        public string LogDate { get; set; }
        public string Channel { get; set; }
        public bool Equals(MaintenanceLog other)
        {
            if (other is null) return false;
            return string.Equals(ServiceName, other.ServiceName, StringComparison.OrdinalIgnoreCase);
        }
        public override bool Equals(object obj) => Equals(obj as MaintenanceLog);
        public override int GetHashCode() => ServiceName?.ToUpperInvariant().GetHashCode() ?? 0;
        public override string ToString() => $"{ServiceName} (Канал: {Channel}, Стоимость: {Cost:N0} руб., Дата: {LogDate})";
    }
    public class FleetReportDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string CategoryName { get; set; }
        public int Power { get; set; }
        public double BasePrice { get; set; }
        public double CalculatedTax { get; set; }
        public int ServiceCount { get; set; }
        public double TotalMaintenanceCost { get; set; }
        public double TotalOwnershipCost { get; set; }
    }
    public class VehicleEventArgs : EventArgs
    {
        public string Message { get; }
        public double OperationPrice { get; }
        public DateTime Timestamp { get; }
        public VehicleEventArgs(string message, double operationPrice)
        {
            Message = message;
            OperationPrice = operationPrice;
            Timestamp = DateTime.Now;
        }
    }
    public class FleetManager
    {
        public event Action<object, VehicleEventArgs> StatusChanged;
        public void NotifyStatus(string message, double price)
        {
            StatusChanged?.Invoke(this, new VehicleEventArgs(message, price));
        }
        public List<string> EvaluateFleetWithClosure(
            IEnumerable<Vehicle> vehicles,
            double inflationIndex,
            double ecoBonusThreshold)
        {
            int processedCount = 0;
            Predicate<Vehicle> highValueFilter = v =>
                (v.BasePrice * inflationIndex) >= ecoBonusThreshold;
            Func<Vehicle, double> adjustedCostCalculator = v =>
            {
                processedCount++;
                return Math.Round(v.BasePrice * inflationIndex + v.CalculateTax(), 2);
            };
            var results = vehicles
                .Where(v => highValueFilter(v))
                .Select(v => $"[Замыкание #{processedCount + 1}] {v.Model}: Скорректированная стоимость = {adjustedCostCalculator(v):N2} руб. (Коэфф.: {inflationIndex})")
                .ToList();
            NotifyStatus($"Выполнен расчет через замыкание (обработано ТС: {processedCount})", ecoBonusThreshold);
            return results;
        }
    }
}