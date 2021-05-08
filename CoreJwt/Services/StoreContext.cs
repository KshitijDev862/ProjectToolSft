using CoreJwt.Models;
using CoreJwt.Models.Projects;
using CoreJwt.Models.Task;  
using Microsoft.EntityFrameworkCore;

namespace CoreJwt.Services {
  public class StoreContext : DbContext {
    public StoreContext (DbContextOptions<StoreContext> options) : base (options) { }
    public DbSet<Employees> employees { get; set; }
    public DbSet<Roles> roles { get; set; }
    public DbSet<Memberships> membership { get; set; }
    public DbSet<Projects> projects { get; set; }
    public DbSet<Clients> clients { get; set; }
    public DbSet<Currency> currancy { get; set; }
    public DbSet<Industry> industry { get; set; }
    public DbSet<Priority> priority { get; set; }
    public DbSet<ProjectManager> projectMgr { get; set; }
    public DbSet<Projectmethodology> projectMethodolgy { get; set; }
    public DbSet<ProjectStatus> projectstatus { get; set; }
    public DbSet<TaskType> taskType { get; set; }
    public DbSet<User> users { get; set; }
    public DbSet<AssiginProject> assiginProject { get; set; }
    public DbSet<UnAssignProject> unassiginProject { get; set; }
    public DbSet<ProjectRole> roleProject { get; set; }
    public DbSet<TaskMaster> Task { get; set; }
    public DbSet<Timelogs> timelog { get; set; }
     public DbSet<CalanderLog> calanderlog { get; set; }

    protected override void OnModelCreating (ModelBuilder builder) {
      base.OnModelCreating (builder);
    }
  }

}