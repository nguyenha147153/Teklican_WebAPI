namespace Teklican.Contracts.Products
{
    public record CreateProductRequest(
        string Name,
        string Description,
        decimal Price,
        string CategoryId,
        string Image,
        int Tax);
}
