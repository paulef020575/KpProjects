using System.Diagnostics;
using KpProjects.Classes;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace KpProjects.Data
{
    /// <summary>
    ///     Контекст данных
    /// </summary>
    public class KpProjectsContext : DbContext
    {
        #region Properties

        #region Persons

        public DbSet<Person> Persons { get; set; }

        #endregion

        #region Projects

        public DbSet<KpProject> Projects { get; set; }

        #endregion


        #region Milestones

        public DbSet<Milestone> Milestones { get; set; }

        #endregion

        #region Tasks

        public DbSet<KpTask> Tasks { get; set; }

        #endregion

        #endregion

        #region ctor

        private KpProjectsContext() { }

        public KpProjectsContext(DbContextOptions<KpProjectsContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.Migrate();
        }

        #endregion

        #region Methods

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany<KpProject>(p => p.Projects)
                .WithOne(pr => pr.HeadPerson)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<KpProject>()
                .HasMany(p => p.Members)
                .WithMany(p => p.ProjectMembers)
                .UsingEntity(e =>
                {
                    e.ToTable("ProjectMembers");
                });

            modelBuilder.Entity<Person>()
                .HasMany<KpTask>(p => p.Tasks)
                .WithOne(t => t.Author)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Person>()
                .HasMany<KpTask>(p => p.ExecutionTasks)
                .WithOne(t => t.Executor)
                .OnDelete(DeleteBehavior.NoAction);

        }

        #endregion


        #endregion
    }
}
