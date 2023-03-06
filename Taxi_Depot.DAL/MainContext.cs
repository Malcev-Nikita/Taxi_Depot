using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taxi_Depot.DAL.Enums;
using Taxi_Depot.DAL.Models;
using static Taxi_Depot.DAL.Enums.OrderStatus;

namespace Taxi_Depot.DAL
{
    public class MainContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Transport> Transports { get; set; }


        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasData(new List<Driver>()
                {
                    new Driver() {Id = 1, Name = "Никита", Surname = "Мальцев", Phone = "+79896817945"},
                    new Driver() {Id = 2, Name = "Александр", Surname = "Копаев", Phone= "+79378286840"},
                });
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasData(new List<Order>()
                {
                    new Order() {Id = 1, FullName = "Арнаутов Иван Павлович", ClientPhone = "+79370590439", Status = OrderStatusEnum.Waiting, From = "наб. Сталина, 88", Where = "пл. Домодедовская, 17", Cost = 600},
                    new Order() {Id = 2, FullName = "Марков Евгений Максимович", ClientPhone = "+79371635151", Status = OrderStatusEnum.Delivered, From = "пл. Будапештсткая, 90", Where = "шоссе Славы, 92", Cost = 580},
                    new Order() {Id = 3, FullName = "Макаров Егор Александрович", ClientPhone = "+79373022327", Status = OrderStatusEnum.Waiting, From = "спуск Чехова, 99", Where = "пр. Бухарестская, 98", Cost = 531},
                    new Order() {Id = 4, FullName = "Шульгин Арсений Михайлович", ClientPhone = "+79376235721", Status = OrderStatusEnum.Canceled, From = "проезд Гагарина, 26", Where = "шоссе 1905 года, 35", Cost = 406},
                    new Order() {Id = 5, FullName = "Смирнов Максим Георгиевич", ClientPhone = "+79371508088", Status = OrderStatusEnum.Canceled, From = "въезд Славы, 67", Where = "пл. Гагарина, 48", Cost = 202},
                    new Order() {Id = 6, FullName = "Суслова Александра Львовна", ClientPhone = "+79374186791", Status = OrderStatusEnum.Delivered, From = "спуск Домодедовская, 56", Where = "въезд Ленина, 69", Cost = 556},
                    new Order() {Id = 7, FullName = "Меркулов Максим Никитич", ClientPhone = "+79370334512", Status = OrderStatusEnum.Canceled, From = "въезд Славы, 26", Where = "шоссе Славы, 94", Cost = 557},
                    new Order() {Id = 8, FullName = "Фролова Виктория Максимовна", ClientPhone = "+79373681997", Status = OrderStatusEnum.Canceled, From = "пл. Ладыгина, 15", Where = "шоссе Ладыгина, 13", Cost = 398},
                    new Order() {Id = 9, FullName = "Шубин Михаил Васильевич", ClientPhone = "+79374895787", Status = OrderStatusEnum.OnMove, From = "ул. Бухарестская, 70", Where = "спуск Славы, 52", Cost = 281},
                    new Order() {Id = 10, FullName = "Егоров Дмитрий Артёмович", ClientPhone = "+79370687599", Status = OrderStatusEnum.Delivered, From = "пл. Гагарина, 53", Where = "пер. Славы, 65", Cost = 493},
                });
            });
        }
    }
}
