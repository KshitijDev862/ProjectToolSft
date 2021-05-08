using System;
namespace CoreJwt.Models.Projects
{
    public class Projects
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Priority { get; set; }
        public string ProjectDetails { get; set; }
        public string ProjectMethology { get; set; }
        public string TaskType { get; set; }
        public string EstimatedHr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectManagerId { get; set; }
        public string Client { get; set; }
        public string Currency { get; set; }        
        public string ProjectStatus { get; set; }
        public string Industry { get; set; }
        public string CreatedBy { get; set; } 
        public DateTime CreatedDate { get; set; }
        public int AssignUser { get; set; } 
        public Projects()
        {
            CreatedDate=DateTime.Now;
        }
    }
}