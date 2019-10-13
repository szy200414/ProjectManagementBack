using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.Models
{
    public class MissionOwner : BaseEntity
    {
        [ForeignKey(nameof(Mission))]
        public Guid MissionId { get; set; }
        public Mission Mission { get; set; }

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }

    }
}
