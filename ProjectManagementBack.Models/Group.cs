using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.Models
{
    public class Group: BaseEntity
    {
        public string GroupName { get; set; }
        public string Desc { get; set; }

    }
}
