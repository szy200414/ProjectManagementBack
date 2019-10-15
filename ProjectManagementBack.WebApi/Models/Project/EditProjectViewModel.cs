using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementBack.WebApi.Models.Project
{
    public class EditProjectViewModel
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid OwnerId { get; set; }
        public string CoverImage { get; set; }
        public int State { get; set; }
        public int ScoreTot { get; set; }

    }
}