using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementBack.WebApi.Models.Project
{
    public class CreateMissionListViewModel
    {
        [Required]
        public string ListName { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

    }
}