namespace Teklican.Contracts.Products
{
    public record UpdateProductRequest(
        Guid Id,
        string Name,
        string Description,
        decimal Amount,
        string Current,
        string Sku,
        string Status,
        int CategoryId);
}
