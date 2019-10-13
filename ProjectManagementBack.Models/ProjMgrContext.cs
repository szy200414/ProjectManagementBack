using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.Models
{
    public class ProjMgrContext: DbContext
    {
        public ProjMgrContext(): base("ProjMgrContext")
        {
            Database.SetInitializer<ProjMgrContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Annonce> Annonces { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<MissionList> MissionLists { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<MissionOwner> MissionOwners { get; set; }
        public DbSet<MissionLog> MissionLogs { get; set; }


    }
}
