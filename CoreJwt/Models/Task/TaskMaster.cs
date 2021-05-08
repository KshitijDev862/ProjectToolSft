using CoreJwt.Models.Projects;
using CoreJwt.Models;
using System;
namespace CoreJwt.Models.Task
{
    public class TaskMaster
    {
        public int Id { get; set; }
        public string TaskType { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TaskTypeId { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        public int TaskGroupId { get; set; }
        public int RelatedToId { get; set; }
        public string attachedFile { get; set; }
        public int ProStatusId { get; set; }
        public int IndustryId { get; set; } 
        public string StartDate { get; set; }
        public string DueDate { get; set; }
        public string EstimateHr { get; set; }
        public string BreakTime { get; set; }
        public string SpendTime { get; set; }
        public string TimeLog1 { get; set; }
        public string TimeLog2 { get; set; }
        public string checklist { get; set; }
        public string status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public TaskMaster()
        {
            status="In Progress";
            CreatedAt=DateTime.Now;
            IsDeleted=false;
        }
    }
}