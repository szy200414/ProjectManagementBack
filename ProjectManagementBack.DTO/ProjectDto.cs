using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.DTO
{
    public class ProjectDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CoverImage { get; set; } 
        public int State { get; set; }
        public int ScoreTot { get; set; }


    }
}
