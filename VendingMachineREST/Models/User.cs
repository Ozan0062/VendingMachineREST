using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VendingMachineREST.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? MobilePhone { get; set; }

        public int length = 8;

        public User() 
        {
        }


        public string CreatePassword()
        {
            const string valid = "UDLRM";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public void ValidateFirstName()
        {
            if (FirstName == null)
            {
                throw new ArgumentNullException("First name is required");
            }
            if (FirstName.Length < 2)
            {
                throw new ArgumentException("First name must be at least 2 characters");
            }
        }

        public void ValidateLastName()
        {
            if (LastName == null)
            {
                throw new ArgumentNullException("Last name is required");
            }
            if (LastName.Length < 2)
            {
                throw new ArgumentException("Last name must be at least 2 characters");
            }
        }

        public void ValidateEmail()
        {
            if (Email == null)
            {
                throw new ArgumentNullException("Email is required");
            }
            if (!Email.Contains("@"))
            {
                throw new ArgumentException("Email must contain @");
            }
            if (!Email.Contains("."))
            {
                throw new ArgumentException("Email must contain .");
            }
        }
        public void ValidatePassword() 
        {
            if (Password == null)
            {
                throw new ArgumentNullException("Password is required");
            }
            if (Password.Length != 8)
            {
                throw new ArgumentException("Password must be 8 characters");
            }
        }
        public void ValidateMobilePhone()
        {
            if (MobilePhone == null)
            {
                throw new ArgumentNullException("Mobile phone is required");
            }
            if (MobilePhone.Length < 8)
            {
                throw new ArgumentException("Mobile phone must be at least 8 characters");
            }
            if (MobilePhone.Length > 13)
            {
                throw new ArgumentException("Mobile phone must be maximum 13 characters");
            }
        }
        public void Validate()
        {
            ValidateFirstName();
            ValidateLastName();
            ValidateEmail();
            ValidatePassword();
            ValidateMobilePhone();
        }
    }

}
