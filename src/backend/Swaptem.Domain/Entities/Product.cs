using Swaptem.Domain.Common;
using Swaptem.Domain.Enums;

namespace Swaptem.Domain.Entities;

public class Product : BaseEntity
{
    public Guid SellerId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }
    public required string PublicEvidenceUrl { get; set; } // Link ?nh/video b?ng ch?ng
    
    public ProductType ProductType { get; set; }
    public string? SecretData { get; set; } // N?i dung bán (File path ho?c Account info)
    
    public ProductStatus Status { get; set; } = ProductStatus.Available;

    // Relationships
    public User? Seller { get; set; }
    public ICollection<Order> Orders { get; set; } = [];
}
