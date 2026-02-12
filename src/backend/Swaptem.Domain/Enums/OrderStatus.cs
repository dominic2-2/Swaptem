namespace Swaptem.Domain.Enums;

public enum OrderStatus
{
    Created,
    Paid,               // Ti?n vào sàn
    Disputed,           // ?ang khi?u n?i (chung cho SelfResolve và AdminReview)
    Completed,          // Buyer xác nh?n ho?c h?t gi?
    Refunded,           // Hoàn ti?n cho Buyer
    Cancelled           // H?y tr??c khi thanh toán
}
