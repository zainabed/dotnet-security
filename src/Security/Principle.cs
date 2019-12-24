using System.Collections.Generic;

namespace Security
{
    public interface Principle
    {
        string GetUsername();
        Credential GetCredential();

        bool IsActive();

        IEnumerable<Role> GetRoles();
    }
}