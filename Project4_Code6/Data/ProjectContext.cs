using Microsoft.EntityFrameworkCore;
using Project4_Code6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4_Code6.Data
{
    public class ProjectContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");

        }
    }
}
