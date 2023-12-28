namespace Clean.Architecture.Application.Interfaces.Authentication
{
    public interface IJwtAuthentication
    {
        string GenerateToken(
            string login,
            int userId);
    }
}
