using expansetrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace expansetrackerAPI.Interfaces
{
    public interface ISessionRepository
    {
        public void CreateSessionToken(int userId, string token, DateTime expiryDate);
        public SessionRegistration GetSessionByToken(string token);
        public void InvalidateSessionToken(string token);

    }
}
