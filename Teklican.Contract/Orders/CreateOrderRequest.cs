namespace Teklican.Contracts.Orders
{
    public record CreateOrderRequest(
        string CustomerId,
        List<OrderDetail> OrderDetails);

    public record OrderDetail(
        List<Products> Products);

    public record Products(
        string Name,
        decimal Description,
        string Price,
        string Status,
        string CategoryId);
}
