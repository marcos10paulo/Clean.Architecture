namespace Clean.Architecture.Application.Interfaces.Configuration
{
    public interface IEnvironmentSystem
    {
        int? UserId { get; }
        string? UserName { get; }
        
        void UpdateEnvironmnetSystem(int? userId = null, string? userName = null);
    }
}
