using Swaptem.Domain.Common;

namespace Swaptem.Domain.Entities;

public class Message : BaseEntity
{
    public Guid ConversationId { get; set; }
    public Guid SenderId { get; set; } // Ng??i g?i
    
    public required string Content { get; set; }
    public bool IsSystemMessage { get; set; } = false; // Tin nh?n h? th?ng (VD: "?ã chuy?n sang tr?ng thái Tranh ch?p")

    // Relationships
    public Conversation? Conversation { get; set; }
    public User? Sender { get; set; }
}
