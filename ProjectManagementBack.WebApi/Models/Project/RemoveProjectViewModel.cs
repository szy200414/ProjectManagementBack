using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementBack.WebApi.Models.Project
{
    public class RemoveProjectViewModel
    {
        [Required]
        public Guid Id { get; set; }

    }
}