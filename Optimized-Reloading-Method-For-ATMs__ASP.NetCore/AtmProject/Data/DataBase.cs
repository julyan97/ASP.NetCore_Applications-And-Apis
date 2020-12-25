using AtmProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtmProject.Data
{
    public class DataBase : DbContext
    {
        public DbSet<Atm> Atms { get; set; }
        public DbSet<HistoricData> HistoricData { get; set; }
        public DbSet<Prices> Prices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-FS8CQTH;Database=AtmDataBase;Integrated Security=true");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-M81N75M\SQLEXPRESS;Database=AtmDataBase;Integrated Security=true");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-O5PN67F\SQLEXPRESS;Database=AtmDataBase;Integrated Security=true");
            //optionsBuilder.UseSqlServer(@"Data Source=tcp:atmserverplan.database.windows.net,1433;Initial Catalog=AtmDataBase;User Id=atmserver@atmserverplan.database.windows.net;Password=AtmService123;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atm>()
                .HasMany(x => x.HD)
                .WithOne(x => x.Atm)
                .HasForeignKey(x=>x.AtmId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Atm>()
                .HasMany(x => x.Prices)
                .WithOne(x => x.Atm)
                .HasForeignKey(x=>x.AtmId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Atm>()
                .HasIndex(x => x.TID)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }


    }
}
