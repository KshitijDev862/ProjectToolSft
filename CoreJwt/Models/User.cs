using System;
using CoreJwt.Models;
using CoreJwt.Models.Projects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace CoreJwt.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public string imgsrc { get; set; } 
        public bool IsActive { get; set; } 
        public int  RoleId { get; set; } 
        public string ProjectsIds { get; set; }
        public  Roles  Role { get; set; } 
        public int ProjectRoleId { get; set; }
        public ProjectRole ProjectRole { get; set; }
    }
}