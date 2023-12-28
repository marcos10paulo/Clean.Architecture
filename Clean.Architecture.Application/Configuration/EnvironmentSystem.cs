using Clean.Architecture.Application.Interfaces.Configuration;

namespace Clean.Architecture.Application.Configuration
{
    public class EnvironmentSystem : IEnvironmentSystem
    {
        public int? UserId { get; private set; }
        public string? UserName { get; private set; }

        public void UpdateEnvironmnetSystem(int? userId = null, string? userName = null)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}
