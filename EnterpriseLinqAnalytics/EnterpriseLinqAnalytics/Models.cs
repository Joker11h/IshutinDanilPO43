using System;

namespace EnterpriseLinqAnalytics
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double DiscountRate { get; private set; }
        public Category(int id, string name, double discountRate)
        {
            Id = id;
            Name = name;
            DiscountRate = discountRate;
        }
    }
    public class Product : IEquatable<Product>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int CategoryId { get; private set; }
        public double Price { get; private set; }
        public int Stock { get; private set; }
        public Product(int id, string name, int categoryId, double price, int stock)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Price = price;
            Stock = stock;
        }
        public bool Equals(Product? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }
        public override bool Equals(object? obj) => Equals(obj as Product);
        public override int GetHashCode() => Id.GetHashCode();
    }
    public class Sale
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public string CustomerName { get; private set; }
        public int Quantity { get; private set; }
        public string SaleDate { get; private set; }
        public string Channel { get; private set; }
        public Sale(int id, int productId, string customerName, int quantity, string saleDate, string channel)
        {
            Id = id;
            ProductId = productId;
            CustomerName = customerName;
            Quantity = quantity;
            SaleDate = saleDate;
            Channel = channel;
        }
    }
    public class SaleReportDto
    {
        public int SaleId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string Channel { get; set; } = string.Empty;
        public string SaleDate { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double DiscountedPrice { get; set; }
        public double TotalAmount { get; set; }
    }
    public class CategoryGroupDto
    {
        public string CategoryName { get; set; } = string.Empty;
        public double DiscountPercent { get; set; }
        public int ProductsCount { get; set; }
        public string ProductList { get; set; } = string.Empty;
    }
    public class CategorySummaryDto
    {
        public string CategoryName { get; set; } = string.Empty;
        public int DealsCount { get; set; }
        public double TotalRevenue { get; set; }
        public double AverageCheck { get; set; }
        public double MinPurchase { get; set; }
        public double MaxPurchase { get; set; }
    }
}