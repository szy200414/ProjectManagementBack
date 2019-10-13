using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.Models
{
    public class UserGroup: BaseEntity
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Group))]
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public string Position { get; set; }

    }
}
