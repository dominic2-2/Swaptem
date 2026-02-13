using Swaptem.Domain.Common;

namespace Swaptem.Domain.Entities;

public class BlockedPayout : BaseEntity
{
    public required string BankAccount { get; set; }
    public required string BankName { get; set; }
    
    public Guid OriginalUserId { get; set; } // K? gây ra n?
    public decimal DebtAmount { get; set; }  // S? ti?n n? lúc b? Block
    
    public bool IsResolved { get; set; } = false;
    
    // Transaction nào ?ã tr? n? ?? g? cái Block này?
    public Guid? ResolvedTransactionId { get; set; } 

    // Relationships
    public User? OriginalUser { get; set; }
    public Transaction? ResolvedTransaction { get; set; }
}
