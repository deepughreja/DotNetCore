using AspNetCoreMyExersice.DTO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreMyExcersice.DataAccess.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(new Employee()
            {
                Id = 3,
                Name = "ManjulaBen",
                Email = "ManjulaBen@Gmail.com"
            });
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
