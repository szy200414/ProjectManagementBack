using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.Models
{
    public class Annonce: BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }
        public int Priority { get; set; }

        [ForeignKey(nameof(Group))]
        public Guid GroupId { get; set; }
        public Group Group { get; set; }

        [ForeignKey(nameof(CreatePerson))]
        public Guid CreatePersonId { get; set; }
        public User CreatePerson { get; set; }
    }
}
