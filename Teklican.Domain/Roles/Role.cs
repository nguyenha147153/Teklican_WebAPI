using Teklican.Domain.Models;
using Teklican.Domain.Roles.ValueObjects;

namespace Teklican.Domain.Roles
{
    public sealed class Role : Entity<RoleId>
    {
        public Role() 
        { 
        }
        public string Name { get; private set; } = null!;

        public Role(RoleId roleId, string name) : base(roleId)
        {
            Name = name;
        }

        public static Role Create(string name)
        {
            return new(RoleId.CreateUnique(), name);
        }
    }
}
