using AbstractMebelDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractMebelDatabaseImplement
{
    public class AbstractMebelDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-0TUFHPTU\SQLEXPRESS;Initial Catalog=AbstractMebelHomeDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Zagotovka> Zagotovkas { set; get; }
        public virtual DbSet<Mebel> Mebels { set; get; }
        public virtual DbSet<MebelZagotovka> MebelZagotovkas { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<StorageZagotovka> StorageZagotovkas { set; get; }
        public virtual DbSet<Storage> Storages { set; get; }
        public virtual DbSet<Implementer> Implementers { set; get; }
    }
}
