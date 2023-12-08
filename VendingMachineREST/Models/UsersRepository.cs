namespace VendingMachineREST.Models
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
            string generatedPassword = User.CreatePassword();
            user.Password = generatedPassword;
            user.Validate();
            _context.User.Add(user);
            _context.SaveChanges();
            SMS.SendMessage();
            return user;
        }

        public IEnumerable<User?> GetAll(string? firstName = null, string? lastName = null, string? email = null, string? mobileNumber = null) 
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
            if (mobileNumber != null)
            {
                filteredUsers = filteredUsers.Where(u => u.MobileNumber == mobileNumber);
            }
            return filteredUsers;
        } 

        public User GetByPassword(string password)
        {
            return _context.User.Single(u => u.Password == password);
        }

        public List<string>? GetUsersPhonenumber() 
        {
        return _context.User.Select(u => u.MobileNumber).ToList();
        }

        public List<string>? GetUsersEmail()
        {
            return _context.User.Select(u => u.Email).ToList();
        }
    }
}
