 using System;
 using CoreJwt.Models.Projects;
 using CoreJwt.Models.Task;
 using CoreJwt.Models;
namespace CoreJwt.Models
{
    public class Timelogs
    {
         public int Id { get; set; }
         public int ProjectId { get; set; }
         public int TaskId { get; set; }
         public TaskMaster Task { get; set; }
         public int UserId { get; set; }
         public User User { get; set; }
         public DateTime date { get; set; }
         public DateTime StartTime { get; set; }
         public DateTime EndTime { get; set; } 
         public string BreakTime { get; set; }
         public string SpendHr { get; set; }
         public bool Isbillable { get; set; }
         public DateTime CreatedAt { get; set; }
         public bool IsActive { get; set; }
         public DateTime timmer { get; set; }
         public Timelogs () {
             CreatedAt = DateTime.Now;
             IsActive = true;
         }
    }
}