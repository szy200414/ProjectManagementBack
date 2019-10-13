using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.Models
{
    public class ProjectMember: BaseEntity
    {
        [ForeignKey(nameof(Member))]
        public Guid MemberId { get; set; }
        public User Member { get; set; }

        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public string Role { get; set; }


    }
}
