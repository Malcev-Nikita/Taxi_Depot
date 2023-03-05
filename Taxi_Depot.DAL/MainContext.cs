using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taxi_Depot.DAL.Models;

namespace Taxi_Depot.DAL
{
    public class MainContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Service> Service { get; set; }


        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasIndex(n => n.Id).IsUnique();
                entity.HasData(new List<Driver>()
                {
                    new Driver() {Id = 1, Name = "Никита", Surname = "Мальцев", Phone = "+79896817945"},
                    new Driver() {Id = 2, Name = "Александр", Surname = "Копаев", Phone= "+79378286840"},
                });


            });
        }
    }
}
