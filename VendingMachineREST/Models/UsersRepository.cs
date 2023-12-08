﻿using System.Net;

namespace VendingMachineREST.Models
{
    public class UsersRepository
    {
        private readonly UsersDbContext? _context;
        private readonly string generatedPassword = User.CreatePassword();

        public UsersRepository(UsersDbContext context) 
        {
            _context = context;
        }

        public async Task SendMessage()
        {
            string username = "+4540688969";
            string password = "zZBhFeKR";
            string tophonenumberwithcountrycode = "+4540688969";
            string theMessage = $"Dit kodeord er: {generatedPassword}";

            try
            {
                // Opret URL med parametre
                string pathtouse = $"https://api.suresms.com/Script/SendSMS.aspx?login={username}&password={password}&to={tophonenumberwithcountrycode}&Text={WebUtility.UrlEncode(theMessage)}";

                // Lav en webanmodning
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(pathtouse);

                    // Håndter responsen efter behov (kan tilpasses efter API'ets krav)
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("SMS sendt med succes.");
                    }
                    else
                    {
                        Console.WriteLine($"Fejl ved afsendelse af SMS. Statuskode: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl ved afsendelse af SMS: {ex.Message}");
            }
        }

        public User? Add(User user)
        {
            user.Password = generatedPassword;
            user.Validate();
            _context.User.Add(user);
            _context.SaveChanges();
            SendMessage();
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
