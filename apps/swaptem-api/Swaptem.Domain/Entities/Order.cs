using Swaptem.Domain.Common;
using Swaptem.Domain.Enums;

namespace Swaptem.Domain.Entities;

public class Order : BaseEntity
{
    public required string OrderCode { get; set; } // Mã ??n hàng ng?n g?n (VD: #ORD-123)
    
    public Guid BuyerId { get; set; }
    public Guid SellerId { get; set; }
    public Guid ProductId { get; set; }
    
    public decimal FinalPrice { get; set; }
    public decimal PlatformFee { get; set; } // Phí sàn
    
    public OrderStatus Status { get; set; } = OrderStatus.Created;
    
    public DateTime? PaidAt { get; set; }
    public DateTime? DisputeDeadline { get; set; } // H?n chót khi?u n?i (PaidAt + 72h)

    // Relationships
    public User? Buyer { get; set; }
    public User? Seller { get; set; }
    public Product? Product { get; set; }
    public ICollection<Transaction> Transactions { get; set; } = [];
    public ICollection<Conversation> Conversations { get; set; } = [];
}
