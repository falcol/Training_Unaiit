using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Training_Unaiit.Models.Faculty;
using Training_Unaiit.Models.Grade;
using Training_Unaiit.Models.School;

namespace Unaiit.Models
{
    public class UnaiitDbContext : IdentityDbContext<AppUser>
    {
        public UnaiitDbContext(DbContextOptions<UnaiitDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var model in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = model.GetTableName() ?? model.ClrType.Name;
                if (tableName.StartsWith("AspNet"))
                {
                    model.SetTableName(tableName.Substring(6));
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyBlog;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<SchoolTable> School { get; set; } = default!;
        public DbSet<FacultyTable> Faculty { get; set; } = default!;
        public DbSet<GradeTable> Grade { get; set; } = default!;
    }
}
