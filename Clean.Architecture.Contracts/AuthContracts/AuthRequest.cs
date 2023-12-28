namespace Clean.Architecture.Contracts.AuthContracts
{
    public record AuthRequest
    (
        string Username,
        string Password
    );
}
