using ProjectManagementBack.DAL;
using ProjectManagementBack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.BLL
{
    public class UserManager
    {
        public async static Task CreateUser(string firstName, string lastName, string email, string password, string imagePath, string tel)
        {
            using (var userSvc = new UserService())
            {
                await userSvc.CreateAsync(new Models.User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Password = password,
                    ImagePath = imagePath,
                    Tel = tel,
                }, true);
            }
        }

        public static bool Login(string email, string password, out Guid userId)
        {
            using (UserService userService = new DAL.UserService())
            {
                User user =  userService.GetAll(m => m.Email == email && m.Password == password).FirstOrDefault();
                if (user==null)
                {
                    userId = Guid.Empty;
                    return false;
                }
                else
                {
                    userId = user.Id;
                    return true;
                }
            }
        }
    }
}