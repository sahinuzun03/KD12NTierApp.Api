using KD12NTierApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD12NTierApp.DataAccess.EntityFramework.Mapping
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Name).HasMaxLength(25).HasColumnType("nvarchar");
            builder.Property(x => x.Surname).HasMaxLength(25).HasColumnType("nvarchar");
        }
    }
}
