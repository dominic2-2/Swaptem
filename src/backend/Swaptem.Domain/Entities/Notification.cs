using Swaptem.Domain.Common;

namespace Swaptem.Domain.Entities;

public class Notification : BaseEntity
{
    public Guid UserId { get; set; } // FK t?i User
    public required string Content { get; set; }
    public string? Link { get; set; } // Link b?m vào nh?y t?i ??n hàng/tranh ch?p
    public bool IsRead { get; set; } = false;

    // Relationship
    public User? User { get; set; }
}
