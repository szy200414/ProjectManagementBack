using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.DTO
{
    public class MissionDto
    {
        public string MissionName { get; set; }
        public string Desc { get; set; }
        public int Priority { get; set; }
        public int Score { get; set; }

    }
}
