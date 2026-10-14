namespace VehicleFleetApp
{
    public class Car : Vehicle
    {
        public bool IsElectric { get; private set; }
        public Car(string model, int power, bool isElectric)
            : base(model, power)
        {
            IsElectric = isElectric;
        }
        public override string GetInfo()
        {
            string engineType = IsElectric ? "Электродвигатель" : "ДВС";
            return $"[Легковой] {base.GetInfo()} | Тип: {engineType} | Налог: {CalculateTax():N2} тг.";
        }
        public override double CalculateTax()
        {
            double rate = IsElectric ? 5.0 : 12.0;
            return Power * rate;
        }
    }
}