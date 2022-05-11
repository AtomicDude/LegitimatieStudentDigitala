using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LegitimatieStudentDigitala.Models;
using LegitimatieStudentDigitala.Models.Base;

namespace LegitimatieStudentDigitala.Data
{
    public class Context : DbContext
    {
        public DbSet<Domeniu> Domenii { get; set; }
        public DbSet<Facultate> Facultati { get; set; }
        public DbSet<User> Useri { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
        .Entries()
        .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).DataModificat = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).DataCreat = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
