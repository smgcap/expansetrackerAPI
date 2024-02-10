using expansetrackerAPI.Interfaces;
using expansetrackerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace expansetrackerAPI.Data.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpanseDbContext _context;
        public UserRepository(ExpanseDbContext expanseDbContext)
        {
                _context = expanseDbContext;
        }
        public void Register(UserRegisterApi userRegistraion)
        {
            byte[] passwordHash, passwordkey;
            using (var hmac = new HMACSHA512())
            {
                passwordkey = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userRegistraion.Password));
            }

            UserRegistraion user = new UserRegistraion();
            user.UserName = userRegistraion.UserName;
            user.Password = passwordHash;
            user.PasswordKey = passwordkey;
            user.DateOfBirth = userRegistraion.DateOfBirth;
            user.Email = userRegistraion.Email;
            user.FirstName = userRegistraion.FirstName;
            user.LastName = userRegistraion.LastName;
            user.MiddleName = userRegistraion.MiddleName;
            user.CountryCode = userRegistraion.CountryCode;

            _context.Add(user);
        }

        public async Task<bool> UserAlreadyExist(string userName)
        {
            return await _context.userRegistraions.AnyAsync(x => x.UserName == userName);
        }

        async Task<UserRegistraion> IUserRepository.Authenticate(string userName, string passwordText)
        {
            var user = await _context.userRegistraions.FirstOrDefaultAsync(x => x.UserName == userName);
            if (!MatchPasswordHash(passwordText, user.Password, user.PasswordKey))
                return null;

            return user;
        }

        private bool MatchPasswordHash(string passwordText, byte[] password, byte[] passwordkey)
        {
            using (var hmac = new HMACSHA512(passwordkey))
            {
                var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordText));
                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != password[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
