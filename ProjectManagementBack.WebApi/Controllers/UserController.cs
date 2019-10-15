using ProjectManagementBack.BLL;
using ProjectManagementBack.WebApi.Filters;
using ProjectManagementBack.WebApi.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManagementBack.WebApi.Controllers
{
    [MyAuth]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("createUser")]
        public async Task<IHttpActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                await UserManager.CreateUser(model.FirstName, model.LastName, model.Email, 
                    model.Password, model.ImagePath, model.Tel);
                return this.SendData("Success");
            }
            else
            {
                return this.ErrorData("Your data is not correct");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IHttpActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (UserManager.Login(model.Email, model.Password, out Guid userid))
                {
                    return this.SendData(JwtTools.Encoder(new Dictionary<string, object>()
                    {
                        {"username", model.Email },
                        {"userid", userid }
                    }));
                }
                else
                {
                    return this.ErrorData("Your Email or your password is not correct");
                }
            }
            else
            {
                return this.ErrorData("Your entries are not correct");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("getAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            var users = UserManager.GetAllUsers();
            if (users != null)
            {
                return this.SendData(users);
            }
            else
            {
                return this.ErrorData("Don't have any user");
            }
        }
    }

    
}
