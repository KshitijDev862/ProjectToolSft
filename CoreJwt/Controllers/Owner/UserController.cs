using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CoreJwt.Controllers.Owner {
    [ApiController]
    [Route ("api/[controller]")]
    public class UserController : ControllerBase {
        private readonly StoreContext _context;
        private readonly IWebHostEnvironment _environment;
        public UserController (StoreContext context, IWebHostEnvironment environment) {
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

        [HttpPost ("registerUser/{ProId}/{User}/{RoleId}/{proIds}")]
        public async Task<IActionResult> UserRegister (int ProId, string User, int RoleId, string proIds) {
            try {
                AssiginProject Ap = new AssiginProject ();
                User uu = new User ();
                Ap.User = User;
                Ap.ProjectId = ProId;
                Ap.RoleId = RoleId;
                Ap.ProjectRoleId = 4;
                uu.UserName = User;
                uu.RoleId = RoleId;
                uu.IsActive = true;
                uu.ProjectRoleId = 4;
                uu.ProjectsIds = "<br/>" + proIds;
                await _context.assiginProject.AddAsync (Ap);
                await _context.users.AddAsync (uu);
                await _context.SaveChangesAsync ();
                return Ok (201);
            } catch (Exception ex) {
                throw ex;
            }
        }

        [HttpPost ("RemoveFromUnassing/{user}/{propId}")]
        public async Task<IActionResult> RemoveUnassinProject (string user, int propId) {
            try {
                var users = await _context.unassiginProject.Where (c => c.UserName == user && c.ProjectId == propId).FirstOrDefaultAsync ();
                _context.unassiginProject.Remove (users);
                await _context.SaveChangesAsync ();
                return Ok ();
            } catch (Exception ex) {
                throw ex;
            }
        }

        [HttpPost ("registerUserModel/{ProId}/{User}/{RoleId}/{proIds}")]
        public async Task<IActionResult> UserModelRegister (int ProId, string User, int RoleId, string proIds) {
            try {
                var pro = await _context.assiginProject.Where (c => c.User == User).FirstOrDefaultAsync ();
                var user = await _context.users.Where (c => c.UserName == User).FirstOrDefaultAsync ();
                AssiginProject Ap = new AssiginProject ();

                Ap.User = User;
                Ap.ProjectId = ProId;
                Ap.RoleId = pro.RoleId;
                Ap.ProjectRoleId = 4;
                user.ProjectsIds = user.ProjectsIds + "<br/>" + proIds;
                await _context.assiginProject.AddAsync (Ap);
                _context.users.Update (user);
                await _context.SaveChangesAsync ();
                return Ok (201);
            } catch (Exception ex) {
                throw ex;
            }
        }

        [HttpPost ("UpdateUser/{id}")]
        public async Task<IActionResult> UPdateUser (int id, [FromBody] AssignProjectDtos proDtos) {
            try {
                var assignPro = await _context.users.Where (c => c.Id == id).SingleOrDefaultAsync ();
                assignPro.FirstName = proDtos.FirstName;
                assignPro.LastName = proDtos.LastName;
                assignPro.ShortName = proDtos.ShortName;
                assignPro.UserName = proDtos.UserName;
                assignPro.imgsrc = proDtos.imgsrc;
                _context.users.Update (assignPro);
                await _context.SaveChangesAsync ();
                return Ok (201);
            } catch (Exception ex) {
                throw ex;
            }
        }

        [HttpGet ("getAssignUser")]
        public async Task<IActionResult> GetAssignProject () {
            var user = await _context.users.Where (x => x.IsActive == true)
                .Select (x => new User () {
                    Id = x.Id,
                        UserName = x.UserName,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        ShortName = x.ShortName,
                        Role = x.Role,
                        ProjectsIds = x.ProjectsIds,
                        IsActive = x.IsActive,
                        imgsrc = String.Format ("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.imgsrc)
                }).ToListAsync ();
            return Ok (user);
        }

        [HttpGet ("getAssignUserDisabled")]
        public async Task<IActionResult> GetAssignDisabled () {
            var user = await _context.users.Where (x => x.IsActive == false)
                .Select (x => new User () {
                    Id = x.Id,
                        UserName = x.UserName,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        ShortName = x.ShortName,
                        Role = x.Role,
                        IsActive = x.IsActive,
                        imgsrc = String.Format ("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.imgsrc)

                }).ToListAsync ();
            return Ok (user);
        }

        [HttpGet ("getAssignProject/{user}")]
        public async Task<IActionResult> GetAssignProject (string user) {
            var assignproject = await _context.assiginProject.Include (c => c.Role).Include (c => c.Project)
                .Where (c => c.User == user)
                .ToListAsync ();
            return Ok (assignproject);
        }

        [HttpGet ("getProject")]
        public async Task<IActionResult> GetProject () {
            var projects = await _context.projects.ToListAsync ();
            return Ok (projects);
        }

        [HttpGet ("getAssignUserById/{Id}")]
        public async Task<IActionResult> GetAssignProjectById (int Id) {
            var project = await _context.users.Where (c => c.Id == Id).SingleOrDefaultAsync ();
            return Ok (project);
        }

        [HttpPost ("RemoveAssignUser/{user}")]
        public async Task<IActionResult> RemoveAssign (string user) {
            var itemToUpdate = await _context.users.Where (c => c.UserName == user).FirstOrDefaultAsync ();
            itemToUpdate.IsActive = false;
            _context.users.Update (itemToUpdate);
            await _context.SaveChangesAsync ();
            return Ok ();
        }

        //Remove From assign Table
        [HttpPost ("removeFromAssign/{User}/{projectId}")]
        public async Task<IActionResult> RemoveFromAssign (string User, int projectId) {
            try {
                var pro = await _context.assiginProject.Where (c => c.User == User && c.ProjectId == projectId).FirstOrDefaultAsync ();
                _context.assiginProject.Remove (pro); 
                //Add In Unassign Project
                UnAssignProject up = new UnAssignProject ();
                up.UserName = User;
                up.ProjectId = projectId;
                await _context.unassiginProject.AddAsync (up);
                await _context.SaveChangesAsync ();
                return Ok (201);
            } catch (Exception ex) {
                throw ex;
            }
        }

    }
}