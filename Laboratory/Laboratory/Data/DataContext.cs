using Laboratoty.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoty.Data
{
    public class DataContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DataContext()
        {
            Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlite("Data Source = data.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(new List<Position>()
            {
                new Position { Id = 1,Title = "Лаборант" },
                new Position { Id = 2,Title = "Преподаватель" },
                new Position { Id = 3,Title = "Бакалавр" },
                new Position { Id = 4,Title = "Магистр" },
                new Position { Id = 5,Title = "Аспирант" },
                new Position { Id = 6,Title = "Бухгалтер" },

                });

            modelBuilder.Entity<Family>().HasData(new List<Family>()
            {
                new Family { Id = 1,Title = "Не женат/не замужем" },
                new Family { Id = 2,Title = "Женат/Замужем" },
                new Family { Id = 3,Title = "Разведен(-а)" }
            });

            modelBuilder.Entity<Gender>().HasData(new List<Gender>()
            {
                new Gender{ Id = 1,Title = "Мужской" },
                new Gender{ Id = 2,Title = "Женский" }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
