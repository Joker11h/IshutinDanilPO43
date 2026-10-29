using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CorpFleetAnalytics
{
    public partial class FormMain : Form
    {
        private readonly SqliteFleetRepository _repository;
        private readonly FleetManager _fleetManager;
        private List<Vehicle> _inMemoryVehicles;
        private int _currentPage = 1;
        private const int PageSize = 3;
        public FormMain()
        {
            InitializeComponent();

            _repository = new SqliteFleetRepository();
            _fleetManager = new FleetManager();
            _inMemoryVehicles = _repository.GetAll();
            _fleetManager.StatusChanged += (sender, e) =>
            {
                string logEntry = $"[{e.Timestamp:HH:mm:ss}] {e.Message} (Сумма операции: {e.OperationPrice:N2} руб.)";
                lstEventsTab4.Items.Insert(0, logEntry);
            };
            cmbTypeTab1.SelectedIndex = 0;
            RefreshAllTabs();
            _fleetManager.NotifyStatus("Система CorpFleet Analytics успешно инициализирована", _inMemoryVehicles.Sum(v => v.BasePrice));
        }
        private void RefreshAllTabs()
        {
            RefreshTab1List();
            RefreshTab2DtoGrid();
            RefreshTab3Analytics();
            RefreshTab4Pagination();
        }
        private void RefreshTab1List()
        {
            lstVehiclesTab1.DataSource = null;
            lstVehiclesTab1.DataSource = _inMemoryVehicles.ToList();
        }
        private void btnAddTab1_Click(object sender, EventArgs e)
        {
            try
            {
                string model = txtModelTab1.Text;
                int power = (int)numPowerTab1.Value;
                double price = (double)numPriceTab1.Value;
                double extra = (double)numExtraTab1.Value;
                int nextId = _inMemoryVehicles.Any() ? _inMemoryVehicles.Max(v => v.Id) + 1 : 1;
                Vehicle newVehicle = cmbTypeTab1.SelectedIndex == 0
                    ? new CargoVehicle(nextId, model, power, price, extra, 1, 0.08)
                    : new PassengerVehicle(nextId, model, power, price, (int)extra, 2, 0.05);
                _repository.Add(newVehicle);
                _inMemoryVehicles = _repository.GetAll();
                RefreshAllTabs();
                _fleetManager.NotifyStatus($"Добавлено новое ТС: {newVehicle.Model}", newVehicle.BasePrice);
                txtOopOutputTab1.Text = $"Успешно добавлено ТС в SQLite и ООП-коллекцию:{Environment.NewLine}{newVehicle}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка валидации ООП-модели", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDeleteTab1_Click(object sender, EventArgs e)
        {
            if (lstVehiclesTab1.SelectedItem is Vehicle selected)
            {
                _repository.Delete(selected.Id);
                _inMemoryVehicles = _repository.GetAll();
                RefreshAllTabs();
                _fleetManager.NotifyStatus($"Удалено ТС #{selected.Id} ({selected.Model})", selected.BasePrice);
            }
        }
        private void btnCloneTab1_Click(object sender, EventArgs e)
        {
            if (lstVehiclesTab1.SelectedItem is Vehicle selected)
            {
                var cloned = (Vehicle)selected.Clone();
                cloned.Passport.SerialNumber = $"CLONE-PTS-{DateTime.Now:mmss}";
                cloned.Passport.InspectionNotes.Add("Добавлена запись ТО только в клоне");
                _inMemoryVehicles.Add(cloned);
                RefreshTab1List();
                txtOopOutputTab1.Text =
                    $"=== ДЕМОНСТРАЦИЯ ГЛУБОКОГО КЛОНИРОВАНИЯ (Deep Copy в ICloneable) ==={Environment.NewLine}" +
                    $"Оригинал: {selected}{Environment.NewLine}" +
                    $"Клон:     {cloned}{Environment.NewLine}" +
                    $"Проверка ссылок TechPassport: ReferenceEquals = {ReferenceEquals(selected.Passport, cloned.Passport)} (Изменение паспорта клона НЕ затронуло оригинал!)";
                _fleetManager.NotifyStatus($"Выполнено глубокое клонирование ТС: {selected.Model}", cloned.BasePrice);
            }
        }
        private void btnSortTab1_Click(object sender, EventArgs e)
        {
            _inMemoryVehicles.Sort();
            RefreshTab1List();
            txtOopOutputTab1.Text = "Список отсортирован по возрастанию базовой стоимости (через реализацию интерфейса IComparable<Vehicle>).";
            _fleetManager.NotifyStatus("Выполнена сортировка реестра через IComparable", _inMemoryVehicles.FirstOrDefault()?.BasePrice ?? 0);
        }
        private void btnExportTab1_Click(object sender, EventArgs e)
        {
            if (lstVehiclesTab1.SelectedItem is Vehicle selected)
            {
                if (selected is IExportable exportableItem)
                {
                    string exportData = exportableItem.GetExportInfo();
                    txtOopOutputTab1.Text =
                        $"=== ВЫЗОВ ЯВНОЙ РЕАЛИЗАЦИИ ИНТЕРФЕЙСА IExportable (через паттерн 'is') ==={Environment.NewLine}" +
                        $"Класс объекта: {selected.GetType().Name}{Environment.NewLine}" +
                        $"Результат exportableItem.GetExportInfo():{Environment.NewLine}{exportData}";
                    _fleetManager.NotifyStatus($"Экспорт данных IExportable для {selected.Model}", selected.CalculateTax());
                }
            }
        }
        private void btnEqualsTab1_Click(object sender, EventArgs e)
        {
            if (lstVehiclesTab1.SelectedItem is Vehicle selected)
            {
                string saveStatus = selected.Save();
                var duplicateTest = new CargoVehicle(999, selected.Model, selected.Power, selected.BasePrice + 500000, 15);
                bool isEqual = selected.Equals(duplicateTest);
                txtOopOutputTab1.Text =
                    $"=== ПРОВЕРКА System.Object (Equals / GetHashCode) и IStorable ==={Environment.NewLine}" +
                    $"1. Выбранное ТС: {selected.Model} ({selected.Power} л.с.), Hash = {selected.GetHashCode()}{Environment.NewLine}" +
                    $"2. Тестовый объект с той же моделью и мощностью, но другой ценой: Hash = {duplicateTest.GetHashCode()}{Environment.NewLine}" +
                    $"3. Результат Equals(obj): {isEqual} (сравнение строго по Model и Power){Environment.NewLine}" +
                    $"4. Статус IStorable.Save(): {saveStatus}";
                _fleetManager.NotifyStatus($"Сохранение в файл (IStorable) и проверка Equals для {selected.Model}", selected.BasePrice);
            }
        }
        private List<FleetReportDto> BuildFleetReportDtos()
        {
            var vehicles = _repository.GetAll();
            var categories = _repository.GetCategories();
            var logs = _repository.GetMaintenanceLogs();
            return vehicles
                .Join(
                    categories,
                    v => v.CategoryId,
                    c => c.Id,
                    (v, c) => new { Vehicle = v, CategoryName = c.CategoryName }
                )
                .GroupJoin(
                    logs,
                    vc => vc.Vehicle.Id,
                    log => log.VehicleId,
                    (vc, vLogs) =>
                    {
                        double maintSum = vLogs.Sum(l => l.Cost);
                        double tax = vc.Vehicle.CalculateTax();
                        return new FleetReportDto
                        {
                            Id = vc.Vehicle.Id,
                            Model = vc.Vehicle.Model,
                            CategoryName = vc.CategoryName,
                            Power = vc.Vehicle.Power,
                            BasePrice = vc.Vehicle.BasePrice,
                            CalculatedTax = tax,
                            ServiceCount = vLogs.Count(),
                            TotalMaintenanceCost = maintSum,
                            TotalOwnershipCost = Math.Round(vc.Vehicle.BasePrice + tax + maintSum, 2)
                        };
                    }
                )
                .ToList();
        }
        private void RefreshTab2DtoGrid()
        {
            string search = txtSearchTab2.Text?.Trim() ?? string.Empty;
            double minPrice = (double)numMinPriceTab2.Value;
            double maxPrice = (double)numMaxPriceTab2.Value;
            var filteredDtos = BuildFleetReportDtos()
                .Where(dto => dto.BasePrice >= minPrice && dto.BasePrice <= maxPrice)
                .Where(dto => string.IsNullOrEmpty(search)
                              || dto.Model.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0
                              || dto.CategoryName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(dto => dto.CategoryName)
                .ThenByDescending(dto => dto.BasePrice)
                .ToList();
            dgvDtoTab2.DataSource = filteredDtos;
            bool anyExpensiveService = filteredDtos.Any(d => d.TotalMaintenanceCost > 50000);
            bool allHaveTax = filteredDtos.All(d => d.CalculatedTax > 0);
            var topCostVehicle = filteredDtos.FirstOrDefault();
            lblQuantifiersTab2.Text =
                $"Проверки LINQ: Any(ТО > 50 000 руб.) = {anyExpensiveService} | " +
                $"All(Налог > 0) = {allHaveTax} | " +
                $"FirstOrDefault() = {(topCostVehicle != null ? $"{topCostVehicle.Model} ({topCostVehicle.CategoryName})" : "Нет данных")}";
        }
        private void btnApplyLinqTab2_Click(object sender, EventArgs e)
        {
            RefreshTab2DtoGrid();
        }
        private void btnResetLinqTab2_Click(object sender, EventArgs e)
        {
            txtSearchTab2.Text = string.Empty;
            numMinPriceTab2.Value = 0;
            numMaxPriceTab2.Value = 25000000;
            RefreshTab2DtoGrid();
        }
        private void RefreshTab3Analytics()
        {
            var dtos = BuildFleetReportDtos();
            var groupedStats = dtos
                .GroupBy(d => d.CategoryName)
                .Select(g => new
                {
                    Категория = g.Key,
                    Количество_ТС = g.Count(),
                    Сумма_Стоимости = g.Sum(x => x.BasePrice),
                    Средняя_Цена = Math.Round(g.Average(x => x.BasePrice), 2),
                    Мин_Цена = g.Min(x => x.BasePrice),
                    Макс_Цена = g.Max(x => x.BasePrice),
                    Сумма_Налогов = Math.Round(g.Sum(x => x.CalculatedTax), 2),
                    Расходы_на_ТО = g.Sum(x => x.TotalMaintenanceCost)
                })
                .ToList();
            dgvGroupsTab3.DataSource = groupedStats;
            string summaryReport = groupedStats.Aggregate(
                "АНАЛИТИЧЕСКАЯ СВОДКА ПО КАТЕГОРИЯМ АВТОПАРКА (LINQ Aggregate):" + Environment.NewLine,
                (acc, item) => acc + $"• {item.Категория}: {item.Количество_ТС} ед. | Фонд стоимости: {item.Сумма_Стоимости:N0} руб. | Средняя цена: {item.Средняя_Цена:N0} руб. | Диапазон: [{item.Мин_Цена:N0} .. {item.Макс_Цена:N0}] руб." + Environment.NewLine,
                finalAcc => finalAcc + $"--- ОБЩИЙ ИТОГ ПО ПАРКУ: {dtos.Count} ТС на сумму {dtos.Sum(d => d.BasePrice):N0} руб. ---"
            );
            txtAggregateSummaryTab3.Text = summaryReport;
            RunSetOperation("Intersect");
        }
        private void RunSetOperation(string mode)
        {
            var allLogs = _repository.GetMaintenanceLogs();
            var onlineLogs = allLogs.Where(l => string.Equals(l.Channel, "Online", StringComparison.OrdinalIgnoreCase));
            var offlineLogs = allLogs.Where(l => string.Equals(l.Channel, "Offline", StringComparison.OrdinalIgnoreCase));
            IEnumerable<MaintenanceLog> result = mode == "Intersect"
                ? onlineLogs.Intersect(offlineLogs)
                : mode == "Except"
                    ? onlineLogs.Except(offlineLogs)
                    : onlineLogs.Union(offlineLogs);
            lstSetsTab3.DataSource = result
                .Select(l => $"[{mode.ToUpper()}] Услуга: {l.ServiceName} | Стоимость: {l.Cost:N0} руб. | Канал образца: {l.Channel}")
                .ToList();
            _fleetManager.NotifyStatus($"Выполнена операция над множествами ТО: {mode}", result.Sum(x => x.Cost));
        }
        private void btnIntersectTab3_Click(object sender, EventArgs e)
        {
            RunSetOperation("Intersect");
        }
        private void btnExceptTab3_Click(object sender, EventArgs e)
        {
            RunSetOperation("Except");
        }
        private void btnUnionTab3_Click(object sender, EventArgs e)
        {
            RunSetOperation("Union");
        }
        private void RefreshTab4Pagination()
        {
            var allDtos = BuildFleetReportDtos()
                .OrderBy(d => d.CategoryName)
                .ThenByDescending(d => d.BasePrice)
                .ToList();
            int totalPages = Math.Max(1, (int)Math.Ceiling(allDtos.Count / (double)PageSize));
            if (_currentPage > totalPages) _currentPage = totalPages;
            if (_currentPage < 1) _currentPage = 1;
            var pagedData = allDtos
                .Skip((_currentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();
            dgvPageTab4.DataSource = pagedData;
            lblPageInfoTab4.Text = $"Страница {_currentPage} из {totalPages} (Записей на странице: {pagedData.Count}, Всего: {allDtos.Count})";
        }
        private void ChangePage(int delta)
        {
            _currentPage += delta;
            RefreshTab4Pagination();
            _fleetManager.NotifyStatus($"Переход на страницу пагинации #{_currentPage}", _currentPage);
        }
        private void btnPrevPageTab4_Click(object sender, EventArgs e)
        {
            ChangePage(-1);
        }
        private void btnNextPageTab4_Click(object sender, EventArgs e)
        {
            ChangePage(1);
        }
        private void btnClosureTab4_Click(object sender, EventArgs e)
        {
            var closureLog = _fleetManager.EvaluateFleetWithClosure(_inMemoryVehicles, inflationIndex: 1.12, ecoBonusThreshold: 6000000);
            closureLog.ForEach(line => lstEventsTab4.Items.Insert(0, line));
        }
    }
}