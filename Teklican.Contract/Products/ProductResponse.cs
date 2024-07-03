namespace Teklican.Contracts.Products
{
    public record ProductResponse(
        Guid Id,
        string Name,
        string Description,
        decimal Amount,
        string Status,
        int CategoryId);
}
