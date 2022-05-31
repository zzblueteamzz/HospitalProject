﻿using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Data.Model;
using Microsoft.AspNetCore.Identity;
using Data.Model.Models;

namespace Data.HospitalCountext
{
    public class HospitalContext: IdentityDbContext<User, HospitalRoles, int>
    {
        public HospitalContext()
        {
        }

        //{
        //}

        public HospitalContext(DbContextOptions<HospitalContext> options)
                : base(options)
        {
        }

        public DbSet<HospitalRoles> HospitalRoles { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "Nurse",
                NormalizedName = "Nurse".ToUpper()
            },
             new IdentityRole
             {
                 Name = "Doctor",
                 NormalizedName = "Doctor".ToUpper()
             },
            new IdentityRole
            {
                Name = "HospitalManager",
                NormalizedName = "HospitalManager".ToUpper()
            });

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
           // options.UseSqlServer("Server = DESKTOP-A77J6HG; Database = HospitalDataBase; Trusted_connection=True;");
        }
    }
}
