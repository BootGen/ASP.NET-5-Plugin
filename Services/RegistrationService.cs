using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace WebProject.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationDbContext dbContext;

        public RegistrationService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ProfileResponse CheckRegistration(RegistrationData data)
        {
            bool isEmailInUse = dbContext.Users.Where(u => u.Email == data.Email).Any();
            bool isUserNameInUse = dbContext.Users.Where(u => u.UserName == data.UserName).Any();
            return new ProfileResponse
                {
                    Success = !isUserNameInUse && !isEmailInUse,
                    IsUserNameInUse = isUserNameInUse,
                    IsEmailInUse = isEmailInUse
                };
        }

        public ProfileResponse Register(RegistrationData data)
        {
            var response = CheckRegistration(data);
            if (response.Success)
            {
                User newUser = new User {
                    UserName = data.UserName,
                    Email = data.Email
                };
                newUser.PasswordHash = new PasswordHasher<User>().HashPassword(newUser, data.Password);
                dbContext.Users.Add(newUser);
                dbContext.SaveChanges();
            }
            return response;
        }
    }
}
