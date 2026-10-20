using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace StoreLinqApp
{
    public partial class FormMain : Form
    {
        private List<OrderItem> onlineOrders = new();
        private List<OrderItem> storeOrders = new();
        public FormMain()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            DatabaseService.InitializeDatabase();
            onlineOrders = DatabaseService.GetOrders("OnlineOrders");
            storeOrders = DatabaseService.GetOrders("StoreOrders");
            dgvResults.DataSource = onlineOrders;
        }
        private void BtnCalcAggregates_Click(object? sender, EventArgs e)
        {
            if (!onlineOrders.Any()) return;
            int totalOrders = onlineOrders.Count();
            int largeOrders = onlineOrders.Count(x => (x.Price * x.Quantity) > 1000m);
            lblCount.Text = $"Count():Всего:{totalOrders}|Чек свыше 1000:{largeOrders}";
            decimal totalRevenue = onlineOrders.Sum(x => x.Price * x.Quantity);
            lblSum.Text = $"Sum():Выручка:{totalRevenue:N2}";
            decimal avgUnitPrice = onlineOrders.Average(x => x.Price);
            decimal avgOrderValue = onlineOrders.Average(x => x.Price * x.Quantity);
            lblAvg.Text = $"Average():Средняя цена:{avgUnitPrice:N2}|Средний чек:{avgOrderValue:N2}";
            decimal minPrice = onlineOrders.Min(x => x.Price);
            decimal maxPrice = onlineOrders.Max(x => x.Price);
            lblMinMax.Text = $"Min()/Max():Мин:{minPrice:N2}|Макс:{maxPrice:N2}";
            string categoriesSummary = onlineOrders.Select(x => x.Category).Distinct().Aggregate("Категории:", (acc, next) => acc + next + "|");
            lblAggregate.Text = $"Aggregate():{categoriesSummary.TrimEnd('|')}";
            dgvResults.DataSource = onlineOrders.ToList();
        }
        private void BtnExceptOnlineOnly_Click(object? sender, EventArgs e)
        {
            var onlineOnlyObjects = onlineOrders.Except(storeOrders).ToList();
            dgvResults.DataSource = onlineOnlyObjects;
        }
        private void BtnIntersectBoth_Click(object? sender, EventArgs e)
        {
            var commonObjects = onlineOrders.Intersect(storeOrders).ToList();
            dgvResults.DataSource = commonObjects;
        }
        private void BtnUnionAllUnique_Click(object? sender, EventArgs e)
        {
            var allUniqueObjects = onlineOrders.Union(storeOrders).ToList();
            dgvResults.DataSource = allUniqueObjects;
        }
        private void BtnConcatDistinct_Click(object? sender, EventArgs e)
        {
            var concatDistinctNames = onlineOrders.Select(x => x.ProductName).Concat(storeOrders.Select(x => x.ProductName)).Distinct().ToList();
            var unionNames = onlineOrders.Select(x => x.ProductName).Union(storeOrders.Select(x => x.ProductName)).ToList();
            bool areEqual = concatDistinctNames.SequenceEqual(unionNames);
            var concatDistinctObjects = onlineOrders.Concat(storeOrders).Distinct().ToList();
            dgvResults.DataSource = concatDistinctObjects;
            MessageBox.Show($"Concat().Distinct():{concatDistinctNames.Count}\nUnion():{unionNames.Count}\nSequenceEqual:{areEqual}", "Сравнение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}