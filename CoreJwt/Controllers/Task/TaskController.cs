using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoreJwt.Models.Task;
using CoreJwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CoreJwt.Controllers.Task {
    [ApiController]
    [Route ("api/[controller]")]
    public class TaskController : ControllerBase {
        private readonly StoreContext _context;
        private readonly IWebHostEnvironment _environment;
        public TaskController (StoreContext context, IWebHostEnvironment environment) {
            _context = context;
            this._environment = environment;
        }

        [HttpPost ("AddImg")]
        public async Task<IActionResult> SaveImage (IFormFile file) {
            string imgName = new string (Path.GetFileNameWithoutExtension (file.FileName).ToArray ());
            imgName = imgName + Path.GetExtension (file.FileName);
            var imgPath = Path.Combine (_environment.ContentRootPath, "Images", imgName);
            using (var steam = new FileStream (imgPath, FileMode.Create)) {
                await file.CopyToAsync (steam);
            }
            return Ok (file);
        }

        [HttpPost ("register")]
        public async Task<IActionResult> Register ([FromBody] TaskMaster task) {
            try {
                await _context.Task.AddAsync (task);
                await _context.SaveChangesAsync ();
                return Ok (task);
            } catch (Exception ex) {
                throw ex;
            }
        }

        [HttpPost ("UpdateTaskStatus/{id}/{status}")]
        public async Task<IActionResult> Updatestatus (int id, string status) {
            try {
                var updatetask = await _context.Task.Where (v => v.Id == id).FirstOrDefaultAsync ();
                updatetask.status = status;
                updatetask.CreatedAt = DateTime.Now;
                _context.Task.Update (updatetask);
                await _context.SaveChangesAsync ();
                return Ok (200);
            } catch (Exception ex) {
                throw ex;
            }
        }

        [HttpPost ("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask (int id) {
            try {
                var updatetask = await _context.Task.Where (v => v.Id == id).FirstOrDefaultAsync ();
                updatetask.IsDeleted = true;
                _context.Task.Update (updatetask);
                await _context.SaveChangesAsync ();
                return Ok (200);
            } catch (Exception ex) {
                throw ex;
            }
        }

        [HttpGet ("getTask")]
        public async Task<IActionResult> GetTask () {
            var task = await _context.Task.Include (c => c.User).Include (c => c.Priority).Where (c => c.IsDeleted == false).ToListAsync ();
            return Ok (task);
        }

        [HttpGet ("getTaskById/{id}")]
        public async Task<IActionResult> GetTask (int id) {
            var task = await _context.Task.Include (c => c.User).Include (c => c.Priority).Where (c => c.IsDeleted == false && c.Id == id).ToListAsync ();
            return Ok (task);
        }

        [HttpPost ("UpdateTask/{id}")]
        public async Task<IActionResult> UpdateTask (int id, [FromBody] TaskMaster task) {
            try {
                var updatetask = await _context.Task.Where (v => v.Id == id).FirstOrDefaultAsync ();
                updatetask.TaskType = task.TaskType;
                updatetask.ProjectId = task.ProjectId;

                updatetask.UserId = task.UserId;
                updatetask.TaskTypeId = task.TaskTypeId;
                updatetask.PriorityId = task.PriorityId;
                updatetask.TaskGroupId = task.TaskGroupId;
                updatetask.RelatedToId = task.RelatedToId;
                updatetask.ProStatusId = task.ProStatusId;
                updatetask.IndustryId = task.IndustryId;
                updatetask.StartDate = task.StartDate;
                updatetask.DueDate = task.DueDate;
                updatetask.EstimateHr = task.EstimateHr;
                updatetask.BreakTime = task.BreakTime;
                updatetask.SpendTime = task.SpendTime;
                updatetask.TimeLog1 = task.TimeLog1;
                updatetask.TimeLog2 = task.TimeLog2;
                updatetask.checklist = task.checklist;

                _context.Task.Update (updatetask);
                await _context.SaveChangesAsync ();
                return Ok (200);
            } catch (Exception ex) {
                throw ex;
            }
        }

        [HttpGet ("getTaskStatusCount")]
        public async Task<IActionResult> GetTaskStatusCount () {
            var progress = await _context.Task.Include (c => c.User).Include (c => c.Priority).Where (c => c.status == "In Progress" && c.IsDeleted == false).ToListAsync ();
            var close = await _context.Task.Include (c => c.User).Include (c => c.Priority).Where (c => c.status == "Closed" && c.IsDeleted == false).ToListAsync ();
            var resolve = await _context.Task.Include (c => c.User).Include (c => c.Priority).Where (c => c.status == "Resolved" && c.IsDeleted == false).ToListAsync ();
            var news = await _context.Task.Include (c => c.User).Include (c => c.Priority).Where (c => c.status == "New Assign" && c.IsDeleted == false).ToListAsync ();
            return Ok (new { progress, close, resolve, news });
        }

        [HttpGet ("getTaskStatusByParams/{paramss}")]
        public async Task<IActionResult> GetTaskStatusCount (string paramss) {
            if (paramss == "1") {
                var progress = await _context.Task.Include (c => c.User).Include (c => c.Priority).Where (c => c.PriorityId == Convert.ToInt32 (paramss) && c.IsDeleted == false).ToListAsync ();
                return Ok (progress);
            }
            
             else {
                var progress = await _context.Task.Include (c => c.User).Include (c => c.Priority).Where (c => c.status == paramss && c.IsDeleted == false).ToListAsync ();

                return Ok (progress);
            }
            return Ok ();
        }
    }
}