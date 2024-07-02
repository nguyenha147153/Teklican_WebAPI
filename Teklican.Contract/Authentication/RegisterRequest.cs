using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teklican.Contracts.Authentication
{
    public record RegisterRequest(
        int RoleId,
        string FirstName, 
        string LastName, 
        string Email, 
        string Password,
        string Phone,
        string Address);
}
