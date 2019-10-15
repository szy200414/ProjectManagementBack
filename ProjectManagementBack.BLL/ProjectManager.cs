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
            DateTime beginDate, DateTime endDate, string coverImage, Guid ownerId)
        {
            using (var projSvc = new ProjectService())
            {
                await projSvc.CreateAsync(new Project()
                {
                    Name = name,
                    Desc = desc,
                    CoverImage = coverImage,
                    BeginDate = beginDate,
                    EndDate = endDate,
                    OwnerId = ownerId
                }, true);
            }
        }

        public static List<ProjectDto> GetAllProjects()
        {
            using (var projSvc = new ProjectService())
            {
                var projects = projSvc.GetAll().OrderBy(m=>m.CreateTime).Include(m => m.Owner).Select(m => new ProjectDto()
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

        public static async Task EditProject(Guid id, string name, string desc,
            DateTime beginDate, DateTime endDate, string coverImage, Guid ownerId,
            int state, int scoreTot)
        {
            using (var projSvc = new ProjectService())
            {
                await projSvc.EditAsync(new Project()
                {
                    Id = id,
                    Name = name,
                    Desc = desc,
                    BeginDate = beginDate,
                    EndDate = endDate,
                    CoverImage = coverImage,
                    OwnerId = ownerId,
                    State = state,
                    ScoreTot = scoreTot,
                }, true);
            }
        }

        public static async Task RemoveProject(Guid id)
        {
            using (var projSvc = new ProjectService())
            {
                await projSvc.Remove(id, true);
            }
        }

        public static List<MissionList> GetMissionListByProjectId(Guid projectId)
        {
            using (var missionListSvc = new MissionListService())
            {
                return missionListSvc.GetAll(m => m.ProjectId == projectId).ToList();
            }
        }

        public static async Task CreateMissionList(string listName, Guid projectId)
        {
            using (var missionListSvc = new MissionListService())
            {
                var list = missionListSvc.GetAll(m => m.ProjectId == projectId).ToList();
                await missionListSvc.CreateAsync(new MissionList()
                {
                    ListName = listName,
                    ProjectId = projectId,
                    Order = list.Count() + 1,
                }, true);
            }
        }

        public static async Task CreateMission(string missionName, Guid missionListId, 
            string desc, int priority, int score)
        {
            using (var missionSvc = new MissionService())
            {
                await missionSvc.CreateAsync(new Mission()
                {
                    MissionName = missionName,
                    MissionListId = missionListId,
                    Desc = desc,
                    Priority = priority,
                    Score = score,
                }, true);

            }
        }

        public static IQueryable<Mission> GetMissionByListId(Guid listId)
        {
            using (var missionSvc = new MissionService())
            {
                return missionSvc.GetAll(m => m.MissionListId == listId);
            }
        }
    }
}
