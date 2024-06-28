using Teklican.Contracts.Products;

namespace Teklican.Contracts.Orders
{
    public record OrderResponse(
        string Id,
        string CustomerId,
        decimal Total,
        string Status,
        List<OrderDetailResponse> OrderDetails
        );

    public record OrderDetailResponse(
        string Id,
        int Quantity,
        decimal SubTotal,
        string Status,
        List<OrderItemsResponse> Products);

    public record OrderItemsResponse(
        string Id,
        string Name,
        decimal Description,
        string Price,
        string Status,
        string CategoryId);
}
