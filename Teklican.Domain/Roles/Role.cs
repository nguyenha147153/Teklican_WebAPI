namespace Teklican.Domain.Roles
{
    public sealed class Role
    {        
        public RoleId Id { get; set; } = null!;
        public string Name { get; private set; } = null!;

        public Role(RoleId roleId, string name)
        {
            Id = roleId;
            Name = name;
        }

        public static Role Create(RoleId roleId,string name)
        {
            return new(roleId,name);
        }

        public Role()
        {
        }
    }
}
