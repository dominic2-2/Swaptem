using Swaptem.Domain.Common;
using Swaptem.Domain.Enums;

namespace Swaptem.Domain.Entities;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    
    public decimal DebtAmount { get; set; } = 0;
    public int DisputeLostCount { get; set; } = 0; // ??m s? l?n thua (Logic 3-Strikes)
    
    public UserRole Role { get; set; } = UserRole.Member;
    public UserStatus Status { get; set; } = UserStatus.Active;

    // Relationships
    public ICollection<Product> Products { get; set; } = [];
    public ICollection<Order> OrdersBought { get; set; } = []; // Buyer
    public ICollection<Order> OrdersSold { get; set; } = [];   // Seller
    public ICollection<Transaction> Transactions { get; set; } = [];
    public ICollection<Notification> Notifications { get; set; } = [];
    public ICollection<BlockedPayout> CausedBlocks { get; set; } = [];
}
