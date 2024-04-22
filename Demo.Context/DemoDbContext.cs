using Demo.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Context
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext() : base("DemoDbConnectionString")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestSpares> RequestSpares { get; set; }
        public DbSet<Spare> Spares { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<DefectType> DefectTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(x => x.RequestWorkers)
                .WithRequired(x => x.Worker)
                .WillCascadeOnDelete(false);
        }
    }
}
