using KD12NTierApp.DataAccess.EntityFramework.Mapping;
using KD12NTierApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD12NTierApp.DataAccess.EntityFramework.Context
{
    public class KD12NTierAppDbContext : DbContext
    {
        public KD12NTierAppDbContext(DbContextOptions<KD12NTierAppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMapping());
        }
    }
}
