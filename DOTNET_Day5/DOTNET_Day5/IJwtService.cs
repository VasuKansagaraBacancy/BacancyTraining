namespace DOTNET_Day5
{
    public interface IJwtService
    {
        string GenerateToken(string username);
    }
}