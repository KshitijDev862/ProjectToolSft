using System;
using CoreJwt.Models;
using CoreJwt.Models.Projects;
namespace CoreJwt.Models.Projects {
    public class AssiginProject {
        public int Id { get; set; }
        public string User { get; set; }
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get; set; }
        public int ProjectRoleId { get; set; }
        public ProjectRole ProjectRole { get; set; }
        public Projects Project { get; set; }
        public DateTime CreatedAt { get; set; }
        public AssiginProject () {
            CreatedAt = DateTime.Now;
        }
    }
}