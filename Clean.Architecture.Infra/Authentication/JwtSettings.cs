namespace Clean.Architecture.Infra.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "Jwt";
        public string Key { get; init; } = null;
        public int ExpiryMinutes { get; init; }
    }
}
