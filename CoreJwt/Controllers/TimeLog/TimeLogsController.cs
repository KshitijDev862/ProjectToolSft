using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoreJwt.Models;
using CoreJwt.Models.Task;
using CoreJwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CoreJwt.Controllers.TimeLog {
    [ApiController]
    [Route ("api/[controller]")]
    public class TimeLogsController : ControllerBase {
        private readonly StoreContext _context;
        public TimeLogsController (StoreContext context) {
            _context = context;
        }

        [HttpPost ("AddTimeLog")]
        public async Task<IActionResult> AddTimeLog ([FromBody] Timelogs log) {

            try {
                var task = await _context.Task.Where (c => c.Id == log.TaskId).FirstOrDefaultAsync ();
                CalanderLog cl = new CalanderLog ();
                cl.Subject = task.TaskType;
                cl.StartTime = log.StartTime;
                cl.EndTime = log.EndTime;
                cl.CategoryColor = "#1aaa55";
                await _context.timelog.AddAsync (log);
                await _context.calanderlog.AddAsync (cl);
                await _context.SaveChangesAsync ();
                return Ok (log);
            } catch (Exception ex) {
                throw ex;
            }
        }

        [HttpGet ("GetTimeLogList")]
        public async Task<IActionResult> GetTimeLogList () {
            var task = await _context.timelog.Include (x => x.Task).Include (x => x.User).ToListAsync ();
            if (task == null)
                return NoContent ();

            return Ok (task);
        }

        [HttpGet ("getCalanderTimelog")]
        public async Task<IActionResult> GetCalenderTimelog () {
            var log = await _context.calanderlog.ToListAsync ();
            if (log == null)
                return NoContent ();

            return Ok (log);
        }

        [HttpGet ("getTaskByProject/{projectId}")]
        public async Task<IActionResult> GetTaskByProjectId (int projectId) {
            var task = await _context.Task.Where (x => x.ProjectId == projectId).ToListAsync ();
            if (task == null)
                return NoContent ();

            return Ok (task);
        }

        [HttpGet ("getUserAssinToTask/{taskId}")]
        public async Task<IActionResult> GetUserByTaskId (int taskId) {
            var task = await _context.Task.Include (v => v.User).Where (x => x.Id == taskId).ToListAsync ();
            if (task == null)
                return NoContent ();

            return Ok (task);
        }

        [HttpGet ("getTaskByUserId/{userId}")]
        public async Task<IActionResult> GetTaskByUserId (int userId) {
            var task = await _context.Task.Where (x => x.UserId == userId).FirstOrDefaultAsync ();
            if (task == null)
                return NoContent ();

            return Ok (task);
        }

        [HttpPost ("UpdateTimmer/{taskId}")]
        public async Task<IActionResult> AddTimeLog (int taskId) {
            try {
                var tasklog = await _context.timelog.Where (c => c.TaskId == taskId).FirstOrDefaultAsync ();
                tasklog.timmer = DateTime.Now;
                _context.Update (tasklog);
                await _context.SaveChangesAsync ();
                return Ok ();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}