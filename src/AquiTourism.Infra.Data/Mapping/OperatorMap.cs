using AquiTourism.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Infra.Data.Mapping
{
    public class OperatorMap : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.ToTable("Aq.Operator");
            builder.Property(o => o.Name).IsRequired().HasMaxLength(100);
            builder.Property(o => o.Email).IsRequired().HasMaxLength(200);
            builder.Property(o => o.PasswordHash).IsRequired();
            builder.Property(o => o.PasswordSalt).IsRequired();
            builder.Property(o => o.CPF).IsRequired().HasMaxLength(11);
            builder.Property(o => o.CreatorUserId).IsRequired();
        }
    }
}
