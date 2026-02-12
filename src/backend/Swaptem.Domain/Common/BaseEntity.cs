namespace Swaptem.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid(); // T? ??ng sinh UUID m?i
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
