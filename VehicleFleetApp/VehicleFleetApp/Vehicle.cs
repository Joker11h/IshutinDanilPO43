using System;

namespace VehicleFleetApp
{
    public abstract class Vehicle
    {
        public string Model { get; private set; }
        public int Power { get; private set; }
        protected Vehicle(string model, int power)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Модель транспортного средства не может быть пустой.", nameof(model));

            if (power <= 0)
                throw new ArgumentOutOfRangeException(nameof(power), "Мощность двигателя должна быть положительным числом.");

            Model = model.Trim();
            Power = power;
        }
        public virtual string GetInfo()
        {
            return $"Модель: {Model} | Мощность: {Power} л.с.";
        }
        public abstract double CalculateTax();
        public override string ToString()
        {
            return GetInfo();
        }
    }
}