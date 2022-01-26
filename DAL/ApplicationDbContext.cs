using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<HoursReport> HoursReport { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectUser> ProjectUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUser>().HasKey(sc => new { sc.UserId, sc.ProjectId });
         
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "John", Password="1111", Email = "john@john.com", Role = 1 },
                new User { Id = 2, Name = "Michael", Password = "2222", Email = "michael@michael.com", Role = 0 }
    );
            modelBuilder.Entity<HoursReport>().HasData(new HoursReport { Id = 1 ,FromDateTime = DateTime.Parse("23/01/2021 12:26"),ProjectId = 1, UserId = 1 }
            
   );
            modelBuilder.Entity<Project>().HasData(new Project { Id = 1, Name="Project1" },
                new Project { Id = 2, Name = "Project2" },
                new Project { Id = 3, Name = "Project3" }

   );
            modelBuilder.Entity<ProjectUser>().HasData(new ProjectUser { ProjectId = 1, UserId = 1 },
                new ProjectUser { ProjectId = 2, UserId = 1 },
                new ProjectUser { ProjectId = 3, UserId = 2 }

   );
        }
    }
    

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MyProjServer/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
    
    
}