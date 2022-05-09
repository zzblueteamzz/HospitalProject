using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Data.Model;

namespace Data.HospitalCountext
{
    public class HospitalContext: IdentityDbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
                : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Speciality> Specialities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server = DESKTOP-A77J6HG;; Database = HospitalDataBase; Trusted_connection=True;");
        }
    }
}
