using ProjectManagementBack.DAL;
using ProjectManagementBack.DTO;
using ProjectManagementBack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.BLL
{
    public class ProjectManager
    {
        public static async Task CreateProject(string name, string desc,
            DateTime beginDate, DateTime endDate, string coverImage, Guid owmerId)
        {
            using (var projSvc = new ProjectService())
            {
                await projSvc.CreateAsync(new Project()
                {
                    Name = name,
                    Desc = desc,
                    BeginDate = beginDate,
                    EndDate = endDate,
                    OwnerId = owmerId
                }, true);
            }
        }

        public static List<ProjectDto> GetAllProjects()
        {
            using (var projSvc = new ProjectService())
            {
                var projects = projSvc.GetAll().Include(m => m.Owner).Select(m => new ProjectDto()
                {
                    Name = m.Name,
                    Desc = m.Desc,
                    Id = m.Id,
                    BeginDate = m.BeginDate,
                    EndDate = m.EndDate,
                    CoverImage = m.CoverImage,
                    OwnerId = m.OwnerId,
                    OwnerFirstName = m.Owner.FirstName,
                    OwnerLastName = m.Owner.LastName,
                    State = m.State,
                    ScoreTot = m.ScoreTot
                });
                return projects.ToList();
            }            
        }

        public static async Task<ProjectDto> GetProjectById(Guid id)
        {
            using (var projSvc = new ProjectService())
            {
                var project = await projSvc.GetOneAsync(id);
                if (project != null)
                {
                    var projectDto = new ProjectDto()
                    {
                        Name = project.Name,
                        Desc = project.Desc,
                        Id = project.Id,
                        BeginDate = project.BeginDate,
                        EndDate = project.EndDate,
                        CoverImage = project.CoverImage,
                        OwnerId = project.OwnerId,
                        OwnerFirstName = project.Owner.FirstName,
                        OwnerLastName = project.Owner.LastName,
                        State = project.State,
                        ScoreTot = project.ScoreTot
                    };
                    return projectDto;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
