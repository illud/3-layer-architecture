using System;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repository
{
    public class DbCtx : DbContext
    {
        public DbCtx()
        {
        }

        public DbCtx(DbContextOptions<DbCtx> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=csharpentity;uid=root;password=root", new MySqlServerVersion(new Version(8, 0, 11)));
            }
        }
    }
}
