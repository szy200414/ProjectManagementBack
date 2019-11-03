using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.Models
{
    public class Mission: BaseEntity
    {
        public string MissionName { get; set; }
        public string Desc { get; set; }
        public int Priority { get; set; }
        public int Score { get; set; }

        public DateTime DueDate { get; set; } 


        [ForeignKey(nameof(MissionList))]
        public Guid MissionListId { get; set; }
        public MissionList MissionList { get; set; }

    }
}
