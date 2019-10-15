using ProjectManagementBack.BLL;
using ProjectManagementBack.WebApi.Filters;
using ProjectManagementBack.WebApi.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProjectManagementBack.WebApi.Controllers
{
    [MyAuth]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/project")]
    public class ProjectController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("createProject")]
        public async Task<IHttpActionResult> CreateProject(CreateProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                await ProjectManager.CreateProject(model.Name, model.Desc, 
                    model.BeginDate, model.EndDate, model.CoverImage, model.OwnerId);
                var projects = ProjectManager.GetAllProjects();
                return this.SendData(projects);
            }
            else
            {
                return this.ErrorData("Your entries are not correct");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("getAllProjects")]
        public IHttpActionResult GetAllProject()
        {
            var projects = ProjectManager.GetAllProjects();
            if (projects != null)
            {
                return this.SendData(projects);
            }
            else
            {
                return this.ErrorData("There isn't any project");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("getProjectsById")]
        public async Task<IHttpActionResult> GetProjectById(GetProjectByIdViewModel model)
        {
            if (ModelState.IsValid)
            {
                var project = await ProjectManager.GetProjectById(model.Id);
                if (project != null)
                {
                    return this.SendData(project);
                }
                else
                {
                    return this.ErrorData("Project not Exist");
                }
                
            }
            else
            {
                return this.ErrorData("Your entries isn't correct");
            }
                
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("editProject")]
        public async Task<IHttpActionResult> EditProject(EditProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                await ProjectManager.EditProject(model.Id, model.Name, model.Desc, model.BeginDate, model.EndDate,
                    model.CoverImage, model.OwnerId, model.State, model.ScoreTot);
                var projects = ProjectManager.GetAllProjects().ToList();
                return this.SendData(projects);
            }
            else
            {
                return this.ErrorData("Your entries are not correct");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("removeProject")]
        public async Task<IHttpActionResult> RemoveProject(RemoveProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                await ProjectManager.RemoveProject(model.Id);
                var projects = ProjectManager.GetAllProjects().ToList();
                return this.SendData(projects);
            }
            else
            {
                return this.ErrorData("Your entry isn't correct");
            }
        }
    }
}
