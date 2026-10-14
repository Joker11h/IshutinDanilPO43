using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace VehicleFleetApp
{
    public partial class FormMain : Form
    {
        private readonly List<Vehicle> fleet = new List<Vehicle>();

        public FormMain()
        {
            InitializeComponent();
            cmbVehicleType.Items.Clear();
            cmbVehicleType.Items.AddRange(new object[] { "Легковой", "Грузовой" });
            cmbVehicleType.SelectedIndex = 0;
        }
        private void cmbVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCar = cmbVehicleType.SelectedIndex == 0;
            chkIsElectric.Enabled = isCar;
            numCapacity.Enabled = !isCar;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string model = txtModel.Text.Trim();
                int power = (int)numPower.Value;
                string selectedType = cmbVehicleType.SelectedItem?.ToString() ?? "Легковой";
                Vehicle newVehicle;
                if (selectedType == "Легковой")
                {
                    bool isElectric = chkIsElectric.Checked;
                    newVehicle = new Car(model, power, isElectric);
                }
                else
                {
                    double capacity = (double)numCapacity.Value;
                    newVehicle = new Truck(model, power, capacity);
                }
                fleet.Add(newVehicle);
                lstFleet.Items.Add(newVehicle.GetInfo());
                txtModel.Clear();
                txtModel.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCalculateTax_Click(object sender, EventArgs e)
        {
            if (fleet.Count == 0)
            {
                MessageBox.Show("Автопарк пуст. Добавьте хотя бы одно транспортное средство.",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            double totalTax = 0;
            foreach (Vehicle v in fleet)
            {
                totalTax += v.CalculateTax();
            }

            lblTotalTax.Text = $"Суммарный налог: {totalTax:N2} тг.";
        }
        private void btnSaveStorable_Click(object sender, EventArgs e)
        {
            int savedCount = 0;
            string targetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "trucks_fleet.txt");
            foreach (Vehicle v in fleet)
            {
                if (v is IStorable storable)
                {
                    storable.Save(targetPath);
                    savedCount++;
                }
            }
            if (savedCount > 0)
            {
                MessageBox.Show($"Сохранено грузовых ТС ({savedCount} шт.) в файл:\n{targetPath}",
                    "Сохранение успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("В автопарке нет объектов, поддерживающих интерфейс IStorable (грузовиков).",
                    "Нет данных для сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}