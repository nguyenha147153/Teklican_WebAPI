namespace Teklican.Contracts.Products
{
    public record ProductResponse(
        string Id,
        string Name,
        string Description,
        decimal Price,
        string Status,
        string CategoryId,
        string Image,
        int Tax);
}
