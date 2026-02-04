```mermaid
erDiagram
    %% --- ENTITIES ---
    USER {
        int UserId PK
        string Username
        string Email
        string PasswordHash
        decimal DebtAmount
        string Status "ACTIVE, BANNED, DEACTIVATED"
        datetime CreatedAt
    }

    PRODUCT {
        int ProductId PK
        int SellerId FK
        string Title
        string Description
        decimal BasePrice
        string PublicEvidenceUrl
        string SecretData "FILE, LINK, SECRET"
        string Status "AVAILABLE, SOLD, HIDDEN"
        datetime CreatedAt
    }

    ORDER {
        int OrderId PK
        string OrderCode
        int BuyerId FK
        int SellerId FK
        int ProductId FK
        decimal FinalPrice
        decimal PlatformFee
        string Status "CREATED, PAID, DISPUTED, COMPLETED, REFUNDED, CANCELLED"
        datetime PaidAt
        datetime DisputeDeadline
        datetime CreatedAt
    }

    TRANSACTION {
        int TransactionId PK
        int OrderId FK
        int UserId FK
        string Type "DEPOSIT, PAYOUT, REFUND"
        decimal Amount
        string PayoutInfo
        string AdminEvidence
        string Status "CREATED, PENDING, SUCCESS, FAILED"
        datetime CreatedAt
    }

    CONVERSATION {
        int ConversationId PK
        int OrderId FK
        string Type "NEGOTIATION, ORDERCHAT, SELFRESOLVE, DISPUTE"
        datetime CreatedAt
    }

    MESSAGE {
        int MessageId PK
        int ConversationId FK
        int SenderId FK
        string Content
        boolean IsSystemMessage
        datetime SentAt
    }

    NOTIFICATION {
        int NotificationId PK
        int UserId FK
        string Content
        string Link
        boolean IsRead
        datetime CreatedAt
    }

    %% --- RELATIONSHIPS ---
    USER ||--o{ PRODUCT : owns
    USER ||--o{ ORDER : places_buyer
    USER ||--o{ ORDER : receives_seller
    
    PRODUCT ||--o{ ORDER : item_of

    ORDER ||--o{ TRANSACTION : has_history
    USER ||--o{ TRANSACTION : performs

    ORDER ||--o{ CONVERSATION : context
    CONVERSATION ||--|{ MESSAGE : contains
    USER ||--o{ MESSAGE : sends

    USER ||--o{ NOTIFICATION : receives
```
