using System;
namespace StoreLinqApp
{
    public record OrderItem(int Id, string CustomerName, string ProductName, string Category, decimal Price, int Quantity)
    {
        public decimal Total => Price * Quantity;
        public virtual bool Equals(OrderItem? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(ProductName, other.ProductName, StringComparison.OrdinalIgnoreCase);
        }
        public override int GetHashCode()
        {
            return ProductName != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(ProductName) : 0;
        }
    }
}