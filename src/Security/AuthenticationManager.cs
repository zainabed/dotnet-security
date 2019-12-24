namespace Security
{
    public interface AuthenticationManager
    {
        Principle GetPrinciple();

        void SetPrinciple(Principle principle);

        void Reset();
    }
}