namespace Clean.Architecture.Contracts.UserContracts
{
    public record UserCreateRequest(
        string Username,
        string Password
    );
}
