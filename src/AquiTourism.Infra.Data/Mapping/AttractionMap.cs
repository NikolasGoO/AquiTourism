using AquiTourism.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AquiTourism.Infra.Data.Mapping
{
    public class AttractionMap : IEntityTypeConfiguration<Attraction>
    {
        public void Configure(EntityTypeBuilder<Attraction> builder)
        {
            builder.ToTable("Aq.Attraction");
            builder.Property(a => a.ImagesUrl).HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
            v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)).IsRequired();
            
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Type).IsRequired();
            builder.Property(a => a.Slogan).HasMaxLength(200);
            builder.Property(a => a.Description).IsRequired().HasMaxLength(1000);
            builder.Property(a => a.ShortDescription).HasMaxLength(100);
            builder.Property(a => a.Price);
            builder.Property(a => a.Schedules).IsRequired().HasMaxLength(500);
            builder.Property(a => a.Address).HasMaxLength(300);
            builder.Property(a => a.Link).HasMaxLength(1000);
        }
    }
}
