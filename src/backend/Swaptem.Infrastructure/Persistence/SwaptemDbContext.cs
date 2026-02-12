using Microsoft.EntityFrameworkCore;
using Swaptem.Domain.Entities;
using Swaptem.Domain.Enums;

namespace Swaptem.Infrastructure.Persistence;

public class SwaptemDbContext : DbContext
{
    public SwaptemDbContext(DbContextOptions<SwaptemDbContext> options) : base(options)
    {
    }

    // Khai báo ??y ?? các b?ng
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<BlockedPayout> BlockedPayouts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // --- 1. USER RELATIONSHIPS ---
        // User s? h?u nhi?u Product
        modelBuilder.Entity<User>()
            .HasMany(u => u.Products)
            .WithOne(p => p.Seller)
            .HasForeignKey(p => p.SellerId)
            .OnDelete(DeleteBehavior.Restrict);

        // User nh?n nhi?u Notification
        modelBuilder.Entity<User>()
            .HasMany(u => u.Notifications)
            .WithOne(n => n.User)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // --- 2. ORDER RELATIONSHIPS (Ph?c t?p nh?t) ---
        // Order - Buyer
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Buyer)
            .WithMany(u => u.OrdersBought)
            .HasForeignKey(o => o.BuyerId)
            .OnDelete(DeleteBehavior.Restrict); // Không xóa user n?u ?ã mua hàng

        // Order - Seller
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Seller)
            .WithMany(u => u.OrdersSold)
            .HasForeignKey(o => o.SellerId)
            .OnDelete(DeleteBehavior.Restrict);

        // Order - Product
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Product)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // --- 3. TRANSACTION RELATIONSHIPS ---
        // Transaction - Order
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Order)
            .WithMany(o => o.Transactions)
            .HasForeignKey(t => t.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        // Transaction - User (Ng??i th?c hi?n)
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.User)
            .WithMany(u => u.Transactions)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Transaction - RelatedTransaction (Self-Referencing: Payout & DebtDeduction)
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.RelatedTransaction)
            .WithMany(t => t.ChildTransactions)
            .HasForeignKey(t => t.RelatedTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        // --- 4. CONVERSATION & MESSAGE (Chat system) ---
        // Conversation thu?c v? Order
        modelBuilder.Entity<Conversation>()
            .HasOne(c => c.Order)
            .WithMany(o => o.Conversations)
            .HasForeignKey(c => c.OrderId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa ??n -> xóa chat

        // Conversation ???c t?o b?i User (Creator)
        modelBuilder.Entity<Conversation>()
            .HasOne(c => c.Creator)
            .WithMany() // User không c?n list ConversationsStarted (n?u không c?n thi?t)
            .HasForeignKey(c => c.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Message thu?c v? Conversation
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Conversation)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ConversationId)
            .OnDelete(DeleteBehavior.Cascade);

        // Message ???c g?i b?i User (Sender)
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        // --- 5. BLOCKED PAYOUT (Logic ch?n & chu?c) ---
        // BlockedPayout do User g?c gây ra
        modelBuilder.Entity<BlockedPayout>()
            .HasOne(b => b.OriginalUser)
            .WithMany(u => u.CausedBlocks)
            .HasForeignKey(b => b.OriginalUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // BlockedPayout ???c gi?i quy?t b?i Transaction (1-1)
        modelBuilder.Entity<BlockedPayout>()
            .HasOne(b => b.ResolvedTransaction)
            .WithOne(t => t.ResolvedBlock)
            .HasForeignKey<BlockedPayout>(b => b.ResolvedTransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        // --- 6. C?U HÌNH DATA TYPE ---
        // Decimal (Ti?n t?)
        var decimalProps = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

        foreach (var p in decimalProps)
        {
            p.SetPrecision(18);
            p.SetScale(2);
        }

        // Enum -> String (D? ??c trong DB)
        modelBuilder.Entity<User>().Property(u => u.Role).HasConversion<string>();
        modelBuilder.Entity<User>().Property(u => u.Status).HasConversion<string>();
        modelBuilder.Entity<Product>().Property(p => p.ProductType).HasConversion<string>();
        modelBuilder.Entity<Product>().Property(p => p.Status).HasConversion<string>();
        modelBuilder.Entity<Order>().Property(o => o.Status).HasConversion<string>();
        modelBuilder.Entity<Transaction>().Property(t => t.Type).HasConversion<string>();
        modelBuilder.Entity<Transaction>().Property(t => t.Status).HasConversion<string>();
        modelBuilder.Entity<Conversation>().Property(c => c.Type).HasConversion<string>();
    }
}
