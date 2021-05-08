using CoreJwt.Models.Projects;
namespace CoreJwt.Models.Projects {
    public class UnAssignProject {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ProjectId { get; set; }
        public Projects Project { get; set; }
    }
}