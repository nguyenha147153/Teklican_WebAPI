namespace Teklican.Contracts.Products
{
    public record CreateProductRequest(
        string Name,
        string Description,
        decimal Amount,
        string Sku,
        string Status,
        int CategoryId);
}
