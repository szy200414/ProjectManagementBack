using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.Models
{
    public class Project: BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CoverImage { get; set; } 

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public int State { get; set; } = 0;
        public int ScoreTot { get; set; } = 0;

    }
}
