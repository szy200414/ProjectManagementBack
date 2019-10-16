using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.DTO
{
    public class MissionListDto
    {
        public Guid Id { get; set; } 
        public string ListName { get; set; }
        public int Order { get; set; }
        public List<MissionDto> Missions { get; set; } 
    }
}
