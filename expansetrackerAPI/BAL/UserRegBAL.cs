using expansetrackerAPI.Data.Repo;

namespace expansetrackerAPI.BAL
{
    public class UserRegBAL
    {
        private readonly SessionRepository _sessionRepository;

        public UserRegBAL(SessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public string GenerateSessionToken()
        {
            return Guid.NewGuid().ToString();
        }

        public void CreateSession(int userId, string token, DateTime expiryDate)
        {
            _sessionRepository.CreateSessionToken(userId, token, expiryDate);
        }

        public bool ValidateSessionToken(string token)
        {
            var session = _sessionRepository.GetSessionByToken(token);
            return session != null;
        }

        public void InvalidateSessionToken(string token)
        {
            _sessionRepository.InvalidateSessionToken(token);
        }
    }
}

