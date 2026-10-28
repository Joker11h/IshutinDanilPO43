using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterpriseLinqAnalytics
{
    public class ReportService
    {
        private readonly List<Category> _categories;
        private readonly List<Product> _products;
        private readonly List<Sale> _sales;
        public ReportService(List<Category> categories, List<Product> products, List<Sale> sales)
        {
            _categories = categories;
            _products = products;
            _sales = sales;
        }
        public void AddSaleInMemory(Sale newSale) => _sales.Add(newSale);
        public Product? FindProductByName(string namePart)
        {
            return _products.FirstOrDefault(p =>
                p.Name.Contains(namePart, StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<SaleReportDto> GetSalesReportDeferredQuery()
        {
            return _sales
                .Join(_products,
                    sale => sale.ProductId,
                    product => product.Id,
                    (sale, product) => new { sale, product })
                .Join(_categories,
                    sp => sp.product.CategoryId,
                    category => category.Id,
                    (sp, category) =>
                    {
                        double discountedPrice = Math.Round(sp.product.Price * (1.0 - category.DiscountRate), 2);
                        return new SaleReportDto
                        {
                            SaleId = sp.sale.Id,
                            CustomerName = sp.sale.CustomerName,
                            ProductName = sp.product.Name,
                            CategoryName = category.Name,
                            Channel = sp.sale.Channel,
                            SaleDate = sp.sale.SaleDate,
                            Quantity = sp.sale.Quantity,
                            DiscountedPrice = discountedPrice,
                            TotalAmount = Math.Round(discountedPrice * sp.sale.Quantity, 2)
                        };
                    });
        }
        public List<CategoryGroupDto> GetCategoriesWithProductsGroupJoin()
        {
            return _categories
                .GroupJoin(
                    _products,
                    category => category.Id,
                    product => product.CategoryId,
                    (category, productsGroup) => new CategoryGroupDto
                    {
                        CategoryName = category.Name,
                        DiscountPercent = Math.Round(category.DiscountRate * 100, 1),
                        ProductsCount = productsGroup.Count(),
                        ProductList = productsGroup.Any()
                            ? string.Join(", ", productsGroup.Select(p => p.Name))
                            : "Нет товаров"
                    })
                .ToList();
        }
        public List<SaleReportDto> GetFilteredAndSortedSales(string? categoryName, string? channel)
        {
            IEnumerable<SaleReportDto> query = GetSalesReportDeferredQuery();

            if (!string.IsNullOrWhiteSpace(categoryName) && categoryName != "Все категории")
            {
                query = query.Where(s => s.CategoryName == categoryName);
            }
            if (!string.IsNullOrWhiteSpace(channel) && channel != "Все каналы")
            {
                query = query.Where(s => s.Channel == channel);
            }
            return query
                .OrderBy(s => s.CategoryName)
                .ThenByDescending(s => s.TotalAmount)
                .ToList();
        }
        public List<SaleReportDto> GetPage(int pageNumber, int pageSize, out int totalPages, out int totalRecords)
        {
            var orderedQuery = GetSalesReportDeferredQuery()
                .OrderBy(s => s.CategoryName)
                .ThenByDescending(s => s.TotalAmount);
            totalRecords = orderedQuery.Count();
            totalPages = Math.Max(1, (int)Math.Ceiling((double)totalRecords / pageSize));
            int validPage = Math.Clamp(pageNumber, 1, totalPages);
            return orderedQuery
                .Skip((validPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public List<CategorySummaryDto> GetCategoryAnalytics()
        {
            return GetSalesReportDeferredQuery()
                .GroupBy(s => s.CategoryName)
                .Select(g => new CategorySummaryDto
                {
                    CategoryName = g.Key,
                    DealsCount = g.Count(),
                    TotalRevenue = Math.Round(g.Sum(x => x.TotalAmount), 2),
                    AverageCheck = Math.Round(g.Average(x => x.TotalAmount), 2),
                    MinPurchase = Math.Round(g.Min(x => x.TotalAmount), 2),
                    MaxPurchase = Math.Round(g.Max(x => x.TotalAmount), 2)
                })
                .OrderByDescending(c => c.TotalRevenue)
                .ToList();
        }
        public string GenerateGlobalFinancialAuditString()
        {
            var summaries = GetCategoryAnalytics();
            if (!summaries.Any())
                return "Нет данных для формирования финансового аудита.";
            string reportBody = summaries.Aggregate(
                "=== ГЛОБАЛЬНЫЙ ФИНАНСОВЫЙ АУДИТ КОМПАНИИ ===\r\n",
                (acc, item) => acc +
                    $"• Категория [{item.CategoryName}]: Сделок = {item.DealsCount} | " +
                    $"Выручка = {item.TotalRevenue:N2} ₽ | Ср. чек = {item.AverageCheck:N2} ₽ " +
                    $"(Min: {item.MinPurchase:N2} ₽, Max: {item.MaxPurchase:N2} ₽)\r\n",
                finalAcc =>
                {
                    double grandTotal = summaries.Sum(x => x.TotalRevenue);
                    int totalDeals = summaries.Sum(x => x.DealsCount);
                    var topCategory = summaries.FirstOrDefault();
                    string leaderInfo = topCategory is not null
                        ? $"{topCategory.CategoryName} ({topCategory.TotalRevenue:N2} ₽)"
                        : "Н/Д";
                    return finalAcc +
                           $"------------------------------------------------------------\r\n" +
                           $"ИТОГО ПО КОМПАНИИ: {totalDeals} сделок на сумму {grandTotal:N2} ₽ | " +
                           $"Лидер продаж: {leaderInfo}";
                });
            return reportBody;
        }
        private IEnumerable<Product> GetProductsSoldInChannel(string channel)
        {
            return _sales
                .Where(s => s.Channel == channel)
                .Join(_products, s => s.ProductId, p => p.Id, (s, p) => p);
        }
        public List<Product> GetOnlineOnlyProductsExcept()
        {
            var onlineProducts = GetProductsSoldInChannel("Online");
            var retailProducts = GetProductsSoldInChannel("Retail");
            return onlineProducts
                .Except(retailProducts)
                .OrderBy(p => p.Id)
                .ToList();
        }
        public List<Product> GetCommonProductsIntersect()
        {
            var onlineProducts = GetProductsSoldInChannel("Online");
            var retailProducts = GetProductsSoldInChannel("Retail");
            return onlineProducts
                .Intersect(retailProducts)
                .OrderBy(p => p.Id)
                .ToList();
        }
        public List<Product> GetAllSoldProductsUnion()
        {
            var onlineProducts = GetProductsSoldInChannel("Online");
            var retailProducts = GetProductsSoldInChannel("Retail");
            return onlineProducts
                .Union(retailProducts)
                .OrderBy(p => p.Id)
                .ToList();
        }
        public string RunDeferredVsImmediateDemo(DatabaseInitializer db)
        {
            IEnumerable<SaleReportDto> deferredQuery = GetSalesReportDeferredQuery();
            List<SaleReportDto> immediateSnapshot = deferredQuery.ToList();
            int countBefore = immediateSnapshot.Count;
            Product? sampleProduct = _products.FirstOrDefault(p => p.Id == 1);
            if (sampleProduct is null)
                return "Ошибка демонстрации: тестовый товар не найден.";
            Sale newSale = db.InsertSale(
                sampleProduct.Id,
                "Тестов Т.Т. (Deferred Demo)",
                1,
                DateTime.Now.ToString("yyyy-MM-dd"),
                "Online");
            AddSaleInMemory(newSale);
            int deferredCountAfter = 0;
            foreach (var _ in deferredQuery)
            {
                deferredCountAfter++;
            }
            int immediateCountAfter = immediateSnapshot.Count;
            return $"До добавления продажи: {countBefore} зап.\r\n" +
                   $"После добавления новой продажи ('{newSale.CustomerName}'):\r\n" +
                   $"• Немедленная выборка (ToList snapshot): {immediateCountAfter} зап. (данные зафиксированы в памяти).\r\n" +
                   $"• Отложенный запрос (IEnumerable при итерации foreach): {deferredCountAfter} зап. (динамически подтянул новую запись!).";
        }
    }
}