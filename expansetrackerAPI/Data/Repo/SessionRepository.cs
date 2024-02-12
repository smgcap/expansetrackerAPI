using expansetrackerAPI.Interfaces;
using expansetrackerAPI.Models;

namespace expansetrackerAPI.Data.Repo
{
    public class SessionRepository:ISessionRepository
    {
        private readonly ExpanseDbContext _context;

        public SessionRepository(ExpanseDbContext context)
        {
            _context = context;
        }

        public void CreateSessionToken(int userId, string token, DateTime expiryDate)
        {
            var session = new SessionRegistration
            {
                UserId = userId,
                Token = token,
                ExpiryDate = expiryDate
            };
            _context.sessionRegistraions.Add(session);
            _context.SaveChanges();
        }

        public SessionRegistration GetSessionByToken(string token)
        {
            return _context.sessionRegistraions.FirstOrDefault(s => s.Token == token && s.ExpiryDate > DateTime.Now);
        }

        public void InvalidateSessionToken(string token)
        {
            var session = _context.sessionRegistraions.FirstOrDefault(s => s.Token == token);
            if (session != null)
            {
                _context.sessionRegistraions.Remove(session);
                _context.SaveChanges();
            }
        }
    }
}
