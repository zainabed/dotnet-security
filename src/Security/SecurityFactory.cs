namespace Security
{
    public interface SecurityFactory
    {
        AuthenticationManager GetAuthenticationManager();
        
        AuthorizationManager GetAuthorizationManager();
    }
}