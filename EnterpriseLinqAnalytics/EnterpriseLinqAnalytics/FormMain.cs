using System;
using System.Linq;
using System.Windows.Forms;

namespace EnterpriseLinqAnalytics
{
    public partial class FormMain : Form
    {
        private DatabaseInitializer _dbInitializer = null!;
        private ReportService _reportService = null!;
        private int _currentPage = 1;
        private int _totalPages = 1;
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            _dbInitializer = new DatabaseInitializer();
            _dbInitializer.InitializeDatabase();
            var categories = _dbInitializer.LoadCategories();
            var products = _dbInitializer.LoadProducts();
            var sales = _dbInitializer.LoadSales();
            _reportService = new ReportService(categories, products, sales);
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Все категории");
            cmbCategory.Items.AddRange(categories.Select(c => (object)c.Name).ToArray());
            cmbCategory.SelectedIndex = 0;
            cmbChannel.Items.Clear();
            cmbChannel.Items.AddRange(new object[] { "Все каналы", "Online", "Retail" });
            cmbChannel.SelectedIndex = 0;
            RefreshAllViews();
        }
        private void RefreshAllViews()
        {
            ApplyFilterTab1();
            dgvGrouping.DataSource = _reportService.GetCategoryAnalytics();
            txtAggregateAudit.Text = _reportService.GenerateGlobalFinancialAuditString();
            dgvSets.DataSource = _reportService.GetOnlineOnlyProductsExcept();
            lblSetStatus.Text = "Except: Товары, проданные ТОЛЬКО через Online (ни разу не проданные в Retail).";
            LoadPageTab4();
        }
        private void ApplyFilterTab1()
        {
            string? selectedCat = cmbCategory.SelectedItem?.ToString();
            string? selectedChan = cmbChannel.SelectedItem?.ToString();
            dgvSalesDto.DataSource = _reportService.GetFilteredAndSortedSales(selectedCat, selectedChan);
        }
        private void LoadPageTab4()
        {
            int pageSize = (int)numPageSize.Value;
            var pageData = _reportService.GetPage(_currentPage, pageSize, out _totalPages, out int totalRecords);
            dgvPaging.DataSource = pageData;
            lblPageInfo.Text = $"Страница {_currentPage} из {_totalPages} (Всего записей: {totalRecords})";
            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPages;
        }
        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilterTab1();
        }
        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = 0;
            cmbChannel.SelectedIndex = 0;
            ApplyFilterTab1();
        }
        private void btnShowGroupJoin_Click(object sender, EventArgs e)
        {
            dgvSalesDto.DataSource = _reportService.GetCategoriesWithProductsGroupJoin();
        }
        private void btnDeferredDemo_Click(object sender, EventArgs e)
        {
            lblDeferredInfo.Text = _reportService.RunDeferredVsImmediateDemo(_dbInitializer);
            RefreshAllViews();
        }
        private void btnExcept_Click(object sender, EventArgs e)
        {
            dgvSets.DataSource = _reportService.GetOnlineOnlyProductsExcept();
            lblSetStatus.Text = "Except: Товары, проданные ТОЛЬКО через Online (ни разу не проданные в Retail).";
        }
        private void btnIntersect_Click(object sender, EventArgs e)
        {
            dgvSets.DataSource = _reportService.GetCommonProductsIntersect();
            lblSetStatus.Text = "Intersect: Популярные товары, проданные И в Online, И в Retail.";
        }
        private void btnUnion_Click(object sender, EventArgs e)
        {
            dgvSets.DataSource = _reportService.GetAllSoldProductsUnion();
            lblSetStatus.Text = "Union: Полный список уникальных проданных позиций без дубликатов.";
        }
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadPageTab4();
            }
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadPageTab4();
            }
        }
        private void numPageSize_ValueChanged(object sender, EventArgs e)
        {
            if (_reportService == null) return;
            _currentPage = 1;
            LoadPageTab4();
        }
    }
}