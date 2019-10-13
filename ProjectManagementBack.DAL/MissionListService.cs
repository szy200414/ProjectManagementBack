using ProjectManagementBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.DAL
{
    public class MissionListService: BaseService<MissionList>
    {
        public MissionListService() : base(new ProjMgrContext())
        {

        }
    }
}
