namespace expansetrackerAPI.Interfaces
{
    public interface IJwtService
    {
        public string GenerateJwtToken(string username);
    }
}
