﻿namespace expansetrackerAPI.Models
{
    public class UserRegistraion
    {
        public int ID { get; set; }
        public required string FirstName { get; set; }
        public required string MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string CountryCode { get; set; }
    }
}
