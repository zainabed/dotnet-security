using System.Collections.Generic;

namespace Security
{
    public interface AuthorizationManager
    {
        bool IsAuthenticated();

        bool HasRole(Role role);
        
        bool HasAnyRole(IEnumerable<Role> roles);
        
        bool HasRoles(IEnumerable<Role> roles);
    }
}