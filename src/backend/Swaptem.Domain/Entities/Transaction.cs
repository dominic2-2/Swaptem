using Swaptem.Domain.Common;
using Swaptem.Domain.Enums;

namespace Swaptem.Domain.Entities;

public class Transaction : BaseEntity
{
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; } // Ng??i th?c hi?n giao d?ch
    
    // Self-Referencing: ?? bi?t giao d?ch tr? n? này thu?c v? giao d?ch Payout nào
    public Guid? RelatedTransactionId { get; set; } 
    
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    
    public string? PayoutInfo { get; set; } // STK Ngân hàng (L?u snapshot lúc rút)
    public string? AdminEvidence { get; set; } // ?nh bill chuy?n kho?n c?a Admin
    
    public TransactionStatus Status { get; set; } = TransactionStatus.Pending;

    // Relationships
    public Order? Order { get; set; }
    public User? User { get; set; }
    public Transaction? RelatedTransaction { get; set; } // Parent Transaction
    public ICollection<Transaction> ChildTransactions { get; set; } = [];
    
    // Cái này ?? bi?t transaction này ?ã gi?i c?u Block nào (Optional)
    public BlockedPayout? ResolvedBlock { get; set; } 
}
