﻿namespace VendingMachineREST.Models
{
    public class UsersRepository
    {
        private readonly UsersDbContext? _context;

        public UsersRepository(UsersDbContext context) 
        {
            _context = context;
        }

        public User? Add(User user)
        {
            user.CreatePassword();
            user.Validate();
            _context?.User.Add(user);
            _context?.SaveChanges();
            return user;
        }

        public IEnumerable<User?> GetAll(string? firstName = null, string? lastName = null, string? email = null, string? mobilePhone = null) 
        {
            IEnumerable<User> filteredUsers = _context.User;
            if (firstName != null)
            {
                filteredUsers = filteredUsers.Where(u => u.FirstName == firstName);
            }
            if (lastName != null)
            {
                filteredUsers = filteredUsers.Where(u => u.LastName == lastName);
            }
            if (email != null)
            {
                filteredUsers = filteredUsers.Where(u => u.Email == email);
            }
            if (mobilePhone != null)
            {
                filteredUsers = filteredUsers.Where(u => u.MobilePhone == mobilePhone);
            }
            return filteredUsers;
        } 
    }
}
