using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Web.API.Models
{
    public class TestContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<DateInterval> DateIntervals { get; set; }
        public DbSet<EventLog> EventLogger { get; set; }

        public static string ConnectionString { get; set; }
        public static int MessageMaxLength;

        //public TestContext(DbContextOptions<TestContext> options)
        //    : base(options)
        //{
        //    Database.EnsureCreated();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MessageMaxLength = 4000;
        }
    }
}
