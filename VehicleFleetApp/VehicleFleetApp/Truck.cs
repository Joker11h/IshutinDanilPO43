using System;
using System.IO;
using System.Text;

namespace VehicleFleetApp
{
    public class Truck : Vehicle, IStorable
    {
        public double LoadCapacity { get; private set; }
        public string FilePath { get; private set; }
        public Truck(string model, int power, double loadCapacity, string defaultFilePath = "trucks_fleet.txt")
            : base(model, power)
        {
            if (loadCapacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(loadCapacity), "Грузоподъемность должна быть больше нуля.");

            LoadCapacity = loadCapacity;
            FilePath = defaultFilePath;
        }
        public override string GetInfo()
        {
            return $"[Грузовой] {base.GetInfo()} | Грузоподъемность: {LoadCapacity:N1} т | Налог: {CalculateTax():N2} тг.";
        }
        public override double CalculateTax()
        {
            return Power * 25.0;
        }
        public void Save(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                FilePath = path;
            }

            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {GetInfo()}{Environment.NewLine}";
            File.AppendAllText(FilePath, logEntry, Encoding.UTF8);
        }
    }
}