using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementBack.WebApi.Models.Project
{
    public class CreateMissionViewModel
    {
        [Required]
        public string MissionName { get; set; }

        [Required]
        public Guid MissionListId { get; set; }

        [Required]
        public string Desc { get; set; }

        [Required]
        public int Priority { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public DateTime DueTime { get; set; }


    }
}