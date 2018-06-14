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
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
