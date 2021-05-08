using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoreJwt.Models;
using CoreJwt.Models.Dtos;
using CoreJwt.Models.Login;
using CoreJwt.Models.Projects;
using CoreJwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CoreJwt.Controllers.Owner {
    [ApiController]
    [Route ("api/[controller]")]
    public class ProjectController : ControllerBase {
        private readonly StoreContext _context;
        public ProjectController (StoreContext context) {
            _context = context;
        }

        [HttpPost ("register")]
        public async Task<IActionResult> Register ([FromBody] Projects project) {

            try {
                await _context.AddAsync (project);
                await _context.SaveChangesAsync ();
                return Ok (201);
            } catch (Exception ex) {
                throw ex;
            }

        }

        [HttpPost ("UpdateCompleted/{id}")]
        public async Task<IActionResult> UpdateCompleted (int id) {

            try {
                var updateProject = await _context.projects.Where (c => c.Id == id).FirstOrDefaultAsync ();
                updateProject.ProjectStatus = "Completed";
                _context.Update (updateProject);
                await _context.SaveChangesAsync ();
                return Ok (200);
            } catch (Exception ex) {
                throw ex;
            }
            return Ok (200);
        }

        [HttpPost ("AddUser/{id}/{user}")]
        public async Task<IActionResult> UpdateCompleted (int id, string user) {
            var project = await _context.projects.Where (c => c.Id == id).FirstOrDefaultAsync ();
            project.AssignUser++;
            _context.projects.Update (project);
            await _context.SaveChangesAsync ();
            AssiginProject uu = new AssiginProject ();
            uu.ProjectId = id;
            uu.User = user;
            uu.RoleId = 4;
            await _context.assiginProject.AddAsync (uu);
            await _context.SaveChangesAsync ();
            return Ok ();
        }

        [HttpPost ("AssignPojectRole")]
        public async Task<IActionResult> UpdateCompleted ([FromBody] UpdateProjectRole[] updateproject) {
            foreach (var item in updateproject) {
                var itemToUpdate = await _context.assiginProject.Where (c => c.Id == item.Id).SingleOrDefaultAsync ();
                itemToUpdate.ProjectRoleId = item.ProRoleId;
                _context.assiginProject.Update (itemToUpdate);
                await _context.SaveChangesAsync ();
            }
            return Ok ();
        }

        [HttpGet ("getUser")]
        public async Task<IActionResult> GetUser () {
            var user = await _context.users.ToListAsync ();
            return Ok (user);
        }

        [HttpPost ("UpdateProject/{id}")]
        public async Task<IActionResult> UpdateProject (int id, [FromBody] Projects project) {
            try {
                var updateProject = await _context.projects.Where (c => c.Id == id).FirstOrDefaultAsync ();
                updateProject.ProjectName = project.ProjectName;
                updateProject.Priority = project.Priority;
                updateProject.ProjectDetails = project.ProjectDetails;
                updateProject.ProjectMethology = project.ProjectMethology;
                updateProject.TaskType = project.TaskType;
                updateProject.EstimatedHr = project.EstimatedHr;
                updateProject.StartDate = project.StartDate;
                updateProject.EndDate = project.EndDate;
                updateProject.ProjectManagerId = project.ProjectManagerId;
                updateProject.Client = project.Client;
                updateProject.Currency = project.Currency;
                updateProject.ProjectStatus = project.ProjectStatus;
                updateProject.Industry = project.Industry;
                updateProject.CreatedBy = project.CreatedBy;
                _context.Update (updateProject);
                await _context.SaveChangesAsync ();
                return Ok (200);
            } catch (Exception ex) {
                throw ex;
            }
            return Ok (200);
        }

        [HttpPost ("AddUnassignedPro/{user}/{proIds}")]
        public async Task<IActionResult> AddunassignedProject (string user, int proIds) {

            var project = await _context.projects.Where (v => v.Id != proIds).ToListAsync ();
            foreach (var item in project) {
                UnAssignProject up = new UnAssignProject ();
                up.ProjectId = item.Id;
                up.UserName = user;
                await _context.unassiginProject.AddAsync (up);
                await _context.SaveChangesAsync ();
            }
            return Ok ();
        }

        [HttpGet ("getUnassignedProject/{user}")]
        public async Task<IActionResult> GetunassignedProject (string user) {
            var project = await _context.unassiginProject.Include (c => c.Project).Where (v => v.UserName == user).ToListAsync ();
            return Ok (project);
        }

        [HttpGet ("getAssignedUser/{proId}")]
        public async Task<IActionResult> GetAssigned (int proId) {
            var user = await _context.assiginProject.Include (c => c.Role).Include (c => c.ProjectRole).Where (x => x.ProjectId == proId).ToListAsync ();
            return Ok (user);
        }

        [HttpGet ("getProjectById/{id}")]
        public async Task<IActionResult> GetProjectById (int id) {
            var project = await _context.projects.Where (c => c.Id == id).FirstOrDefaultAsync ();
            return Ok (project);
        }

        [HttpGet ("getProjectHold")]
        public async Task<IActionResult> GetProjecthold () {
            var project = await _context.projects.Where (c => c.ProjectStatus == "On Hold").ToListAsync ();
            return Ok (project);
        }

        [HttpGet ("getProject")]
        public async Task<IActionResult> GetProject () {
            var project = await _context.projects.ToListAsync ();
            return Ok (project);
        }

        [HttpGet ("getProjectStack")]
        public async Task<IActionResult> GetProjectStack () {
            var project = await _context.projects.Where (c => c.ProjectStatus == "Stacked").ToListAsync ();
            return Ok (project);
        }

        [HttpGet ("getProjectStart")]
        public async Task<IActionResult> GetProjectStart () {
            var project = await _context.projects.Where (c => c.ProjectStatus == "Started").ToListAsync ();
            return Ok (project);
        }

        [HttpGet ("getProjectCompleted")]
        public async Task<IActionResult> GetProjectCompleted () {
            var project = await _context.projects.Where (c => c.ProjectStatus == "Completed").ToListAsync ();
            return Ok (project);
        }

        // Call From Master for Dropdown
        [HttpGet ("getMasterData")]
        public async Task<IActionResult> GetMasterDropdown () {
            var priority = await _context.priority.ToListAsync ();
            var promethodology = await _context.projectMethodolgy.ToListAsync ();
            var tasktype = await _context.taskType.ToListAsync ();
            var projectmgr = await _context.projectMgr.ToListAsync ();
            var client = await _context.clients.ToListAsync ();
            var currancy = await _context.currancy.ToListAsync ();
            var projectStatus = await _context.projectstatus.ToListAsync ();
            var industry = await _context.industry.ToListAsync ();
            return Ok (new { priority, promethodology, tasktype, projectmgr, client, currancy, projectStatus, industry });
        }

        [HttpGet ("getUserRole")]
        public async Task<IActionResult> GetUserWithRole () {
            var UserRole = await _context.users.Include (c => c.Role).ToListAsync ();
            return Ok (UserRole);
        }

        [HttpGet ("getRoleData")]
        public async Task<IActionResult> GetRole () {
            var UserRole = await _context.roles.ToListAsync ();
            return Ok (UserRole);
        }

        [HttpGet ("getProjectRole")]
        public async Task<IActionResult> GetProjectRole () {
            var UserRole = await _context.roleProject.ToListAsync ();
            return Ok (UserRole);
        }

    }
}