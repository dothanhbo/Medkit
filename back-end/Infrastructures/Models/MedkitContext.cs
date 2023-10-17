using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Models
{
    public class MedkitContext : DbContext
    {
        public MedkitContext() { }
        public MedkitContext(DbContextOptions<MedkitContext> options) : base(options)
        {
        }
        private string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config.GetConnectionString("MedkitDB");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        public virtual DbSet<OriginalMedicine>? OriginalMedicines { get; }
        public virtual DbSet<Disease> Diseases { get; }
        public virtual DbSet<MedicineDisease> MedicineDisease { get; }
        public virtual DbSet<AdminEmployee> AdminEmployees { get; }
        public virtual DbSet<Order> Orders { get; }
        public virtual DbSet<Product> Products { get; }
        public virtual DbSet<User> Users { get; }
        public virtual DbSet<Medicine> Medicines { get; }
        public virtual DbSet<UsingHistory> UsingHistories { get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineDisease>().HasKey(m => new
            {
                m.OriginalMedicineId,
                m.DiseaseId
            });
        }
    }
}
