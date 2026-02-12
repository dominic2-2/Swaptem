namespace Swaptem.Domain.Enums;

public enum TransactionType
{
    Deposit,        // N?p ti?n (n?u có ví) ho?c Buyer thanh toán
    Payout,         // Rút ti?n v? bank (Seller nh?n ti?n)
    Refund,         // Hoàn ti?n l?i cho Buyer
    DebtDeduction   // Tr? n? (C?n tr? vào Payout)
}
