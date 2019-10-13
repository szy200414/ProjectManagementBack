using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.Models
{
    public class MissionLog : BaseEntity
    {
        public string Desc { get; set; }

        [ForeignKey(nameof(Mission))]
        public Guid MissionId { get; set; }
        public Mission Mission { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
