using System.ComponentModel.DataAnnotations;

namespace expansetrackerAPI.Models
{
    public class UserRegistraion
    {
        public int ID { get; set; }
        [Required]
        public  string FirstName { get; set; }
        [Required]
        public  string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public  string Email { get; set; }
        [Required]
        public  string UserName { get; set; }
        [Required]
        public byte[] Password { get; set; }     
        public byte[] PasswordKey { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public  string CountryCode { get; set; }
    }
    public class UserRegisterApi
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CountryCode { get; set; }

    }
    public class SessionRegistration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
