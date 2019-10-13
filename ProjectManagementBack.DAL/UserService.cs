using ProjectManagementBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.DAL
{
    public class UserService: BaseService<User>
    {
        public UserService() : base(new ProjMgrContext())
        {

        }
    }
}
