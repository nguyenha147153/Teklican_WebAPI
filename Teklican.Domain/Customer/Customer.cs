using Teklican.Domain.Customer.ValueObjects;
using Teklican.Domain.Models;
using Teklican.Domain.Orders.ValueObjects;
using Teklican.Domain.Users.ValueObjects;



namespace Teklican.Domain.Customer
{
    public sealed class Customer : AggregateRoot<CustomerId>
    {
        private readonly List<OrderId> _orders = new();
        public UserId UserId { get;}
        public string Name { get;}
        public string Phone {  get;}
        public string Address { get;}
        private IReadOnlyList<OrderId> OrderIds => _orders.AsReadOnly();
        public Customer(
            CustomerId customerId,
            UserId userId,
            string name,
            string phone,
            string address) : base(customerId)
        {
            UserId = userId;
            Name = name;
            Phone = phone;
            Address = address;
        }
        public static Customer Create(
            UserId userId,
            string name,
            string phone,
            string address)
        {
            return new(
                CustomerId.CreateUnique(),
                userId,
                name,
                phone,
                address);
        }
    }
}
