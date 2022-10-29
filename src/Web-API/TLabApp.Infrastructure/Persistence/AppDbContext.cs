using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TLabApp.Domain.Entities;

namespace TLabApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public string DbPath { get; set; }
        public AppDbContext() : base()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            // var path = Environment.GetFolderPath(folder);
            var root = Environment.CurrentDirectory;
            DbPath = System.IO.Path.Join(root, "TLabDb.db");

        }


        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<SkillPersonMap> SkillPersonMap { get; set; }


        #region override methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }


        #endregion

    }
}
