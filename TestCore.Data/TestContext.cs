using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestCore.Data.Models;

namespace TestCore.Data
{
    public class TestContext : DbContext
    {
        public DbSet<Counter> Counters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = localhost; Database = test_core; Trusted_Connection = True;");
        }
    }
}
