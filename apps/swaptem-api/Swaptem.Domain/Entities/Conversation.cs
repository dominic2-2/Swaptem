using Swaptem.Domain.Common;
using Swaptem.Domain.Enums;

namespace Swaptem.Domain.Entities;

public class Conversation : BaseEntity
{
    public Guid OrderId { get; set; }
    public Guid CreatorId { get; set; } // Ng??i b?t ??u cu?c h?i tho?i
    
    public ConversationType Type { get; set; }

    // Relationships
    public Order? Order { get; set; }
    public User? Creator { get; set; }
    public ICollection<Message> Messages { get; set; } = [];
}
