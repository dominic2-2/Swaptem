```mermaid
erDiagram
    USER {
        uuid UserId PK
        string Username
        string Email
        string PasswordHash
        decimal DebtAmount
        int DisputeLostCount
        string Role "ADMIN, MEMBER"
        string Status "ACTIVE, BANNED, DEACTIVATED"
        datetime CreatedAt
    }

    PRODUCT {
        uuid ProductId PK
        uuid SellerId FK
        string Title
        string Description
        decimal BasePrice
        string PublicEvidenceUrl
        string ProductType "FILE, ACCOUNT"
        string SecretData
        string Status "AVAILABLE, SOLD, HIDDEN"
        datetime CreatedAt
    }

    ORDER {
        uuid OrderId PK
        string OrderCode
        uuid BuyerId FK
        uuid SellerId FK
        uuid ProductId FK
        decimal FinalPrice
        decimal PlatformFee
        string Status "CREATED, PAID, DISPUTED, COMPLETED, REFUNDED, CANCELLED"
        datetime PaidAt
        datetime DisputeDeadline
        datetime CreatedAt
    }

    TRANSACTION {
        uuid TransactionId PK
        uuid OrderId FK
        uuid UserId FK
        uuid RelatedTransactionId FK 
        string Type "DEPOSIT, PAYOUT, REFUND, DEBT_DEDUCTION"
        decimal Amount
        string PayoutInfo
        string AdminEvidence
        string Status "PENDING, SUCCESS, FAILED"
        datetime CreatedAt
    }

    CONVERSATION {
        uuid ConversationId PK
        uuid OrderId FK
        uuid CreatorId FK
        string Type "NEGOTIATION, ORDERCHAT, SELFRESOLVE, DISPUTE"
        datetime CreatedAt
    }

    MESSAGE {
        uuid MessageId PK
        uuid ConversationId FK
        uuid SenderId FK
        string Content
        boolean IsSystemMessage
        datetime CreatedAt
    }

    NOTIFICATION {
        uuid NotificationId PK
        uuid UserId FK
        string Content
        string Link
        boolean IsRead
        datetime CreatedAt
    }

    BLOCKED_PAYOUT {
        uuid BlockId PK
        string BankAccount
        string BankName
        uuid OriginalUserId FK
        decimal DebtAmount
        boolean IsResolved
        uuid ResolvedTransactionId FK
        datetime CreatedAt
    }

    %% --- RELATIONSHIPS ---
    USER ||--o{ PRODUCT : owns
    USER ||--o{ ORDER : places_buyer
    USER ||--o{ ORDER : receives_seller
    
    PRODUCT ||--o{ ORDER : item_of

    ORDER ||--o{ TRANSACTION : has_history
    USER ||--o{ TRANSACTION : performs

    ORDER ||--|{ CONVERSATION : context
    USER ||--o{ CONVERSATION : starts

    CONVERSATION ||--|{ MESSAGE : contains
    USER ||--o{ MESSAGE : sends

    USER ||--o{ NOTIFICATION : receives

    USER ||--o{ BLOCKED_PAYOUT : caused_block
    TRANSACTION ||--o| BLOCKED_PAYOUT : resolves_block
    TRANSACTION ||--o{ TRANSACTION : "related_to"
```
