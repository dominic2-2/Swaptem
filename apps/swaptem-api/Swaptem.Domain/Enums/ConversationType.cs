namespace Swaptem.Domain.Enums;

public enum ConversationType
{
    Negotiation,    // Th??ng l??ng giá
    OrderChat,      // Chat sau khi ?ã thanh toán (trao ??i hàng)
    SelfResolve,    // T? th?a thu?n khi có Dispute
    Dispute         // Khi Admin vào cu?c
}
