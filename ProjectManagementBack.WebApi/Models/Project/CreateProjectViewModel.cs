using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementBack.WebApi.Models.Project
{
    public class CreateProjectViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public DateTime BeginDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string CoverImage { get; set; } 
        [Required]
        public Guid OwnerId { get; set; }
    }
}