using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Models.Data
{
    public partial class timesheet_dbContext : DbContext
    {
        public timesheet_dbContext()
        {
        }

        public timesheet_dbContext(DbContextOptions<timesheet_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<LeadProject> LeadProjects { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<ProjectTask> Tasks { get; set; } = null!;
        public virtual DbSet<UserProject> UserProjects { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DKN2LNL\\SQLEXPRESS;Database=timesheet_db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Category>().HasQueryFilter(category => category.DeletedDate == null);

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENT_COUNTRY");
            });

            modelBuilder.Entity<Client>().HasQueryFilter(client => client.DeletedDate == null);

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Country>().HasQueryFilter(country => country.DeletedDate == null);

            modelBuilder.Entity<LeadProject>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProjectId });

                entity.HasOne(d => d.UserProject)
                    .WithOne(p => p.LeadProject)
                    .HasForeignKey<LeadProject>(d => new { d.UserId, d.ProjectId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LEAD_PROJECT_USER_PROJECT");
            });

            modelBuilder.Entity<LeadProject>().HasQueryFilter(lp => lp.DeletedDate == null);

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROJECT_CLIENT");
            });

            modelBuilder.Entity<Project>().HasQueryFilter(project => project.DeletedDate == null);

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Role>().HasQueryFilter(role => role.DeletedDate == null);

            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TaskTables)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TASK_CATEGORY");

                entity.HasOne(d => d.UserProject)
                    .WithMany(p => p.TaskTables)
                    .HasForeignKey(d => new { d.UserId, d.ProjectId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TASK_USER_PROJECT");
            });

            modelBuilder.Entity<UserProject>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProjectId });

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.UserProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_PROJECT_PROJECT");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProjects)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_PROJECT_USER_TABLE");
            });

            modelBuilder.Entity<UserProject>().HasQueryFilter(up => up.DeletedDate == null);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Username).HasDefaultValueSql("('')");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserTables)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_USER_ROLE");
            });

            modelBuilder.Entity<User>().HasQueryFilter(user => user.DeletedDate == null);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
