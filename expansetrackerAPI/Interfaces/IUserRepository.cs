using expansetrackerAPI.Models;

namespace expansetrackerAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<UserRegistraion> Authenticate(string userName,string passwordText);
        void Register(UserRegisterApi userRegistraion);
        Task<bool> UserAlreadyExist (string username);
    }
}
