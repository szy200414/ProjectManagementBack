using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.Models
{
    public class MissionList: BaseEntity
    {
        public string ListName { get; set; }

        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public int Order { get; set; }

    }
}
