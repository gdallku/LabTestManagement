using LabTestManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabTestManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Doctor

            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                Id = 1,
                FirstName = "Gezim",
                Email="gez.@asd.com",

                Image = "apple.jpg",
                Telephone=0444444,
                Description = "An apple is a sweet, edible fruit produced by an apple tree (Malus pumila). Apple trees are cultivated worldwide and are the most widely grown species in the genus Malus."

            });

            #endregion
            #region Services
            modelBuilder.Entity<Service>().HasData(new Service
            {
                Id = 1,
                Name = "Gezim"
            });

            #endregion
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<IdentityUser> Users { get; set; }

        public DbSet<Service> Services{ get; set; }
    }
}
